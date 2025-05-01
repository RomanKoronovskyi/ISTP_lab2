namespace RentAPIWebApp.Models
{
    public class UsersHasRealtors
    {
        public int Id { get; set; }

        public virtual Users Usr { get; set; }

        public virtual Realtors Rl { get; set; }
    }

}
