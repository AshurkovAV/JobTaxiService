using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using JobTaxiService.Dto;

namespace JobTaxiService.Service
{
    public class DataService : IDataService
    {
        private readonly IJobRepository _jobRepository;
        public DataService(IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
        }
        public User CheckUser(YandexProfil yandexProfil, string deviceId)
        {
            var result = new User();    
            var userResult = _jobRepository.GetUser(yandexProfil.default_phone.number, yandexProfil.default_email);
            if (userResult == null) {
                result = _jobRepository.InsertUser(
                        new User
                        {
                            IdYandex = yandexProfil.id,
                            ClientId = yandexProfil.client_id,
                            Birthday = yandexProfil.birthday != ""?Convert.ToDateTime(yandexProfil.birthday):null,
                            DefaultEmail = yandexProfil.default_email,
                            DefaultAvatarId = yandexProfil.default_avatar_id,
                            DefaultPhone = yandexProfil.default_phone.number,
                            DisplayName = yandexProfil.display_name,
                            FirstName = yandexProfil.first_name,
                            LastName = yandexProfil.last_name,
                            Login = yandexProfil.login,
                            Sex = yandexProfil.sex,
                            RealName = yandexProfil.real_name,
                            IsAvatarEmpty = yandexProfil.is_avatar_empty,
                            DeviceId = deviceId

                        });
            }
            else
            {
                result = userResult;
            }

            return result;
        }       
    }
}
