using castgroup.services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace castgroup.api.Filters
{
    public class CustomExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order { get; } = int.MaxValue - 10;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is CustomException exception)
            {
                context.Result = new ObjectResult(new
                {
                    title = "Erro de regra de negócio",
                    error = exception.Message
                })
                {
                    StatusCode = 400,
                };
                context.ExceptionHandled = true;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context) { }

    }
}
