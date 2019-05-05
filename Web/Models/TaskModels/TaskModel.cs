using System.ComponentModel.DataAnnotations;

namespace Web.Models.TaskModels
{
    public class TaskModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string ClientAddress { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }
    }
}
