using System.Linq;
using System.Reflection;
using AoiHosizora.Swagger.Attribute;
using AoiHosizora.Swagger.Extension;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AoiHosizora.Swagger.Filter {

    public class PropertyOperationFilter : IOperationFilter {

        public void Apply(OpenApiOperation operation, OperationFilterContext context) {
            if (context.MethodInfo == null) {
                return;
            }

            var parameters = context.MethodInfo.GetParameters();
            foreach (var param in parameters) {
                if (!param.ParameterType.IsClass) {
                    continue;
                }
                var properties = param.ParameterType.GetProperties();
                foreach (var prop in properties) {
                    var attr = prop.GetCustomAttributes<SwaggerProperty>().FirstOrDefault();
                    if (attr == null) {
                        continue;
                    }
                    ApplyToParam(operation, prop.Name.ToSnakeCase(), attr);
                }
            }
        }

        private static bool ApplyToParam(OpenApiOperation op, string property, SwaggerProperty attr) {
            var val = op.Parameters.FirstOrDefault(p => p.Name == property);
            if (val == null) {
                return false;
            }
            val.Description = attr.Description;
            val.Required = attr.Required;
            return true;
        }
    }
}
