using BTO.SmartHomeAPI.Controllers.Base;
using BTO.ComonComon.Extentions;
using BTO.SmartHomeDatas.Dto;
using BTO.SmartHomeModel.Dtos;
using BTO.SmartHomeModel.Entities;
using Easy2Patch.Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BTO.SmartHomeModel.Enums;

namespace BTO.SmartHomeAPI.Controllers.System
{
    [ApiController]
    [Route("api/[action]")]
    public class UsersController : BaseController
    {
        public UsersController(IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(httpContextAccessor, configuration)
        {

        }

        #region User

        [HttpPost("UserSaveOrEdit")]
        public IActionResult UserSaveOrEdit([FromBody] RequestItem<t_Users> request)
        {
            //Log
            new t_ConnecLogDtos().CreateConnectLog(httpContextAccessor.GetIP(), "UserSaveOrEdit", request.UserName, request.Password.Decrypt());

            if (!GetAuthentication(request.UserName, request.Password.Decrypt(),this))
            {
                return Unauthorized();
            }

            ResultItem<t_Users> resUsers = new ResultItem<t_Users>();
            if (request.Object != null)
            {
                t_UserDtos UserDtos = new t_UserDtos();
                if (request.Object.ObjectID == 0)
                {
                    resUsers = UserDtos.Add(request.Object);
                }
                else
                {
                    resUsers = UserDtos.Edit(request.Object);
                }
            }
            return Json(resUsers);
        }

        [HttpPost("UserDelete")]
        public IActionResult UserDelete([FromBody] RequestItem<List<int>> request)
        {
            //Log
            new t_ConnecLogDtos().CreateConnectLog(httpContextAccessor.GetIP(), "UserSaveOrEdit", request.UserName, request.Password.Decrypt());

            if (!GetAuthentication(request.UserName, request.Password.Decrypt(),this))
            {
                return Unauthorized();
            }

            if (request.Object != null)
            {
                t_UserDtos UserDtos = new t_UserDtos();
                if (request.Object.Count > 0)
                {
                    var response = UserDtos.Delete(x => request.Object.Contains(x.ObjectID), false);
                    return Json(response);

                }
            }
            return NotFound();
        }

        [HttpPost("UserList")]
        public async Task<IActionResult> UserList([FromBody] RequestItem<RequestList> request)
        {
            //Log
            new t_ConnecLogDtos().CreateConnectLog(httpContextAccessor.GetIP(), "UserList", request.UserName, request.Password.Decrypt());

            if (!GetAuthentication(request.UserName, request.Password.Decrypt(),this))
            {
                return Unauthorized();
            }

            if (request.Object != null)
            {
                t_UserDtos UserDtos = new t_UserDtos();
                ResultItem<t_Users> resUsers = new ResultItem<t_Users>();

                Expression<Func<t_Users, bool>> e1 = x => true;

              
                switch (request.Object.IsDeleted)
                {
                    case enDeleteType.NotDeleted:
                        {
                            e1 = e1.And(x => !x.IsDelete);

                            break;
                        }
                    case enDeleteType.Deleted:
                        {
                            e1 = e1.And(x => x.IsDelete);
                            break;
                        }
                    
                }


                if (request.Object.Relations)
                {
                    resUsers = await UserDtos.AsyncGetList(e1);
                }
                else
                {
                    resUsers = UserDtos.GetRelational(e1);
                }

                if (!request.Object.OrderByID)
                {
                    resUsers.List = resUsers.List.OrderByDescending(x => x.ObjectID).ToList();
                }

                return Json(resUsers);

            }
            return NotFound();
        }

        #endregion

    }
}
