using CTTSite.MockData;
using CTTSite.Models;
using CTTSite.Services.DB;

namespace CTTSite.Services.NormalService
{
    public class ItemService : IItemService
    {
        public DBServiceGeneric<Item> DBServiceGeneric;
        public List<Item> Items;

        public ItemService(DBServiceGeneric<Item> dBServiceGeneric)
        {
            DBServiceGeneric = dBServiceGeneric;
            Items = GetAllItems();
        }

        public async Task CreateItemAsync(Item item)
        {
            await DBServiceGeneric.AddObjectAsync(item);
        }

        public async Task DeleteItemByIDAsync(int ID)
        {
            Item itemToBeDeleted = null;
            if(GetItemByID(ID) != null) 
            { 
                itemToBeDeleted = GetItemByID(ID);
                await DBServiceGeneric.DeleteObjectAsync(itemToBeDeleted);
            }
        }

        public List<Item> GetAllItems()
        {
            return DBServiceGeneric.GetObjectsAsync().Result.ToList();
        }

        public async Task UpdateItemAsync(Item itemN)
        {
            if(itemN != null) 
            { 
                foreach(Item itemO in Items) 
                { 
                    if(itemO.ID == itemN.ID)
                    {
                        itemO.Name = itemN.Name;
                        itemO.Description = itemN.Description;
                        itemO.Price = itemN.Price;
                        itemO.Stock = itemN.Stock;
                        itemO.IMG = itemN.IMG;
                        await DBServiceGeneric.UpdateObjectAsync(itemO);
                    }
                }
            }
        }

        public Task UpdateItemStockAsync(int amount)
        {
            throw new NotImplementedException();
        }

        public Item GetItemByID(int ID) 
        { 
            foreach(Item item in Items)
            {
                if(item.ID == ID)
                {
                    return item;
                }
            }
            return null;
        }

    }
}
