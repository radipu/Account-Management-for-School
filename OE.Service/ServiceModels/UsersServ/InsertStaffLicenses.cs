using OE.Data;

namespace OE.Service.ServiceModels
{
    public class InsertStaffLicenses
    {
        public UserAuthentications UserAuthentications { get; set; }
        //[NOTE: Extra]
        public string OurEduId { get; set; }
        public string Message { get; set; }
    }
}

