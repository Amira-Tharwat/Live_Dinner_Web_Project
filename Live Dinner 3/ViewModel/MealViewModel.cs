using Live_Dinner_3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Live_Dinner_3.ViewModel
{
    public class MealViewModel
    {
        public Meal meal { get; set; }
        public IEnumerable<SelectListItem> chefs { get; set; }

    }
}
