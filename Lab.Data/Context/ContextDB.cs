using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Lab.Domain.DBObjects;
using Lab.Domain.Entities;
using Lab.Domain.Interface.IEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab.Data.Context
{
    public class ContextDB : DbContext
    {

        public ContextDB() : base()
        {

        }

        public ContextDB(DbContextOptions<DbContext> options):base(options)
        {
            
        }



        protected override void OnConfiguring(DbContextOptionsBuilder options)
         {
           // var stringConexao = "Data Source=DESKTOP-G4UNLMH\\SQLEXPRESS;Database=TesteDB1;Integrated Security=True;TrustServerCertificate=true;MultipleActiveResultSets=true";
           var stringConexao = "Data Source=sql.bsite.net\\MSSQL2016;Database=caapp_SampleDB;Escola Id=caapp_SampleDB;Password=1234;TrustServerCertificate=true;MultipleActiveResultSets=true";
            options.UseSqlServer(stringConexao);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<EscolaDB> Escolas{ get; set; }

    }
}
