using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BelInt_WebHelper.Models;
using Microsoft.AspNetCore.Identity;

namespace BelInt_WebHelper
{
    public class BelIntDbContext : IdentityDbContext<Models.User>
    {
        public BelIntDbContext(DbContextOptions<BelIntDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.SeedUsers(builder);
            this.SeedUserRoles(builder);
        }
        private void SeedUsers(ModelBuilder builder)
        {
            var user1 = new User()
            {
                Id = "only1superman",
                SurName = "Иванов",
                FirstName = "Иван",
                LastName = "Иванович",
                UserName = "Admin",
                Email = "admin@belint.gomel.by",
                LockoutEnabled = false,
                DateOfBirth = DateTime.Parse("01.01.1970"),
                Department = new Department()
                {
                    Name = "Не указано",
                },
            };
            var user2 = new User()
            {
                Id = "first-finance-man",
                SurName = "Запечкина",
                FirstName = "Зинаида",
                LastName = "Зиждивна",
                UserName = "FinanceGirl",
                Email = "finance1@belint.gomel.by",
                LockoutEnabled = false,
                DateOfBirth = DateTime.Parse("01.01.1970"),
                Department = new Department()
                {
                    Name = "Бухгалтерия",
                },
            };
            var user3 = new User()
            {
                Id = "first-intarmed-man",
                SurName = "Героический",
                FirstName = "Георгий",
                LastName = "ГейОргиевич",
                UserName = "RainbowMan",
                Email = "gacha-macho@belint.gomel.by",
                LockoutEnabled = false,
                DateOfBirth = DateTime.Parse("29.02.2000"),
                Department = new Department()
                {
                    Name = "Отдел тарифов и организации международных перевозок",
                },
            };
            var user4 = new User()
            {
                Id = "first-contract-man",
                SurName = "Крестов",
                FirstName = "Константин",
                LastName = "Вольфович",
                UserName = "GreatHeal",
                Email = "contract-depart@belint.gomel.by",
                LockoutEnabled = false,
                DateOfBirth = DateTime.Parse("23.11.1975"),
                Department = new Department()
                {
                    Name = "отдел исполнения договоров",
                },
            };


            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            passwordHasher.HashPassword(user1, "AdminBelint123");
            passwordHasher.HashPassword(user2, "FinanceBelint123");
            passwordHasher.HashPassword(user3, "FinanceBelint123");
            passwordHasher.HashPassword(user4, "FinanceBelint123");

            builder.Entity<User>().HasData(user1);
            builder.Entity<User>().HasData(user2);
            builder.Entity<User>().HasData(user3);
            builder.Entity<User>().HasData(user4);
        }

        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "only1superrole", Name = "Admin", NormalizedName = "Администратор" },
                new IdentityRole() { Id = "finance-man-role", Name = "Accountant", NormalizedName = "Бухгалтерия" },
                new IdentityRole() { Id = "serios-boss-mad", Name = "Depart-Lead", NormalizedName = "Начальник отделения" },
                new IdentityRole() { Id = "diff-user-in-this-heaven", Name = "User", NormalizedName = "Работник филиала" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "only1superrole", UserId = "only1superuser" },
                new IdentityUserRole<string>() { RoleId = "finance-man-role", UserId = "only1superuser" },
                new IdentityUserRole<string>() { RoleId = "serios-boss-mad", UserId = "only1superuser" },
                new IdentityUserRole<string>() { RoleId = "diff-user-in-this-heaven", UserId = "only1superuser" },

                new IdentityUserRole<string>() { RoleId = "finance-man-role", UserId = "first-finance-man" },

                new IdentityUserRole<string>() { RoleId = "serios-boss-mad", UserId = "first-intarmed-man" },

                new IdentityUserRole<string>() { RoleId = "diff-user-in-this-heaven", UserId = "first-contract-man" }
                );
        }
    }
}
