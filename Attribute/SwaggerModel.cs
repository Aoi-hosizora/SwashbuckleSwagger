using System;

namespace AoiHosizora.Swagger.Attribute {

    [AttributeUsage(AttributeTargets.Class)]
    public class SwaggerModel : System.Attribute {

        public string Description { get; set; }

        public SwaggerModel(string description = "") {
            Description = description;
        }
    }
}
