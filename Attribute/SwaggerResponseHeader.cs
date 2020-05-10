using System;

namespace AoiHosizora.Swagger.Attribute {

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class SwaggerResponseHeader : System.Attribute {

        public int StatusCode { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }

        public SwaggerResponseHeader(int statusCode, string name, string type = "string", string description = "") {
            StatusCode = statusCode;
            Name = name;
            Type = type;
            Description = description;
        }
    }
}
