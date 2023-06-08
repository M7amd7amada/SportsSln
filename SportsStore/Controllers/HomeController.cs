namespace SportsStore.Controllers;

public class HomeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public int PageSize { get; set; } = 2;

    public HomeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index(string? category, int productPage = 1)
    {
        if (_unitOfWork.ProductRepository.Entities is null)
            return NotFound();

        return View(new ProductsListViewModel {
            Products = _unitOfWork.ProductRepository.Entities
                .Where(product => category == null || product.Category == category)
                .OrderBy(product => product.ProductId)
                .Skip ((productPage - 1) * PageSize)
                .Take(PageSize),
            
            PagingInfo = new PagingInfo {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = _unitOfWork.ProductRepository.Entities.Count()
            },

            CurrentCategory = category
        });
    }
}