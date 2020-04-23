using System;
namespace newProjectJs.Models
{
    public class Table
    {
        public int TableId { get; set; }
        public int Number { get; set; }
        public Boolean Active { get; set; }
        public int RestaurantId {get;set;}
        public Restaurant Restaurant { get; set; }
    }
}
