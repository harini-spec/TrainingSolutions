using DoctorAppointmentModelLibrary.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
        public class PatientRepository : IRepository<int, Patient>
        {
            readonly DoctorAppointmentContext context;
            public PatientRepository()
            {
                context = new DoctorAppointmentContext();
            }
            
            /// <summary>
            /// Checks if the value is already present. If not, creates a new entry in the Patient Dictionary 
            /// </summary>
            /// <param name="item">Patient Object</param>
            /// <returns>Inserted Patient Object</returns>
            public Patient Add(Patient item)
            {
                if (context.Patients.ToList().Contains(item))
                {
                    return null;
                }
                context.Patients.Add(item);
                context.SaveChanges();
                return item;
            }
            
            /// <summary>
            /// Checks if the given ID is present. If found, deletes the Patient record in the given ID 
            /// </summary>
            /// <param name="key">ID of the Patient</param>
            /// <returns>Deleted Patient data if present, else null</returns>
            public Patient Delete(int key)
            {
                List<Patient> patients = context.Patients.ToList();
                Patient patient = patients.SingleOrDefault(x => x.Id == key);
                if (patient != null)
                {
                    context.Patients.Remove(patient);
                    context.SaveChanges();
                    return patient;
                }
                else
                {
                    return null;
                }
            }
            
            /// <summary>
            /// Gets the Patient record of given ID
            /// </summary>
            /// <param name="key">ID of the patient</param>
            /// <returns>Patient record if present, else null</returns>
            public Patient Get(int key)
            {
                Patient patient = context.Patients.Include(p => p.Appointments).SingleOrDefault(x => x.Id == key);
                if (patient != null)
                    return patient;
                return null;
            }
            
            /// <summary>
            /// Gets all the Patient records
            /// </summary>
            /// <returns>Patient records as a List</returns>
            public List<Patient> GetAll()
            {
                List<Patient> patients = context.Patients.Include(p => p.Appointments).ToList();
                    if (patients.Count != 0)
                        return patients;
                return null;
            }
            
            /// <summary>
            /// Updates the existing patient record 
            /// </summary>
            /// <param name="item">Patient record</param>
            /// <returns>Updated Patient record</returns>
            public Patient Update(Patient item)
            {
                List<Patient> patients = context.Patients.ToList();
                Patient patient = patients.SingleOrDefault(x => x.Id == item.Id);
                if (patient != null)
                {
                    patient = item;
                    context.Patients.Update(patient);
                    context.SaveChanges();
                    return patient;
                }
                return null;
            }

    }
}
