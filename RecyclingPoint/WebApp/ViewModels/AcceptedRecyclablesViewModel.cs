using WebApp.Models;

namespace WebApp.ViewModels
{
    public class AcceptedRecyclablesViewModel
    {
        public IEnumerable<AcceptedRecyclable> AcceptedRecyclables { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
