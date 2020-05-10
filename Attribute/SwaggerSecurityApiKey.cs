using System;

namespace AoiHosizora.Swagger.Attribute {

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SwaggerSecurityApiKey : System.Attribute {

        public string Id { get; set; }

        public SwaggerSecurityApiKey(string id) {
            Id = id;
        }
    }
}
