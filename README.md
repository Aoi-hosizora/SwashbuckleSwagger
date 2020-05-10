# AoiHosizora.Swagger

+ AspNetCore customer swagger based on [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
+ See nuget in [AoiHosizora.Swagger](https://www.nuget.org/packages/AoiHosizora.Swagger/)

### Functions

+ `FileUpload`
+ `SecurityApiKey`
+ `DefaultValue`
+ `Model`
+ `Property`

### Usage

```c#
services.AddSwaggerGen(options => {
    // ...
    options.EnableAnnotations();
    options.AddSecurityDefinition("secret", new OpenApiSecurityScheme { // demo
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Name = "Authorization"
    });
    options.EnableAoiHosizoraSwaggerAnnotations();
});
```

```c#
// demo for SecurityApiKey
[HttpGet("test")]
[SwaggerSecurityApiKey("secret")]
// [Authorize]
public IActionResult Test() { }
```

### Required

+ .NETCore >= 3.0

### Install

```bash
# Package manager
Install-Package AoiHosizora.Swagger -Version 1.0.1

# .NET CLI
dotnet add package AoiHosizora.Swagger --version 1.0.1
```

### Reference

+ [Swashbuckle.AspNetCore](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)
+ [.nuspec reference](https://docs.microsoft.com/en-us/nuget/reference/nuspec)
