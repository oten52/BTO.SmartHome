using BTO.ComonComon.Extentions;
using BTO.SmartHomeDatas.Dto;
using BTO.SmartHomeModel.Base;
using BTO.SmartHomeModel.Dtos;
using BTO.SmartHomeModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTO.SmartHomeDatas.Business
{
    public class AuthenticationBusiness:Singleton<AuthenticationBusiness>
    {

        public bool GetAuthentication(string UserName, string Password, string ControllerName, string ActionName)
        {

            ResultItem<t_Users> resUser = new t_UserDtos().Get(x => x.UserName == UserName && x.Password == Password);

            if (!resUser.Object.IsNull())
            {

                if (!ControllerName.IsNullOrEmpty() && !ActionName.IsNullOrEmpty())
                {
                    ResultItem<t_IActionResults> resActionResult = new t_IActionResultDtos().Get(x => x.ControlName == ControllerName && x.ActionName == ActionName);

                    if (resActionResult.Object.IsNull())
                    {
                        return false;
                    }
                    else
                    {
                        ResultItem<t_IActionResultAuthenticationMaps> resActionResultAuthenticationMaps = new t_IActionResultAuthenticationMapDtos().Get(x => x.t_UserID == resUser.Object.ObjectID && x.t_IActionResultID == resActionResult.Object.ObjectID);
                        if (resActionResultAuthenticationMaps.Object.IsNull())
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
                return true;

            }
            return false;
        }
    }
}
