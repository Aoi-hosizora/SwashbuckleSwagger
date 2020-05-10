using AoiHosizora.Swagger.Filter;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AoiHosizora.Swagger.Extension {

    public static class SwaggerExtension {

        public static void EnableAoiHosizoraSwaggerAnnotations(this SwaggerGenOptions options) {
            // common
            options.OperationFilter<FileUploadOperationFilter>();
            options.OperationFilter<ResponseHeaderOperationFilter>();

            // security
            options.OperationFilter<SecurityApiKeyOperationFilter>();

            // default
            options.OperationFilter<DefaultOperationFilter>();
            options.SchemaFilter<DefaultSchemaFilter>();

            // model
            options.SchemaFilter<ModelSchemaFilter>();

            // property
            options.OperationFilter<PropertyOperationFilter>();
            options.SchemaFilter<PropertySchemaFilter>();
        }
    }
}
