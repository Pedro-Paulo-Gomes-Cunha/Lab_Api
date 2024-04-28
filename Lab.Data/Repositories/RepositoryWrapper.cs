using System;
using Lab.Domain.Interface.IRepository;

namespace Lab.Data.Repositories
{
	public class RepositoryWrapper : IRepositoryWrapper
	{

        IEscolaRepository _EscolaRepository;

      
        public RepositoryWrapper()
		{
		}

        public IEscolaRepository EscolaRepository
        {
            get
            {
                if (_EscolaRepository == null)
                {
                    _EscolaRepository = new EscolaRepository();
                }
                return _EscolaRepository;
            }
        }

    }
}

