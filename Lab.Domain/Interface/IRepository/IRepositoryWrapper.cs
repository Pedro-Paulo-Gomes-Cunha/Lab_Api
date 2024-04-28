using System;
namespace Lab.Domain.Interface.IRepository
{
	public interface IRepositoryWrapper
	{
        IEscolaRepository EscolaRepository { get; }
    }
}

