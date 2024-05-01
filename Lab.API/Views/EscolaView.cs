using Lab.Domain.DTOs;
using Web.Api.Views;

namespace Lab.Api.Views
{
    public class EscolaView
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Numero_de_Salas { get; set; }
        public ProvinciaView Provincia { get; set; }
        public EscolaView() { }

        public EscolaView(Guid id, string nome, string email, int numero_de_salas)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Numero_de_Salas = numero_de_salas;
           
        }

        public EscolaDto ConvertToDto()
        {
            return new EscolaDto(this.Id, this.Nome, this.Email, this.Numero_de_Salas, this.Provincia.nome);
        }
    }
}
