using Lab.Domain.DTOs;
using Lab.Domain.EntityValidations.EscolaValidation;
using Lab.Domain.Interface.IRepository;
using Lab.Domain.Interface.IService;

namespace Lab.Domain.Service
{
	public class EscolaService : IEscolaService
	{
        IRepositoryWrapper _repositoryWrapper;
		public EscolaService(IRepositoryWrapper repositoryWrapper)
		{
            this._repositoryWrapper = repositoryWrapper;
		}

        public void Save(EscolaDto obj)
        {
            var validation = new IsEcolaValid().Validate(obj.ConvertToEntity());

            if (!validation.IsValid)
            {
                throw new Exception(validation.Message);
            }

            _repositoryWrapper.EscolaRepository.Save(obj);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EscolaDto> FindAll()
        {
            var AllPeople = _repositoryWrapper.EscolaRepository.FindAll().ToList();

            return AllPeople.AsEnumerable();
        }


        public EscolaDto FindById(Guid id)
        {
            return _repositoryWrapper.EscolaRepository.FindById(id);
        }

        public void Remove(Guid id)
        {
            _repositoryWrapper.EscolaRepository.Remove(id);
        }

        public void Update(EscolaDto obj)
        {
            var validation = new IsEcolaValid().Validate(obj.ConvertToEntity());

            if (!validation.IsValid)
            {
                throw new Exception(validation.Message);
            }
            _repositoryWrapper.EscolaRepository.Update(obj);
        }

        public IEnumerable<EscolaDto> FindByProvincia(string Província)
        {
           return _repositoryWrapper.EscolaRepository.FindByProvincia(Província);
        }

        public IEnumerable<EscolaDto> FindByNome(string Nome)
        {
            return _repositoryWrapper.EscolaRepository.FindByNome(Nome);
        }
    }
}

