namespace CTTSite.Models
{
    public class CartItem
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public int Amount { get; set; }
        public int UserID { get; set; }
        public bool Paid { get; set; }

        public CartItem(int iD, int itemID, int amount, int userID, bool paid)
        {
            ID=iD;
            ItemID=itemID;
            Amount=amount;
            UserID=userID;
            Paid=paid;
        }

        public CartItem()
        {
            
        }
    }
}
