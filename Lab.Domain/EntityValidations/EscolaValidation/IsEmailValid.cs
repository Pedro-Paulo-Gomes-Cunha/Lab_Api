using DomainValidationCore.Interfaces.Specification;
using Lab.Domain.Entities;

namespace Lab.Domain.EntityValidations.EscolaValidation
{
    public class IsEmailValid : ISpecification<Escola>
    {
        public bool IsSatisfiedBy(Escola entity)
        {
           if(string.IsNullOrWhiteSpace(entity.Email)) { return false; }

            return EmailValidation.IsValid(entity.Email);
        }
    }
}
