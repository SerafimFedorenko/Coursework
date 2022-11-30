using WebApp.Models;

namespace WebApp.ViewModels
{
    public class RecyclableTypesViewModel
    {
        public IEnumerable<RecyclableType> RecyclableTypes { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
