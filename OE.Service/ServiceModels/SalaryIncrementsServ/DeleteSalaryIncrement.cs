
using OE.Data;

namespace OE.Service.ServiceModels.SalaryIncrementsServ
{
    public class DeleteSalaryIncrement
    {
        public SalaryIncrements SalaryIncrements { get; set; }
        public long SalaryIncrementId { get; set; }
    }
}