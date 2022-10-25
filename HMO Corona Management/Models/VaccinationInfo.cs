namespace HMO_Corona_Management.Models
{
    /*
     * This Class represents the details of the patient vaccinations
     */
    public class VaccinationInfo
    {
        // Properties
        public DateTime? vaccinationDate { get; set; }
        public string? vaccinationManufacturer { get; set; }

        // Ctors
        public VaccinationInfo()
        {
            vaccinationDate = new DateTime();
            vaccinationManufacturer = "";
        }
        public VaccinationInfo(DateTime _vaccinationDate,string _vaccinationManufacturer)
        {
            vaccinationDate = _vaccinationDate;
            vaccinationManufacturer = _vaccinationManufacturer;
        }

        public VaccinationInfo(VaccinationInfo _vaccinationInfo)
        {
            vaccinationDate = _vaccinationInfo.vaccinationDate;
            vaccinationManufacturer = _vaccinationInfo.vaccinationManufacturer;
        }

    }
}
