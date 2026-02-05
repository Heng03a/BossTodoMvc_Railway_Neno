using BossTodoMvc.Application.Services;
using Microsoft.AspNetCore.Mvc;
using BossTodoMvc.Web.ViewModels;


namespace BossTodoMvc.Web.Controllers;

public class TodosController : Controller
{
    private readonly TodoService _todoService;

    public TodosController(TodoService todoService)
    {
        _todoService = todoService;
    }

public async Task<IActionResult> Index(string status = "all", string sort = "newest")
{
    var items = await _todoService.GetFilteredAsync(status, sort);

    var vm = new TodoListViewModel
    {
        Items = items,
        Status = status,
        Sort = sort
    };

    return View(vm);
}

    [HttpPost]
    public async Task<IActionResult> Create(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            return RedirectToAction(nameof(Index));
        }

        await _todoService.AddAsync(title);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> Toggle(int id)
    {
        await _todoService.ToggleCompleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        await _todoService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

[HttpGet]
public async Task<IActionResult> Edit(int id)
{
    var todo = await _todoService.GetByIdAsync(id);
    if (todo == null)
        return NotFound();

    var vm = new EditTodoViewModel
    {
        Id = todo.Id,
        Title = todo.Title
    };

    return View(vm);
}

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(EditTodoViewModel model)
{
    if (!ModelState.IsValid)
        return View(model);

    await _todoService.UpdateAsync(model.Id, model.Title);
    return RedirectToAction(nameof(Index));
}


}
