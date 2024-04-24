using DoctorAppointmentBLLibrary;
using DoctorAppointmentDALLibrary;
using DoctorAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentManagementBLTest
{
    public class AppointmentBLTest
    {
        IRepository<int, Appointment> AppointmentRepository;
        IAppointmentService AppointmentBL;
        [SetUp]
        public void Setup()
        {
            AppointmentRepository = new AppointmentRepository();
            Appointment appointment1 = new Appointment() { doctorId = 1, patientId = 1, AppointmentDate = Convert.ToDateTime("2024-04-24") };
            Appointment appointment2 = new Appointment() { doctorId = 2, patientId = 1, AppointmentDate = Convert.ToDateTime("2024-04-25") };
            AppointmentRepository.Add(appointment1);
            AppointmentRepository.Add(appointment2);
            AppointmentBL = new AppointmentBL(AppointmentRepository);
        }

        [Test]
        public void AddAppointmentSuccessTest()
        {
            // Arrange
            Appointment appointment = new Appointment() { doctorId = 3, patientId = 1, AppointmentDate = Convert.ToDateTime("2024 - 04 - 24") };

            // Action
            var result = AppointmentBL.AddAppointment(appointment);

            // Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void AddAppointmentExceptionTest()
        {
            // Arrange
            Appointment appointment = new Appointment() { doctorId = 1, patientId = 1, AppointmentDate = Convert.ToDateTime("2024 - 04 - 24") };

            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => AppointmentBL.AddAppointment(appointment));

            //Assert
            Assert.AreEqual("Appointment is not found", exception.Message);
        }

        [Test]
        public void CancelAppointmentSuccessTest()
        {
            // Action
            var result = AppointmentBL.CancelAppointment(1);

            // Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void CancelAppointmentExceptionTest()
        {
            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => AppointmentBL.CancelAppointment(5));

            //Assert
            Assert.AreEqual("Appointment is not found", exception.Message);
        }

        [Test]
        public void ChangeDateSuccessTest()
        {
            // Action
            var result = AppointmentBL.ChangeDate(1, Convert.ToDateTime("2024-10-10"));

            // Assert
            Assert.AreEqual(Convert.ToDateTime("2024-10-10"), result.AppointmentDate);
        }

        [Test]
        public void ChangeDateExceptionTest()
        {
            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => AppointmentBL.ChangeDate(5, Convert.ToDateTime("2024-10-10")));

            //Assert
            Assert.AreEqual("Appointment is not found", exception.Message);
        }

        [Test]
        public void GetAppointmentByIdSuccessTest()
        {
            // Action
            var result = AppointmentBL.GetAppointmentById(1);

            // Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void GetAppointmentByIdExceptionTest()
        {
            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => AppointmentBL.GetAppointmentById(5));

            //Assert
            Assert.AreEqual("Appointment is not found", exception.Message);
        }

        [Test]
        public void GetAppointmentsByAppointmentDateSuccessTest()
        {
            // Action
            var result = AppointmentBL.GetAppointmentsByAppointmentDate(Convert.ToDateTime("2024 - 04 - 24"));

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetAppointmentsByAppointmentDateNoAppointmentsInDateExceptionTest()
        {
            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => AppointmentBL.GetAppointmentsByAppointmentDate(Convert.ToDateTime("2024 - 04 - 23")));

            //Assert
            Assert.AreEqual("Appointment is not found", exception.Message);
        }

        [Test]
        public void GetAppointmentsByAppointmentDateNoAppointmentsExceptionTest()
        {
            //Arrange
            AppointmentBL.CancelAppointment(1);
            AppointmentBL.CancelAppointment(2);

            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => AppointmentBL.GetAppointmentsByAppointmentDate(Convert.ToDateTime("2024 - 04 - 23")));

            //Assert
            Assert.AreEqual("Appointment is not found", exception.Message);
        }
    }
}