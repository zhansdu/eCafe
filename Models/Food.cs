namespace newProjectJs.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int RestaurantId {get; set;}
        public Restaurant Restaurant { get; set; }
    }
}
