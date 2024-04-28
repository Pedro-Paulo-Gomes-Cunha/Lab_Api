using Lab.Domain.DTOs;

namespace Lab.Domain.Interface.IRepository
{
    public interface IEscolaRepository
    {
        IEnumerable<EscolaDto> FindAll();
        void Save(EscolaDto obj);
        EscolaDto FindById(Guid id);
        void Update(EscolaDto obj);
        void Remove(Guid id);
        IEnumerable<EscolaDto> FindByProvincia(string Província);
        IEnumerable<EscolaDto> FindByNome(string Nome);
    }
}
