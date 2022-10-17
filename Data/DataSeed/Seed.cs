using Core.Models.EmployeesInfo;
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
                    ArabicName = "البنك السعودي الهولندي",
                    EnglishName = "SAUDI HOLLANDI BANK",
                    Code = "AAALSARIXXX",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Bank()
                {
                    ArabicName = "بنك البلاد",
                    EnglishName = "BANK AL BILAD",
                    Code = "ALBIXXXXXXX",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Bank()
                {
                    ArabicName = "البنك العربي الوطني",
                    EnglishName = "ARAB NATIONAL BANK",
                    Code = "ARNBSARIXXX",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Bank()
                {
                    ArabicName = "بنك الجزيرة",
                    EnglishName = "BANK AL-JAZIRA",
                    Code = "BJAZSAJEXXX",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Bank()
                {
                    ArabicName = "البنك السعودي الفرنسي",
                    EnglishName = "AL BANK AL SAUDI AL FRANSI",
                    Code = "BSFRSARIXXX",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Bank()
                {
                    ArabicName = "بنك الانما",
                    EnglishName = "BANK AL INMA",
                    Code = "INMASARIXXX",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Bank()
                {
                    ArabicName = "البنك الأهلي التجاري",
                    EnglishName = "NATIONAL COMMERCIAL BANK",
                    Code = "NCBKSAJEXXX",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Bank()
                {
                    ArabicName = "بنك الرياض",
                    EnglishName = "RIYAD BANK",
                    Code = "RIBLSARIXXX",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Bank()
                {
                    ArabicName = "بنك الراجحي",
                    EnglishName = "AL RAJHI BANKING & INVESTMENT CORP.",
                    Code = "RJHISARIXXX",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                }
            };

            dbContext.Banks.AddRange(banks);
            dbContext.SaveChanges();
        }
        public static async Task SeedNationality(AppDbContext dbContext)
        {
            if (await dbContext.Nationalities.AnyAsync())
            {
                return;
            }

            var nationalities = new List<Nationality>()
            {
                new Nationality()
                {
                    ArabicName = "استراليا",
                    EnglishName= "AUSTRALIA",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Nationality()
                {
                    ArabicName = "بريطانيا",
                    EnglishName= "BRITAIN",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Nationality()
                {
                    ArabicName = "كندا",
                    EnglishName= "CANADA",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Nationality()
                {
                    ArabicName = "مصر",
                    EnglishName= "EGYPT",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Nationality()
                {
                    ArabicName = "اثيوبيا",
                    EnglishName= "ETHIOPIA",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Nationality()
                {
                    ArabicName = "فرنسا",
                    EnglishName= "FRANCE",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Nationality()
                {
                    ArabicName = "مصر",
                    EnglishName= "EGYPT",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                }
            };
        }
    }
}
