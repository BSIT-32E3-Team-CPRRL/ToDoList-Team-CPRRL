using Microsoft.AspNetCore.Mvc;

public class TodoController : Controller
{
    private readonly TodoDbContext _context;

    public TodoController(TodoDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var todoItems = _context.TodoItems.ToList();
        return View(todoItems);
    }

    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Delete(int id)
    {
        var item = _context.TodoItems.Find(id);
        if (item == null)
        {
            return NotFound();
        }

        _context.TodoItems.Remove(item);
        _context.SaveChanges();
        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    public IActionResult Create(TodoItem item)
    {
        if (ModelState.IsValid)
        {
            _context.Add(item);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(item);
    }

    public IActionResult MarkAsCompleted(int id)
    {
        var item = _context.TodoItems.Find(id);
        if (item != null)
        {
            item.IsCompleted = true;
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}
