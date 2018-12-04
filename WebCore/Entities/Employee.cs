namespace WebCore.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int LanguageId { get; set; }
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
        public Language Language { get; set; }
    }
}