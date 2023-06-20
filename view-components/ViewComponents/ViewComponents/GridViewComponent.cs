using Microsoft.AspNetCore.Mvc;

namespace ViewComponents.ViewComponents
{
    //[ViewComponent]
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(); //invoke a partial view -> ~/Views/Shared/Components/Grid/Default.cshtml
        }
    }
}
