using EmployeeRequestTrackerAppWithAPI.Contexts;
using EmployeeRequestTrackerAppWithAPI.Models;
using EmployeeRequestTrackerAppWithAPI.Repositories;
using EmployeeRequestTrackerAppWithAPI.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeRequestTrackerApplnTest
{
    public class EmployeeRepositoryTest
    {
        RequestTrackerContext context;
        [SetUp]
        public void Setup()
        {
            DbContextOptionsBuilder optionsBuilder = new DbContextOptionsBuilder()
                                                        .UseInMemoryDatabase("dummyDB");
            context = new RequestTrackerContext(optionsBuilder.Options);

        }
        [Test]
        public async Task GetEmployeeTest()
        {
            //Arrange
            IRepository<int, Employee> employeeRepo = new EmployeeRepository(context);
            await employeeRepo.Add(new Employee
            {
                Id = 101,
                Name = "Test1",
                DateOfBirth = new DateTime(2002, 12, 12),
                Phone = "9988776655",
                Role = "Admin",
                Image = ""
            });
            IEmployeeService employeeService = new EmployeeBasicService(employeeRepo);

            //Action
            var result = await employeeService.GetEmployeeByPhone("9988776655");
            
            //Assert
            Assert.That(result, Is.Not.Null);
        }

        [Test]
        public async Task SuccessTest()
        {
            //Arrange
            IRepository<int, Employee> employeeRepo = new EmployeeRepository(context);

            //Action
            var result = await employeeRepo.GetById(101);

            //Assert
            Assert.That(101, Is.EqualTo(result.Id));
        }
    }
}
