using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CsvHelper;
using System.IO;

namespace PatientsTypeahead.Models
{
    /// <summary>
    /// static class which will be invoked from controller
    /// </summary>
    public static class PatientData
    {
        /// <summary>
        /// this method returns the list of patients
        /// </summary>
        /// <param name="searchText">first name or last name</param>
        /// <returns></returns>
        public static List<Patient> ReadPatients(string searchText)
        {
            List<Patient> patientList = null;
            List<Patient> searchList = null;
            // open the file which is stored in app_data folder
            using (TextReader fileReader = File.OpenText(
                Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath,
                "App_Data", "patients.csv")))
            {
                // use the third party nuget package csvhelper to read the csv 
                CsvReader csvReader = new CsvReader(fileReader);
                // as the csv is having headers set the below flag to true
                csvReader.Configuration.HasHeaderRecord = true;
                // convert all the records from csv to view model and to list
                patientList = csvReader.GetRecords<Patient>().ToList();
                // check if patient list is not null 
                if (patientList?.Count > 0)
                {
                    // search with first name or last name using contains.
                    // based on the requirement , this can be changed to startsWtih as well.
                    searchList = patientList.Where(patient => patient.firstName.ToLowerInvariant().Contains(searchText) ||
                                                patient.lastName.ToLowerInvariant().Contains(searchText))
                                                .Select(patient => patient)
                                                .ToList();
                }
            }
            // return the list 
            return searchList;
        }
    }
}