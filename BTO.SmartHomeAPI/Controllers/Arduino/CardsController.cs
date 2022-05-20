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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace BTO.SmartHomeAPI.Controllers.Arduino
{
    [ApiController]
    [Route("api/[action]")]

    public class CardsController : BaseController
    {
        public CardsController(IHttpContextAccessor httpContextAccessor, IConfiguration configuration) : base(httpContextAccessor, configuration)
        {

        }

        public static bool _isAlarmMode = false;
        public static bool _hollLedStatus = false;
        public static List<string> ldtHareket = new List<string>();

        #region CARD

        [HttpPost("CardSaveOrEdit")]
        public IActionResult CardSaveOrEdit([FromBody] RequestItem<t_Cards> request)
        {
            //Log
            new t_ConnecLogDtos().CreateConnectLog(httpContextAccessor.GetIP(), "CardSaveOrEdit", request.UserName, request.Password.Decrypt());


            if (!GetAuthentication(request.UserName, request.Password.Decrypt(),this))
            {
                return Unauthorized();
            }

            ResultItem<t_Cards> resCards = new ResultItem<t_Cards>();
            if (request.Object != null)
            {
                t_CardDtos cardDtos = new t_CardDtos();
                if (request.Object.ObjectID == 0)
                {
                    resCards = cardDtos.Add(request.Object);
                }
                else
                {
                    resCards = cardDtos.Edit(request.Object);
                }
            }
            return Json(resCards);
        }

        [HttpPost("CardDelete")]
        public IActionResult CardDelete([FromBody] RequestItem<List<int>> request)
        {
            //Log
            new t_ConnecLogDtos().CreateConnectLog(httpContextAccessor.GetIP(), "CardSaveOrEdit", request.UserName, request.Password.Decrypt());

            if (!GetAuthentication(request.UserName, request.Password.Decrypt(),this))
            {
                return Unauthorized();
            }

            if (request.Object != null)
            {
                t_CardDtos cardDtos = new t_CardDtos();
                if (request.Object.Count > 0)
                {
                    var response = cardDtos.Delete(x => request.Object.Contains(x.ObjectID), false);
                    return Json(response);

                }
            }
            return NotFound();
        }

        [HttpPost("CardList")]
        public async Task<IActionResult> CardList([FromBody] RequestItem<RequestList> request)
        {
            //Log
            new t_ConnecLogDtos().CreateConnectLog(httpContextAccessor.GetIP(), "CardList", request.UserName, request.Password.Decrypt());

            if (!GetAuthentication(request.UserName, request.Password.Decrypt(),this))
            {
                return Unauthorized();
            }
            if (request.Object != null)
            {
                t_CardDtos cardDtos = new t_CardDtos();
                ResultItem<t_Cards> resCards = new ResultItem<t_Cards>();

                Expression<Func<t_Cards, bool>> e1 = x => true;

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
                    resCards = await cardDtos.AsyncGetList(e1);
                }
                else
                {
                    resCards = cardDtos.GetRelational(e1);
                }

                if (!request.Object.OrderByID)
                {
                    resCards.List = resCards.List.OrderByDescending(x => x.ObjectID).ToList();
                }

                return Json(resCards);

            }

            return NotFound();
        }

        // GetCardInfo - Arduino üzerinden atılan isteğe cevap vererek pin ve mod durumlarını günceller
        [HttpPost("GetCardInfo")]
        public async Task<IActionResult> GetArduinoInfo([FromBody] RequestItem<Object> request)
        {

            if (!GetAuthentication(request.UserName, request.Password.Decrypt(),this))
            {
                return Unauthorized();
            }

            ResultItem<t_Cards> resultItem = await new t_CardDtos().AsyncGet(x => x.SensorGuid == new Guid(request.Object.ToString()));

            if (resultItem.Status == enState.Success)
            {

                ResultItem<t_Pins> resultPins = await new t_PinDtos().AsyncGetList(x => x.CardId==resultItem.Object.ObjectID);

                var D15 = resultPins.List.FirstOrDefault(x => x.PinNumber == 15);
                var D2 = resultPins.List.FirstOrDefault(x => x.PinNumber == 2);


                dynamic d = new ExpandoObject();
                d.Mode = resultItem.Object.ModeType;
                d.D15 = D15.Status;
                d.D2 = D2.Status;

                return Json(d);
            }

            return NotFound();
        }

        #endregion

    }
}
