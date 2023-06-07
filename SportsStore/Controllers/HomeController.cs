namespace SportsStore.Controllers;

public class HomeController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    public int PageSize { get; set; } = 4;

    public HomeController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index(int productPage = 1)
    {
        if (_unitOfWork.ProductRepository.Entities is null)
            return NotFound();

        return View(_unitOfWork.ProductRepository.Entities
            .OrderBy(product => product.ProductId)
            .Skip((productPage - 1) * PageSize)
            .Take(PageSize));
    }
}