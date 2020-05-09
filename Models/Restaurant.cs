using System;
namespace newProjectJs.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ManagerId {get;set;}
        public Manager Manager { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string LittleDescription { get; set; }
        public string BigDescription { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public string Kitchen {get; set;}
        public string Contacts{get; set;}
        public int AvarageMoney{get; set;}
    }
}
