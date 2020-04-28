using Microsoft.Extensions.Configuration;
using System;
namespace Dotnetcore_Webapi_MongoDB.Entities
{
    public class DbSettings
    {
        public string ConnectionString;
        public string Database;
        public IConfigurationRoot IConfigurationRoot;
    }
}