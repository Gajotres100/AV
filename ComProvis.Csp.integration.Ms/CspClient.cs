using ComProvis.Csp.Infrastructure.MS;
using ComProvis.Csp.Infrastructure.MS.Entities.GetCustomerResponse;
using ComProvis.Csp.Infrastructure.MS.Entities.GetCustomersResponse;
using ComProvis.Csp.Infrastructure.MS.Entities.GetCustomersSubscriptionResponse;
using ComProvis.Csp.Infrastructure.MS.Entities.GetSubscriptionUsageRecordsResponse;
using ComProvis.CSP.Application.Interfaces;
using ComProvis.CSP.Domain.Customers;
using ComProvis.CSP.Domain.Subscriptions;
using Marvin.StreamExtensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Linq;
using ComProvis.Csp.Infrastructure.MS.Entities;
using ComProvis.CSP.Domain.Invoices;
using ComProvis.Csp.Infrastructure.MS.Entities.GetInvoiceResponse;
using ComProvis.Csp.Infrastructure.MS.Entities.GetSubscriptionResourceUsageResponse;
using ComProvis.Csp.Infrastructure.MS.Entities.GetInvoiceLineItems;
using ComProvis.Csp.Infrastructure.MS.Entities.GetAzureInvoiceLineItems;

namespace ComProvis.Csp.integration.Ms
{
    public class CspClient : ICspClient
    {
        #region Params

        private readonly HttpClient _client;
        private readonly IMsTokenClient _msTokenClient;

        #endregion

        #region Ctor

        public CspClient(HttpClient client, IMsTokenClient msTokenClient)
        {
            _msTokenClient = msTokenClient;
            _client = client;            

            _client.BaseAddress = new Uri("https://api.partnercenter.microsoft.com");
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();            
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add("MS-RequestId", Guid.NewGuid().ToString());
            _client.DefaultRequestHeaders.Add("CorrelationId", Guid.NewGuid().ToString());
        }

        #endregion

        #region Metods

        public async Task<List<Customer>> GetCustomersAsync()
        {
            var token = await  _msTokenClient.GetTokenAsync();
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                "v1/customers");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);

            using (var response = await _client.SendAsync(request,
              HttpCompletionOption.ResponseHeadersRead))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                var customers = stream.ReadAndDeserializeFromJson<GetCustomersResponse>();

                return customers.items.Select(x => new Customer
                {
                    Name = x.companyProfile.companyName,
                    Id = x.companyProfile.tenantId.GetValueOrDefault(),
                    Domain=x.companyProfile.domain

                }).ToList();
            }
        }

        public async Task<Customer> GetCustomerAsync(string tenantId)
        {
            var token = await _msTokenClient.GetTokenAsync();
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"v1/customers/{tenantId}");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);

            using (var response = await _client.SendAsync(request,
              HttpCompletionOption.ResponseHeadersRead))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                var customer = stream.ReadAndDeserializeFromJson<GetCustomerResponse>();

                return new Customer
                {
                    Domain = customer.companyProfile.domain,  
                    Name=customer.companyProfile.companyName,
                    Address=customer.companyProfile.address?.addressLine1,
                    Country=customer.companyProfile.address?.country,
                    City=customer.companyProfile.address?.city,
                    PostalCode = customer.companyProfile.address?.postalCode,
                    PhoneNumber = customer.companyProfile.address?.phoneNumber,
                };
            }
        }

        public async Task<List<Subscription>> GetCustomersSubscriptionAsync(string tenantId)
        {
            var token = await _msTokenClient.GetTokenAsync();
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"v1/customers/{tenantId}/subscriptions");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);

            using (var response = await _client.SendAsync(request,
               HttpCompletionOption.ResponseHeadersRead))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                var subscriptions = stream.ReadAndDeserializeFromJson<GetCustomersSubscriptionResponse>();

                return subscriptions?.items.Select(x => new Subscription
                {
                    FriendlyName = x.friendlyName,
                    Quantity = x.quantity,
                    Id = x.id
                }).ToList();
            }
        }

        public async Task<List<UsageRecord>> GetSubscriptionUsageRecordsAsync(string tenantId)
        {
            var token = await _msTokenClient.GetTokenAsync();
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"v1/customers/{tenantId}/subscriptions/usagerecords");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);

            using (var response = await _client.SendAsync(request,
               HttpCompletionOption.ResponseHeadersRead))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                var usageRecords = stream.ReadAndDeserializeFromJson<GetSubscriptionUsageRecordsResponse>();

                return usageRecords?.items. Select(x => new UsageRecord
                {
                    ResourceName = x.resourceName,
                    Status=x.status,
                    CurrencyLocale=x.currencyLocale,
                    Id=x.id,
                    LastModifiedDate=x.lastModifiedDate,
                    ResourceId=x.resourceId,
                    TotalCost=x.totalCost,
                    OfferId=x.offerId
                    
                }).ToList();
            }
        }

        public async Task<List<ResourceUsage>> GetSubscriptionResourceUsageAsync(string tenantId, string subscriptionId)
        {
            var token = await _msTokenClient.GetTokenAsync();
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"v1/customers/{tenantId}/subscriptions/{subscriptionId}/usagerecords/resources");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);

            using (var response = await _client.SendAsync(request,
               HttpCompletionOption.ResponseHeadersRead))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                var resourceUsage = stream.ReadAndDeserializeFromJson<GetSubscriptionResourceUsageResponse>();

                return resourceUsage?.items.Select(x => new ResourceUsage
                {
                    Id = x.id,
                    Category = x.category,
                    Subcategory = x.subcategory,
                    Name=x.name,
                    QuantityUsed=x.quantityUsed,
                    TotalCost=x.totalCost,
                    Unit=x.unit
                    
                }).ToList();
            }
        }

        public async Task<List<Invoice>> GetInvoicesAsync()
        {
            var token = await _msTokenClient.GetTokenAsync();
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"v1/invoices/");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);

            using (var response = await _client.SendAsync(request,
               HttpCompletionOption.ResponseHeadersRead))
            {
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                var invoices = stream.ReadAndDeserializeFromJson<GetInvoiceResponse>();

                return invoices?.items.Select(x => new Invoice
                {
                    InvoiceId = x.id,
                    PaidAmount=x.paidAmount,
                    TotalCharges=x.totalCharges,
                    InvoiceDate=x.invoiceDate
                }).ToList();
            }
        }

        public async Task<Invoice> GetInvoiceByIdAsync(string invoiceId)
        {
            var token = await _msTokenClient.GetTokenAsync();
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"v1/invoices/{invoiceId}");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);

            using (var response = await _client.SendAsync(request,
               HttpCompletionOption.ResponseHeadersRead))
            {                
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                var invoiceItems = stream.ReadAndDeserializeFromJson<GetInvoiceByIdResponse>();

                return new Invoice
                {
                    InvoiceId = invoiceItems.id,
                    InvoiceDetailLinks = invoiceItems?.invoiceDetails?.Select(x=> x.links?.self?.uri).ToList()
                };
            }
        }

        public async Task<List<OfficeInvoiceLineItem>> GetOfficeInvoiceLineItemsAsync(string link)
        {
            var token = await _msTokenClient.GetTokenAsync();
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"v1/{link}");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);

            using (var response = await _client.SendAsync(request,
               HttpCompletionOption.ResponseHeadersRead))
            {
                var string1 = await response.Content.ReadAsStringAsync();
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                var invoiceItems = stream.ReadAndDeserializeFromJson<GetOfficeInvoiceLineItems>();

                return invoiceItems?.items.Select(x => new OfficeInvoiceLineItem
                {
                    PartnerId = x.partnerId,
                    CustomerId = x.customerId,
                    CustomerName = x.customerName,
                    MpnId = x.mpnId,
                    OrderId=x.orderId,
                    SubscriptionId = x.subscriptionId,
                    SyndicationPartnerSubscriptionNumber = x.syndicationPartnerSubscriptionNumber,
                    OfferId=x.offerId,
                    DurableOfferId=x.durableOfferId,
                    OfferName = x.offerName,
                    SubscriptionStartDate = x.subscriptionStartDate,
                    SubscriptionEndDate = x.subscriptionEndDate,
                    ChargeStartDate = x.chargeStartDate,
                    ChargeEndDate = x.chargeEndDate,
                    UnitPrice = x.unitPrice,
                    Quantity = x.quantity,
                    Amount=x.amount,
                    TotalOtherDiscount=x.totalOtherDiscount,
                    Subtotal = x.subtotal,
                    Tax = x.tax,
                    TotalForCustomer = x.totalForCustomer,
                    Currency=x.currency,
                    DomainName = x.domainName,
                    SubscriptionName = x.subscriptionName,
                    SubscriptionDescription=x.subscriptionDescription,
                    BillingCycleType =x.billingCycleType
                }).ToList();
            }
        }

        public async Task<List<AzureInvoiceLineItem>> GetAzureInvoiceLineItemsAsync(string link)
        {
            var token = await _msTokenClient.GetTokenAsync();
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"v1/{link}");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.access_token);

            using (var response = await _client.SendAsync(request,
               HttpCompletionOption.ResponseHeadersRead))
            {
                var string1 = await response.Content.ReadAsStringAsync();
                var stream = await response.Content.ReadAsStreamAsync();
                response.EnsureSuccessStatusCode();
                var invoiceItems = stream.ReadAndDeserializeFromJson<GetAzureInvoiceLineItems>();

                return invoiceItems?.items.Select(x => new AzureInvoiceLineItem
                {
                    CustomerId = x.customerId,
                    CustomerCompanyName = x.customerCompanyName,
                    DomainName = x.domainName,
                    IncludedQuantity = x.includedQuantity,
                    ListPrice = x.listPrice,
                    OverageQuantity = x.overageQuantity,
                    Sku = x.sku
                }).ToList();
            }
        }

        #endregion
    }
}
