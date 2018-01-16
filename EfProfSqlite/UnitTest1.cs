using HibernatingRhinos.Profiler.Appender.EntityFramework;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EfProfSqlite
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1()
        {
            // The test passes if this line is commented out
            EntityFrameworkProfiler.Initialize();

            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            try
            {
                var options = new DbContextOptionsBuilder<CompanyContext>()
                    .UseSqlite(connection)
                    .Options;

                using (var context = new CompanyContext(options))
                {
                    context.Database.EnsureCreated();
                }

                using (var context = new CompanyContext(options))
                {
                    context.Company.Add(new Company()
                    {
                        Name = "Tri-State Amalgamated Office Supply, a division of Global Tetrahedron International Unlimited"
                    });
                    context.SaveChanges();
                }
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
