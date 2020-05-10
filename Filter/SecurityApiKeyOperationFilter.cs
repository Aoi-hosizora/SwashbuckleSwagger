using System.Collections.Generic;
using System.Linq;
using AoiHosizora.Swagger.Attribute;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AoiHosizora.Swagger.Filter {

    public class SecurityApiKeyOperationFilter : IOperationFilter {

        public void Apply(OpenApiOperation operation, OperationFilterContext context) {
            var attrs = context.MethodInfo.GetCustomAttributes(true).OfType<SwaggerSecurityApiKey>().ToList();
            if (attrs.Count == 0) {
                return;
            }

            var securities = new List<OpenApiSecurityRequirement>();
            foreach (var attr in attrs) {
                var schema = new OpenApiSecurityScheme {
                    Reference = new OpenApiReference {
                        Type = ReferenceType.SecurityScheme,
                        Id = attr.Id
                    }
                };
                securities.Add(new OpenApiSecurityRequirement {
                    [schema] = new string[] { }
                });
            }
            operation.Security = securities;
        }
    }
}
