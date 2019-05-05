namespace Web.Models.TaskModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ClientAddress { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }
    }
}
