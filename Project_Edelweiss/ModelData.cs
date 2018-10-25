using System.Linq;
using Edelweiss.DAL.EF;
using Edelweiss.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace Project_Edelweiss
{
    public class ModelData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            //if (!context.Users.Any())
            //{
            //    context.Users.AddRange
            //    (
            //        new User() { Email = "1@mail.com", PasswordHash = "asd"}
            //    );
            //}


            if (!context.Countries.Any())
            {
                context.Countries.AddRange
                (

                    new Country() { Name = "Кыргызстан", Utc = 6},
                    new Country() { Name = "Россия", Utc = 3 },
                    new Country() { Name = "США", Utc = -8 }

                );
                context.SaveChanges();
            }

            if (!context.Roles.Any())
            {
                context.Roles.AddRange
                (
                    new IdentityRole() { Name = "Admin", NormalizedName = "ADMIN" },
                    new IdentityRole() { Name = "Agent", NormalizedName = "AGENT" },
                    new IdentityRole() { Name = "Cashier", NormalizedName = "CASHIER" },
                    new IdentityRole() { Name = "Controller", NormalizedName = "CONTROLLER" },
                    new IdentityRole() { Name = "ControllerExtended", NormalizedName = "CONTROLLEREXTENDED" },
                    new IdentityRole() { Name = "NeedChangePassword", NormalizedName = "NEEDCHANGEPASSWORD" }
                    
                );
                context.SaveChanges();
            }


            if (!context.Agents.Any())
            {
                context.Agents.AddRange
                    (
                        
                        new Agent() { Name = "System", CountryId = context.Countries.FirstOrDefault(c => c.Name == "Кыргызстан").Id},
                        new Agent() { Name = "Optima", CountryId = context.Countries.FirstOrDefault(c => c.Name == "Кыргызстан").Id, ImageLogo = $"images/Агент 1/Агент 1.jpg" },
                        new Agent() { Name = "Demir Bank", CountryId = context.Countries.FirstOrDefault(c => c.Name == "Кыргызстан").Id },
                        new Agent() { Name = "KICB", CountryId = context.Countries.FirstOrDefault(c => c.Name == "Кыргызстан").Id, ImageLogo = $"images/KICB/kicb-logo.png" },
                        new Agent() { Name = "ЦБ РФ", CountryId = context.Countries.FirstOrDefault(c => c.Name == "Россия").Id },
                        new Agent() { Name = "Optima-Osh", CountryId = context.Countries.FirstOrDefault(c => c.Name == "Кыргызстан").Id },
                        new Agent() { Name = "Demir Bank - Osh", CountryId = context.Countries.FirstOrDefault(c => c.Name == "Кыргызстан").Id},
                        new Agent() { Name = "KICB - Osh", CountryId = context.Countries.FirstOrDefault(c => c.Name == "Кыргызстан").Id, ImageLogo = $"images/KICB/kicb-logo.png" },
                        new Agent() { Name = "Capital", CountryId = context.Countries.FirstOrDefault(c => c.Name == "Россия").Id },
                        new Agent() { Name = "VTB", CountryId = context.Countries.FirstOrDefault(c => c.Name == "Россия").Id },
                        new Agent() { Name = "BankOfMoscow", CountryId = context.Countries.FirstOrDefault(c => c.Name == "Россия").Id },
                        new Agent() { Name = "GP Morgan", CountryId = context.Countries.FirstOrDefault(c => c.Name == "США").Id }

                    );
                context.SaveChanges();
            }

            if (!context.Clients.Any())
            {
                context.Clients.AddRange
                    (
                        new Client() {Name = "Клиент 1", LastName = "Test", PassportData = "AN1882831", MobilePhone = "123456789"},
                        new Client() { Name = "Клиент 2" },
                        new Client() { Name = "Клиент 3" }
                    );
                context.SaveChanges();
            }

            if (!context.Currencies.Any())
            {
                context.Currencies.AddRange
                (
                    new Currency() { Name = "USD" },
                    new Currency() { Name = "KGS" },
                    new Currency() { Name = "RUB" },
                    new Currency() { Name = "EUR" },
                    new Currency() { Name = "KZT" }
                );
                context.SaveChanges();
            }

            if (!context.Ranges.Any())
            {
                context.Ranges.AddRange
                (
                    new Range() { MinValue = 0.01m,  MaxValue = 1000 },
                    new Range() { MinValue = 1000.01m, MaxValue = 10000 },
                    new Range() { MinValue = 10000.01m, MaxValue = 150000 }
                );
                context.SaveChanges();
            }

        }
    }
}
