using System.ComponentModel.DataAnnotations;

namespace RentAPIWebApp.Models
{
    public class Districts
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Назва району")]
        public string DsName { get; set; }

        public virtual ICollection<Flats> Flats { get; set; } = new List<Flats>();
    }

}
