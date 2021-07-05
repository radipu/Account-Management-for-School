
using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels.PayScalesServ;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OE.Service
{
    public class PayScalesServ : IPayScalesServ
    {
        #region "Variables"
        private readonly IPayScalesRepo<PayScales> _PayScalesRepo;
        private readonly IDesignationsRepo<Designations> _DesignationsRepo;       
        private readonly IStaffsRepo<Staffs> _StaffsRepo;      
        #endregion "Variables"

        #region "Constructor"
        public PayScalesServ(IPayScalesRepo<PayScales> PayScalesRepo,           
            IStaffsRepo<Staffs> StaffsRepo,           
            IDesignationsRepo<Designations> DesignationsRepo)
        {
            _PayScalesRepo = PayScalesRepo;
            _DesignationsRepo = DesignationsRepo;         
            _StaffsRepo = StaffsRepo;           
        }
        #endregion "Constructor"

        #region "Get Methods"  
        public getPayScalesList getPayScalesList()
        {
            var model = new getPayScalesList();
            try
            {
                var PayScalesList = _PayScalesRepo.GetAll().ToList();
                var DesignationsList = _DesignationsRepo.GetAll().ToList();               
                var StaffsList = _StaffsRepo.GetAll().ToList();               
                var query = (from _PayScales in PayScalesList                              
                             join _Staffs in StaffsList on _PayScales?.StaffId equals _Staffs?.Id
                             join _Designation in DesignationsList on _Staffs?.DesignationId equals _Designation?.Id
                              select new { _PayScales, _Staffs , _Designation });
                          
                var list = new List<getPayScalesList_PayScales>();
                foreach (var item in query)
                {
                    var temp = new getPayScalesList_PayScales()
                    {
                        Id = item._PayScales.Id,                        
                        StaffId=item._PayScales.StaffId,
                        StaffName=item._Staffs.FirstName+" "+item._Staffs.LastName,
                        DesignationId = item._Staffs.DesignationId,                       
                        SalaryYear = item._PayScales.SalaryYear,                      
                        DesignationName = item._Designation.Name,
                        BasicSalary=item._PayScales.BasicSalary,
                        BasicSalaryTermNo=item._PayScales.BasicSalaryTermNo,
                        BonusSalary=item._PayScales.BonusSalary,
                        BonusSalaryTermNo=item._PayScales.BonusSalaryTermNo   
                        
                    };
                    list.Add(temp);
                };
                model = new getPayScalesList()
                {
                    _PayScales = list
                };

            }
            catch (Exception)
            {

            }
            return model;
        }
        #endregion "Get Methods" 

        
        #region "Insert update and delete Function"  
        public string InsertPayScale(InsertPayScale obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    if (obj.PayScales != null)
                    {
                        DateTime SalaryYear = DateTime.ParseExact(obj.PayScales.Year, "yyyy", null);
                        var PayScales = new InsertPayScale_PayScales()
                        {
                            StaffId = obj.PayScales.StaffId,
                            BasicSalary = obj.PayScales.BasicSalary,
                            SalaryYear = SalaryYear,
                            BasicSalaryTermNo = obj.PayScales.BasicSalaryTermNo,
                            BonusSalary = obj.PayScales.BonusSalary,
                            BonusSalaryTermNo = obj.PayScales.BonusSalaryTermNo
                        };
                        _PayScalesRepo.Insert(PayScales);
                        returnResult = "Saved";
                    }
                }
            }
            catch (Exception ex)
            {
                returnResult = "ERROR102:ClassesServ/InsertClassessList - " + ex.Message;
            }
            return returnResult;
        }
        public string UpdatePayScale(UpdatePayScale obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    if (obj.PayScales != null)
                    {
                        DateTime SalaryYear = DateTime.ParseExact(obj.PayScales.Year, "yyyy", null);
                        var currentItem = _PayScalesRepo.Get(obj.PayScales.Id);
                        currentItem.StaffId = obj.PayScales.StaffId;
                        currentItem.BasicSalary = obj.PayScales.BasicSalary;
                        currentItem.SalaryYear = SalaryYear;
                        currentItem.BasicSalaryTermNo = obj.PayScales.BasicSalaryTermNo;
                        currentItem.BonusSalary = obj.PayScales.BonusSalary;
                        currentItem.BonusSalaryTermNo = obj.PayScales.BonusSalaryTermNo;
                        _PayScalesRepo.Update(currentItem);
                        returnResult = "Saved";
                    }
                }
            }
            catch (Exception ex)
            {
                returnResult = "ERROR102:FeeTypesServ/UpdateFeeTypes - " + ex.Message;
            }
            return returnResult;
        }
        public DeletePayScale DeletePayScale(DeletePayScale obj)
        {
            var returnModel = new DeletePayScale();
            var PayScales = _PayScalesRepo.Get(obj.PayScalesId);
            if (PayScales != null)
            {
                _PayScalesRepo.Delete(PayScales);
            }
            return returnModel;
        }
        #endregion "Insert update and delete Function"  
       
        private decimal netSalary(long StaffId)
        {
            var  model= 0;
            var PayScalesList = _PayScalesRepo.GetAll();
            var DesignationsList = _DesignationsRepo.GetAll();
            var StaffsList = _StaffsRepo.GetAll();
            var query = (from _PayScales in PayScalesList
                         join _Staffs in StaffsList on _PayScales?.StaffId equals _Staffs?.Id
                         join _Designation in DesignationsList on _Staffs?.DesignationId equals _Designation?.Id
                         select new { _PayScales, _Staffs, _Designation }).SingleOrDefault();
            var Basicsalary = query._PayScales.BasicSalary * query._PayScales.BasicSalaryTermNo;
            var BonusSalary = query._PayScales.BonusSalary * query._PayScales.BonusSalaryTermNo;
            var totalSalary = Basicsalary + BonusSalary;

            return model;
        }
      
    }
}
