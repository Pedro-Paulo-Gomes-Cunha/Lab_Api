using Lab.Domain.DTOs;

namespace Lab.Api.Views
{
    public class EscolaView
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Numero_de_Salas { get; set; }
        public string Provincia { get; set; }

        public EscolaView() { }

        public EscolaView(Guid id, string nome, string email, int numero_de_salas, string provincia)
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
