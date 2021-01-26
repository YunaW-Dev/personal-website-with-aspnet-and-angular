using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data
{
    public class SeedMyContext
    {
        public static async Task SeedAsync(MyContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.ProjectYears.Any())
                {
                    var yearsFile = File.ReadAllText("../Infrastructure/Data/SeedingData/years.json");
                    var years = JsonSerializer.Deserialize<List<ProjectYear>>(yearsFile);
                    foreach (var item in years)
                    {
                        context.ProjectYears.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

                if (!context.ProjectTypes.Any())
                {
                    var typesFile = File.ReadAllText("../Infrastructure/Data/SeedingData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProjectType>>(typesFile);
                    foreach (var item in types)
                    {
                        context.ProjectTypes.Add(item);
                    }
                    await context.SaveChangesAsync();
                }


                if (!context.Projects.Any())
                {
                    var projectsFile = File.ReadAllText("../Infrastructure/Data/SeedingData/projects.json");
                    var projects = JsonSerializer.Deserialize<List<Project>>(projectsFile);
                    foreach (var item in projects)
                    {
                        context.Projects.Add(item);
                    }
                    await context.SaveChangesAsync();
                }



            }
            catch (Exception ex)
            {

            }
        }
    }
}