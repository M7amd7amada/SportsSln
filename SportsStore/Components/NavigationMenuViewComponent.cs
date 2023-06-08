namespace SportsStore.Components;

public class NavigationMenuViewComponent : ViewComponent
{
    private readonly IUnitOfWork _unitOfWork;

    public NavigationMenuViewComponent(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IViewComponentResult Invoke()  
    {
        return View(_unitOfWork.ProductRepository.Entities?
            .Select(product => product.Category)
            .Distinct()
            .OrderBy(product => product));
    }
}