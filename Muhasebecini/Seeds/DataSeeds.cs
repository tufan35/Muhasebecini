using Microsoft.EntityFrameworkCore;
using Muhasebecini.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Muhasebecini.Seeds
{
    public class DataSeeds
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<DatabaseContext>();
            context.Database.Migrate();
        }
    }
}
