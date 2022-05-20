using BTO.ComonComon.Extentions;
using BTO.SmartHomeAPI.Controllers.Base;
using BTO.SmartHomeDatas.Dto;
using BTO.SmartHomeModel.Dtos;
using BTO.SmartHomeModel.Entities;
using BTO.SmartHomeModel.Enums;
using Easy2Patch.Common.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BTO.SmartHomeAPI.Controllers.Arduino
{
    [ApiController]
    [Route("api/[action]")]
    public class PinsController : BaseController
    {
        public PinsController(IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(httpContextAccessor, configuration)
        {

        }

        #region PIN

        [HttpPost("PinSaveOrEdit")]
        public IActionResult PinSaveOrEdit([FromBody] RequestItem<t_Pins> request)
        {
            //Log
            new t_ConnecLogDtos().CreateConnectLog(httpContextAccessor.GetIP(), "PinSaveOrEdit", request.UserName, request.Password.Decrypt());

            if (!GetAuthentication(request.UserName, request.Password.Decrypt(),this))
            {
                return Unauthorized();
            }

            ResultItem<t_Pins> resPins = new ResultItem<t_Pins>();
            if (request.Object != null)
            {
                t_PinDtos PinDtos = new t_PinDtos();
                if (request.Object.ObjectID == 0)
                {
                    resPins = PinDtos.Add(request.Object);
                }
                else
                {
                    resPins = PinDtos.Edit(request.Object);
                }
            }
            return Json(resPins);
        }

        [HttpPost("PinDelete")]
        public IActionResult PinDelete([FromBody] RequestItem<List<int>> request)
        {
            //Log
            new t_ConnecLogDtos().CreateConnectLog(httpContextAccessor.GetIP(), "PinSaveOrEdit", request.UserName, request.Password.Decrypt());

            if (!GetAuthentication(request.UserName, request.Password.Decrypt(),this))
            {
                return Unauthorized();
            }

            if (request.Object != null)
            {
                t_PinDtos PinDtos = new t_PinDtos();
                if (request.Object.Count > 0)
                {
                    var response = PinDtos.Delete(x => request.Object.Contains(x.ObjectID), false);
                    return Json(response);

                }
            }
            return NotFound();
        }

        [HttpPost("PinList")]
        public async Task<IActionResult> PinList([FromBody] RequestItem<RequestList> request)
        {
            //Log
            new t_ConnecLogDtos().CreateConnectLog(httpContextAccessor.GetIP(), "PinList", request.UserName, request.Password.Decrypt());

            if (!GetAuthentication(request.UserName, request.Password.Decrypt(),this))
            {
                return Unauthorized();
            }

            if (request.Object != null)
            {
                t_PinDtos PinDtos = new t_PinDtos();
                ResultItem<t_Pins> resPins = new ResultItem<t_Pins>();

                Expression<Func<t_Pins, bool>> e1 = x => true;

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
                    resPins =await  PinDtos.AsyncGetList(e1);
                }
                else
                {
                    resPins = PinDtos.GetRelational(e1);
                }

                if (!request.Object.OrderByID)
                {
                    resPins.List = resPins.List.OrderByDescending(x => x.ObjectID).ToList();
                }

                return Json(resPins);

            }
            return NotFound();
        }

        #endregion


    }
}
