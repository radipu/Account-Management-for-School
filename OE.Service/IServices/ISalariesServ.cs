
using OE.Service.ServiceModels.SalariesServ;
using OE.Service.ServiceModels.SalarysServ;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service
{
    public interface ISalariesServ
    {
        #region "Get Function Definitions"
        getSalariesList getSalariesList(long staffId, long salaryYear);       
        getStaffList getStaffList(string path);
        ProduceStaffsSalary ProduceStaffsSalary(ProduceStaffsSalary obj);
        #endregion "Get Function Definitions"     
        IEnumerable<dropdown_TermNo> dropdown_TermNo(long StaffId, long salaryYear);
        IEnumerable<dropdown_BonusTermNo> dropdown_BonusTermNo(long StaffId, long salaryYear);

        #region "Insert update and delete Function Definitions"  
        string InsertSalary(InsertSalary obj);
        string UpdateSalary(UpdateSalary obj);
        string DeleteSalary(DeleteSalary obj);
        #endregion "Insert update and delete Function Definitions"  
        

    }
}
