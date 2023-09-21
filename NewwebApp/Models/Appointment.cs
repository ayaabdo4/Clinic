﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text.Json.Serialization;

namespace NewwebApp.Models
{
    public class Appointment
    {

        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public string Status { get; set; } = "free";

        public string Detail { get; set; }




    }

    
}