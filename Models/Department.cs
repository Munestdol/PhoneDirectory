namespace PhoneDirectory.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
    }
}
