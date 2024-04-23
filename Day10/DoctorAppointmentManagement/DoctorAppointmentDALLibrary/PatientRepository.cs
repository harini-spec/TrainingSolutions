using DoctorAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentDALLibrary
{
        public class PatientRepository : IRepository<int, Patient>
        {
            readonly Dictionary<int, Patient> _patients;
            public PatientRepository()
            {
                _patients = new Dictionary<int, Patient>();
            }
            
            /// <summary>
            /// Automatically generates ID for Patients 
            /// </summary>
            /// <returns>ID as int type</returns>
            public int GenerateId()
            {
                if (_patients.Count() == 0)
                    return 1;
                int id = _patients.Keys.Max();
                return ++id;
            }
            
            /// <summary>
            /// Checks if the value is already present. If not, creates a new entry in the Patient Dictionary 
            /// </summary>
            /// <param name="item">Patient Object</param>
            /// <returns>Inserted Patient Object</returns>
            public Patient Add(Patient item)
            {
                if (_patients.ContainsValue(item))
                {
                    return null;
                }
                item.Id = GenerateId();
                _patients.Add(item.Id, item);
                return item;
            }
            
            /// <summary>
            /// Checks if the given ID is present. If found, deletes the Patient record in the given ID 
            /// </summary>
            /// <param name="key">ID of the Patient</param>
            /// <returns>Deleted Patient data if present, else null</returns>
            public Patient Delete(int key)
            {
                if (_patients.ContainsKey(key))
                {
                    Patient patient = _patients[key];
                    _patients.Remove(key);
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
                if(_patients.ContainsKey(key))
                    return _patients[key];
                return null;
            }
            
            /// <summary>
            /// Gets all the Patient records
            /// </summary>
            /// <returns>Patient records as a List</returns>
            public List<Patient> GetAll()
            {
                if (_patients.Count == 0)
                    return null;
                return _patients.Values.ToList();
            }
            
            /// <summary>
            /// Updates the existing patient record 
            /// </summary>
            /// <param name="item">Patient record</param>
            /// <returns>Updated Patient record</returns>
            public Patient Update(Patient item)
            {
                if (_patients.ContainsValue(item))
                {
                    _patients[item.Id] = item;
                    return _patients[item.Id];
                }
                return null;
            }

    }
}
