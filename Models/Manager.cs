namespace newProjectJs.Models
{
    public class Manager : User
    {
    	public int ManagerId{get;set;}
    	public int AdminId{get;set;}
        public Admin Admin { get; set; }
    }
}
