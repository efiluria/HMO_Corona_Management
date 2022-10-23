namespace HMO_Corona_Management.Models
{
    public class VaccinationInfo
    {
        public DateTime? vaccinationDate { get; set; }
        public string? vaccinationManufacturer { get; set; }

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

    }
}
