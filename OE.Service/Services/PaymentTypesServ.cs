
using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels.PaymentTypesServ;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OE.Service
{
    public class PaymentTypesServ : IPaymentTypesServ
    {
        #region "Variables"
        private readonly IPaymentTypesRepo<PaymentTypes> _PaymentTypesRepo;
        #endregion "Variables"

        #region "Constructor"
        public PaymentTypesServ(IPaymentTypesRepo<PaymentTypes> PaymentTypesRepo)
        {
            _PaymentTypesRepo = PaymentTypesRepo;
        }
        #endregion "Constructor"

        #region "Get Methods"  
        public getPaymentTypesList getPaymentTypesList()
        {
            var model = new getPaymentTypesList();
            try
            {
                var PaymentTypesList = _PaymentTypesRepo.GetAll().ToList();

                var list = new List<getPaymentTypesList_PaymentTypes>();
                foreach (var item in PaymentTypesList)
                {
                    var temp = new getPaymentTypesList_PaymentTypes()
                    {
                        Id = item.Id,
                        Name = item.Name
                    };
                    list.Add(temp);
                };
                model = new getPaymentTypesList()
                {
                    _PaymentTypes = list
                };
            }
            catch (Exception)
            {

            }
            return model;
        }
        public IEnumerable<dropdown_PaymentTypes> dropdown_PaymentTypes()
        {
            var queryAll = _PaymentTypesRepo.GetAll().ToList();
            var getPaymentTypes = from p in queryAll
                                  select p;
            var queryResult = new List<dropdown_PaymentTypes>();
            foreach (var item in getPaymentTypes)
            {
                var d = new dropdown_PaymentTypes()
                {
                    Id = item.Id,
                    Name = item.Name
                };
                queryResult.Add(d);
            }
            return queryResult;
        }
        #endregion "Get Methods" 
        
        #region "Insert update and delete Function"  
        public string InsertPaymentType(InsertPaymentType obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    //[Note: insert 'states' table]
                    if (obj.PaymentTypes != null)
                    {
                        var PaymentTypes = new InsertPaymentTypet_PaymentTypes()
                        {
                            Name = obj.PaymentTypes.Name
                        };
                        _PaymentTypesRepo.Insert(PaymentTypes);
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
        public string UpdatePaymentType(UpdatePaymentType obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {

                    if (obj.PaymentTypes != null)
                    {
                        var PaymentTypes = new UpdatePaymentType_PaymentTypes()
                        {
                            Id = obj.PaymentTypes.Id,
                            Name = obj.PaymentTypes.Name
                        };
                        _PaymentTypesRepo.Update(PaymentTypes);
                        returnResult = "Saved";
                    }
                }
            }
            catch (Exception ex)
            {
                returnResult = "ERROR102:AddressesServ/UpdateAddress - " + ex.Message;
            }
            return returnResult;
        }
        public DeletePaymentType DeletePaymentType(DeletePaymentType obj)
        {
            var returnModel = new DeletePaymentType();
            var PaymentType = _PaymentTypesRepo.Get(obj.PaymentTypeId);
            if (PaymentType != null)
            {
                _PaymentTypesRepo.Delete(PaymentType);
                returnModel.Message = "Delete Successful.";
            }
            return returnModel;
        }
        #endregion "Insert update and delete Function"  
    }
}
