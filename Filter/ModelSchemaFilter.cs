using System.Linq;
using System.Reflection;
using AoiHosizora.Swagger.Attribute;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AoiHosizora.Swagger.Filter {
    
    public class ModelSchemaFilter : ISchemaFilter {

        public void Apply(OpenApiSchema schema, SchemaFilterContext context) {
            if (context.Type == null) {
                return;
            }
            var attr = context.Type.GetCustomAttributes<SwaggerModel>().FirstOrDefault();
            if (attr == null) {
                return;
            }
            schema.Description = attr.Description;
        }
    }
}
