using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Lab.Data.Context;
using Lab.Domain.DBObjects;
using Lab.Domain.DTOs;
using Lab.Domain.Entities;
using Lab.Domain.Interface.IRepository;

namespace Lab.Data.Repositories
{
	public class EscolaRepository : BaseRepository<EscolaDB>, IEscolaRepository
    {
        protected ContextDB Dbconection = new();
        public EscolaRepository()
		{
		}

        public IEnumerable<EscolaDto> FindAll()
        {
            var Lista_de_Escolas = GetAll();

            return Lista_de_Escolas.Select(x=>x.ConvertToDto());
        }

        public EscolaDto FindById(Guid id)
        {
            var dbObject = GetById(id);

            if (dbObject == null) return null;

            return dbObject.ConvertToDto();
        }

        public IEnumerable<EscolaDto> FindByNome(string Nome)
        {
            return Dbconection.Escolas.Where(x => x.Nome.ToUpper().Equals(Nome.ToUpper())).Select(x => x.ConvertToDto()).AsEnumerable();
        }

        public IEnumerable<EscolaDto> FindByProvincia(string Província)
        {
            return Dbconection.Escolas.Where(x => x.Provincia.Equals(Província)).Select(x => x.ConvertToDto()).AsEnumerable();
        }

        public void Remove(Guid id)
        {
            var dbObject = GetById(id);

            if (dbObject != null)
                Remove(dbObject);
        }

        public void Save(EscolaDto obj)
        {
            var dbObject = obj.ConvertToDbo();

            dbObject.Id = Guid.NewGuid();

            Add(dbObject);
        }

        public void Update(EscolaDto obj)
        {
            Update(obj.ConvertToDbo());
        }
    }
}