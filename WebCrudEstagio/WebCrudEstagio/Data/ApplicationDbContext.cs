using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebCrudEstagio.Models;

namespace WebCrudEstagio.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}
		public DbSet<Estagiario> Estagiario { get; set; }
		public DbSet<LogAuditoria> LogAuditoria { get; set; }
	}
}
