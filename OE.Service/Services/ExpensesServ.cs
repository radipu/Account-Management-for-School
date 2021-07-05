
using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels.ExpensesServ;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OE.Service
{
    public class ExpensesServ : IExpensesServ
    {
        #region "Variables"
        private readonly IExpensesRepo<Expenses> _ExpensesRepo;
        private readonly IExpenseTypesRepo<ExpenseTypes> _ExpenseTypesRepo;
        private readonly IInstitutionsRepo<Institutions> _InstitutionsRepo;
        #endregion "Variables"

        #region "Constructor"
        public ExpensesServ(
            IExpensesRepo<Expenses> ExpensesRepo, 
            IExpenseTypesRepo<ExpenseTypes> ExpenseTypesRepo,
            IInstitutionsRepo<Institutions> InstitutionsRepo
            )
        {
            _ExpenseTypesRepo = ExpenseTypesRepo;
            _ExpensesRepo = ExpensesRepo;
            _InstitutionsRepo = InstitutionsRepo;            
        }
        #endregion "Constructor"

        #region "Get Methods"  
        public getExpensesList getExpensesList()
        {
            var model = new getExpensesList();
            try
            {
                var ExpensesList = _ExpensesRepo.GetAll().ToList();
                var ExpenseTypeList = _ExpenseTypesRepo.GetAll().ToList();
                var query = (from _Expenses in ExpensesList
                             join _ExpenseType in ExpenseTypeList on _Expenses?.ExpenseTypeId equals _ExpenseType?.Id
                             orderby _ExpenseType.Name ascending
                             select new { _Expenses, _ExpenseType });
                var list = new List<getExpensesList_Expenses>();
                foreach (var item in query)
                {
                    var temp = new getExpensesList_Expenses()
                    {
                        Id = item._Expenses.Id,
                        Name = item._Expenses.Name,
                        Amount = item._Expenses.Amount,
                        Date = item._Expenses.Date,
                        ExpenseTypeId = item._Expenses.ExpenseTypeId,
                        ExpenseTypeName = item._ExpenseType.Name
                    };
                    list.Add(temp);
                };
                model = new getExpensesList()
                {
                    _Expenses = list
                };
            }
            catch (Exception)
            {

            }
            return model;
        }
        public allExpenses allExpenses()
        {
            var model = new allExpenses();
            try
            {
                var ExpensesList = _ExpensesRepo.GetAll().ToList();
                var getAllExpenses = from p in ExpensesList
                                     select p.Amount;
                var allAmount = getAllExpenses.Sum();
                model = new allExpenses()
                {
                    ammount = allAmount
                };
            }
            catch (Exception)
            {

            }
            return model;
        }
        public SearchExpenses SearchExpenses(SearchExpenses obj)
        {
            var model = (dynamic)null;
            try
            {
                DateTime StartDate = Convert.ToDateTime(obj.StartDate);
                DateTime EndDate = Convert.ToDateTime(obj.EndDate);
                var ExpensesList = _ExpensesRepo.GetAll().ToList();
                var ExpenseTypeList = _ExpenseTypesRepo.GetAll().ToList();

                var query = (from _Expenses in ExpensesList
                             join _ExpenseType in ExpenseTypeList on _Expenses?.ExpenseTypeId equals _ExpenseType?.Id
                             orderby _ExpenseType.Name ascending
                             where _Expenses.Date >= StartDate && _Expenses.Date <= EndDate
                             select new { _Expenses, _ExpenseType });
                var getAmount = (from p in ExpensesList
                                 where p.Date >= StartDate && p.Date <= EndDate
                                 select p.Amount);
                var allGetAmount = getAmount.Sum();
                var list = new List<SearchExpenses_Expenses>();
                foreach (var item in query)
                {
                    var temp = new SearchExpenses_Expenses()
                    {
                        Id = item._Expenses.Id,
                        Name = item._Expenses.Name,
                        Amount = item._Expenses.Amount,
                        Date = item._Expenses.Date,
                        ExpenseTypeId = item._Expenses.ExpenseTypeId,
                        ExpenseTypeName = item._ExpenseType.Name
                    };
                    list.Add(temp);
                };
                model = new SearchExpenses()
                {
                    _Expenses = list,
                    DateRangeAmount = allGetAmount
                };
            }
            catch (Exception)
            {

            }
            return model;
        }
        #endregion "Get Methods" 

       
        #region "Insert update and delete Function"  
        public string InsertExpense(InsertExpense obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    if (obj.Expenses != null)
                    {
                        var Expenses = new InsertExpenses_Expenses()
                        {
                            Name = obj.Expenses.Name,
                            Amount = obj.Expenses.Amount,
                            Date = obj.Expenses.Date,
                            ExpenseTypeId = obj.Expenses.ExpenseTypeId
                        };
                        _ExpensesRepo.Insert(Expenses);
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
        public string UpdateExpense(UpdateExpense obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    if (obj.Expenses != null)
                    {
                        var currentItem = _ExpensesRepo.Get(obj.Expenses.Id);
                        currentItem.Id = obj.Expenses.Id;
                        currentItem.Name = obj.Expenses.Name;
                        currentItem.Amount = obj.Expenses.Amount;
                        currentItem.Date = obj.Expenses.Date;
                        currentItem.ExpenseTypeId = obj.Expenses.ExpenseTypeId;
                        _ExpensesRepo.Update(currentItem);
                        returnResult = "Saved";
                    }
                }
            }
            catch (Exception ex)
            {
                returnResult = "ERROR102:ExpensesServ/UpdateExpenses - " + ex.Message;
            }
            return returnResult;
        }
        public DeleteExpense DeleteExpense(DeleteExpense obj)
        {
            var returnModel = new DeleteExpense();
            var Expenses = _ExpensesRepo.Get(obj.ExpenseId);
            if (Expenses != null)
            {
                _ExpensesRepo.Delete(Expenses);
            }
            return returnModel;
        }
        #endregion "Insert update and delete Function"  

        #region "Report Method"
        public PrintGetExpensesList PrintGetExpensesList()
        {
            var model = new PrintGetExpensesList();
            try
            {
                var ExpensesList = _ExpensesRepo.GetAll().ToList();
                var institution = _InstitutionsRepo.GetAll().FirstOrDefault();
                var ExpenseTypeList = _ExpenseTypesRepo.GetAll().ToList();
                var query = (from _Expenses in ExpensesList
                             join _ExpenseType in ExpenseTypeList on _Expenses?.ExpenseTypeId equals _ExpenseType?.Id
                             orderby _ExpenseType.Name ascending
                             select new { _Expenses, _ExpenseType });
                var list = new List<PrintGetExpensesList_Expenses>();
                foreach (var item in query)
                {
                    var temp = new PrintGetExpensesList_Expenses()
                    {
                        Id = item._Expenses.Id,
                        Name = item._Expenses.Name,
                        Amount = item._Expenses.Amount,
                        Date = item._Expenses.Date,
                        ExpenseTypeId = item._Expenses.ExpenseTypeId,
                        ExpenseTypeName = item._ExpenseType.Name
                    };
                    list.Add(temp);
                };
                //[NOTE: map institutions]
                var currentInstitution = new PrintGetExpensesList_Institutions()
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
                model = new PrintGetExpensesList()
                {
                    _Expenses = list,
                    Institution = currentInstitution
                };
            }
            catch (Exception)
            {

            }
            return model;
        }
        public PrintSearchExpenses PrintSearchExpenses(PrintSearchExpenses obj)
        {
            var model = (dynamic)null;
            try
            {
                DateTime StartDate = Convert.ToDateTime(obj.StartDate);
                DateTime EndDate = Convert.ToDateTime(obj.EndDate);
                var ExpensesList = _ExpensesRepo.GetAll().ToList();
                var ExpenseTypeList = _ExpenseTypesRepo.GetAll().ToList();
                var institution = _InstitutionsRepo.GetAll().FirstOrDefault();
                var query = (from _Expenses in ExpensesList
                             join _ExpenseType in ExpenseTypeList on _Expenses?.ExpenseTypeId equals _ExpenseType?.Id
                             orderby _ExpenseType.Name ascending
                             where _Expenses.Date >= StartDate && _Expenses.Date <= EndDate
                             select new { _Expenses, _ExpenseType });
                var getAmount = (from p in ExpensesList
                                 where p.Date >= StartDate && p.Date <= EndDate
                                 select p.Amount);
                var allGetAmount = getAmount.Sum();
                var list = new List<PrintSearchExpenses_Expenses>();
                foreach (var item in query)
                {
                    var temp = new PrintSearchExpenses_Expenses()
                    {
                        Id = item._Expenses.Id,
                        Name = item._Expenses.Name,
                        Amount = item._Expenses.Amount,
                        Date = item._Expenses.Date,
                        ExpenseTypeId = item._Expenses.ExpenseTypeId,
                        ExpenseTypeName = item._ExpenseType.Name
                    };
                    list.Add(temp);
                };
                var currentInstitution = new PrintSearchExpenses_Institutions()
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
                model = new PrintSearchExpenses()
                {
                    _Expenses = list,
                    DateRangeAmount = allGetAmount,
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
