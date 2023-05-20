using CTTSite.Models;

namespace CTTSite.Services.Interface
{
    public interface IShippingInfoService
    {
        Task CreateShippingInfoAsync(ShippingInfo shippingInfo);
        Task<ShippingInfo> GetShippingByOrderIDAsync(int ID);
        Task DeleteShippingInfoAsync(int ID);
        Task UpdateShippingAsync(ShippingInfo shippingInfo);
    }
}
