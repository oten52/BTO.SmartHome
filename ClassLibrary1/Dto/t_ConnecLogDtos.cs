using BTO.SmartHomeModel.Entities;
using DonusumAykome.WebAPI.Data;

namespace BTO.SmartHomeDatas.Dto
{

    public class t_ConnecLogDtos : EfEntityRepository<t_ConnectLogs>
    {

        public async void CreateConnectLog(string IpAdress, string MethodName, string UserName, string Password)
        {

            await AsyncAdd(new t_ConnectLogs()
            {
                IpAdress = IpAdress,
                MethodName = MethodName,
                UserName = UserName,
                Password = Password

            });
        }

    }
}
