using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using AoiHosizora.Swagger.Attribute;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AoiHosizora.Swagger.Filter {

    public class ResponseHeaderOperationFilter : IOperationFilter {

        public void Apply(OpenApiOperation operation, OperationFilterContext context) {
            var attrs = context.MethodInfo.GetCustomAttributes(true).OfType<SwaggerResponseHeader>().ToList();
            if (attrs.Count == 0) {
                return;
            }

            foreach (var attr in attrs) {
                var response = operation.Responses.FirstOrDefault(x => x.Key == attr.StatusCode.ToString(CultureInfo.InvariantCulture)).Value;
                if (response == null) {
                    continue;
                }

                if (response.Headers == null) {
                    response.Headers = new Dictionary<string, OpenApiHeader>();
                }
                response.Headers.Add(attr.Name, new OpenApiHeader {
                    Description = attr.Description,
                    Schema = new OpenApiSchema {Type = attr.Type, Description = attr.Description}
                });
            }
        }
    }
}
