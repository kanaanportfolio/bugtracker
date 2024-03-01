using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BTA.Api.Filters;

public class VersioningResourceFilter : Attribute, IResourceFilter
{
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        if (!context.HttpContext.Request.Path.Value.ToLower().Contains("2"))
        {
            context.Result = new BadRequestObjectResult(new
                {
                    Versioning = new[] 
                    {
                        "This version is now deprecated. Use v2."
                    }
                });
        }
    }
    public void OnResourceExecuted(ResourceExecutedContext context)
    {
    }
}