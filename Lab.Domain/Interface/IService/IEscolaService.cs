
using Lab.Domain.DTOs;

namespace Lab.Domain.Interface.IService
{
	public interface IEscolaService : IServiceBase<EscolaDto>
	{
        IEnumerable<EscolaDto> FindByProvincia(string Província);
        IEnumerable<EscolaDto> FindByNome(string Nome);
    }
}

