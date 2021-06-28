namespace ConsoleApp.Base
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using static Microsoft.AspNetCore.Http.StatusCodes;

    public class ComponentControllerBase : ControllerBase
    {
        protected IActionResult InternalActionResult([ActionResultStatusCode] int httpStatusCode) => StatusCode(httpStatusCode);
        protected IActionResult InternalActionResult([ActionResultStatusCode] int httpStatusCode, [ActionResultObjectValue] object response) => httpStatusCode switch
        {
            Status200OK => Ok(response),
            Status201Created => StatusCode(Status201Created, response),
            _ => NotFound()
        };
    }
}
