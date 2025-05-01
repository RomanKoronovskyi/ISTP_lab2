using System.ComponentModel.DataAnnotations;

namespace RentAPIWebApp.Models
{
    public class Realtors
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Повне ім'я")]
        public string RlName { get; set; }
        [Display(Name = "Загальна інформація")]
        public string RlInfo { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Номер телефону")]
        public string RlPhone { get; set; }
        [Display(Name = "Рейтинг")]
        public double RlRating { get; set; }
        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Електронна пошта")]
        public string RlEmail { get; set; }

        public virtual ICollection<UsersHasRealtors> UserHasRealtors { get; set; } = new List<UsersHasRealtors>();
    }

}
