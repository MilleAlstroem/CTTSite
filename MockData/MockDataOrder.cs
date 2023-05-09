using CTTSite.Models;

namespace CTTSite.MockData
{
    public class MockDataOrder
    {
        public static List<Order> Orders = new List<Order>()
        {
            new Order(0, 2, 56, true, false),
            new Order(0, 2, 82, false, true),
            new Order(0, 2, 23, true, true),
            new Order(0, 2, 64, true, false),
        };

        public static List<Order> GetMockOrders() { return Orders; }
    }
}
