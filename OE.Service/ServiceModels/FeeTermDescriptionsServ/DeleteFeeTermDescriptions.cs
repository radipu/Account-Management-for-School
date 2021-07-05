
using OE.Data;

namespace OE.Service.ServiceModels.FeeTermDescriptionsServ
{
    public class DeleteFeeTermDescriptions
    {
        public DeleteFeeTermDescriptions_FeeTermDescriptions FeeTermDescriptions { get; set; }
        
        public string Message { get; set; }
    }
    public class DeleteFeeTermDescriptions_FeeTermDescriptions : FeeTermDescriptions
    {
       
    }
}