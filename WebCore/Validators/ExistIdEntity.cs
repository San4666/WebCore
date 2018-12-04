using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using WebCore.Repositories;

namespace WebCore.Validators
{
    public  class ExistIdEntity : ValidationAttribute
    {
        private readonly Type baseRepository;

        public ExistIdEntity(Type baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        
        protected override ValidationResult IsValid(object userId, ValidationContext validationContext)
        {
            var existRepository = (IExistRepository)validationContext.GetService(baseRepository);

            Debug.Assert(existRepository != null, nameof(existRepository) + " != null");
            
            return (userId is int id && existRepository.Exist(id))
                ? ValidationResult.Success
                : new ValidationResult(ErrorMessageString);
        }
    }
}