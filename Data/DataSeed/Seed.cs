using Core.Models.EmployeesInfo;
using Core.Models.Financial;
using Core.Models.General;
using Core.Models.Jobs;
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

            dbContext.Nationalities.AddRange(nationalities);
            dbContext.SaveChanges();
        }

        public static async Task SeedGrades(AppDbContext dbContext)
        {
            if (await dbContext.Grades.AnyAsync())
            {
                return;
            }

            var grades = new List<Grade>()
            {
                new Grade()
                {
                    Name = "المرتبة الأولى",
                    GradeNumber = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Grade()
                {
                    Name = "المرتبة الثانية",
                    GradeNumber = 2,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Grade()
                {
                    Name = "المرتبة الثالثة",
                    GradeNumber = 3,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Grade()
                {
                    Name = "المرتبة الرابعة",
                    GradeNumber = 4,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Grade()
                {
                    Name = "المرتبة الخامسة",
                    GradeNumber = 5,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Grade()
                {
                    Name = "المرتبة السادسة",
                    GradeNumber = 6,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Grade()
                {
                    Name = "المرتبة السابعة",
                    GradeNumber = 7,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Grade()
                {
                    Name = "المرتبة الثامنة",
                    GradeNumber = 8,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Grade()
                {
                    Name = "المرتبة التاسعة",
                    GradeNumber = 9,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Grade()
                {
                    Name = "المرتبة العاشرة",
                    GradeNumber = 10,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Grade()
                {
                    Name = "المرتبة الحادية عشر",
                    GradeNumber = 11,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Grade()
                {
                    Name = "المرتبة الثانية عشر",
                    GradeNumber = 12,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Grade()
                {
                    Name = "المرتبة الثالثة عشر",
                    GradeNumber = 13,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Grade()
                {
                    Name = "المرتبة الرابعة عشر",
                    GradeNumber = 14,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Grade()
                {
                    Name = "المرتبة الخامسة عشر",
                    GradeNumber = 15,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                }
            };

            dbContext.Grades.AddRange(grades);
            dbContext.SaveChanges();
        }
        public static async Task SeedLevels(AppDbContext dbContext)
        {
            if (await dbContext.Levels.AnyAsync())
            {
                return;
            }

            var leveles = new List<Level>()
            {
                new Level()
                {
                    Name = "الدرجة الأولى",
                    LevelNumber = 1,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Level()
                {
                    Name = "الدرجة الثانية",
                    LevelNumber = 2,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Level()
                {
                    Name = "الدرجة الثالثة",
                    LevelNumber = 3,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Level()
                {
                    Name = "الدرجة الرابعة",
                    LevelNumber = 4,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Level()
                {
                    Name = "الدرجة الخامسة",
                    LevelNumber = 5,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Level()
                {
                    Name = "الدرجة السادسة",
                    LevelNumber = 6,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Level()
                {
                    Name = "الدرجة السابعة",
                    LevelNumber = 7,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Level()
                {
                    Name = "الدرجة الثامنة",
                    LevelNumber = 8,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Level()
                {
                    Name = "الدرجة التاسعة",
                    LevelNumber = 9,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Level()
                {
                    Name = "الدرجة العاشرة",
                    LevelNumber = 10,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Level()
                {
                    Name = "الدرجة الحادية عشر",
                    LevelNumber = 11,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Level()
                {
                    Name = "الدرجة الثانية عشر",
                    LevelNumber = 12,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Level()
                {
                    Name = "الدرجة الثالثة عشر",
                    LevelNumber = 13,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Level()
                {
                    Name = "الدرجة الرابعة عشر",
                    LevelNumber = 14,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Level()
                {
                    Name = "الدرجة الخامسة عشر",
                    LevelNumber = 15,
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                }
            };

            dbContext.Levels.AddRange(leveles);
            dbContext.SaveChanges();
        }

        public static async Task SeedJobVisa(AppDbContext dbContext)
        {
            if (await dbContext.JobVisas.AnyAsync())
            {
                return;
            }

            var jobVisas = new List<JobVisa>()
            {
                new JobVisa()
                {
                    Name = "مهندس معماري",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new JobVisa()
                {
                    Name = "مهندس ميكانيكا",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new JobVisa()
                {
                    Name = "مطور برمجيات",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new JobVisa()
                {
                    Name = "محاسب",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new JobVisa()
                {
                    Name = "فني مختبر",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new JobVisa()
                {
                    Name = "طبيب عام",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new JobVisa()
                {
                    Name = "سائق شاحنة",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                }
            };

            dbContext.JobVisas.AddRange(jobVisas);
            dbContext.SaveChanges();
        }
        public static async Task SeedQualifications(AppDbContext dbContext)
        {
            if (await dbContext.Qualifications.AnyAsync())
            {
                return;
            }

            var qualifications = new List<Qualification>()
            {
                new Qualification()
                {
                    Name = "مهندس معماري",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Qualification()
                {
                    Name = "مهندس ميكانيكا",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Qualification()
                {
                    Name = "مطور برمجيات",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Qualification()
                {
                    Name = "محاسب",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Qualification()
                {
                    Name = "فني مختبر",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Qualification()
                {
                    Name = "طبيب عام",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                },
                new Qualification()
                {
                    Name = "سائق شاحنة",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration"
                }
            };

            dbContext.Qualifications.AddRange(qualifications);
            dbContext.SaveChanges();
        }

        public static async Task SeedJobGroupAndSubGroups(AppDbContext dbContext)
        {
            if (await dbContext.JobGroups.AnyAsync())
            {
                return;
            }

            var jobGroups = new List<JobGroup>()
            {
                new JobGroup()
                {
                    ArabicName = "التخصصية",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    JobSubGroups = new List<JobSubGroup>()
                    {
                        new JobSubGroup()
                        {
                            ArabicName = "الاشرافية على الاعمال التخصصية",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "المهندسين",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الخبراء والمستشارين",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الاعمال القانونية",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الجودة والنوعية",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "التنظيم والتخطيط",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        }
                    }
                },
                new JobGroup()
                {
                    ArabicName = "الطبية والصحية",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    JobSubGroups = new List<JobSubGroup>()
                    {
                        new JobSubGroup()
                        {
                            ArabicName = "الطب البشري وطب الاسنان",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الطب البيطري",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "أخصائيي الخدمات الطبية والصحية",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الصيادلة",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "المراقبة الصيحة",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "التمريض",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        }
                    }
                },
                new JobGroup()
                {
                    ArabicName = "الإدارية والمالية",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    JobSubGroups = new List<JobSubGroup>()
                    {
                        new JobSubGroup()
                        {
                            ArabicName = "الاشرافية على الاعمال الادارية والمالية",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "مراقبي المواقع",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "مراقبين الاسكان",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "إدارة شئون المتعاقدين",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "المساعدون الاداريون",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "المحاسبة والتدقيق",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "مدققين العقود",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الميزانية",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "التخزين والمستودعات",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "مراقبي العهد",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "المشتريات",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "التأمين",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الاحصاء",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        }
                    }
                },
                new JobGroup()
                {
                    ArabicName = "الإدارية المعاونة",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    JobSubGroups = new List<JobSubGroup>()
                    {
                        new JobSubGroup()
                        {
                            ArabicName = "الاشرافية على الادارية المعاونة",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "قارئ العدادات",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "النسخ والطباعة",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "مأموري الارشيف والوثائق",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الخدمات الادارية المساندة",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الكتابية",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "السكرتارية ومديري المكاتب",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الترجمة",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        }
                    }
                },
                new JobGroup()
                {
                    ArabicName = "العمال والمستخدمين",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    JobSubGroups = new List<JobSubGroup>()
                    {
                        new JobSubGroup()
                        {
                            ArabicName = "العمال",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الحراس",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "المراسلين",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "السائقين",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "القهوجيه",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        }
                    }
                },
                new JobGroup()
                {
                    ArabicName = "الاجتماعية والثقافية والإعلامية",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    JobSubGroups = new List<JobSubGroup>()
                    {
                        new JobSubGroup()
                        {
                            ArabicName = "الاخصائيين والاجتماعيين",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الاخصائيين النفسيين",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "العلاقات العامة",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الاخراج الاعلامي",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "التصوير التلفزيوني والفوتوغرافي",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الخط والرسم",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "أمناء المكتبات",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الطبع والتحميض",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "التصحيح اللغوي والاوفست",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        }
                    }
                },
                new JobGroup()
                {
                    ArabicName = "التعليمة والدينية",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    JobSubGroups = new List<JobSubGroup>()
                    {
                        new JobSubGroup()
                        {
                            ArabicName = "التعليم",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "التدريب",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الشئون الدينية",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الرياضية",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        }
                    }
                },
                new JobGroup()
                {
                    ArabicName = "الحرفية",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    JobSubGroups = new List<JobSubGroup>()
                    {
                        new JobSubGroup()
                        {
                            ArabicName = "الاشرافية على الحرفية",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "السباكين",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "النجارين",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الحدادين",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "البناء",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "التبليط",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "التلييس",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الدهانين",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الزجاج",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الحلاقة",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "اللحام",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "التنجيد",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الخبازين",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الطهي ومقدمي الطعام",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "مصلحي المفاتيح والاقفال",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "السمكرة ودهان العربات",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "مصلحي الاطارات وغيار الزيت",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الزاعيين",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "تدريب وراعية الحيوانات",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "منظفي وكوايي الملابس",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الخياطة والنسيج",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "العزل",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الجزارة",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الجبس والزخرفة",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "حدادة المباني",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        }
                    }
                },
                new JobGroup()
                {
                    ArabicName = "الفنية والفنية المساعدة",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    JobSubGroups = new List<JobSubGroup>()
                    {
                        new JobSubGroup()
                        {
                            ArabicName = "الاشرافية على الاعمال الفنية المساعدة",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "إعمال الميكانيكا",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الكهرباء",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الالكترونيات",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الاتصالات",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "المساحة",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الرسم المعماري",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "مراقبي أعمال الطرق",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "فنيي الزراعة",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "مشغلي المعدات والاليات",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "فنيي المطابع",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "صيانة الحاسب الالي",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "مكافحة الحشرات",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "فنيي الاسفلت",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "المختبرات الفنية",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "مراقبي الانشاءات",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                    }
                },
                new JobGroup()
                {
                    ArabicName = "العمليات",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    JobSubGroups = new List<JobSubGroup>()
                    {
                        new JobSubGroup()
                        {
                            ArabicName = "المبرمجون",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "تحليل النظم",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "مشغلي الحاسب الالي",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "فني شبكات الحاسب الالي",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "مدخلي البيانات",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "مأموري الاتصالات",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "البحرية والموانئ",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "المراقبة والرصد جوي",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الاطفاء والانقاذ",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "الامن والسلامة",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        },
                        new JobSubGroup()
                        {
                            ArabicName = "السلامة المهنية",
                            CreatedDate= DateTime.Now,
                            CreatedBy = "Migrations"
                        }
                    }
                }
            };

            dbContext.JobGroups.AddRange(jobGroups);
            dbContext.SaveChanges();
        }
        public static async Task SeedDepartmentAndBranchs(AppDbContext dbContext)
        {
            if (await dbContext.Departments.AnyAsync())
            {
                return;
            }

            var departments = new List<Department>()
            {
                new Department()
                {
                    ArabicName = "قسم الضيافات الملكية",
                    ShortArName = "قسم الضيافات الملكية",
                    EnglishName = "VIP VILLA",
                    ShortEnName = "VIP VILLA",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    Branches = new List<Branch>()
                    {
                        new Branch()
                        {
                            ArabicName = "كل الفروع",
                            ShortArName = "كل الفروع",
                            EnglishName = "ALL SECTIONS",
                            ShortEnName = "ALL SECTIONS",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الادارة",
                            ShortArName = "الادارة",
                            EnglishName = "ADMIN",
                            ShortEnName = "ADMIN",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        }
                    }
                },
                new Department()
                {
                    ArabicName = "مكتب مدير الادارة",
                    ShortArName = "مكتب مدير الادارة",
                    EnglishName = "DIRECTORS OFFICE",
                    ShortEnName = "DIR. OFFICE",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    Branches = new List<Branch>()
                    {
                        new Branch()
                        {
                            ArabicName = "مكتب الصادر والوارد",
                            ShortArName = "مكتب الصادر والوارد",
                            EnglishName = "INCOMING & OUTGOING",
                            ShortEnName = "INCOMING & OUTGOING",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "المطبعة",
                            ShortArName = "المطبعة",
                            EnglishName = "PRINT PLANT",
                            ShortEnName = "PRINT PL.",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "لجنة تأمين الاحتياجات",
                            ShortArName = "تأمين الاحتياجات",
                            EnglishName = "PROCUREMENT COMMITTEE",
                            ShortEnName = "PROC. COMM.",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الفرع المالي",
                            ShortArName = "الفرع المالي",
                            EnglishName = "FINANCE",
                            ShortEnName = "FINANCE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "كل الفروع",
                            ShortArName = "كل الفروع",
                            EnglishName = "ALL SECTIONS",
                            ShortEnName = "ALL SECTIONS",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "العقـــــود",
                            ShortArName = "العقـــــود",
                            EnglishName = "CONTRACTS",
                            ShortEnName = "CONTRACTS",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مكتب المدير - المتابعة الادارية",
                            ShortArName = "المتابعة -1",
                            EnglishName = "DIRECTOR'S OFFICE.",
                            ShortEnName = "DIRECTOR'S OFFICE.",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "المتابعة -2",
                            ShortArName = "المتابعة -2",
                            EnglishName = "FOLLOW UP-2",
                            ShortEnName = "FOLLOW UP-2",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "فرع العلاقات العامه",
                            ShortArName = "فرع العلاقات العامه",
                            EnglishName = "GENERAL RELATIONS SECTION",
                            ShortEnName = "GENERAL RELATION",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الشؤون القانونية",
                            ShortArName = "أكاديمية الباطن",
                            EnglishName = "LAWYERS OFFICE",
                            ShortEnName = "LAWYERS OFFICE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مكتب الخطابات السرية",
                            ShortArName = "مكتب الخطابات السرية",
                            EnglishName = "CONFIDENTIAL OFFICE",
                            ShortEnName = "CONFIDENTIAL OFFICE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مكتب الادارة",
                            ShortArName = "مكتب الادارة",
                            EnglishName = "DIRECTORS ADMINT. OFFICE",
                            ShortEnName = "ADMIN. OFFICE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مكتب مساعد المدير",
                            ShortArName = "مكتب مساعد المدير",
                            EnglishName = "OFFICE, ASST. DIRECTOR",
                            ShortEnName = "OFFICE, ASST. DIRECTOR",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مكتب المدير",
                            ShortArName = "مكتب المدير",
                            EnglishName = "DIRECTOR'S OFFICE",
                            ShortEnName = "DIRECTOR'S OFFICE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        }
                    }
                },
                new Department()
                {
                    ArabicName = "قسم الشؤون الدينية",
                    ShortArName = "لجنة الاحتياجات",
                    EnglishName = "RELIGIOUS AFFAIRS",
                    ShortEnName = "PROCUREMENT",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    Branches = new List<Branch>()
                    {
                        new Branch()
                        {
                            ArabicName = "الادارية",
                            ShortArName = "الادارية",
                            EnglishName = "ADMIN",
                            ShortEnName = "DIR. OFFICE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "كل الفروع",
                            ShortArName = "كل الفروع",
                            EnglishName = "ALL SECTIONS",
                            ShortEnName = "ALL SECTIONS",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        }
                    }
                },
                new Department()
                {
                    ArabicName = "قسم المتابعة ومراقبة الجودة",
                    ShortArName = "الجودة النوعية",
                    EnglishName = "QUALITY ASSURANCE",
                    ShortEnName = "QUALITY ASSURANCE",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    Branches = new List<Branch>()
                    {
                        new Branch()
                        {
                            ArabicName = "الادارية",
                            ShortArName = "الادارية",
                            EnglishName = "ADMINISTRATION",
                            ShortEnName = "ADMIN",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "كل الفروع",
                            ShortArName = "كل الفروع",
                            EnglishName = "ALL SECTIONS",
                            ShortEnName = "ALL SECTIONS",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مراقبه الجودة",
                            ShortArName = "مراقبه الجودة",
                            EnglishName = "QUALITY ASSUARANCE",
                            ShortEnName = "QUALITY ASSUARANCE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "التخطيط والمتابعة",
                            ShortArName = "التخطيط والمتابعة",
                            EnglishName = "QUALITY ASSUARANCE",
                            ShortEnName = "QUALITY ASSUARANCE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "المراجعة الداخلية",
                            ShortArName = "المراجعة الداخلية",
                            EnglishName = "QUALITY ASSUARANCE",
                            ShortEnName = "QUALITY ASSUARANCE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        }
                    }
                },
                new Department()
                {
                    ArabicName = "قسم شؤون العاملين",
                    ShortArName = "شئون الموظفين",
                    EnglishName = "PERSONNEL",
                    ShortEnName = "PERSONNEL",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    Branches = new List<Branch>()
                    {
                        new Branch()
                        {
                            ArabicName = "المكتب الاداري بشئون الموظفين",
                            ShortArName = "المكتب الاداري",
                            EnglishName = "ADMIN",
                            ShortEnName = "ADMIN",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "كل الفروع",
                            ShortArName = "كل الفروع",
                            EnglishName = "ALL SECTIONS",
                            ShortEnName = "ALL SECTIONS",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        }
                    }
                },
                new Department()
                {
                    ArabicName = "قسم الاسكان والممتلكات",
                    ShortArName = "الاسكان",
                    EnglishName = "HOUSING",
                    ShortEnName = "HOUSING",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    Branches = new List<Branch>()
                    {
                        new Branch()
                        {
                            ArabicName = "المكتب الاداري بقسم الاسكان",
                            ShortArName = "المكتب الاداري",
                            EnglishName = "ADMIN",
                            ShortEnName = "ADMIN",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مراقبة المفاتيح بالاسكان",
                            ShortArName = "مراقبة المفاتيح",
                            EnglishName = "KEY CONTROL",
                            ShortEnName = "KEY CONTROL",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "التفتيش",
                            ShortArName = "التفتيش",
                            EnglishName = "INSPCTION",
                            ShortEnName = "INSPCTION",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "كل الفروع",
                            ShortArName = "كل الفروع",
                            EnglishName = "ALL SECTIONS",
                            ShortEnName = "ALL SECTIONS",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الممتلكات",
                            ShortArName = "الممتلكات",
                            EnglishName = "PROPERTY",
                            ShortEnName = "PROPERTY",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "ضيافة المكية كبار الشخصيات",
                            ShortArName = "ضيافة المكية كبار الشخصيات",
                            EnglishName = "VIP ALARTIWAYA",
                            ShortEnName = "VIP ALARTIWAYA",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        }
                    }
                },
                new Department()
                {
                    ArabicName = "قسم الخدمات العامة",
                    ShortArName = "الخدمات",
                    EnglishName = "GENERAL SERVICES",
                    ShortEnName = "SERV.",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    Branches = new List<Branch>()
                    {
                        new Branch()
                        {
                            ArabicName = "المكتب الاداري بالخدمات",
                            ShortArName = "المكتب الاداري",
                            EnglishName = "ADMIN",
                            ShortEnName = "ADMIN",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الترفيه",
                            ShortArName = "الترفيه",
                            EnglishName = "RECREATION",
                            ShortEnName = "RECREATION",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "النظافة",
                            ShortArName = "النظافة",
                            EnglishName = "CUSTODIAL",
                            ShortEnName = "CUSTODIAL",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "المغسلة",
                            ShortArName = "المغسلة",
                            EnglishName = "LAUNDRY",
                            ShortEnName = "LAUNDRY",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الصيانة",
                            ShortArName = "الصيانة",
                            EnglishName = "MAINTENANCE",
                            ShortEnName = "MAINTENANCE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "المشتل",
                            ShortArName = "المشتل",
                            EnglishName = "NURSERY",
                            ShortEnName = "NURSERY",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "خدمات الطعام",
                            ShortArName = "خدمات الطعام",
                            EnglishName = "CATERING",
                            ShortEnName = "CATERING",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "العيادة البيطرية",
                            ShortArName = "العيادة البيطرية",
                            EnglishName = "VETERNARY CLINIC",
                            ShortEnName = "VET. CLINIC",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "المكتبة",
                            ShortArName = "المكتبة",
                            EnglishName = "LIBRARY",
                            ShortEnName = "LIBRARY",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مشروع المزرعة",
                            ShortArName = "مشروع المزرعة",
                            EnglishName = "FARM PROJECT",
                            ShortEnName = "FARM PROJ.",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الاستقبال والمستودعات",
                            ShortArName = "الاستقبال والمستودعات",
                            EnglishName = "RECEPTION &STORE",
                            ShortEnName = "RECPT.& ST.",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "قسم البيئة",
                            ShortArName = "قسم البيئة",
                            EnglishName = "ENTOMOLOGY",
                            ShortEnName = "ENTOMOLOGY",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مشروع منتزه رأس مشعاب",
                            ShortArName = "مشروع منتزه",
                            EnglishName = "PARK PROJECT",
                            ShortEnName = "PARK PROJECT",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الضيافة / كبار الشخصيات",
                            ShortArName = "الضيافة / كبار الشخصيات",
                            EnglishName = "GUEST HOUSE/VIP",
                            ShortEnName = "GUEST HOUSE/VIP",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الخدمات / البقالة",
                            ShortArName = "الخدمات / البقالة",
                            EnglishName = "COMMISSARY",
                            ShortEnName = "COMMISSARY",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الزراعة",
                            ShortArName = "الزراعة",
                            EnglishName = "LANDSCAPING",
                            ShortEnName = "LANDSCAPING",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الخدمات / مكتب المعسكر",
                            ShortArName = "مكتب المعسكر",
                            EnglishName = "CAMP OFFICE",
                            ShortEnName = "CAMP OFFICE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "المتابعة",
                            ShortArName = "المتابعة",
                            EnglishName = "FOLLOW-UP",
                            ShortEnName = "FOLLOW-UP",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "التكييف الهوائي",
                            ShortArName = "التكييف الهوائي",
                            EnglishName = "AIR CONDITIONING & REFRIGERATION",
                            ShortEnName = "A/C & REF.",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الكهرباء",
                            ShortArName = "الكهرباء",
                            EnglishName = "ELECTRICAL",
                            ShortEnName = "ELECTRICAL",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "السباكة",
                            ShortArName = "السباكة",
                            EnglishName = "PLUMBING",
                            ShortEnName = "PLUMBING",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الادارية",
                            ShortArName = "الادارية",
                            EnglishName = "ADMIN",
                            ShortEnName = "DIR. OFFICE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الدهان",
                            ShortArName = "الدهان",
                            EnglishName = "PAINTING",
                            ShortEnName = "PAINTING",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الصيانة العامة",
                            ShortArName = "الصيانة العامة",
                            EnglishName = "G.M. SHOP",
                            ShortEnName = "G.M. SHOP",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "رأس مشعاب",
                            ShortArName = "رأس مشعاب",
                            EnglishName = "RAM PROJECT",
                            ShortEnName = "RAM PROJECT",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الري",
                            ShortArName = "الري",
                            EnglishName = "IRRIGATION",
                            ShortEnName = "IRRIGATION",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مكافحة الحشرات",
                            ShortArName = "مكافحة الحشرات",
                            EnglishName = "SANITATION",
                            ShortEnName = "SANITATION",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الخياطة",
                            ShortArName = "الخياطة",
                            EnglishName = "TAILOR SHOP",
                            ShortEnName = "TAILOR SHOP",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الحدادة",
                            ShortArName = "الحدادة",
                            EnglishName = "SHEET METAL",
                            ShortEnName = "SHT. METAL",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "لجنة مراقبة الأسواق",
                            ShortArName = "لجنة مراقبة الأسواق",
                            EnglishName = "MARKET PROCUREMENT",
                            ShortEnName = "MARKET PRUC.",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الضيافة الملكية بحفرالباطن",
                            ShortArName = "الضيافة الملكية",
                            EnglishName = "ROYAL VILLA HAFR",
                            ShortEnName = "ROYAL VILLA HAFR",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الخدمات / نادي الفروسية",
                            ShortArName = "الخدمات / نادي الفروسية",
                            EnglishName = "EQUESTRIAN CLUB",
                            ShortEnName = "EQ. CLUB",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "كل الفروع",
                            ShortArName = "كل الفروع",
                            EnglishName = "ALL SECTIONS",
                            ShortEnName = "ALL SECTIONS",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "النجارة",
                            ShortArName = "النجارة",
                            EnglishName = "CARPENTARY",
                            ShortEnName = "CARPENTARY",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "حديقة الانعام الجميله",
                            ShortArName = "حديقة الانعام الجميله",
                            EnglishName = "ZOO PROJECT",
                            ShortEnName = "ZOO PROJECT",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "خدمات سقيا المياه",
                            ShortArName = "سقيا المياه",
                            EnglishName = "WATER SERVICE",
                            ShortEnName = "WS",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        }
                    }
                },
                new Department()
                {
                    ArabicName = "قسم الضيافة العسكرية والنوادي",
                    ShortArName = "الخدمات العامة",
                    EnglishName = "OFFICERS CLUB",
                    ShortEnName = "GEN. SERV.",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    Branches = new List<Branch>()
                    {
                        new Branch()
                        {
                            ArabicName = "نادي الضباط / قسم الخدمات العامة",
                            ShortArName = "نادي الضباط",
                            EnglishName = "OFFICERS CLUB",
                            ShortEnName = "OFF. CLUB",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مكتب الادارة بالرياض /قسم الخدمات العامة",
                            ShortArName = "مكتب الادارة بالرياض",
                            EnglishName = "RIYADH VILLA",
                            ShortEnName = "RYD. VILLA",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الضيافة العسكرية",
                            ShortArName = "الضيافة العسكرية",
                            EnglishName = "MILITARY GUEST HOUSE",
                            ShortEnName = "MILT. GUEST. HOUSE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مدارس -1",
                            ShortArName = "مدارس -1",
                            EnglishName = "SCHOOL (A)",
                            ShortEnName = "SCHOOL (A)",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مدارس-2",
                            ShortArName = "مدارس-2",
                            EnglishName = "SCHOOL (B)",
                            ShortEnName = "SCHOOL (B)",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مدارس-4",
                            ShortArName = "مدارس-4",
                            EnglishName = "SCHOOL (D)",
                            ShortEnName = "SCHOOL (D)",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الشئون الدينية",
                            ShortArName = "الشئون الدينية",
                            EnglishName = "RELIGIOUS AFFAIRS",
                            ShortEnName = "RELIGIOUS AFFAIRS",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مكتب الادارة",
                            ShortArName = "مكتب الادارة",
                            EnglishName = "DIRECTORATE OFFICE",
                            ShortEnName = "DIRECTOR OFF.",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الضيافة",
                            ShortArName = "الضيافة",
                            EnglishName = "GUESTS HOUSE",
                            ShortEnName = "GUESTS HOUSE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "شئون الموظفين",
                            ShortArName = "شئون الموظفين",
                            EnglishName = "PERSONNEL",
                            ShortEnName = "PERSONNEL",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مكتب قائد المنطقة",
                            ShortArName = "مكتب قائد المنطقة",
                            EnglishName = "COMMANDER OFFICE",
                            ShortEnName = "COMMANDER OFF.",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الفرع المالى",
                            ShortArName = "الفرع المالى",
                            EnglishName = "FINANCE BRANCH",
                            ShortEnName = "FINANCE BRANCH",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "المالى",
                            ShortArName = "المالى",
                            EnglishName = "FINANCE",
                            ShortEnName = "FINANCE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "المركز الثقافي النسائي",
                            ShortArName = "نادي السيدات",
                            EnglishName = "LADIES CLUB",
                            ShortEnName = "LADIES CLUB",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "طيران الجيش",
                            ShortArName = "طيران الجيش",
                            EnglishName = "ARMY AVIATION",
                            ShortEnName = "ARMY AVIATION",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الإبتدائية الأولى بنات",
                            ShortArName = "الإبتدائية الأولى",
                            EnglishName = "1ST ELEMENTARY GIRLS SCHOOL",
                            ShortEnName = "1ST ELEMENTARY GIRLS SCHOOL",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الإبتدائية الرابعة بنات",
                            ShortArName = "الإبتدائية الرابعة",
                            EnglishName = "4TH ELEMENTARY GIRLS SCHOOL",
                            ShortEnName = "4TH ELEMENTARY GIRLS SCHOOL",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الإبتدائية الثالثة بنات",
                            ShortArName = "الإبتدائية الثالثة",
                            EnglishName = "3RD ELEMENTARY GIRLS SCHOOL",
                            ShortEnName = "3RD ELEMENTARY GIRLS SCHOOL",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الإبتدائية الثانية بنات",
                            ShortArName = "الإبتدائية الثانية",
                            EnglishName = "2ND ELEMENTARY GIRLS SCHOOL",
                            ShortEnName = "2ND ELEMENTARY GIRLS SCHOOL",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الروضة",
                            ShortArName = "الروضة",
                            EnglishName = "CHILD CARE",
                            ShortEnName = "CHILD CARE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الثقافة والتعليم",
                            ShortArName = "الثقافة والتعليم",
                            EnglishName = "CULTURAL AND EDUCATION",
                            ShortEnName = "CULTURAL AND EDUCATION",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "إدارة الإشراف الفني / الأشغال العسكرية",
                            ShortArName = "إدارة الإشراف الفني",
                            EnglishName = "TECHNICAL SUPERVISION",
                            ShortEnName = "TECH. SUP.",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "إدارة التشغيل والصيانة بالطائف",
                            ShortArName = "الصيانة بالطائف",
                            EnglishName = "O&M TAIF",
                            ShortEnName = "O&M TAIF",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "إدارة التشغيل والصيانة بالعيينة",
                            ShortArName = "الصيانة بالعيينة",
                            EnglishName = "O&M OYAINA",
                            ShortEnName = "O&M OYAINA",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "إدارة التشغيل والصيانة بالمنطقة الشرقية",
                            ShortArName = "بالمنطقة الدمام",
                            EnglishName = "O&M DAMMAM",
                            ShortEnName = "O&M DAMMAM",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "إدارة التشغيل والصيانة بالقصيم",
                            ShortArName = "الصيانة بالقصيم",
                            EnglishName = "O&M AL-GASEEM",
                            ShortEnName = "O&M AL-GASEEM",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "إدارة مدينة الملك فيصل الجنوبية",
                            ShortArName = "الملك فيصل الجنوبية",
                            EnglishName = "O&M KFMC SOUTH",
                            ShortEnName = "O&M KFMC SOUTH",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "ادارة التشغيل والصيانه بالمدينه المنوره",
                            ShortArName = "الصيانه بالمدينه",
                            EnglishName = "O&M AL- MADINA MUNAWWARA",
                            ShortEnName = "O&M AL- MADINA MUNAWWARA",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "ادارة التشغيل والصيانه بالخرج والسليل",
                            ShortArName = "الخرج والسليل",
                            EnglishName = "O&M  AL KHARJ & AL SULAEL",
                            ShortEnName = "O&M  AL KHARJ & AL SULAEL",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "إدارة مدينة الملك عبد العزيز بتبوك",
                            ShortArName = "تبوك",
                            EnglishName = "O&M  TABUK",
                            ShortEnName = "O&M  TABUK",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الشئون الدينية - إدارة المدينة",
                            ShortArName = "إدارة المدينة",
                            EnglishName = "RELIGIOUS AFFAIRS - O&M",
                            ShortEnName = "RELIGIOUS AFFAIRS - O&M",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "نادي الفروسية",
                            ShortArName = "نادي الفروسية",
                            EnglishName = "EQUESTRIAN CLUB",
                            ShortEnName = "EQUESTRIAN CLUB",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "معهد الأمير سلطان",
                            ShortArName = "معهد الأمير سلطان",
                            EnglishName = "PRINCE SULTAN INSTITUTE",
                            ShortEnName = "PRINCE SULTAN INSTITUTE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الضيافة الملكية بالارطاوية",
                            ShortArName = "الضيافة الملكية بالارطاوية",
                            EnglishName = "ROYAL VILLA ARTHAWIYA",
                            ShortEnName = "ROYAL VILLA ARTHAWIYA",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "ميادين الرماية /قسم الخدمات العامة",
                            ShortArName = "ميادين الرماية",
                            EnglishName = "FIRING RANGE",
                            ShortEnName = "FIRING RANGE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "كل الفروع",
                            ShortArName = "كل الفروع",
                            EnglishName = "ALL SECTIONS",
                            ShortEnName = "ALL SECTIONS",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مدارس -3",
                            ShortArName = "مدارس -3",
                            EnglishName = "SCHOOL(C)",
                            ShortEnName = "SCHOOL(C)",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مدارس-5",
                            ShortArName = "مدارس-5",
                            EnglishName = "SCHOOL (E)",
                            ShortEnName = "SCHOOL (E)",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الشئون الرياضية",
                            ShortArName = "الشئون الرياضية",
                            EnglishName = "SPORTS AFFAIRS",
                            ShortEnName = "SPORTS AFFAIRS",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الاشغال العسكرية",
                            ShortArName = "الاشغال العسكرية",
                            EnglishName = "MILITARY WORKS",
                            ShortEnName = "MILITARY WORKS",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الأسناد الهندسي",
                            ShortArName = "الأسناد الهندسي",
                            EnglishName = "ENGINEERING SUPPORT",
                            ShortEnName = "ENGINEERING SUPPORT",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مدرسة سلاح المهندسين",
                            ShortArName = "مدرسة سلاح المهندسين",
                            EnglishName = "ENGINEERING SCHOOL",
                            ShortEnName = "ENGINEERING SCHOOL",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "لجنة مراقبة الاسواق",
                            ShortArName = "لجنة مراقبة الاسواق",
                            EnglishName = "MARKET CONTROL",
                            ShortEnName = "MARKET CONTROL",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "إدارة مدينة الملك فهد العسكرية",
                            ShortArName = "مدينة الملك فهد",
                            EnglishName = "KFMC",
                            ShortEnName = "KFMC",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "إدارة الشئون الرياضية الرياض",
                            ShortArName = "الرياضية الرياض",
                            EnglishName = "SPORTS ADMIN - RIYADH",
                            ShortEnName = "SPORTS ADMIN - RIYADH",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "إدارة التشغيل والصيانة بجازان",
                            ShortArName = "الصيانة جازان",
                            EnglishName = "O&M JAZAN",
                            ShortEnName = "O&M JAZAN",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "إدارة التشغيل والصيانة بالرياض",
                            ShortArName = "الصيانة الرياض",
                            EnglishName = "O&M RIYADH",
                            ShortEnName = "O&M RIYADH",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        }
                    }
                },
                new Department()
                {
                    ArabicName = "قسم إدارة المواد",
                    ShortArName = "إدارة المواد",
                    EnglishName = "MATL MANAGEMENT",
                    ShortEnName = "MATL MANAGEMENT",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Migration",
                    Branches = new List<Branch>()
                    {
                        new Branch()
                        {
                            ArabicName = "المكتب الاداري بالتموين",
                            ShortArName = "المكتب الاداري",
                            EnglishName = "ADMIN",
                            ShortEnName = "ADMIN",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "طلبات المواد",
                            ShortArName = "طلبات المواد",
                            EnglishName = "MATL.REQUEST",
                            ShortEnName = "MATL.REQUEST",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مستودعات التموين",
                            ShortArName = "مستودعات التموين",
                            EnglishName = "STORAGE",
                            ShortEnName = "STORAGE",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "المواصفات",
                            ShortArName = "المواصفات",
                            EnglishName = "SPECIFICATION",
                            ShortEnName = "SPECIFICATION",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "ممتلكات التموين",
                            ShortArName = "ممتلكات التموين",
                            EnglishName = "PROPERTY",
                            ShortEnName = "PROPERTY",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الجرد",
                            ShortArName = "الجرد",
                            EnglishName = "INVERTORY",
                            ShortEnName = "INVERTORY",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "كل الفروع",
                            ShortArName = "كل الفروع",
                            EnglishName = "ALL SECTIONS",
                            ShortEnName = "ALL SECTIONS",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "العهد",
                            ShortArName = "العهد",
                            EnglishName = "CUSTODY",
                            ShortEnName = "CUSTODY",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الضيافة الملكية بحفرالباطن",
                            ShortArName = "الضيافة الملكية بحفرالباطن",
                            EnglishName = "ROYAL VILLA HAFR",
                            ShortEnName = "ROYAL VILLA HAFR",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "ضيافة المكية كبار الشخصيات",
                            ShortArName = "كبار الشخصيات",
                            EnglishName = "VIP ALARTIWAYA",
                            ShortEnName = "VIP ALARTIWAYA",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الشحن والاستلام بالتموين",
                            ShortArName = "الشحن والاستلام",
                            EnglishName = "SHIPPING&RECEIVING",
                            ShortEnName = "SHIPPING&RECEIVING",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مراقبة المخزون",
                            ShortArName = "مراقبة المخزون",
                            EnglishName = "STOCK CONTROL",
                            ShortEnName = "STOCK CONTROL",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مدينة الملك فهد العسكرية",
                            ShortArName = "مدينة الملك فهد",
                            EnglishName = "King Fahad Military City",
                            ShortEnName = "KFMC",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "مدينة الملك عبدالعزيز",
                            ShortArName = "مدينة الملك عبدالعزيز",
                            EnglishName = "King Abdul_Aziz  Military City",
                            ShortEnName = "KAMC",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "نجران",
                            ShortArName = "نجران",
                            EnglishName = "Ngran",
                            ShortEnName = "Ngran",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "المنشأت العسكرية شرورة",
                            ShortArName = "شرورة",
                            EnglishName = "Sharorh",
                            ShortEnName = "Sharorh",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "الخرج والسليل",
                            ShortArName = "الخرج والسليل",
                            EnglishName = "AL_Kharj",
                            ShortEnName = "AL_Kharj",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "المنشات العسكرية الطائف",
                            ShortArName = "الطائف",
                            EnglishName = "AL_Taif",
                            ShortEnName = "AL_Taif",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "المنطقة الجنوبية",
                            ShortArName = "الجنوب",
                            EnglishName = "South Region",
                            ShortEnName = "South Region",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "للمنشآت العسكريه بالعيينه",
                            ShortArName = "للمنشآت العسكريه بالعيينه",
                            EnglishName = "AL-OIAYENAH",
                            ShortEnName = "AL-OIAYENAH",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "إدارة التشغيل والصيانة بالقصيم",
                            ShortArName = "إدارة التشغيل والصيانة بالقصيم",
                            EnglishName = "O&M AL-QASSIM",
                            ShortEnName = "O&M AL-QASSIM",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        },
                        new Branch()
                        {
                            ArabicName = "التموين العسكري",
                            ShortArName = "التموين العسكري",
                            EnglishName = "ARMY SUPPLY",
                            ShortEnName = "ARMY SUPPLY",
                            CreatedDate = DateTime.Now,
                            CreatedBy = "Migration"
                        }
                    }
                }
            };

            dbContext.Departments.AddRange(departments);
            dbContext.SaveChanges();
        }
    }
}
