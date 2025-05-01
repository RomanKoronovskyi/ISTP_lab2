using System.ComponentModel.DataAnnotations;

namespace RentAPIWebApp.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Повне ім'я")]
        public string UsrName { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Електронна пошта")]
        public string UsrEmail { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Номер телефону")]
        public string UsrPhone { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Пароль")]
        public string UsrPassword { get; set; }

        public virtual ICollection<UsersHasRealtors> UserHasRealtors { get; set; } = new List<UsersHasRealtors>();
        public virtual ICollection<Favourites> Favourites { get; set; } = new List<Favourites>();
    }

}
