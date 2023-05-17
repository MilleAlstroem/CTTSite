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
            Items = GetAllItemsAsync().Result;
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
            Item itemToBeDeleted = await GetItemByIDAsync(ID);
            if (itemToBeDeleted != null)
            {
                Items.Remove(itemToBeDeleted);
                JsonFileService.SaveJsonObjects(Items);
                await DBServiceGeneric.DeleteObjectAsync(itemToBeDeleted);
            }
        }

        public async Task<List<Item>> GetAllItemsAsync()
        {
            return (await DBServiceGeneric.GetObjectsAsync()).ToList();
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

        public async Task<Item> GetItemByIDAsync(int ID) 
        { 
            //foreach(Item item in Items)
            //{
            //    if(item.ID == ID)
            //    {
            //        return item;
            //    }
            //}
            //return null;

            return await DBServiceGeneric.GetObjectByIdAsync(ID);
        }

        public async Task UpdateItemStockAsync(int itemID, int amount)
        {
            Item item = await GetItemByIDAsync(itemID);
            if (item != null)
            {
                if (amount > 0)
                {
                    item.Stock += amount;
                    //JsonFileService.SaveJsonObjects(Items);
                    await DBServiceGeneric.UpdateObjectAsync(item);
                }
                else
                {
                    item.Stock -= amount;
                    //JsonFileService.SaveJsonObjects(Items);
                    await DBServiceGeneric.UpdateObjectAsync(item);
                }
            }
        }

        public async Task UpdateItemQuantityByID(int ItemID, int Quantity)
        {
            Item item = await GetItemByIDAsync(ItemID);
            if (item != null)
            {
                item.Stock = item.Stock - Quantity;
                //JsonFileService.SaveJsonObjects(Items);
                await DBServiceGeneric.UpdateObjectAsync(item);
            }
        }

    }
}
