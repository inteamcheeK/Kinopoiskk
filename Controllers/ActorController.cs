using Microsoft.AspNetCore.Mvc;
namespace Kinopoiskk.Controllers;

public class ActorController : Controller
{
    private readonly DataContext dbContext;

    public ActorController(DataContext dataContext)
    {

        this.dbContext = dataContext;
    }

    public IActionResult Index()
    {
        List<Actor> actors = new List<Actor>();
        actors = dbContext.Actors.ToList();
        return View(actors);
    }

    [HttpGet]
    public IActionResult AddActor()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Store(Actor actors)
    {
        dbContext.Actors.Add(actors);
        dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("[controller]/[action]/{id}")]
    public IActionResult Edit(int id)
    {
        var actors = dbContext.Actors.Find(id);

        return View(actors);
    }
    
    [HttpPost]
    [Route("[controller]/[action]/{id}")]
    public IActionResult Update(int id, Actor newActor)
    {
        var oldActor = dbContext.Actors.Find(id);
        oldActor.FirstName = newActor.FirstName;
        oldActor.LastName = newActor.LastName;
        oldActor.DateOfBirth = newActor.DateOfBirth;
        oldActor.Country = newActor.Country;
        dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
    
    [HttpGet]
    [Route("[controller]/[action]/{id}")]
    public IActionResult Delete(int id)
    {
        var actors = dbContext.Actors.Find(id);
        dbContext.Actors.Remove(actors);
        dbContext.SaveChanges();
        return RedirectToAction("Index");
    }
}