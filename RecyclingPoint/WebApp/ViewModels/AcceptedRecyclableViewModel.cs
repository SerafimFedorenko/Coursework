using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.ViewModels
{
    public class AcceptedRecyclableViewModel
    {
        public int Id { get; set; }
        public int Enperience { get; set; }
        public string StorageType { get; set; }
        public Employee? Employee { get; set; }
        public Storage? Storage { get; set; }
        public RecyclableType? RecyclableType { get; set; }
        [Display(Name = "Количество")]
        public int Quantity { get; set; }
        [Display(Name = "Дата")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
