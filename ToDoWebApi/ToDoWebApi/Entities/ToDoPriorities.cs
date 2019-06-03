namespace ToDoWebApi.Entities
{
    public class ToDoPriorities
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string GetPriority()
        {
            return Name;
        }
    }
}
