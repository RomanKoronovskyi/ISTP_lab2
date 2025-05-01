namespace RentAPIWebApp.Models
{
    public class Favourites
    {
        public int Id { get; set; }

        public virtual Users Usr { get; set; }

        public virtual Flats Fl { get; set; }
    }

}
