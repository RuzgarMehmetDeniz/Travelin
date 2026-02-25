using Microsoft.AspNetCore.Mvc;

namespace Project3Travelin.ViewComponents.TourViewComponent
{
    public class _TourBannerImageComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}