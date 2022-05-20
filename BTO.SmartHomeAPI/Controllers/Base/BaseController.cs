using BTO.ComonComon.Extentions;
using BTO.SmartHomeDatas.Business;
using BTO.SmartHomeDatas.Dto;
using BTO.SmartHomeModel.Dtos;
using BTO.SmartHomeModel.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;

namespace BTO.SmartHomeAPI.Controllers.Base
{
    public class BaseController : Controller
    {
        protected IHttpContextAccessor httpContextAccessor;


        public BaseController(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            this.httpContextAccessor = httpContextAccessor;

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Controller c = context.Controller as Controller;

            base.OnActionExecuting(context);
        }

        protected bool GetAuthentication(string UserName, string Password, Controller controller)
        {

            
            return AuthenticationBusiness.Instance().GetAuthentication(UserName,Password,GetControllerName(controller),GetActionrName(controller));
        }

        protected string GetControllerName(Controller controller)
        {
            return Convert.ToString(controller.ControllerContext.RouteData.Values["controller"]);
        }
        protected string GetActionrName(Controller controller)
        {
            return Convert.ToString(controller.ControllerContext.RouteData.Values["action"]);
        }

    }
}
