using DoctorAppointmentBLLibrary;
using DoctorAppointmentDALLibrary;
using DoctorAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentManagementBLTest
{
    public class PatientBLTest
    {
        IRepository<int, Patient> PatientRepository;
        IPatientService PatientBL;
        [SetUp]
        public void Setup()
        {
            PatientRepository = new PatientRepository();
            Patient patient1 = new Patient() { Name = "Nana", Age = 34, Gender = "Female", Description = "Fever", Appointments = { 1, 2 } };
            Patient patient2 = new Patient() { Name = "Sana", Age = 36, Gender = "Female", Description = "Headache" };
            PatientRepository.Add(patient1);
            PatientRepository.Add(patient2);
            PatientBL = new PatientBL(PatientRepository);
        }

        [Test]
        public void AddPatientSuccessTest()
        {
            // Arrange
            Patient patient = new Patient()
            {
                Name = "Naina",
                Age = 40,
                Gender = "Female",
                Description = "Fever",
                Appointments = { 1 }
            };

            // Action
            var result = PatientBL.AddPatient(patient);

            // Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void AddPatientExceptionTest()
        {
            // Arrange
            Patient patient = new Patient() { Name = "Nana", Age = 34, Gender = "Female", Description = "Fever", Appointments = { 1, 2 } };

            //Action
            var exception = Assert.Throws<PatientAlreadyExistsException>(() => PatientBL.AddPatient(patient));

            //Assert
            Assert.AreEqual("Patient Record already exists", exception.Message);
        }

        [Test]
        public void ChangePatientNameSuccessTest()
        {

            // Action
            var result = PatientBL.ChangePatientName(1, "Rama");

            // Assert
            Assert.AreEqual("Rama", result.Name);
        }

        [Test]
        public void ChangePatientNameExceptionTest()
        {
            //Action
            var exception = Assert.Throws<PatientDoesNotExistException>(() => PatientBL.ChangePatientName(5, "Lakshi"));

            //Assert
            Assert.AreEqual("Patient Record does not exist", exception.Message);
        }

        [Test]
        public void GetPatientAppointmentsSuccessTest()
        {
            // Action
            var result = PatientBL.GetPatientAppointments(1);

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetPatientAppointmentsExceptionNoAppointmentsTest()
        {
            //Action
            var exception = Assert.Throws<NoAppointmentsFoundException>(() => PatientBL.GetPatientAppointments(2));

            //Assert
            Assert.AreEqual("No appointments were found", exception.Message);
        }

        [Test]
        public void GetPatientAppointmentsNoPatientExceptionTest()
        {
            //Action
            var exception = Assert.Throws<PatientDoesNotExistException>(() => PatientBL.GetPatientAppointments(5));

            //Assert
            Assert.AreEqual("Patient Record does not exist", exception.Message);
        }

        [Test]
        public void GetPatientByIdSuccessTest()
        {
            // Action
            var result = PatientBL.getPatientById(1);

            // Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void GetPatientByIdExceptionTest()
        {
            //Action
            var exception = Assert.Throws<PatientDoesNotExistException>(() => PatientBL.getPatientById(5));

            //Assert
            Assert.AreEqual("Patient Record does not exist", exception.Message);
        }
    }
}