
using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels.SalaryIncrementsServ;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OE.Service
{
    public class SalaryIncrementsServ : ISalaryIncrementsServ
    {
        #region "Variables"
        private readonly ISalaryIncrementsRepo<SalaryIncrements> _SalaryIncrementsRepo;
        #endregion "Variables"

        #region "Constructor"
        public SalaryIncrementsServ(ISalaryIncrementsRepo<SalaryIncrements> SalaryIncrementsRepo)
        {
            _SalaryIncrementsRepo = SalaryIncrementsRepo;
        }
        #endregion "Constructor"

        #region "Get Methods"  
        public getSalaryIncrementsList getSalaryIncrementsList()
        {
            var model = new getSalaryIncrementsList();
            try
            {
                var SalaryIncrementsList = _SalaryIncrementsRepo.GetAll().ToList();
                var list = new List<getSalaryIncrementsList_SalaryIncrements>();
                foreach (var item in SalaryIncrementsList)
                {
                    var temp = new getSalaryIncrementsList_SalaryIncrements()
                    {
                        Id = item.Id,
                        StaffId = item.StaffId,
                        DesigignationId = item.DesigignationId,
                        PayScalesId = item.PayScalesId,
                        Date = item.Date,
                        Amount = item.Amount
                    };
                    list.Add(temp);
                };
                model = new getSalaryIncrementsList()
                {
                    _SalaryIncrements = list
                };
            }
            catch (Exception)
            {

            }
            return model;
        }
        #endregion "Get Methods" 

        #region "Insert update and delete Function"  
        public string InsertSalaryIncrement(InsertSalaryIncrement obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    if (obj.SalaryIncrements != null)
                    {
                        var SalaryIncrements = new InsertSalaryIncrement_SalaryIncrements()
                        {
                            StaffId = obj.SalaryIncrements.StaffId,
                            DesigignationId = obj.SalaryIncrements.DesigignationId,
                            PayScalesId = obj.SalaryIncrements.PayScalesId,
                            Date = obj.SalaryIncrements.Date,
                            Amount = obj.SalaryIncrements.Amount
                        };
                        _SalaryIncrementsRepo.Insert(SalaryIncrements);
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

        public string UpdateSalaryIncrement(UpdateSalaryIncrement obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    if (obj.SalaryIncrements != null)
                    {
                        var SalaryIncrements = new UpdateSalaryIncrement_SalaryIncrements()
                        {
                            Id = obj.SalaryIncrements.Id,
                            StaffId = obj.SalaryIncrements.StaffId,
                            DesigignationId = obj.SalaryIncrements.DesigignationId,
                            PayScalesId = obj.SalaryIncrements.PayScalesId,
                            Date = obj.SalaryIncrements.Date,
                            Amount = obj.SalaryIncrements.Amount
                        };
                        _SalaryIncrementsRepo.Update(SalaryIncrements);
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
        public DeleteSalaryIncrement DeleteSalaryIncrement(DeleteSalaryIncrement obj)
        {
            var returnModel = new DeleteSalaryIncrement();
            var SalaryIncrements = _SalaryIncrementsRepo.Get(obj.SalaryIncrementId);

            if (SalaryIncrements != null)
            {
                _SalaryIncrementsRepo.Delete(SalaryIncrements);
            }
            return returnModel;
        }
        #endregion "Insert update and delete Function"  
    }
}