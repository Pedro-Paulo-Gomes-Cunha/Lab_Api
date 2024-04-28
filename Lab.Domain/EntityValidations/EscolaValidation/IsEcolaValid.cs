using DomainValidationCore.Validation;
using Lab.Domain.Entities;

namespace Lab.Domain.EntityValidations.EscolaValidation
{
    public class IsEcolaValid: Validator<Escola>
    {
        public IsEcolaValid() {
            Add("IsNomeNullOrWhite", new Rule<Escola>(new IsNomeNullOrWhite(), "Campo Nome é obrigatório"));
            Add("IsProvinciaNullOrWhite", new Rule<Escola>(new IsProvinciaNullOrWhite(), "Campo Provincia é obrigatório"));
            Add("IsEmailValid", new Rule<Escola>(new IsEmailValid(), "Campo Email é obrigatório"));
        }
    }
}
