using Conveyor.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Conveyor.DataAccess.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BeltType>()
                .HasMany(x => x.ConveyorBelts)
                .WithOne(x => x.BeltType);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

        public static void Initialize(CustomDbContext dbContext)
        {
            if (!dbContext.Sews.Any())
            {
                dbContext.Sews.Add(new Sew { Power = 0.09, Cost = 219 });
                dbContext.Sews.Add(new Sew { Power = 0.18, Cost = 250 });
                dbContext.Sews.Add(new Sew { Power = 0.25, Cost = 238 });
                dbContext.Sews.Add(new Sew { Power = 0.25, Cost = 280 });
                dbContext.Sews.Add(new Sew { Power = 0.37, Cost = 358 });
                dbContext.Sews.Add(new Sew { Power = 0.37, Cost = 527 });
                dbContext.Sews.Add(new Sew { Power = 0.37, Cost = 330 });
                dbContext.Sews.Add(new Sew { Power = 0.37, Cost = 398 });
                dbContext.Sews.Add(new Sew { Power = 0.37, Cost = 464 });
                dbContext.Sews.Add(new Sew { Power = 0.37, Cost = 495 });
                dbContext.Sews.Add(new Sew { Power = 0.55, Cost = 486 });
                dbContext.Sews.Add(new Sew { Power = 0.55, Cost = 655 });
                dbContext.Sews.Add(new Sew { Power = 0.55, Cost = 815 });
                dbContext.Sews.Add(new Sew { Power = 0.75, Cost = 842 });
                dbContext.Sews.Add(new Sew { Power = 1.5, Cost = 690 });
                dbContext.Sews.Add(new Sew { Power = 1.5, Cost = 1050 });
                dbContext.Sews.Add(new Sew { Power = 2.2, Cost = 1110 });
                dbContext.Sews.Add(new Sew { Power = 2.2, Cost = 1655 });
                dbContext.Sews.Add(new Sew { Power = 2.2, Cost = 1708 });
            }

            if (!dbContext.Motovarios.Any())
            {
                dbContext.Motovarios.Add(new Motovario { Power = 0.12, Cost = 115 });
                dbContext.Motovarios.Add(new Motovario { Power = 0.18, Cost = 107 });
                dbContext.Motovarios.Add(new Motovario { Power = 0.18, Cost = 120 });
                dbContext.Motovarios.Add(new Motovario { Power = 0.25, Cost = 130 });
                dbContext.Motovarios.Add(new Motovario { Power = 0.37, Cost = 160 });
                dbContext.Motovarios.Add(new Motovario { Power = 0.37, Cost = 160 });
                dbContext.Motovarios.Add(new Motovario { Power = 0.55, Cost = 270 });
                dbContext.Motovarios.Add(new Motovario { Power = 1.1, Cost = 300 });
                dbContext.Motovarios.Add(new Motovario { Power = 2.2, Cost = 720 });
            }

            if (!dbContext.MetallCostings.Any())
            {
                dbContext.MetallCostings.Add(new MetallCosting { Name = "Конструкционная сталь", Cost = 2 });
                dbContext.MetallCostings.Add(new MetallCosting { Name = "Нержавеющая сталь", Cost = 7 });
            }

            if (!dbContext.ConveyorBelts.Any())
            {
                dbContext.ConveyorBelts.Add(new ConveyorBelt { Name = "Ammearaal Beltech ES 5.2 White", Cost = 240, BeltType = new BeltType { Type = "Пищевая" } });
                dbContext.ConveyorBelts.Add(new ConveyorBelt { Name = "Ammearaal Beltech Grey", Cost = 240, BeltType = new BeltType { Type = "Не пищевая" } });
            }

            if (!dbContext.Users.Any())
            {
                dbContext.Users.Add(new User { Email = "admin@gmail.com", Password = "25D55AD283AA400AF464C76D713C07AD" });
            }

            dbContext.SaveChanges();
        }

    }
}
