using DoctorAppointmentBLLibrary;
using DoctorAppointmentDALLibrary;
using DoctorAppointmentModelLibrary.Model;
using System.Numerics;

namespace DoctorAppointmentManagementBLTest
{
    public class DoctorBLTest
    {
        IRepository<int, Doctor> DoctorRepository;
        IDoctorService DoctorBL;
        [SetUp]
        public void Setup()
        {
            DoctorRepository = new DoctorRepository();
            DoctorBL = new DoctorBL(DoctorRepository);
        }

        [Test]
        public void AddDoctorSuccessTest()
        {
            // Arrange
            Appointment appointment = new Appointment(14, 1, Convert.ToDateTime("2024-10-10"), "Pending" );
            HashSet<Appointment> appointments = new HashSet<Appointment>() { appointment };
            Doctor doctor = new Doctor("Bhavana", 36, "GS", "MBBS", 20, appointments);

            // Action
            var result = DoctorBL.AddDoctor(doctor);

            // Assert
            Assert.AreEqual(14, result);
        }

        [Test]
        public void AddDoctorFailExceptionTest()
        {
            //Arrange
            Appointment appointment = new Appointment(1, 1, Convert.ToDateTime("2024-10-10"), "Pending");
            HashSet<Appointment> appointments = new HashSet<Appointment>() { appointment };
            Doctor doctor = new Doctor() { Name = "Tara", Age = 36, Specialization = "GS", Experience = 20, Qualification = "MBBS", Appointments = appointments };

            //Action
            var exception = Assert.Throws<DoctorAlreadyExistsException>(() => DoctorBL.AddDoctor(doctor));

            //Assert
            Assert.AreEqual("Doctor Record already exists!", exception.Message);
        }

        [Test]
        public void ChangeNameSuccessTest()
        {
            // Action
            var result = DoctorBL.ChangeName(1, "Saranya");

            // Assert
            Assert.AreEqual("Saranya", result.Name);
        }

        [Test]
        public void ChangeNameFailExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorDoesNotExistException>(() => DoctorBL.ChangeName(100, "Savi"));

            //Assert
            Assert.AreEqual("Doctor Record does not exist!", exception.Message);
        }

        [Test]
        public void GetAllDoctorsSuccessTest()
        {
            // Action
            var result = DoctorBL.GetAllDoctors();

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetDoctorByIDSuccessTest()
        {
            // Action
            var result = DoctorBL.GetDoctorByID(1);

            // Assert
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void GetDoctorByIDExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorDoesNotExistException>(() => DoctorBL.GetDoctorByID(100));

            //Assert
            Assert.AreEqual("Doctor Record does not exist!", exception.Message);
        }

        [Test]
        public void GetDoctorBySpecializationSuccessTest()
        {
            // Action
            var result = DoctorBL.GetDoctorBySpecialization("GS");

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void DeleteDoctorSuccessTest()
        {
            // Action
            var DeletedDoctor = DoctorBL.DeleteDoctor(4);
            var result = DoctorBL.GetAllDoctors();

            // Assert
            Assert.AreEqual(4, DeletedDoctor.Id);
            Assert.AreEqual(3, result.Count);
        }

        [Test]
        public void DeleteDoctorFailExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorDoesNotExistException>(() => DoctorBL.DeleteDoctor(100));

            //Assert
            Assert.AreEqual("Doctor Record does not exist!", exception.Message);
        }

        [Test]
        public void GetAllDoctorsFailExceptionTest()
        {
            //Arrange
            DoctorBL.DeleteDoctor(1);
            DoctorBL.DeleteDoctor(2);
            DoctorBL.DeleteDoctor(3);
            DoctorBL.DeleteDoctor(5);

            //Action
            var exception = Assert.Throws<NoDoctorRecordsFoundException>(() => DoctorBL.GetAllDoctors());

            //Assert
            Assert.AreEqual("No doctor records found!", exception.Message);
        }

        [Test]
        public void GetDoctorBySpecializationNoDoctorsInCollectionExceptionTest()
        {
            //Arrange
            //DoctorBL.DeleteDoctor(1);
            //DoctorBL.DeleteDoctor(2);
            //DoctorBL.DeleteDoctor(6);
            //Action
            var exception = Assert.Throws<NoDoctorRecordsFoundException>(() => DoctorBL.GetDoctorBySpecialization("GS"));

            //Assert
            Assert.AreEqual("No doctor records found!", exception.Message);
        }

        [Test]
        public void GetDoctorBySpecializationNoDoctorsInSpecializationExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorDoesNotExistException>(() => DoctorBL.GetDoctorBySpecialization("Vet"));
            Console.WriteLine(exception.ToString());
            //Assert
            Assert.AreEqual("Doctor Record does not exist!", exception.Message);
        }

        //[Test]
        //public void GetDoctorAppointmentsSuccessTest()
        //{
        //    // Action
        //    var result = DoctorBL.GetDoctorAppointments(12);

        //    // Assert
        //    Assert.AreEqual(1, result.Count);
        //}

        //[Test]
        //public void GetDoctorAppointmentsExceptionNoAppointmentsTest()
        //{
        //    //Action
        //    var exception = Assert.Throws<NoAppointmentsFoundException>(() => DoctorBL.GetDoctorAppointments(2));

        //    //Assert
        //    Assert.AreEqual("No appointments were found", exception.Message);
        //}

        //[Test]
        //public void GetDoctorAppointmentsNoDoctorExceptionTest()
        //{
        //    //Action
        //    var exception = Assert.Throws<DoctorDoesNotExistException>(() => DoctorBL.GetDoctorAppointments(5));

        //    //Assert
        //    Assert.AreEqual("Doctor Record does not exist!", exception.Message);
        //}
    }
}