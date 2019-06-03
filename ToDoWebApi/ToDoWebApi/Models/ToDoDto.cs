namespace ToDoWebApi.Models
{
    public class ToDoDto    
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Time { get; set; }
        public string Created { get; set; }
        public string Updated { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
    }
}
