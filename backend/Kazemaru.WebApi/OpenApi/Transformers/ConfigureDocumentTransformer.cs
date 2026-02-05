using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Models;

namespace Kazemaru.WebApi.OpenApi.Transformers;

public class ConfigureDocumentTransformer : IOpenApiDocumentTransformer
{
    public Task TransformAsync(OpenApiDocument document, OpenApiDocumentTransformerContext context,
        CancellationToken cancellationToken)
    {
        document.Info = new OpenApiInfo
        {
            Title = "Kazemaru - API Reference",
            Version = "v1",
            Description = "enjoy!",
            Contact = new OpenApiContact
            {
                Name = "alenj0x1",
                Url = new Uri("https://github.com/alenj0x1"),
            }
        };
        
        return Task.CompletedTask;
    }
}