using System.ComponentModel.DataAnnotations;

namespace WebCore.Models
{
    public class EmployeeSearch
    {
        [StringLength(10, MinimumLength = 3)] 
        public string LikeFirstName { get; set; }
    }
}