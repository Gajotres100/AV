namespace ComProvis.Csp.Infrastructure.MS.Entities
{
    public class GetTokenParams
    {
        public string resource { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
        public string grant_type { get; set; }
    }
}
