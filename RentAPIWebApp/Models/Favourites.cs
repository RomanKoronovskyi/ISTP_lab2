namespace RentAPIWebApp.Models
{
    public class Favourites
    {
        public int Id { get; set; }

        public int UsrId { get; set; }
        public virtual Users Users { get; set; }

        public int FlId { get; set; }
        public virtual Flats Flats { get; set; }
    }

}
