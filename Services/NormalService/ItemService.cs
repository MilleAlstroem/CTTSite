using CTTSite.MockData;
using CTTSite.Models;
using CTTSite.Services.DB;
using CTTSite.Services.JSON;

namespace CTTSite.Services.NormalService
{
    public class ItemService : IItemService
    {
        public DBServiceGeneric<Item> DBServiceGeneric;
        public JsonFileService<Item> JsonFileService;
        public List<Item> Items;

        public ItemService(DBServiceGeneric<Item> dBServiceGeneric, JsonFileService<Item> jsonFileService)
        {
            DBServiceGeneric = dBServiceGeneric;
            JsonFileService = jsonFileService;
            Items = GetAllItems();
        }

        public async Task CreateItemAsync(Item item)
        {
            //int IDCount = 0;
            //foreach(Item listItem in Items)
            //{
            //    if(IDCount < listItem.ID)
            //    {
            //        IDCount = listItem.ID;
            //    }
            //}
            //item.ID = IDCount + 1;
            Items.Add(item);
            //JsonFileService.SaveJsonObjects(Items);
            await DBServiceGeneric.AddObjectAsync(item);
        }

        public async Task DeleteItemByIDAsync(int ID)
        {
            Item itemToBeDeleted = null;
            if(GetItemByID(ID) != null) 
            { 
                Items.Remove(GetItemByID(ID));
                JsonFileService.SaveJsonObjects(Items);

                itemToBeDeleted = GetItemByID(ID);
                await DBServiceGeneric.DeleteObjectAsync(itemToBeDeleted);
            }
        }

        public List<Item> GetAllItems()
        {
            return DBServiceGeneric.GetObjectsAsync().Result.ToList();
            //return JsonFileService.GetJsonObjects().ToList();
            //return MockData.MockDataItem.GetMockItem();
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
                        //JsonFileService.SaveJsonObjects(Items);
                        await DBServiceGeneric.UpdateObjectAsync(itemO);
                    }
                }
            }
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

        public async Task UpdateItemStockAsync(int itemID, int amount)
        {
            if(GetItemByID(itemID) != null)
            {
                if(amount > 0)
                {
                    GetItemByID(itemID).Stock += amount;
                    //JsonFileService.SaveJsonObjects(Items);
                    await DBServiceGeneric.UpdateObjectAsync(GetItemByID(itemID));
                }
                else
                {
                    GetItemByID(itemID).Stock -= amount;
                    //JsonFileService.SaveJsonObjects(Items);
                    await DBServiceGeneric.UpdateObjectAsync(GetItemByID(itemID));
                }

            }
        }

    }
}
