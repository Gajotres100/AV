using ComProvis.CSP.Domain.Customers;
using ComProvis.CSP.Domain.Invoices;
using ComProvis.CSP.Domain.Subscriptions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComProvis.CSP.Application.Interfaces
{
    public interface ICspClient
    {
        Task<Customer> GetCustomerAsync(string tenantId);
        Task<List<Customer>> GetCustomersAsync();
        Task<List<Subscription>> GetCustomersSubscriptionAsync(string tenantId);
        Task<List<Invoice>> GetInvoicesAsync();
        Task<Invoice> GetInvoiceByIdAsync(string invoiceId);
        Task<List<ResourceUsage>> GetSubscriptionResourceUsageAsync(string tenantId, string subscriptionId);
        Task<List<UsageRecord>> GetSubscriptionUsageRecordsAsync(string tenantId);        
        Task<List<AzureInvoiceLineItem>> GetAzureInvoiceLineItemsAsync(string link);
        Task<List<OfficeInvoiceLineItem>> GetOfficeInvoiceLineItemsAsync(string link);
    }
}
