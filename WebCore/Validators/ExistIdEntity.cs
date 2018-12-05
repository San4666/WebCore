using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using WebCore.Repositories;

namespace WebCore.Validators
{
    public  class ExistIdEntity : ValidationAttribute
    {
        private readonly Type repositoryType;

        public ExistIdEntity(Type repositoryType)
        {
            this.repositoryType = repositoryType;
        }
        
        protected override ValidationResult IsValid(object userId, ValidationContext validationContext)
        {
            var existRepository = (IExistRepository)validationContext.GetService(repositoryType);

            Debug.Assert(existRepository != null, nameof(existRepository) + " != null");
            
            return (userId is int id && existRepository.Exist(id))
                ? ValidationResult.Success
                : new ValidationResult(ErrorMessageString);
        }
    }
}