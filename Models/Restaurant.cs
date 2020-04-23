namespace newProjectJs.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int ManagerId {get;set;}
        public Manager Manager { get; set; }
    }
}
