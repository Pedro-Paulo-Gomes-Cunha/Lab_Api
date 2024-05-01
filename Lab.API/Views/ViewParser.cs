
using Lab.Domain.DTOs;

namespace Lab.Api.Views
{
	public class ViewParser
	{
		public ViewParser()
		{
		}
		public static EscolaView Parse(EscolaDto escola)
		{
			return new EscolaView(escola.Id, escola.Nome, escola.Email, escola.Numero_de_Salas);
		}
    }
}

