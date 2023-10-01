using Microsoft.EntityFrameworkCore;
using ShareCrypt.Models;
using System.Reflection.Metadata;

namespace ShareCrypt.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

       public DbSet<Users> Users { get; set; }
       public DbSet<FF> FF { get; set; }
       public DbSet<OwnedFF> OwnedFF { get; set; }
       public DbSet<Shared> Shared { get; set; }


/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<FF>()
                .HasKey(e => new { e.FFID ,e.OwnerID , e.User.ID});
            modelBuilder.Entity<FF>()
              .HasOne(ee => ee.User);


            modelBuilder.Entity<OwnedFF>()
                .HasNoKey();   
            
            modelBuilder.Entity<Shared>()
                .HasNoKey();

            *//*            modelBuilder.Entity<OwnedFF>()
                           .HasOne(pc => new { pc.UserID,pc.FFID,pc.ParantID});

                        modelBuilder.Entity<OwnedFF>()
                           .HasOne(pc => pc.User);
                        modelBuilder.Entity<OwnedFF>()
                     .HasOne(pc => pc.FFP);

                        modelBuilder.Entity<OwnedFF>()
                        .HasMany(pc => pc.FFs);*/


            /*            modelBuilder.Entity<Shared>()
                   .HasOne(e => new { e.OwnerUser, e.SharedUser, FF })
                   .WithOne()
                    .HasForeignKey<Users>(e => e.ID)
                    .HasForeignKey<FF>(e => e.FFID) ;

                        modelBuilder.Entity<Shared>()
            .HasMany(e => e.FFs)
            .WithOne();
            */







            /*    
                 public int OwnerID { get; set; }
        public int SharedToID { get; set; }
        public int Status { get; set; }
        public int FFID { get; set; }
        public int ParantID { get; set; }
                 public Users OwnerUser { get; set; }
                    public Users SharedUser { get; set; }

                    public FF Parant { get; set; }

                    public ICollection<FF> FFs { get; set; }*/



            /*        modelBuilder.Entity<Shared>()

                  .HasKey(pc => new { pc.OwnerID, pc.SharedToID, pc.FFID,pc.ParantID });

                    modelBuilder.Entity<Shared>()
                       .HasOne(pc => pc.OwnerUser);
                    modelBuilder.Entity<Shared>()
                 .HasOne(pc => pc.SharedUser);

                    modelBuilder.Entity<Shared>()
                 .HasOne(pc => pc.Parant);

                    modelBuilder.Entity<Shared>()
                  .HasMany(pc => pc.FFs);*//*

        }
*/

    }
}
