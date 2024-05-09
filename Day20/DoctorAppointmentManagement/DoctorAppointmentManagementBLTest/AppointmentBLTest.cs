using DoctorAppointmentBLLibrary;
using DoctorAppointmentDALLibrary;
using DoctorAppointmentModelLibrary.Model;
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
            AppointmentBL = new AppointmentBL(AppointmentRepository);
        }

        [Test]
        public void AddAppointmentSuccessTest()
        {
            // Arrange
            Appointment appointment = new Appointment(14, 2, Convert.ToDateTime("2024-10-20"), "Pending");

            // Action
            var result = AppointmentBL.AddAppointment(appointment);

            // Assert
            Assert.AreEqual(20, result);
        }

        [Test]
        public void AddAppointmentExceptionTest()
        {
            // Arrange
            Appointment appointment = new Appointment(12, 1, Convert.ToDateTime("2024-10-20"), "Pending");

            //Action
            var exception = Assert.Throws<AppointmentAlreadyExistsException>(() => AppointmentBL.AddAppointment(appointment));

            //Assert
            Assert.AreEqual("Appointment already exists!", exception.Message);
        }

        [Test]
        public void CancelAppointmentSuccessTest()
        {
            // Action
            var result = AppointmentBL.CancelAppointment(8);

            // Assert
            Assert.AreEqual(8, result.Id);
        }

        [Test]
        public void CancelAppointmentExceptionTest()
        {
            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => AppointmentBL.CancelAppointment(100));

            //Assert
            Assert.AreEqual("Appointment is not found", exception.Message);
        }

        [Test]
        public void ChangeDateSuccessTest()
        {
            // Action
            var result = AppointmentBL.ChangeDate(9, Convert.ToDateTime("2024-8-10"));

            // Assert
            Assert.AreEqual(Convert.ToDateTime("2024-8-10"), result.AppointmentDate);
        }

        [Test]
        public void ChangeDateExceptionTest()
        {
            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => AppointmentBL.ChangeDate(100, Convert.ToDateTime("2024-10-10")));

            //Assert
            Assert.AreEqual("Appointment is not found", exception.Message);
        }

        [Test]
        public void GetAppointmentByIdSuccessTest()
        {
            // Action
            var result = AppointmentBL.GetAppointmentById(10);

            // Assert
            Assert.AreEqual(10, result.Id);
        }

        [Test]
        public void GetAppointmentByIdExceptionTest()
        {
            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => AppointmentBL.GetAppointmentById(100));

            //Assert
            Assert.AreEqual("Appointment is not found", exception.Message);
        }

        [Test]
        public void GetAppointmentsByAppointmentDateSuccessTest()
        {
            // Action
            var result = AppointmentBL.GetAppointmentsByAppointmentDate(Convert.ToDateTime("2024 - 10 - 10"));

            // Assert
            Assert.AreEqual(3, result.Count);
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
            AppointmentBL.CancelAppointment(9);
            AppointmentBL.CancelAppointment(10);
            AppointmentBL.CancelAppointment(11);
            AppointmentBL.CancelAppointment(12);
            AppointmentBL.CancelAppointment(13);

            //Action
            var exception = Assert.Throws<AppointmentNotFoundException>(() => AppointmentBL.GetAppointmentsByAppointmentDate(Convert.ToDateTime("2024 - 04 - 23")));

            //Assert
            Assert.AreEqual("Appointment is not found", exception.Message);
        }
    }
}