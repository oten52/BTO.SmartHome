using BTO.SmartHomeDatas.Dto;
using BTO.SmartHomeModel.Base;
using BTO.SmartHomeModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTO.SmartHomeDatas.Business
{
    public class ExceptionLogBusiness : Singleton<ExceptionLogBusiness>
    {
        public async void CreateExceptionLog(t_ExceptionLogs exceptionLog)
        {
            t_ExceptionLogDtos exceptionLogDtos = new t_ExceptionLogDtos();

            await exceptionLogDtos.AsyncAdd(exceptionLog);
        }
    }
}
