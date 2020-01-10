using ComProvis.Csp.Infrastructure.MS;
using ComProvis.Csp.Infrastructure.MS.Entities;
using Marvin.StreamExtensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ComProvis.Csp.integration.Ms
{
    public class MsTokenClient : IMsTokenClient
    {
        #region Params

        private HttpClient _client;

        private readonly IConfiguration _configuration;
        private readonly MsSettings _settings = new MsSettings();
        GetTokenResponse AccessToken;

        #endregion

        #region Ctor

        public MsTokenClient(HttpClient client, IConfiguration configuration)
        {
            _configuration = configuration;            
            _configuration.GetSection(nameof(MsSettings)).Bind(_settings);

            _client = client;
            _client.BaseAddress = new Uri(_settings.BaseAddress);
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();            
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("return-client-request-id", "true");            
            _client.DefaultRequestHeaders.Add("Host", "login.microsoftonline.com");            
            _client.DefaultRequestHeaders.Add("Expect", "100-continue");
        }

        #endregion

        #region Metods

        public async Task<GetTokenResponse> GetTokenAsync()
        {
            if (AccessToken == null || int.Parse(AccessToken?.expires_in) < 100)
            {
                var request = new HttpRequestMessage(HttpMethod.Post, $"{_settings.TenantId}/oauth2/token")
                {
                    Content = new StringContent($"resource={_settings.Resource}&client_id={_settings.Client_id}&client_secret={_settings.Client_secret}&grant_type={_settings.Grant_type}", Encoding.UTF8, "application/x-www-form-urlencoded")
                };

                using (var response = await _client.SendAsync(request))
                {
                    var stream = await response.Content.ReadAsStreamAsync();
                    response.EnsureSuccessStatusCode();
                    AccessToken = stream.ReadAndDeserializeFromJson<GetTokenResponse>();
                }
            }

            return AccessToken;
        }

        #endregion
    }
}
