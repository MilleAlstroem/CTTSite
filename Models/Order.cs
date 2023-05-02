namespace CTTSite.Models
{
    public class Order
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Shipped { get; set; }

        public Order(int iD, int userID, decimal totalPrice, bool shipped)
        {
            ID=iD;
            UserID=userID;
            TotalPrice=totalPrice;
            Shipped=shipped;
        }

        public Order()
        {
            
        }
    }
}
