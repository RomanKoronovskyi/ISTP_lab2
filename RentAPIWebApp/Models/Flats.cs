using System.ComponentModel.DataAnnotations;

namespace RentAPIWebApp.Models
{
    public class Flats
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Адреса")]
        public string FlAddr { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Загальна площа")]
        public double FlArea { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Кількість кімнат")]
        public int FlRooms { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Ціна")]
        public decimal FlPrice { get; set; }

        public virtual Districts Ds { get; set; }

        public virtual ICollection<Favourites> Favourites { get; set; } = new List<Favourites>();
    }

}
