using Live_Dinner_3.Models;

namespace Live_Dinner_3.ViewModel
{
    public class MenuViewModel
    {
        public List<Meal> Meals { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }


    }
}
