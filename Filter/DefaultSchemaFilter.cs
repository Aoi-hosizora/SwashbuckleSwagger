using System.ComponentModel;
using System.Linq;
using System.Reflection;
using AoiHosizora.Swagger.Extension;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AoiHosizora.Swagger.Filter {

    public class DefaultSchemaFilter : ISchemaFilter {

        public void Apply(OpenApiSchema schema, SchemaFilterContext context) {
            var properties = context.Type.GetProperties();
            if (properties.Length == 0) {
                return;
            }
            foreach (var property in properties) {
                var attr = property.GetCustomAttributes<DefaultValueAttribute>().FirstOrDefault();
                if (attr == null) {
                    continue;
                }

                if (!schema.Properties.ContainsKey(property.Name.ToSnakeCase())) {
                    continue;
                }
                var opProp = schema.Properties[property.Name.ToSnakeCase()];
                if (opProp == null) {
                    continue;
                }

                if (attr.Value != null) {
                    opProp.Extensions.Add("default", new OpenApiString(attr.Value.ToString()));
                }
            }
        }
    }
}
