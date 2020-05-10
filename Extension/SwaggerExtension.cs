using AoiHosizora.Swagger.Filter;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AoiHosizora.Swagger.Extension {

    public static class SwaggerExtension {

        public static void EnableAoiHosizoraSwaggerAnnotations(this SwaggerGenOptions options) {
            options.OperationFilter<FileUploadOperationFilter>();
            options.OperationFilter<ResponseHeaderOperationFilter>();

            options.SchemaFilter<ModelSchemaFilter>();
        }
    }
}
