using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCrudEstagio.Models
{
	[Table("LogAuditoria")]
	public class LogAuditoria
	{
		[Column("Id")]
		[Display(Name = "Codigo")]
		public int Id { get; set; }

		[Column("DetalhesAuditoria")]
		[Display(Name = "Detalhes da Auditoria")]
		public string DetalhesAuditoria { get; set; }

		[Column("EmailUsuario")]
		[Display(Name = "Email do Usuário")]
		public string EmailUsuario { get; set; }
	}
}
