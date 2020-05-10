using System.Linq;
using System.Reflection;
using AoiHosizora.Swagger.Attribute;
using AoiHosizora.Swagger.Extension;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AoiHosizora.Swagger.Filter {

    public class PropertySchemaFilter : ISchemaFilter {

        public void Apply(OpenApiSchema schema, SchemaFilterContext context) {
            var properties = context.Type.GetProperties();
            if (properties.Length == 0) {
                return;
            }
            foreach (var property in properties) {
                var attr = property.GetCustomAttributes<SwaggerProperty>().FirstOrDefault();
                if (attr == null) {
                    continue;
                }
                ApplySchema(schema, property.Name.ToSnakeCase(), attr);
            }
        }

        private static bool ApplySchema(OpenApiSchema schema, string property, SwaggerProperty attr) {
            if (!schema.Properties.ContainsKey(property)) {
                return false;
            }
            var val = schema.Properties[property];
            val.Description = attr.Description;
            schema.Required.Add(property);
            return true;
        }
    }
}
