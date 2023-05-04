﻿using CTTSite.MockData;
using CTTSite.Models;
using CTTSite.Services.DB;
using CTTSite.Services.Interface;
using CTTSite.Services.JSON;

namespace CTTSite.Services.NormalService
{
    public class CartItemService : ICartItemService
    {
        public DBServiceGeneric<CartItem> DBServiceGeneric;
        public JsonFileService<CartItem> JsonFileService;
        public List<CartItem> CartItems;

        public CartItemService(DBServiceGeneric<CartItem> dBServiceGeneric, JsonFileService<CartItem> jsonFileService)
        {
            DBServiceGeneric = dBServiceGeneric;
            JsonFileService = jsonFileService;
            CartItems = GetAllCartItems();
        }

        public async Task AddToCartAsync(CartItem cartItem)
        {
            int IDCount = 0;
            foreach(CartItem listCartItem in CartItems)
            {
                if(IDCount < listCartItem.ID)
                {
                    IDCount = listCartItem.ID;
                }
            }
            cartItem.ID = IDCount + 1;
            CartItems.Add(cartItem);
            JsonFileService.SaveJsonObjects(CartItems);
            //await DBServiceGeneric.AddObjectAsync(cartItem);
        }

        public Task ConvertBoolPaidByUserIDAsync(int userID)
        {
            throw new NotImplementedException();
        }

        public List<CartItem> GetAllCartItems()
        {
            //return MockData.MockDataCartItem.GetMockCartItems();
            return JsonFileService.GetJsonObjects().ToList();
            //return DBServiceGeneric.GetObjectsAsync().Result.ToList();
        }

        public CartItem GetCartItemByID(int ID)
        {
            foreach(CartItem cartItem in CartItems)
            {
                if(cartItem.ID == ID)
                {
                    return cartItem;
                }
            }
            return null;
        }

        public List<CartItem> GetAllCartItemsByUserID(int userID)
        {
            List<CartItem> cartItemsByUserID = new List<CartItem>();
            foreach(CartItem cartItem in CartItems)
            {
                if(cartItem.UserID == userID)
                {
                    cartItemsByUserID.Add(cartItem);
                }
            }
            return cartItemsByUserID;
        }

        public List<CartItem> GetOldCartItemsByID(int ID)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveFromCartByIDAsync(int ID)
        {
            CartItem cartItemToBeDeleted = null;
            if(GetCartItemByID(ID) != null)
            {
                CartItems.Remove(GetCartItemByID(ID));
                JsonFileService.SaveJsonObjects(CartItems);
                //cartItemToBeDeleted = GetCartItemByID(ID);
                //await DBServiceGeneric.DeleteObjectAsync(cartItemToBeDeleted);
            }
        }
    }
}
