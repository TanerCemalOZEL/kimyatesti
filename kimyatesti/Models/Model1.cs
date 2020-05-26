namespace kimyatesti.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Soru> Soru { get; set; }
        public virtual DbSet<Test> Test { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Soru>()
                .HasMany(e => e.Test)
                .WithMany(e => e.Soru)
                .Map(m => m.ToTable("SoruTestBind").MapLeftKey("SoruId").MapRightKey("TestId"));
        }
    }
}
