using DoctorAppointmentBLLibrary;
using DoctorAppointmentDALLibrary;
using DoctorAppointmentModelLibrary;
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
            Doctor doctor1 = new Doctor() { Name = "Nana", Age = 34, Specialization = "Neuro", Experience = 10, Qualification = "MBBS", Appointments = { 1, 2 } };
            Doctor doctor2 = new Doctor() { Name = "Sana", Age = 36, Specialization = "Vet", Experience = 20, Qualification = "MBBS" };
            DoctorRepository.Add(doctor1);
            DoctorRepository.Add(doctor2);
            DoctorBL = new DoctorBL(DoctorRepository);
        }

        [Test]
        public void AddDoctorSuccessTest()
        {
            // Arrange
            Doctor doctor = new Doctor() { Name = "Tara", Age = 36, Specialization = "GS", Experience = 20, Qualification = "MBBS" };

            // Action
            var result = DoctorBL.AddDoctor(doctor);

            // Assert
            Assert.AreEqual(3, result);
        }

        [Test]
        public void AddDoctorFailExceptionTest()
        {
            //Arrange
            Doctor doctor = new Doctor() { Name = "Nana", Age = 34, Specialization = "Neuro", Experience = 10, Qualification = "MBBS", Appointments = { 3, 4 } };

            //Action
            var exception = Assert.Throws<DoctorAlreadyExistsException>(() => DoctorBL.AddDoctor(doctor));

            //Assert
            Assert.AreEqual("Doctor Record already exists!", exception.Message);
        }

        [Test]
        public void ChangeNameSuccessTest()
        {
            // Action
            var result = DoctorBL.ChangeName(1, "Naina");

            // Assert
            Assert.AreEqual("Naina", result.Name);
        }

        [Test]
        public void ChangeNameFailExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorDoesNotExistException>(() => DoctorBL.ChangeName(3, "Naina"));

            //Assert
            Assert.AreEqual("Doctor Record does not exist!", exception.Message);
        }

        [Test]
        public void GetAllDoctorsSuccessTest()
        {
            // Action
            var result = DoctorBL.GetAllDoctors();

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetAllDoctorsFailExceptionTest()
        {
            //Arrange
            DoctorBL.DeleteDoctor(1);
            DoctorBL.DeleteDoctor(2);

            //Action
            var exception = Assert.Throws<NoDoctorRecordsFoundException>(() => DoctorBL.GetAllDoctors());

            //Assert
            Assert.AreEqual("No doctor records found!", exception.Message);
        }

        [Test]
        public void DeleteDoctorSuccessTest()
        {
            // Action
            var DeletedDoctor = DoctorBL.DeleteDoctor(1);
            var result = DoctorBL.GetAllDoctors();

            // Assert
            Assert.AreEqual(1, DeletedDoctor.Id);
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void DeleteDoctorFailExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorDoesNotExistException>(() => DoctorBL.DeleteDoctor(3));

            //Assert
            Assert.AreEqual("Doctor Record does not exist!", exception.Message);
        }

        [Test]
        public void GetDoctorAppointmentsSuccessTest()
        {
            // Action
            var result = DoctorBL.GetDoctorAppointments(1);

            // Assert
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetDoctorAppointmentsExceptionNoAppointmentsTest()
        {
            //Action
            var exception = Assert.Throws<NoAppointmentsFoundException>(() => DoctorBL.GetDoctorAppointments(2));

            //Assert
            Assert.AreEqual("No appointments were found", exception.Message);
        }

        [Test]
        public void GetDoctorAppointmentsNoDoctorExceptionTest()
        {
            //Action
            var exception = Assert.Throws<DoctorDoesNotExistException>(() => DoctorBL.GetDoctorAppointments(5));

            //Assert
            Assert.AreEqual("Doctor Record does not exist!", exception.Message);
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
            var exception = Assert.Throws<DoctorDoesNotExistException>(() => DoctorBL.GetDoctorByID(5));

            //Assert
            Assert.AreEqual("Doctor Record does not exist!", exception.Message);
        }

        [Test]
        public void GetDoctorBySpecializationSuccessTest()
        {
            // Action
            var result = DoctorBL.GetDoctorBySpecialization("Vet");

            // Assert
            Assert.AreEqual(1, result.Count);
        }

        [Test]
        public void GetDoctorBySpecializationNoDoctorsInSpecializationExceptionTest()
        {
            //Action
            var exception = Assert.Throws<NoDoctorRecordsFoundException>(() => DoctorBL.GetDoctorBySpecialization("GS"));
            Console.WriteLine(exception.ToString());
            //Assert
            Assert.AreEqual("No doctor records found!", exception.Message);
        }

        [Test]
        public void GetDoctorBySpecializationNoDoctorsInCollectionExceptionTest()
        {
            //Arrange
            DoctorBL.DeleteDoctor(1);
            DoctorBL.DeleteDoctor(2);
            //Action
            var exception = Assert.Throws<NoDoctorRecordsFoundException>(() => DoctorBL.GetDoctorBySpecialization("Vet"));
            Console.WriteLine(exception.ToString());
            //Assert
            Assert.AreEqual("No doctor records found!", exception.Message);
        }
    }
}