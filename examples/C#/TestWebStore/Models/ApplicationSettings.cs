using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWebStore.Models
{
    public class ApplicationSettings
    {
        public string DefaultStorageConnectionString { get; set; }

        public string RedirectUrlBase { get; set; }

        public string EasyCardEnvironment { get; set; } = "SANDBOX";

        public string EasyCardPrivateApiKey { get; set; }

        public string EasyCardSharedApiKey { get; set; }
    }
}
