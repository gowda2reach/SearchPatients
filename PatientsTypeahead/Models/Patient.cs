using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientsTypeahead.Models
{
    /// <summary>
    /// view model to hold the patient data from csv
    /// </summary>
    public class Patient
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string dateOfbirth { get; set; }
        public string phoneNumber { get; set; }
    }
}