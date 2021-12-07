using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using LI.BookService.Model.Entities;
using LI.BookService.Model.DTO;

namespace LI.BookService.Bll.Helpers
{
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User is GetUserDTO)
            {
                return;
            }

            context.Result = new UnauthorizedResult();
        }
    
    }
}
