using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BelInt_WebHelper.Models;
using Microsoft.AspNetCore.Identity;

namespace BelInt_WebHelper.Data
{
    public class DbInitializer
    {
        public void SeedUsers(ModelBuilder builder)
        {
            var user1 = new User()
            {
                Id = "only1superman",
                SurName = "Иванов",
                FirstName = "Иван",
                LastName = "Иванович",
                UserName = "Admin",
                NormalizedUserName = "Admin".ToUpper(),
                Email = "admin@belint.gomel.by",
                NormalizedEmail = "admin@belint.gomel.by".ToUpper(),
                LockoutEnabled = false,
                DateOfBirth = DateTime.Parse("01.01.1970"),
                DepartmentId = 1
            };
            var user2 = new User()
            {
                Id = "first-finance-man",
                SurName = "Запечкина",
                FirstName = "Зинаида",
                LastName = "Зиждивна",
                UserName = "FinanceGirl",
                NormalizedUserName = "FinanceGirl".ToUpper(),
                Email = "finance1@belint.gomel.by",
                NormalizedEmail = "finance1@belint.gomel.by".ToUpper(),
                LockoutEnabled = false,
                DateOfBirth = DateTime.Parse("01.01.1970"),
                DepartmentId = 2
            };
            var user3 = new User()
            {
                Id = "first-intarmed-man",
                SurName = "Героический",
                FirstName = "Георгий",
                LastName = "ГейОргиевич",
                UserName = "RainbowMan",
                NormalizedUserName = "RainbowMan".ToUpper(),
                Email = "gacha-macho@belint.gomel.by",
                NormalizedEmail = "gacha-macho@belint.gomel.by".ToUpper(),
                LockoutEnabled = false,
                DateOfBirth = DateTime.Parse("29.02.2000"),
                DepartmentId = 3
            };
            var user4 = new User()
            {
                Id = "first-contract-man",
                SurName = "Крестов",
                FirstName = "Константин",
                LastName = "Вольфович",
                UserName = "GreatHeal",
                NormalizedUserName = "GreatHeal".ToUpper(),
                Email = "contract-depart@belint.gomel.by",
                NormalizedEmail = "contract-depart@belint.gomel.by".ToUpper(),
                LockoutEnabled = false,
                DateOfBirth = DateTime.Parse("23.11.1975"),
                DepartmentId = 4
            };


            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            user1.PasswordHash = passwordHasher.HashPassword(user1, "AdminBelint123");
            user2.PasswordHash = passwordHasher.HashPassword(user2, "FinanceBelint123");
            user3.PasswordHash = passwordHasher.HashPassword(user3, "FinanceBelint123");
            user4.PasswordHash = passwordHasher.HashPassword(user4, "FinanceBelint123");

            builder.Entity<User>().HasData(user1, user2, user3, user4);
        }

        public void SeedDepartments(ModelBuilder builder)
        {
            builder.Entity<Department>().HasData(
                new Department() { Id = 1, Name = "Не указано", OrganisationId = 1 },
                new Department() { Id = 2, Name = "Бухгалтерия", OrganisationId = 1 },
                new Department() { Id = 3, Name = "Отдел тарифов и организации международных перевозок", OrganisationId = 1 },
                new Department() { Id = 4, Name = "Отдел исполнения договоров", OrganisationId = 1 }
             );
        }
        public void SeedOrganisations(ModelBuilder builder)
        {
            builder.Entity<Organisation>().HasData(
                new Organisation() { Id = 1, Name = "BelInterTrans", NormalizedName = "Белинтертранс" }
             );
        }
        public void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "only1superrole", Name = "Admin", NormalizedName = "Администратор" },
                new IdentityRole() { Id = "finance-man-role", Name = "Accountant", NormalizedName = "Бухгалтерия" },
                new IdentityRole() { Id = "serios-boss-mad", Name = "Depart-Lead", NormalizedName = "Начальник отделения" },
                new IdentityRole() { Id = "diff-user-in-this-heaven", Name = "User", NormalizedName = "Работник филиала" }
                );
        }

        public void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "only1superrole", UserId = "only1superman" },
                new IdentityUserRole<string>() { RoleId = "finance-man-role", UserId = "only1superman" },
                new IdentityUserRole<string>() { RoleId = "serios-boss-mad", UserId = "only1superman" },
                new IdentityUserRole<string>() { RoleId = "diff-user-in-this-heaven", UserId = "only1superman" },

                new IdentityUserRole<string>() { RoleId = "finance-man-role", UserId = "first-finance-man" },

                new IdentityUserRole<string>() { RoleId = "serios-boss-mad", UserId = "first-intarmed-man" },

                new IdentityUserRole<string>() { RoleId = "diff-user-in-this-heaven", UserId = "first-contract-man" }
                );
        }
    }
}
