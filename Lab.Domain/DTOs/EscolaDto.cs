﻿using Lab.Domain.DBObjects;
using Lab.Domain.Entities;

namespace Lab.Domain.DTOs
{
    public class EscolaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Numero_de_Salas { get; set; }
        public string Provincia { get; set; }

        public EscolaDto() { }

        public EscolaDto(Guid id, string nome, string email, int numero_de_salas, string provincia)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Numero_de_Salas = numero_de_salas;
            Provincia = provincia;
        }
        public Escola ConvertToEntity()
        {
            return new Escola(this.Id, this.Nome, this.Email, this.Numero_de_Salas, this.Provincia);
        }
        public EscolaDB ConvertToDbo()
        {
            return new EscolaDB(this.Id, this.Nome, this.Email, this.Numero_de_Salas, this.Provincia);
        }
    }
}
