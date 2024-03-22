using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHealthToDoListTask.Core.Models
{
    //Note:
    //It is preferable to conduct this validation on the Siprate DTO while keeping the Model clear. In a larger system,
    //Additionally, in case of Complex Validation be necessary within siprate layer.
    //may be also use filtres on the endpoints 

    public class ToDoItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Title field is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Description field is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The DueDate field is required.")]

        [DataType(DataType.DateTime, ErrorMessage = "Please enter a valid date.")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "The IsCompleted field is required.")]
        public bool IsCompleted { get; set; }
    }
}
