using System.Collections.Generic;
using System.Linq;
using AoiHosizora.Swagger.Attribute;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AoiHosizora.Swagger.Filter {

    public class FileUploadOperationFilter : IOperationFilter {

        private static readonly string[] FileParameters = {"contentType", "contentDisposition", "headers", "length", "name", "fileName"};

        public void Apply(OpenApiOperation operation, OperationFilterContext context) {
            var attr = context.MethodInfo.GetCustomAttributes(true).OfType<SwaggerFileUpload>().FirstOrDefault();
            if (attr == null) {
                return;
            }

            var content = operation.RequestBody.Content;
            var formDataProperties = GetProperties(content, "multipart/form-data");
            foreach (var parameter in formDataProperties.Where(p => FileParameters.Contains(p.Key))) {
                formDataProperties.Remove(parameter);
            }
            formDataProperties.Add(attr.Name, new OpenApiSchema {Type = "file", Description = attr.Description});
        }

        private static IDictionary<string, OpenApiSchema> GetProperties(IDictionary<string, OpenApiMediaType> contents, string mediaType) {
            if (!contents.ContainsKey(mediaType)) {
                contents.Add(mediaType, new OpenApiMediaType {
                    Schema = new OpenApiSchema {
                        Type = "object",
                        Properties = new Dictionary<string, OpenApiSchema>()
                    }
                });
            }
            return contents[mediaType].Schema.Properties;
        }
    }
}
