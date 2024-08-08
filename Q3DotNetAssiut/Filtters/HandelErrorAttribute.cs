using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Q3DotNetAssiut.Filtters
{
    public class HandelErrorAttribute : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            ViewResult viewResult = new ViewResult();
            viewResult.ViewName= "Error";
            //catch
            //ContentResult contentResult = new ContentResult();
            //contentResult.Content = "Some Exception Throw";
            context.Result = viewResult;
        }
    }
}
