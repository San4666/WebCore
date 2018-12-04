using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebCore.Repositories;
using WebCore.ViewModels;

namespace WebCore.Filters
{
    public class EmployeeFormFilter :  Attribute,  IResultFilter
    {
        
        private readonly IDepartmentRepository departmentRepository;
        private readonly ILanguageRepository languageRepository;

        public EmployeeFormFilter(IDepartmentRepository departmentRepository, ILanguageRepository languageRepository)
        {
            this.departmentRepository = departmentRepository;
            this.languageRepository = languageRepository;
        }
      
       public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ViewResult viewResult && viewResult.Model is EmployeeForm employeeForm)
            {
                employeeForm.LanguageSelectList = new SelectList(languageRepository.All(), "Id", "Name");
                employeeForm.DepartmentSelectList = new SelectList(departmentRepository.All(), "Id", "Name");
            }
        }

        public void OnResultExecuted(ResultExecutedContext context){}
    }
}