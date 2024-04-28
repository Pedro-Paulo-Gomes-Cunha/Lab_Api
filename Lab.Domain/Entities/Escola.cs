using Lab.Domain.DTOs;
using Lab.Domain.Interface.IEntity;

namespace Lab.Domain.Entities
{
    public class Escola : IEscola
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Numero_de_Salas { get; set; }
        public string Provincia { get; set; }

        public Escola() { }

        public Escola(IEscola escola):this(escola.Id, escola.Nome, escola.Email, escola.Numero_de_Salas, escola.Provincia){ }

        public Escola(Guid id, string nome, string email, int numero_de_salas, string provincia)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Numero_de_Salas = numero_de_salas;
            Provincia = provincia;
        }

        public EscolaDto ConvertToDto()
        {
            return new EscolaDto(this.Id, this.Nome, this.Email, this.Numero_de_Salas, this.Provincia);
        }
    }
}
