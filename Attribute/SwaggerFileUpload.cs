using System;

namespace AoiHosizora.Swagger.Attribute {

    [AttributeUsage(AttributeTargets.Method)]
    public class SwaggerFileUpload : System.Attribute {

        public string Name { get; set; }
        public string Description { get; set; }

        public SwaggerFileUpload(string name, string description = "") {
            Name = name;
            Description = description;
        }
    }
}
