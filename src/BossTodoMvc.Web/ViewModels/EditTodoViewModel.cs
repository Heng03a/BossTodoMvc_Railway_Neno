using System.ComponentModel.DataAnnotations;

namespace BossTodoMvc.Web.ViewModels
{
    public class EditTodoViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
    }
}
