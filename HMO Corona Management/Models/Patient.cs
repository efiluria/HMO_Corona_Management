using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow.CopyAnalysis;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HMO_Corona_Management.Models
{
    public class Patient
    {
        public string id { get; set; } // firebase unique id

        [DisplayName("Full name")]
        public string fullName { get; set; }

        [RegularExpression(@"^[0-9]{1,9}$",
             ErrorMessage = "Characters are not allowed.")]
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

        [DisplayName("Phone")]
        [DataType(DataType.PhoneNumber)]
        public string? phone { get; set; }

        [DisplayName("Mobile phone")]
        [DataType(DataType.PhoneNumber)]
        public string mobilePhone { get; set; }


        private List<VaccinationInfo>? _vaccinationDetails;
        public List<VaccinationInfo>? vaccinationDetails
        {

            get { return _vaccinationDetails; }

            //set { _vaccinationDetails.AddRange(value); }

            set
            {
                if (value is not null)
                {
                    for (int i = 0; i < value.Count(); i++)
                    {
                        _vaccinationDetails[i].vaccinationDate = value[i].vaccinationDate;
                        _vaccinationDetails[i].vaccinationManufacturer = value[i].vaccinationManufacturer;
                    }

                }
                else
                {
                    _vaccinationDetails = value;
                }
            }
        }

        //Pfizer, Moderna, AZ 

        [DisplayName("Positive result date")]
        public DateTime? positiveResultDate { get; set; }

        [DisplayName("Recovery date")]
        public DateTime? recoveryDate { get; set; }

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
            _vaccinationDetails = new List<VaccinationInfo>(3)
            {
                new VaccinationInfo(),new VaccinationInfo(),new VaccinationInfo(),new VaccinationInfo(),
            };
            positiveResultDate = new DateTime();
            recoveryDate = new DateTime();
        }
        public Patient(Patient patient)
        {
            id = patient.id;
            fullName =  patient.fullName;
            patientId = patient.patientId;
            city = patient.city;
            street = patient.street;    
            apt= patient.apt;
            phone = patient.phone;
            mobilePhone = patient.mobilePhone;
            dateOfBirth= new DateTime();
            if(patient.vaccinationDetails is not null)
            {
                for (int i = 0; i < patient.vaccinationDetails.Count(); i++)
                {
                    _vaccinationDetails[i].vaccinationDate = patient.vaccinationDetails[i].vaccinationDate;
                    _vaccinationDetails[i].vaccinationManufacturer= patient.vaccinationDetails[i].vaccinationManufacturer;
                }

            }
            positiveResultDate = patient.positiveResultDate;
            recoveryDate = patient.recoveryDate;
        }

    }
}
