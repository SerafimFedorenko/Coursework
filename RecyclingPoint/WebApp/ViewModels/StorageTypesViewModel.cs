using WebApp.Models;

namespace WebApp.ViewModels
{
    public class StorageTypesViewModel
    {
        public IEnumerable<StorageType> StorageTypes { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
