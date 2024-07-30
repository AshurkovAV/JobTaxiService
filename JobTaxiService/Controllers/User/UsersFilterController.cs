using JobTaxi.Entity;
using JobTaxi.Entity.Models;
using Microsoft.AspNetCore.Mvc;
using JobTaxi.Entity.Log;
using JobTaxi.Entity.Dto;
using JobTaxiService.Dto;
using JobTaxi.Entity.Dto.User;

namespace JobTaxiService.Controllers.User
{
    [ApiController]
    [Route("user/[controller]")]
    public class UsersFilterController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IJobRepository _jobRepository;
        public UsersFilterController(
            ILoggerFactory loggerFactory,
            IJobRepository jobRepository)
        {
            _jobRepository = jobRepository;
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
            var logger = loggerFactory.CreateLogger("JobRepository");
            _logger = logger;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<UsersFilter> Get(int id)
        {
            var result = new UsersFilter();
            _logger.LogInformation("GetUsersFilter");
            var resultOffer = _jobRepository.GetUsersFilter(id);
            result = resultOffer;
            return result;
        }

        

        [HttpPost]
        [Produces("application/json")]
        [Route("create/")]
        public async Task<IActionResult> Create([FromBody] UsersFilterDto usersFilterDto)
        {
            var result = new UsersFilter();
            _logger.LogInformation("CreateUsersFilter");
            var resultData = _jobRepository.CreateUpdateUsersFilter(new UsersFilter
            {
                FilterName = usersFilterDto.FilterName,
                AddressLatitude = usersFilterDto.AddressLatitude,
                AddressLongitude = usersFilterDto.AddressLongitude,
                ParkPercent = usersFilterDto.ParkPercent,
                SelfEmployed = usersFilterDto.SelfEmployed,
                SelfEmployedSum = usersFilterDto.SelfEmployedSum,
                WithdrawMoneyId = usersFilterDto.WithdrawMoneyId,
                WithdrawMoney = usersFilterDto.WithdrawMoney,
                Penalties = usersFilterDto.Penalties,
                Deposit = usersFilterDto.Deposit,
                Insurance = usersFilterDto.Insurance,
                RentalWriteOffTime = usersFilterDto.RentalWriteOffTime,
                GasThrowTaxometr = usersFilterDto.GasThrowTaxometr,
                FirstDayId = usersFilterDto.FirstDayId,
                Ransom = usersFilterDto.Ransom,
                DepositRetId = usersFilterDto.DepositRetId,
                WaybillsId = usersFilterDto.WaybillsId,
                WorkRadiusId = usersFilterDto.WorkRadiusId,
                InspectionId = usersFilterDto.InspectionId,
                MinRentalPeriodId = usersFilterDto.MinRentalPeriodId,

            });
            result = resultData;
            return new ObjectResult(resultData) { StatusCode = StatusCodes.Status201Created }; ;
        }
    }
}