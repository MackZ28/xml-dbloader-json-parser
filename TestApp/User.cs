using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TestApp
{
    class User
    {
      
        [JsonProperty(PropertyName = "Full Name")]
        public string FullName { get; set; }

        public string Country { get; set; }

        [JsonProperty(PropertyName = "Created At")]
        public string CreatedAt { get; set; }

        public string Id { get; set; }

        public string Email { get; set; }

    }
}
