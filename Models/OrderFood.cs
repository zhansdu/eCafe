namespace newProjectJs.Models
{
	public class OrderFood{
		public int OrderFoodId {get;set;}
		public int OrderId{get;set;}
		public Order Order;
		public int FoodId{get;set;}
		public Food Food;
	}
}