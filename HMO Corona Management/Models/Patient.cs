using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.CopyAnalysis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/*
 * This Class represents the patient's details
 */

namespace HMO_Corona_Management.Models
{
    public class Patient
    {
        // Properties
        public string id { get; set; } // firebase unique id

        [DisplayName("Full name")]
        public string fullName { get; set; }

        [RegularExpression(@"^[0-9]{1,9}$",
             ErrorMessage = "Characters are not allowed. Use only digits.")]
        [DisplayName("ID")]
        public string patientId { get; set; }

        [DisplayName("City")]
        public string city { get; set; }

        [DisplayName("Street")]
        public string street { get; set; }

        [DisplayName("Apt.")]
        public int apt { get; set; }

        [DisplayName("Date of birth")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime dateOfBirth { get; set; }

        [RegularExpression(@"^[0-9]{2}-[0-9]{7}$",
            ErrorMessage = "Characters are not allowed. Use format '0d-ddddddd.'")]
        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        public string? phone { get; set; }

        [RegularExpression(@"^[0-9]{3}-[0-9]{7}$",
             ErrorMessage = "Characters are not allowed. Use format '0dd-ddddddd.'")]
        [DisplayName("Mobile phone")]
        [DataType(DataType.PhoneNumber)]
        public string mobilePhone { get; set; }
        public List<VaccinationInfo>? vaccinationDetails{get; set;}

        [DisplayName("Positive result date")]
        public DateTime? positiveResultDate { get; set; }

        [DisplayName("Recovery date")]
        public DateTime? recoveryDate { get; set; }
        
        // Ctors
        public Patient()
        {
            id = "";
            fullName = "";
            patientId = "0";
            city = "";
            street = "";
            apt = 0;
            phone = "";
            mobilePhone = "";
            dateOfBirth = new DateTime();
            vaccinationDetails= new List<VaccinationInfo>(3);    

            //vaccinationDetails 

            positiveResultDate = new DateTime();
            recoveryDate = new DateTime();
            
        }
        public Patient(string _id, string _fullName, string _patientId,string _city,string _street,int _apt,string _phone,string _mobilePhone,DateTime _dateOfBirth, List<VaccinationInfo> _vaccinationDetails, DateTime _positiveResultDate, DateTime _recoveryDate)
        {
            id = _id;
            fullName = _fullName;
            patientId = _patientId;
            city = _city;
            street =_street;
            apt = _apt;
            phone = _phone;
            mobilePhone = _mobilePhone;
            dateOfBirth =_dateOfBirth;
            if (_vaccinationDetails is not null)
            {
                for (int i = 0; i < _vaccinationDetails.Count(); i++)
                {
                    vaccinationDetails[i].vaccinationDate = _vaccinationDetails[i].vaccinationDate;
                    vaccinationDetails[i].vaccinationManufacturer =_vaccinationDetails[i].vaccinationManufacturer;
                }

            }
            positiveResultDate =_positiveResultDate;
            recoveryDate = _recoveryDate;
        }
        public Patient(Patient patient)
        {
            id = patient.id;
            fullName = patient.fullName;
            patientId = patient.patientId;
            city = patient.city;
            street = patient.street;
            apt = patient.apt;
            phone = patient.phone;
            mobilePhone = patient.mobilePhone;
            dateOfBirth = new DateTime();
            if (patient.vaccinationDetails is not null)
            {
                for (int i = 0; i < patient.vaccinationDetails.Count(); i++)
                {
                    vaccinationDetails[i].vaccinationDate = patient.vaccinationDetails[i].vaccinationDate;
                    vaccinationDetails[i].vaccinationManufacturer = patient.vaccinationDetails[i].vaccinationManufacturer;
                }

            }
            positiveResultDate = patient.positiveResultDate;
            recoveryDate = patient.recoveryDate;
        }

    }
}
