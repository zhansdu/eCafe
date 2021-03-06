using System;
namespace newProjectJs.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int RestaurantId { get; set; }
        public Restaurant restaurant { get; set; }
        public int TableId{get;set;}
        public Table Table { get; set; }
        public int ClientId{get;set;}
        public Client Client { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public Boolean Active { get; set; }
    }
}
