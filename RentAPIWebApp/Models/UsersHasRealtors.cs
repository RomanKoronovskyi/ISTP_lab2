namespace RentAPIWebApp.Models
{
    public class UsersHasRealtors
    {
        public int Id { get; set; }

        public int UsrId { get; set; }
        public virtual Users Users { get; set; }

        public int RlId { get; set; }
        public virtual Realtors Realtors { get; set; }
    }

}
