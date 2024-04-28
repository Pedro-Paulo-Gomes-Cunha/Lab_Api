using DomainValidationCore.Interfaces.Specification;
using Lab.Domain.Entities;

namespace Lab.Domain.EntityValidations.EscolaValidation
{
    internal class IsProvinciaNullOrWhite : ISpecification<Escola>
    {
        public bool IsSatisfiedBy(Escola entity)
        {
            return !string.IsNullOrWhiteSpace(entity.Provincia);
        }
    }
}
