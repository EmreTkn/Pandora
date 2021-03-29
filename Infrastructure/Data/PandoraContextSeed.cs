using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class PandoraContextSeed
    {
        public static async Task SeedAsync(PandoraContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Jobs.Any())
                {
                    var jobsData = File.ReadAllText("../Infrastructure/Data/SeedData/work.json");
                    var jobs = JsonSerializer.Deserialize<List<Job>>(jobsData);

                    foreach (var item in jobs)
                    {
                        context.Jobs.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Employeeses.Any())
                {
                    var employeesData = File.ReadAllText("../Infrastructure/Data/SeedData/personel.json");
                    var employeeses = JsonSerializer.Deserialize<List<Employees>>(employeesData);

                    foreach (var item in employeeses)
                    {
                        context.Employeeses.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<PandoraContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
