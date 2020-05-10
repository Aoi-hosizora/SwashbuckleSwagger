using System.ComponentModel;
using System.Linq;
using System.Reflection;
using AoiHosizora.Swagger.Extension;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AoiHosizora.Swagger.Filter {

    public class DefaultOperationFilter : IOperationFilter {

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
                    var attr = prop.GetCustomAttributes<DefaultValueAttribute>().FirstOrDefault();
                    if (attr == null) {
                        continue;
                    }
                    var opProp = operation.Parameters.FirstOrDefault(p => p.Name == prop.Name.ToSnakeCase());
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
}
