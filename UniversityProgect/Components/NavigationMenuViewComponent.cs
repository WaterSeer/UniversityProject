using Microsoft.AspNetCore.Mvc;

namespace UniversityProgect.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        public string Invoke()
        {
            return "This is ViewComponent";
        }
    }
}
