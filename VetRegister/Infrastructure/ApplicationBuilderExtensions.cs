using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VetRegister.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using VetRegister.Data.Models;

namespace VetRegister.Infrastructure
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {

            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<VetRegisterDbContext>();

            data.Database.Migrate();

            //SeedBreeds(data);

            return app;
        }

        //private static void SeedBreeds(VetRegisterDbContext data)
        //{
        //    if (data.Breeds.Any())
        //    {
        //        return;
        //    }

        //    data.Breeds.AddRange(new[]
        //    {
        //        new Breed { Name = "Collie"},
        //        new Breed { Name = "German Shepherd"},
        //        new Breed { Name = "Golden Retriever"}
        //    });

        //    data.SaveChanges();

        //}

    }
}
