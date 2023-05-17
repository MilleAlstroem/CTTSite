using CTTSite.Models;

namespace CTTSite.Services.Interface
{
    public interface IShippingInfoService
    {
        Task CreateShippingInfoAsync(ShippingInfo shippingInfo);

    }
}
