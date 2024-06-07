using GestaoCulto.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GestaoCulto.Repository.Persistence.Context
{
    public class MySqlContext : DbContext
    {

        public DbSet<CongregacaoModel> congregacao { get; set; }
        public DbSet<ParametrosSistemaModel> parametros_sistema { get; set; }
        public DbSet<UsuariosModel> usuarios { get; set; }
        public DbSet<PessoasModel> pessoas { get; set; }
        public DbSet<MinisterioModel> ministerios { get; set; }
        public DbSet<PessoaMinisterioModel> pessoas_ministerios { get; set; }   
        public DbSet<FuncoesMinisteriaisModel> funcoes_ministeriais { get; set; }
        public DbSet<MusicaModel> musicas { get; set; } 

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Retira o delete on cascade
            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                        .SelectMany(t => t.GetForeignKeys())
                        .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            modelBuilder.Entity<PessoaMinisterioModel>().HasOne(c => c.Pessoas).WithMany(c => c.PessoasMinisterios).HasForeignKey(c => c.PessoasId);
            modelBuilder.Entity<PessoaMinisterioModel>().HasOne(c => c.Ministerio).WithMany(c => c.PessoasMinisterios).HasForeignKey(c => c.MinisterioId);

            base.OnModelCreating(modelBuilder);
        }


    }
}
