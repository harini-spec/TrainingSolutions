using DoctorAppointmentBLLibrary;
using DoctorAppointmentDALLibrary;
using DoctorAppointmentModelLibrary.Model;
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
            PatientBL = new PatientBL(PatientRepository);
        }

        [Test]
        public void AddPatientSuccessTest()
        {
            // Arrange
            Appointment appointment = new Appointment(12, 2, Convert.ToDateTime("2024-10-10"), "Pending");
            HashSet<Appointment> appointments = new HashSet<Appointment>() { appointment };
            Patient patient = new Patient("Nana", 34, "Female", appointments );

            // Action
            var result = PatientBL.AddPatient(patient);

            // Assert
            Assert.AreEqual(2, result);
        }

        [Test]
        public void AddPatientExceptionTest()
        {
            // Arrange
            Appointment appointment = new Appointment(12, 2, Convert.ToDateTime("2024-10-10"), "Pending");
            HashSet<Appointment> appointments = new HashSet<Appointment>() { appointment };
            Patient patient = new Patient("Nana", 34, "Female", appointments);
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
            var exception = Assert.Throws<PatientDoesNotExistException>(() => PatientBL.ChangePatientName(100, "Lakshi"));

            //Assert
            Assert.AreEqual("Patient Record does not exist", exception.Message);
        }

        [Test]
        public void GetPatientAppointmentsSuccessTest()
        {
            // Action
            var result = PatientBL.GetPatientAppointments(1);

            // Assert
            Assert.AreEqual(4, result.Count);
        }

        [Test]
        public void GetPatientAppointmentsExceptionNoAppointmentsTest()
        {
            //Action
            var exception = Assert.Throws<NoAppointmentsFoundException>(() => PatientBL.GetPatientAppointments(4));

            //Assert
            Assert.AreEqual("No appointments were found", exception.Message);
        }

        [Test]
        public void GetPatientAppointmentsNoPatientExceptionTest()
        {
            //Action
            var exception = Assert.Throws<PatientDoesNotExistException>(() => PatientBL.GetPatientAppointments(100));

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
            var exception = Assert.Throws<PatientDoesNotExistException>(() => PatientBL.getPatientById(100));

            //Assert
            Assert.AreEqual("Patient Record does not exist", exception.Message);
        }
    }
}