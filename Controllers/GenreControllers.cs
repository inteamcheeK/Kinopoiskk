using Microsoft.AspNetCore.Mvc;
namespace Kinopoiskk.Controllers;
public class GenreController : Controller
{
    private readonly DataContext dbContext;

    public GenreController(DataContext dataContext)
    {

        this.dbContext = dataContext;
    }

    public IActionResult Index()
    {
        List<Genre> genres = new List<Genre>();
        genres = dbContext.Genres.ToList();
        return View(genres);
    }

    [HttpGet]
    public IActionResult AddGenre()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Store(Genre genres)
    {
        dbContext.Genres.Add(genres);
        dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

     [HttpGet]
    [Route("[controller]/[action]/{id}")]
    public IActionResult Edit(int id)
    {
        var genres = dbContext.Genres.Find(id);

        return View(genres);
    }
    
    [HttpPost]
    [Route("[controller]/[action]/{id}")]
    public IActionResult Update(int id, Genre newGenre)
    {
        var oldGenre = dbContext.Genres.Find(id);
        oldGenre.Name = newGenre.Name;
        dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    [Route("[controller]/[action]/{id}")]
    public IActionResult Delete(int id)
    {
        var genres = dbContext.Genres.Find(id);
        dbContext.Genres.Remove(genres);
        dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

}