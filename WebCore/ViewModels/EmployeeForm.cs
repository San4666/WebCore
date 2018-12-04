using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCore.Entities;
using WebCore.Repositories;
using WebCore.Validators;

namespace WebCore.ViewModels
{
    public class EmployeeForm
    {      
        [DisplayName("Имя")]    
        [Required]
        [StringLength(10,MinimumLength = 3)]      
        public string FirstName { get; set; }
        
        [DisplayName("Фамилия")] 
        [Required]
        [StringLength(10,MinimumLength = 3)]
        public string LastName { get; set; }

        [DisplayName("Возраст")]
        [Required]
        [Range(18, 100)]
        public int Age { get; set; }

        [Required]
        [DisplayName("Язык программирования")]
        [ExistIdEntity(typeof(ILanguageRepository))]
        public int LanguageId { get; set; }

        [Required] 
        [DisplayName("Отдел")] 
        [ExistIdEntity(typeof(IDepartmentRepository),ErrorMessage = "Not exist department with it id  ")]
        public int DepartmentId { get; set; }
        
        public SelectList DepartmentSelectList { get; set; }

        public SelectList LanguageSelectList { get; set; }

        public void LoadModel(Employee employee)
        {
            FirstName = employee.FirstName;
            LastName = employee.LastName;
            Age = employee.Age;
            LanguageId = employee.LanguageId;
            DepartmentId = employee.DepartmentId;
        }

        public void UpdateModel(Employee employee)
        {
            employee.FirstName = FirstName;
            employee.LastName = LastName;
            employee.Age = Age;
            employee.LanguageId =  LanguageId;
            employee.DepartmentId = DepartmentId;
        }
    }
}