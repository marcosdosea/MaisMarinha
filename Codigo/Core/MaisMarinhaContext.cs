using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Core
{
    public partial class MaisMarinhaContext : DbContext
    {
        public MaisMarinhaContext()
        {
        }

        public MaisMarinhaContext(DbContextOptions<MaisMarinhaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agendamento> Agendamentos { get; set; }
        public virtual DbSet<Agendaservico> Agendaservicos { get; set; }
        public virtual DbSet<Capitaniaconcurso> Capitaniaconcursos { get; set; }
        public virtual DbSet<Capitania> Capitania { get; set; }
        public virtual DbSet<Clima> Climas { get; set; }
        public virtual DbSet<Concurso> Concursos { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Inscricaoconcurso> Inscricaoconcursos { get; set; }
        public virtual DbSet<InscricaoCurso> Inscricaocursos { get; set; }
        public virtual DbSet<Pessoa> Pessoas { get; set; }
        public virtual DbSet<Servico> Servicos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=123456;database=maismarinha");
            }
            */
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendamento>(entity =>
            {
                entity.ToTable("agendamento");

                entity.HasIndex(e => e.TipoAtendimento, "IDX_TipoAtendimento");

                entity.HasIndex(e => e.IdServico, "fk_Agendamento_Servico1_idx");

                entity.HasIndex(e => e.IdPessoa, "fk_Atendimento_Pessoa1_idx");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.TipoAtendimento)
                    .IsRequired()
                    .HasColumnType("enum('Solicitado','Confirmado','Atendido','Cancelado')")
                    .HasDefaultValueSql("'Solicitado'");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Atendimento_Pessoa1");

                entity.HasOne(d => d.IdServicoNavigation)
                    .WithMany(p => p.Agendamentos)
                    .HasForeignKey(d => d.IdServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Agendamento_Servico1");
            });

            modelBuilder.Entity<Agendaservico>(entity =>
            {
                entity.ToTable("agendaservico");

                entity.HasIndex(e => e.IdServico, "fk_AgendaServico_Servico1_idx");

                entity.HasOne(d => d.IdServicoNavigation)
                    .WithMany(p => p.Agendaservicos)
                    .HasForeignKey(d => d.IdServico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AgendaServico_Servico1");
            });

            modelBuilder.Entity<Capitaniaconcurso>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdCapitania, e.IdConcurso })
                    .HasName("PRIMARY");

                entity.ToTable("capitaniaconcurso");

                entity.HasIndex(e => e.IdCapitania, "fk_Capitania_has_Concurso_Capitania1_idx");

                entity.HasIndex(e => e.IdConcurso, "fk_Capitania_has_Concurso_Concurso1_idx");

                entity.Property(e => e.CapitaniaConcursocol).HasMaxLength(50);

                entity.HasOne(d => d.IdCapitaniaNavigation)
                    .WithMany(p => p.Capitaniaconcursos)
                    .HasForeignKey(d => d.IdCapitania)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Capitania_has_Concurso_Capitania1");

                entity.HasOne(d => d.IdConcursoNavigation)
                    .WithMany(p => p.Capitaniaconcursos)
                    .HasForeignKey(d => d.IdConcurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Capitania_has_Concurso_Concurso1");
            });

            modelBuilder.Entity<Capitania>(entity =>
            {
                entity.ToTable("capitania");

                entity.HasIndex(e => e.Cidade, "IDX_Cidade");

                entity.HasIndex(e => e.Estado, "IDX_Estado");

                entity.HasIndex(e => e.MetareaV, "IDX_MetareaV");

                entity.HasIndex(e => e.Nome, "IDX_Nome");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.MetareaV)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Clima>(entity =>
            {
                entity.ToTable("clima");

                entity.HasIndex(e => e.MetareaV, "IDX_MetareaV");

                entity.HasIndex(e => e.IdCapitania, "fk_clima_capitania1_idx");

                entity.Property(e => e.AlertaMar)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.AlertaVento)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Coordenadas)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DescricaoAlertaMar)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.DescricaoAlertaVento)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.MetareaV)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdCapitaniaNavigation)
                    .WithMany(p => p.Climas)
                    .HasForeignKey(d => d.IdCapitania)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_clima_capitania1");
            });

            modelBuilder.Entity<Concurso>(entity =>
            {
                entity.ToTable("concurso");

                entity.HasIndex(e => e.Estado, "IDX_Estado");

                entity.HasIndex(e => e.Nome, "IDX_Nome");

                entity.Property(e => e.AreaTecnica)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DataFinalInscricao).HasColumnType("date");

                entity.Property(e => e.DataInicialInscricao).HasColumnType("date");

                entity.Property(e => e.DataProva).HasColumnType("date");

                entity.Property(e => e.Escolaridade)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Etapas)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LocalInscricao).HasMaxLength(100);

                entity.Property(e => e.LocalProva)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Turma).HasMaxLength(10);
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.ToTable("curso");

                entity.HasIndex(e => e.Estado, "IDX_Estado");

                entity.HasIndex(e => e.Nome, "IDX_Nome");

                entity.HasIndex(e => e.IdCapitania, "fk_Curso_Capitania1_idx");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DataFim).HasColumnType("date");

                entity.Property(e => e.DataFimInscricao).HasColumnType("date");

                entity.Property(e => e.DataInicial).HasColumnType("date");

                entity.Property(e => e.DataInicioInscricao).HasColumnType("date");

                entity.Property(e => e.Duracao)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Requisitos)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdCapitaniaNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdCapitania)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Curso_Capitania1");
            });

            modelBuilder.Entity<Inscricaoconcurso>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdConcurso, e.IdPessoa })
                    .HasName("PRIMARY");

                entity.ToTable("inscricaoconcurso");

                entity.HasIndex(e => e.IdConcurso, "fk_Concurso_has_Pessoa_Concurso1_idx");

                entity.HasIndex(e => e.IdPessoa, "fk_Concurso_has_Pessoa_Pessoa1_idx");

                entity.Property(e => e.DataInscricao).HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('Solicitada','Confirmada','Indeferida','Cancelada')")
                    .HasDefaultValueSql("'Solicitada'");

                entity.HasOne(d => d.IdConcursoNavigation)
                    .WithMany(p => p.Inscricaoconcursos)
                    .HasForeignKey(d => d.IdConcurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Concurso_has_Pessoa_Concurso1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Inscricaoconcursos)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Concurso_has_Pessoa_Pessoa1");
            });

            modelBuilder.Entity<InscricaoCurso>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.IdPessoa, e.IdCurso })
                    .HasName("PRIMARY");

                entity.ToTable("inscricaocurso");

                entity.HasIndex(e => e.IdCurso, "fk_Pessoa_has_Curso_Curso1_idx");

                entity.HasIndex(e => e.IdPessoa, "fk_Pessoa_has_Curso_Pessoa1_idx");

                entity.Property(e => e.DataInscricao).HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasColumnType("enum('Solicitada','Confirmada','Indeferida','Cancelada')")
                    .HasDefaultValueSql("'Solicitada'");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Inscricaocursos)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pessoa_has_Curso_Curso1");

                entity.HasOne(d => d.IdPessoaNavigation)
                    .WithMany(p => p.Inscricaocursos)
                    .HasForeignKey(d => d.IdPessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pessoa_has_Curso_Pessoa1");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.ToTable("pessoa");

                entity.HasIndex(e => e.Cpf, "Cpf_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Nome, "IDX_Nome");

                entity.Property(e => e.Bairro)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(9)
                    .HasColumnName("CEP");

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Complemento).HasMaxLength(100);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.NumeroEndereco)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefone).HasMaxLength(20);
            });

            modelBuilder.Entity<Servico>(entity =>
            {
                entity.ToTable("servico");

                entity.HasIndex(e => e.IdCapitania, "fk_Servico_Capitania1_idx");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.IdCapitaniaNavigation)
                    .WithMany(p => p.Servicos)
                    .HasForeignKey(d => d.IdCapitania)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Servico_Capitania1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
