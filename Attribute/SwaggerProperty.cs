using System;

namespace AoiHosizora.Swagger.Attribute {

    [AttributeUsage(AttributeTargets.Property)]
    public class SwaggerProperty : System.Attribute {

        public string Description { get; set; }
        public bool Required { get; set; }

        public SwaggerProperty(string description = "", bool required = false) {
            Description = description;
            Required = required;
        }
    }
}
