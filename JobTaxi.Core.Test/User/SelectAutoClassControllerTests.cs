using JobTaxi.Entity;
using JobTaxiService.Controllers.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTaxi.Core.Test.User
{
    public class SelectAutoClassControllerTests
    {
        [Fact]
        public void IndexViewDataMessage()
        {
            LoggerFactory loggerFactory = new LoggerFactory();
            IJobRepository _jobRepository = new JobRepository(loggerFactory);
            // Arrange
            SelectAutoClassController controller = new SelectAutoClassController(loggerFactory, _jobRepository);

            // Act
            var result = controller.Create(new Entity.Dto.User.SelectAutoClassDto 
            { 
                AutoClassId = 1,
                UserFilterId = 1,
                UserId = 129

            });

            // Assert
            Assert.IsType<int>(result?.Id);
        }
    }
}
