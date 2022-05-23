using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livraria.net.infra.Data
{
    public class AlternativoDbContext : IDesignTimeDbContextFactory<ApiDbContext>
    {
        public ApiDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<ApiDbContext>();

            dbContextBuilder.UseNpgsql(configuration.GetConnectionString("Api-StringBd-Postgres"), o =>
            {
                o.EnableRetryOnFailure();
            });

            return new ApiDbContext(dbContextBuilder.Options);
        }
    }
}
