using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTO.ComonComon.Extentions
{
    public static class NetworkExtentions
    {

        public static String GetIP(this IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor != null)
            {
                return httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            }
            else
            {
                return String.Empty;

            }
        }

    }
}
