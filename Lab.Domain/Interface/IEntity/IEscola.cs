
namespace Lab.Domain.Interface.IEntity
{
    public interface IEscola
    {
        Guid Id { get; set; }
        string Nome { get; set; }
        string Email { get; set; }
        int Numero_de_Salas { get; set; }
        string Provincia { get; set; }
    }
}
