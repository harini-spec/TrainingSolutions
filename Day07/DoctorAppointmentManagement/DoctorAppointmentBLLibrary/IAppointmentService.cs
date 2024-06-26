﻿using DoctorAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointmentBLLibrary
{
    public interface IAppointmentService
    {
        int AddAppointment(Appointment appointment);
        Appointment GetAppointmentById(int id);
        List<Appointment> GetAppointmentsByPatientName(string PatientName);
        List<Appointment> GetAppointmentsByDoctorName(string DoctorName);
        List<Appointment> GetAppointmentsByAppointmentDate(DateTime date);
        Appointment UpdateStatus(int id, string status);
        Appointment ChangeDate(int id, DateTime newDate);
        Appointment CancelAppointment(int id);

    }
}
