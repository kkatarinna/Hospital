﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Hospital.Controller;
using Hospital.Observer;
using Hospital.Serializer;
using Hospital.Storage;

namespace Hospital.Model.DAO
{
    /// <summary>
    /// Model represents data of the application.
    /// It can also contain Hospital and can encapsulate business logic.
    /// DAO (Data access object) is a special form of model class
    /// that contains data and is used by controller to access the data.
    /// </summary>
    public class AppointmentDAO : ISubject
    {
        private List<IObserver> _observers;

        private AppointmentStorage _storage;
        private List<Appointment> _appointments;

        private static AppointmentDAO instance = null;
        public static AppointmentDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AppointmentDAO();
                }
                return instance;
            }
        }
        private AppointmentDAO()
        {
            _storage = new AppointmentStorage(new JSONSerializer<Appointment>());
            _appointments = _storage.Load();
            _observers = new List<IObserver>();
        }

        public List<Appointment> GetPatientAppointments(int patientId)
        {
            List<Appointment> patientAppointments = new List<Appointment>();
            foreach (Appointment appointment in _appointments)
            {
                if (appointment.IdPatient == patientId)
                {
                    patientAppointments.Add(appointment);
                }
            }
            return patientAppointments;
        }

        public List<Appointment> GetPastAppointments(int patientId)
        {
            List<Appointment> pastAppointments = new List<Appointment> ();
            List<Appointment> patientAppoinments = GetPatientAppointments(patientId);
            foreach (Appointment appointment in patientAppoinments)
            {
                if (appointment.TimeSlot.Start < DateTime.Now)
                {
                    pastAppointments.Add(appointment);
                }
            }
            return pastAppointments;
        }

        public Appointment GetPatientReception(int patientId)
        {
            List<Appointment> patientAppointments = GetPatientAppointments(patientId);
            foreach (Appointment appointment in patientAppointments)
            {
                TimeSpan diff = appointment.TimeSlot.Start - DateTime.Now;
                if ( diff < new TimeSpan(0,15,0) && diff > new TimeSpan(0, 0, 0))
                {
                    return appointment;
                }

            }
            return null;
        }

        public List<Appointment> GetAppointmentsByRoom(string roomNumber)
        {
            List<Appointment> appointments = new List<Appointment>();
            foreach (Appointment appointment in _appointments)
            {
                if (appointment.RoomNumber == roomNumber)
                {
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }

        public TimeSlot FindFreeTimeSlot(int doctorId, DateTime before)
        {
            DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddHours(1).Hour, 0, 0);
            TimeSlot appointmentTimeSlot = new TimeSlot(now, 15);
            while (true)
            {
                if (appointmentTimeSlot.Start > before)
                {
                    return null;
                }

                if (IsAvailable(doctorId, appointmentTimeSlot))
                {
                    break;
                }
                appointmentTimeSlot.Start = appointmentTimeSlot.Start.AddMinutes(15);
            }
            return appointmentTimeSlot;
        }

        public TimeSlot FindFreeTimeSlot(int doctorId, TimeSpan from, TimeSpan to, DateTime before)
        {
            DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddHours(1).Hour, 0, 0);
            TimeSlot appointmentTimeSlot = new TimeSlot(now, 15);
            while (true)
            {
                if (appointmentTimeSlot.Start > before)
                {
                    return null;
                }
                if (appointmentTimeSlot.Start.TimeOfDay > to)
                {
                    appointmentTimeSlot.Start=appointmentTimeSlot.Start.AddHours(15);
                }
                if (IsAvailable(doctorId, appointmentTimeSlot) && appointmentTimeSlot.Start.TimeOfDay>=from && appointmentTimeSlot.Start.TimeOfDay<=to)
                {
                    break;
                }
                appointmentTimeSlot.Start = appointmentTimeSlot.Start.AddMinutes(15);
            }
            return appointmentTimeSlot;
        }

        //HARDCODED ROOM NUMBER NEEDS CHANGE!!!!
        //TREBA POMERITI U GetAppointmentService
        public List<Appointment> FindSuggestedAppointments(List<Doctor> doctors)
        {
            List<Appointment> suggestedAppointments = new List<Appointment>();
            DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.AddHours(1).Hour, 0, 0);
            TimeSlot timeSlot = new TimeSlot(now, 15);
            while (suggestedAppointments.Count < 3)
            {
                foreach(Doctor doctor in doctors)
                {
                    if(IsAvailable(doctor.Id, timeSlot)){
                        suggestedAppointments.Add(new Appointment(NextId(), doctor.Id, 2, false, timeSlot, "", doctor.Specialization,"04C")) ;
                       
                        if (suggestedAppointments.Count == 3)
                        {
                            break;
                        }
                    }
                }
                timeSlot.Start = timeSlot.Start.AddMinutes(15);
                
            }
            return suggestedAppointments;
        }

        public bool IsAvailable(int doctorId, TimeSlot requestedTimeSlot)
        {
            List<Appointment> _doctorAppointments = GetAllDoctorAppointments(doctorId);
            return isDoctorFree(_doctorAppointments, requestedTimeSlot);
        }

        public List<Appointment> GetAllDoctorAppointments(int doctorId)
        {
            List<Appointment> doctorAppointments = new List<Appointment>();
            foreach (var appointment in _appointments)
            {
                if (appointment.IdDoctor == doctorId)
                {
                    doctorAppointments.Add(appointment);
                }
            }
            return doctorAppointments;
        }
        public List<Appointment> GetAllRoomAppointments(string roomNumber)
        {
            List<Appointment> roomAppointments = new List<Appointment>();
            foreach (var appointment in _appointments)
            {
                if (appointment.RoomNumber == roomNumber)
                {
                    roomAppointments.Add(appointment);
                }
            }
            return roomAppointments;
        }

        private bool isDoctorFree(List<Appointment> doctorAppointments, TimeSlot requestedTimeSlot)
        {
            foreach (Appointment appointment in doctorAppointments)
            {
                if(appointment.TimeSlot.Start<=requestedTimeSlot.Start && 
                   appointment.TimeSlot.Start.AddMinutes(appointment.TimeSlot.Duration) > requestedTimeSlot.Start)
                {
                    return false;
                }
            }
            return true;
        }
        public int NextId()
        {
            return _appointments.Max(s => s.Id) + 1;
        }

        public void Add(Appointment appointment)
        {
            appointment.Id = NextId();
            _appointments.Add(appointment);
            _storage.Save(_appointments);
            NotifyObservers();
        }

        public void Update()
        {
            _storage.Save(_appointments);
            NotifyObservers();
        }

        public void Remove(Appointment appointment)
        {
            _appointments.Remove(appointment);
            _storage.Save(_appointments);
            NotifyObservers();
        }

        public List<Appointment> GetAll()
        {
            return _appointments;
        }

        public void Subscribe(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update();
            }
        }
        private DateTime StartOfDay()
        {
            return new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                8,
                0,
                0);
        }
        private DateTime EndOfDay()
        {
            return new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                20,
                0,
                0);
        }
    }
}