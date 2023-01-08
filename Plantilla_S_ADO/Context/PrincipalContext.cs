using Microsoft.Extensions.Configuration;
using System.IO;

namespace Plantilla_S_ADO.Context
{
    public class PrincipalContext
    {
        private string connection = string.Empty;

        public PrincipalContext()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connection = builder.GetSection("ConnectionStrings:PrincipalConnection").Value;
        }
        public string getConnection()
        {
            return connection;
        }

    }
}
