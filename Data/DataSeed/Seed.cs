using Core.Models.General;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DataSeed
{
    public class Seed
    {
        public static async Task SeedBanks(AppDbContext dbContext)
        {
            if (await dbContext.Banks.AnyAsync())
            {
                return;
            }

            var banks = new List<Bank>()
            {
                new Bank()
                {
                    ArabicName = "City Bank",
                    EnglishName = "CityBank",
                    Code = "CityBank_Code",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Bank()
                {
                    ArabicName = "HSBC",
                    EnglishName = "HSBC",
                    Code = "HSBC_Code",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Bank()
                {
                    ArabicName = "QNB",
                    EnglishName = "QNB",
                    Code = "QNB_Code",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                }
            };

            dbContext.Banks.AddRange(banks);
            dbContext.SaveChanges();
        }
    }
}
