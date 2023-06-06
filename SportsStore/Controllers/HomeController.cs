namespace SportsStore.Controllers;

public class HomeController : Controller
{
    private readonly IProductRepository _repository;

    public HomeController(IProductRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        return View(_repository.Entities);
    }
}