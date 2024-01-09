using Microsoft.AspNetCore.SignalR;
using Domain.Hub;
using Domain.Models;

namespace Domain.Models;
public class ProductRepository
{
    private readonly IHubContext<ProductNotificationHub, INotificationHub> _notificationHubContext;

    public ProductRepository(IHubContext<ProductNotificationHub, INotificationHub> notificationHubContext)
    {
        _notificationHubContext = notificationHubContext;
    }

    public void UpdateProduct(Product updatedProduct)
    {

        _notificationHubContext.Clients.All.SendMessage("Product updated: " + updatedProduct.Name);
    }
}

