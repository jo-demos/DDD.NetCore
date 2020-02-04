using DDD.NetCore.Data.EntityConfig;
using DDD.NetCore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;

namespace DDD.NetCore.Data.Contexts
{
    public class ProjectContext : DbContext
    {
        public IDbContextTransaction Transaction { get; private set; }

        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {

        }

        // TODO: Adicionar DbSet dinâmico
        public DbSet<CervejaEntity> Cerveja { get; set; }
        public DbSet<RevendedorEntity> Revendedor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        public IDbContextTransaction InitTransaction()
        {
            if (Transaction == null)
            {
                Transaction = this.Database.BeginTransaction();
            }

            return Transaction;
        }

        private void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }

        private void Save()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                throw ex;
            }
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void SendChanges()
        {
            Save();
            Commit();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: Aplicar configuração dinâmica
            modelBuilder.ApplyConfiguration(new CervejaConfig());
            modelBuilder.ApplyConfiguration(new RevendedorConfig());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            //{
            //    if (entry.State == EntityState.Added)
            //    {
            //        entry.Property("DataCadastro").CurrentValue = DateTime.Now;
            //    }

            //    if (entry.State == EntityState.Modified)
            //    {
            //        entry.Property("DataCadastro").IsModified = false;
            //    }
            //}
            return base.SaveChanges();
        }
    }
}
