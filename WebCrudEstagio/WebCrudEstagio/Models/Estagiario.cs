using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCrudEstagio.Models
{
	[Table("Estagiario")]
	public class Estagiario
	{
		[Column("Id")]
		[Display(Name = "Codigo")]
		public int Id { get; set; }

		[Column("Nome")]
		[Display(Name = "Nome")]
		public string Nome { get; set; }

		[Column("Telefone")]
		[Display(Name = "Telefone")]
		public string Telefone { get; set; }

		[Column("CEP")]
		[Display(Name = "Código Postal")]
		public string CEP { get; set; }

		[Column("Logradouro")]
		[Display(Name = "Logradouro")]
		public string Endereco { get; set; }

		[Column("Bairro")]
		[Display(Name = "Bairro")]
		public string Bairro { get; set; }

		[Column("Cidade")]
		[Display(Name = "Cidade")]
		public string Cidade { get; set; }

		[Column("UF")]
		[Display(Name = "Estado")]
		public string UF { get; set; }

		[Column("DataAdmissão")]
		[Display(Name = "Data de Admissão")]
		public DateTime DataAdmissão { get; set; }
	}
}
