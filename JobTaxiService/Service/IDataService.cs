using JobTaxi.Entity.Models;
using JobTaxiService.Dto;

namespace JobTaxiService.Service
{
    public interface IDataService
    {
        public User CheckUser(YandexProfil yandexProfil, string deviceId);
    }
}
