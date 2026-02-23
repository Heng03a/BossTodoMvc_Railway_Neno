using Microsoft.AspNetCore.Mvc;
using BossTodoMvc.Application.Interfaces;
using BossTodoMvc.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;


namespace BossTodoMvc.Web.Controllers
{
    [Authorize]
    public class TodosController : Controller
    {
        private readonly ITodoService _todoService;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<IActionResult> Index(string? status, string? sort)
        {
            var todos = await _todoService.GetFilteredAsync(status, sort);
            return View(todos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(string title)
        {
            if (!string.IsNullOrWhiteSpace(title))
            {
                await _todoService.AddAsync(title);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Toggle(int id)
        {
            await _todoService.ToggleCompleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _todoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        // ------------------------
        // EDIT (GET)
        // ------------------------
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

        // ------------------------
        // EDIT (POST)
        // ------------------------
        [HttpPost]
        public async Task<IActionResult> Edit(EditTodoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _todoService.UpdateAsync(model.Id, model.Title);

            return RedirectToAction(nameof(Index));
        }
    }
}
