using OE.Data;

namespace OE.Service.ServiceModels
{
    public class UpdateStaffLicenses
    {
        public UserAuthentications UserAuthentications { get; set; }
        //[NOTE: Extra]
        public string SelectedOurEduId { get; set; }
        public long SelectedActorId { get; set; }
        public string Message { get; set; }
    }
}

