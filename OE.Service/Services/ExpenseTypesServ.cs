
using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels.ExpenseTypesServ;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OE.Service
{
    public class ExpenseTypesServ : IExpenseTypesServ
    {
        #region "Variables"
        private readonly IExpenseTypesRepo<ExpenseTypes> _ExpenseTypesRepo;
        private readonly IInstitutionsRepo<Institutions> _InstitutionsRepo;
        #endregion "Variables"

        #region "Constructor"
        public ExpenseTypesServ(
            IExpenseTypesRepo<ExpenseTypes> ExpenseTypesRepo,
            IInstitutionsRepo<Institutions> InstitutionsRepo
            )
        {
            _ExpenseTypesRepo = ExpenseTypesRepo;
            _InstitutionsRepo = InstitutionsRepo;

        }


        #endregion "Constructor"

        #region "Get Methods"  
        public getExpenseTypeList getExpenseTypesList()
        {
            var model = new getExpenseTypeList();
            try
            {
                var ExpenseTypeList = _ExpenseTypesRepo.GetAll().ToList();
                var list = new List<getExpenseTypeList_ExpenseTypes>();
                foreach (var item in ExpenseTypeList)
                {
                    var temp = new getExpenseTypeList_ExpenseTypes()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        IsActive = item.IsActive
                    };
                    list.Add(temp);
                };
                model = new getExpenseTypeList()
                {
                    _ExpenseTypes = list
                };
            }
            catch (Exception)
            {

            }
            return model;
        }
        public IEnumerable<dropdown_ExpenseTypes> dropdown_ExpenseTypes()
        {
            var queryAll = _ExpenseTypesRepo.GetAll().ToList();
            var getExpenseTypes = from p in queryAll
                                  select p;
            var queryResult = new List<dropdown_ExpenseTypes>();
            foreach (var item in getExpenseTypes)
            {
                var d = new dropdown_ExpenseTypes()
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
        public string InsertExpenseType(InsertExpenseType obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    //[Note: insert 'states' table]
                    if (obj.ExpenseTypes != null)
                    {
                        var ExpenseTypes = new InsertExpenseType_ExpenseTypes()
                        {
                            Name = obj.ExpenseTypes.Name,
                            IsActive = obj.ExpenseTypes.IsActive
                        };
                        _ExpenseTypesRepo.Insert(ExpenseTypes);
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
        public string UpdateExpenseType(UpdateExpenseType obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    if (obj.ExpenseTypes != null)
                    {
                        var currentItem = _ExpenseTypesRepo.Get(obj.ExpenseTypes.Id);
                        currentItem.Name = obj.ExpenseTypes.Name;
                        currentItem.IsActive = obj.ExpenseTypes.IsActive;
                        _ExpenseTypesRepo.Update(currentItem);
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
        public DeleteExpenseType DeleteExpenseType(DeleteExpenseType obj)
        {
            var returnModel = new DeleteExpenseType();
            var ExpenseTypes = _ExpenseTypesRepo.Get(obj.ExpenseTypeId);

            if (ExpenseTypes != null)
            {
                _ExpenseTypesRepo.Delete(ExpenseTypes);
            }
            return returnModel;
        }
        #endregion "Insert update and delete Function"

        #region "Report Method"
        public PrintGetExpenseTypeList PrintGetExpenseTypesList()
        {
            var model = new PrintGetExpenseTypeList();
            try
            {
                var ExpenseTypeList = _ExpenseTypesRepo.GetAll().ToList();
                var institution = _InstitutionsRepo.GetAll().FirstOrDefault();
                var list = new List<PrintGetExpenseTypeList_ExpenseTypes>();
                foreach (var item in ExpenseTypeList)
                {
                    var temp = new PrintGetExpenseTypeList_ExpenseTypes()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        IsActive = item.IsActive
                    };
                    list.Add(temp);
                };

                //[NOTE: map institutions]
                var currentInstitution = new PrintGetExpenseTypeList_Institutions()
                {
                    Id = institution.Id,
                    Name = institution.Name,
                    IsActive = institution.IsActive,
                    LogoPath = institution.LogoPath,
                    FaviconPath = institution.FaviconPath,
                    Email = institution.Email,
                    ContactNo = institution.ContactNo,
                    Address = institution.Address
                };
                model = new PrintGetExpenseTypeList()
                {
                    _ExpenseTypes = list,
                    Institution = currentInstitution
                };
            }
            catch (Exception)
            {

            }
            return model;
        }
        #endregion "Report Method"
       

    }
}
