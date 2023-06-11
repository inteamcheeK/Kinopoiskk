using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace Kinopoiskk.Controllers;

public class UserController : Controller
{
    private readonly DataContext dbContext;

    public UserController(DataContext dataContext)
    {
        this.dbContext = dataContext;
    }

    
    [Authorize]
    public IActionResult Index()
    {
        List<User> users = new List<User>();
        users = dbContext.Users.ToList();
        return View(users);
    }

    [HttpGet]
    public IActionResult UserAdd()
    {
        return View();
    }
    [HttpGet]

    [Route("[controller]/[action]/{id}")]

    public IActionResult Edit(int id)
    {
        var users = dbContext.Users.Find(id);
        return View(users);
    }
    [HttpPost]

    [Route("[controller]/[action]/{id}")]
    public IActionResult Update(int id, User newUser)
    {
        var oldUser = dbContext.Users.Find(id);

        oldUser.Name = newUser.Name;
        oldUser.PhoneNumber = newUser.PhoneNumber;
        oldUser.Password = newUser.Password;

        dbContext.SaveChanges();
        return RedirectToAction("Index");
    }

[HttpPost]
    public IActionResult Store(User users)
    {
    
        users.Name = "testName";
        users.PhoneNumber = "1234567";
        dbContext.Users.Add(users);
        dbContext.SaveChanges();
        return RedirectToAction("Index");

    }
[HttpGet]

    [Route("[controller]/[action]/{id}")]

    public IActionResult Delete(int id)
    {
        var users = dbContext.Users.Find(id);
        dbContext.Users.Remove(users);
        dbContext.SaveChanges();
        return RedirectToAction("Index");
    }


}

