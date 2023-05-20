using CTTSite.Models;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;

namespace CTTSite.Services.NormalService
{
    public class ShippingInfoService : IShippingInfoService
    {
        private readonly JsonFileService<ShippingInfo> _jsonFileService;
        private readonly DBServiceGeneric<ShippingInfo> _dBServiceGeneric;
        List<ShippingInfo> ShippingInfoList;

        public ShippingInfoService(JsonFileService<ShippingInfo> jsonFileService, DBServiceGeneric<ShippingInfo> dBServiceGeneric)
        {
            _jsonFileService = jsonFileService;
            _dBServiceGeneric = dBServiceGeneric;
            ShippingInfoList = _jsonFileService.GetJsonObjects().ToList();
        }

        public async Task CreateShippingInfoAsync(ShippingInfo shippingInfo)
        {
            int IDCount = 0;
            //foreach (ShippingInfo listShippingInfo in ShippingInfoList)
            //{
            //    if (IDCount < listShippingInfo.ID)
            //    {
            //        IDCount = listShippingInfo.ID;
            //    }
            //}
            //shippingInfo.ID = IDCount + 1;
            ShippingInfoList.Add(shippingInfo);
            //_jsonFileService.SaveJsonObjects(ShippingInfoList);
            await _dBServiceGeneric.AddObjectAsync(shippingInfo);
        }

        public async Task<ShippingInfo> GetShippingByOrderIDAsync(int ID)
        {
            return await _dBServiceGeneric.GetObjectByIdAsync(ID);
        }

        public async Task DeleteShippingInfoAsync(int ID)
        {
            ShippingInfo shippingInfoToBeDelete = await GetShippingByOrderIDAsync(ID);
            if (shippingInfoToBeDelete != null)
            {
                ShippingInfoList.Remove(shippingInfoToBeDelete);
                //_jsonFileService.SaveJsonObjects(ShippingInfoList);
                await _dBServiceGeneric.DeleteObjectAsync(shippingInfoToBeDelete);
            }
        }

        public async Task UpdateShippingAsync(ShippingInfo shippingInfo)
        {
            if (shippingInfo != null)
            {
                await _dBServiceGeneric.UpdateObjectAsync(shippingInfo);
            }
        }
    }
}
