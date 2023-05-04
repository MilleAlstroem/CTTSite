using CTTSite.Models;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;

namespace CTTSite.Services.NormalService
{
    public class ShippingInfoService : IShippingInfoService
    {
        public JsonFileService<ShippingInfo> JsonFileService;
        List<ShippingInfo> ShippingInfoList;

        public ShippingInfoService(JsonFileService<ShippingInfo> jsonFileService)
        {
            JsonFileService = jsonFileService;
            ShippingInfoList = JsonFileService.GetJsonObjects().ToList();
        }

        public void CreateShippingInfo(ShippingInfo shippingInfo)
        {
            int IDCount = 0;
            foreach(ShippingInfo listShippingInfo in ShippingInfoList)
            {
                if(IDCount < listShippingInfo.ID)
                {
                    IDCount = listShippingInfo.ID;
                }
            }
            shippingInfo.ID = IDCount + 1;
            ShippingInfoList.Add(shippingInfo);
            JsonFileService.SaveJsonObjects(ShippingInfoList);
        }
    }
}
