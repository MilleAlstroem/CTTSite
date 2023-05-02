using CTTSite.MockData;
using CTTSite.Models;
using CTTSite.Services.DB;

namespace CTTSite.Services.NormalService
{
    public class ItemService : IItemService
    {
        public DBServiceGeneric<Item> DBServiceGeneric;

        public ItemService(DBServiceGeneric<Item> dBServiceGeneric)
        {
            DBServiceGeneric = dBServiceGeneric;
        }

        public Task CreateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItemByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Item> GetAllItems()
        {
            return DBServiceGeneric.GetObjectsAsync().Result.ToList();
        }

        public Task UpdateItemByIDAsync(int ID)
        {
            throw new NotImplementedException();
        }

        public Task UpdateItemStockAsync(int amount)
        {
            throw new NotImplementedException();
        }
    }
}
