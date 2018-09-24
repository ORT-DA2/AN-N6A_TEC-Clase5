using System;
using CityInfo.Contracts.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CityInfo.API.Filters
{
    public class ProtectFilter : Attribute, IActionFilter
    {
        private readonly string _role;
        private readonly ISessionRepository sessions;

        public ProtectFilter(string role)
        {
            _role = role;
            this.sessions = sessions; // pendiente invocar context factory
        }

        // cod origin: https://github.com/Sactos/HomeworksApi/blob/master/Clases/Clase%204%20-%20Filters.md
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // OBTENEMOS EL TOKEN DEL HEADER
            string token = context.HttpContext.Request.Headers["Authorization"];
            // SI EL TOKEN ES NULL CORTAMOS LA PIPELINE Y RETORNAMOS UN RESULTADO
            if (token == null)
            {
                context.Result = new ContentResult()
                {
                    Content = "Token is required",
                };
            }
            
                // VALIDAMOS EL TOKEN
                if (!this.sessions.IsValidToken(token))
                {
                    context.Result = new ContentResult()
                    {
                        Content = "Invalid Token",
                    };
                }
                // CHECKEAMOS QUE EL TOKEN TENGA LOS PERMISOS NECESARIOS
                if (!sessions.HasLevel(token, _role))
                {
                    context.Result = new ContentResult()
                    {
                        Content = "The user isen't " + _role,
                    };
                }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }
    }
}
