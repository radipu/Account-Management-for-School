
using Microsoft.AspNetCore.Mvc;
using OE.Service;
using OE.Service.ServiceModels.ExpensesServ;
using OE.Web.Areas.Institution.Models;
using OE.Web.Areas.Institution.Models.ExpensesVM;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class ExpensesController : Controller
    {
        #region "Variables"
        private readonly IExpensesServ _ExpensesServ;
        private readonly IExpenseTypesServ _ExpenseTypesServ;
        #endregion "Variables"

        #region "Constructor"
        public ExpensesController(
            IExpensesServ ExpensesServ, IExpenseTypesServ ExpenseTypesServ
        )
        {
            _ExpensesServ = ExpensesServ;
            _ExpenseTypesServ = ExpenseTypesServ;

        }
        #endregion "Constructor"

        #region "Get methods"
        public async Task<IActionResult> ExpensesList(int pg = 1)
        {
            try
            {
                var ExpensesList = Task.Run(() => _ExpensesServ.getExpensesList());
                var result = await ExpensesList;
                ViewBag.ddlExpenseType = _ExpenseTypesServ.dropdown_ExpenseTypes();
                var totalAmount = _ExpensesServ.allExpenses();
                var list = new List<IndexExpensesListVM_Expenses>();
                foreach (var item in result._Expenses.ToList())
                {
                    var temp = new IndexExpensesListVM_Expenses()
                    {
                        Id = item.Id,

                        Name = item.Name,
                        Amount = item.Amount,
                        Date = item.Date,
                        ExpenseTypeId = item.ExpenseTypeId,
                        ExpenseTypeName = item.ExpenseTypeName
                    };
                    list.Add(temp);
                };

                #region "Paging"
                const int pageSize = 5;
                if (pg < 1)
                    pg = 1;
                int recsCount = list.Count();
                var pager = new Pager(recsCount, pg, pageSize);
                int recSkip = (pg - 1) * pageSize;
                var data = list.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;

                var model = new IndexExpensesListVM()
                {
                    _Expenses = data,
                    ammount = totalAmount.ammount
                };

                #endregion "Paging"
                
                return View("ExpensesList", model);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }        
        public async Task<IActionResult> ExpensesListByAdmin(int pg = 1)
        {
            try
            {
                var ExpensesList = Task.Run(() => _ExpensesServ.getExpensesList());
                var result = await ExpensesList;
                ViewBag.ddlExpenseType = _ExpenseTypesServ.dropdown_ExpenseTypes();
                var totalAmount = _ExpensesServ.allExpenses();
                var list = new List<IndexExpensesListByAdminVM_Expenses>();
                foreach (var item in result._Expenses.ToList())
                {
                    var temp = new IndexExpensesListByAdminVM_Expenses()
                    {
                        Id = item.Id,

                        Name = item.Name,
                        Amount = item.Amount,
                        Date = item.Date,
                        ExpenseTypeId = item.ExpenseTypeId,
                        ExpenseTypeName = item.ExpenseTypeName
                    };
                    list.Add(temp);
                };

                #region "Paging"
                const int pageSize = 5;
                if (pg < 1)
                    pg = 1;
                int recsCount = list.Count();
                var pager = new Pager(recsCount, pg, pageSize);
                int recSkip = (pg - 1) * pageSize;
                var data = list.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;

                var model = new IndexExpensesListByAdminVM()
                {
                    _Expenses = data,
                    ammount = totalAmount.ammount
                };
                #endregion "Paging"
                
                return View("ExpensesListByAdmin", model);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        
        public async Task<IActionResult> CalculateExpensesByAdmin(string StartDate, string EndDate)
        {
            try
            {
                if (String.IsNullOrEmpty(StartDate) && String.IsNullOrEmpty(EndDate))
                {
                    var model = new CalculateExpensesVM()
                    {
                        _Expenses = null,
                        StartDate = null,
                        EndDate = null
                    };
                    return View("CalculateExpensesByAdmin", model);
                }

                else
                {
                    var result = new SearchExpenses()
                    {
                        StartDate = StartDate,
                        EndDate = EndDate
                    };
                    var SearchExpenses = await Task.Run(() => _ExpensesServ.SearchExpenses(result));
                    var list = new List<CalculateExpensesVM_Expenses>();
                    foreach (var item in SearchExpenses._Expenses.ToList())
                    {
                        var temp = new CalculateExpensesVM_Expenses()
                        {
                            Id = item.Id,

                            Name = item.Name,
                            Amount = item.Amount,
                            Date = item.Date,
                            ExpenseTypeId = item.ExpenseTypeId,
                            ExpenseTypeName = item.ExpenseTypeName
                        };
                        list.Add(temp);
                    };

                    var model = new CalculateExpensesVM()
                    {
                        _Expenses = list,
                        ammount = SearchExpenses.DateRangeAmount,
                        StartDate = StartDate,
                        EndDate = EndDate
                    };
                    
                    return View("CalculateExpensesByAdmin", model);
                }
            }
            catch
            {
                return BadRequest();
            }
        }        
        public async Task<IActionResult> CalculateExpenses(string StartDate, string EndDate, int pg = 1)
        {
            try
            {
                if (String.IsNullOrEmpty(StartDate) && String.IsNullOrEmpty(EndDate))
                {
                    var model = new CalculateExpensesVM()
                    {
                        _Expenses = null,
                        StartDate = null,
                        EndDate = null
                    };
                    return View("CalculateExpenses", model);
                }

                else
                {
                    var result = new SearchExpenses()
                    {
                        StartDate = StartDate,
                        EndDate = EndDate
                    };
                    var SearchExpenses = await Task.Run(() => _ExpensesServ.SearchExpenses(result));
                    var list = new List<CalculateExpensesVM_Expenses>();
                    foreach (var item in SearchExpenses._Expenses.ToList())
                    {
                        var temp = new CalculateExpensesVM_Expenses()
                        {
                            Id = item.Id,

                            Name = item.Name,
                            Amount = item.Amount,
                            Date = item.Date,
                            ExpenseTypeId = item.ExpenseTypeId,
                            ExpenseTypeName = item.ExpenseTypeName
                        };
                        list.Add(temp);
                    };

                    #region "Paging"
                    const int pageSize = 5;
                    if (pg < 1)
                        pg = 1;
                    int recsCount = list.Count();
                    var pager = new Pager(recsCount, pg, pageSize);
                    int recSkip = (pg - 1) * pageSize;
                    var data = list.Skip(recSkip).Take(pager.PageSize).ToList();
                    this.ViewBag.Pager = pager;
                    var model = new CalculateExpensesVM()
                    {
                        _Expenses = data,
                        ammount = SearchExpenses.DateRangeAmount,
                        StartDate = StartDate,
                        EndDate = EndDate
                    };
                    #endregion "Paging"
                   
                    return View("CalculateExpenses", model);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        #endregion "Get methods"
        
        #region "Post_Methods"
        [HttpPost]
        public async Task<IActionResult> InsertExpense(IndexExpensesListVM obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (obj.Expenses != null)
                    {
                        var Expenses = new InsertExpenses_Expenses()
                        {
                            Name = obj.Expenses.Name,
                            Amount = obj.Expenses.Amount,
                            Date = obj.Expenses.Date,
                            ExpenseTypeId = obj.Expenses.ExpenseTypeId,
                        };
                        var model = new InsertExpense()
                        {
                            Expenses = Expenses
                        };
                        await Task.Run(() => _ExpensesServ.InsertExpense(model));
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("ExpensesList");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateExpense(IndexExpensesListVM obj)
        {
            try
            {
                if (obj.Expenses != null)
                {
                    var Expenses = new UpdateExpense_Expenses()
                    {
                        Id = obj.Expenses.Id,
                        Name = obj.Expenses.Name,
                        Amount = obj.Expenses.Amount,
                        Date = obj.Expenses.Date,
                        ExpenseTypeId = obj.Expenses.ExpenseTypeId
                    };
                    var model = new UpdateExpense()
                    {
                        Expenses = Expenses
                    };
                    await Task.Run(() => _ExpensesServ.UpdateExpense(model));
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("ExpensesList");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteExpense(long ExpenseId)
        {
            try
            {
                var model = new DeleteExpense()
                {
                    ExpenseId = ExpenseId
                };
                await Task.Run(() => _ExpensesServ.DeleteExpense(model));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("ExpensesList");
        }
        #endregion "post method"

        #region "Report Methods"
        public IActionResult PrintExpensesList()
        {
            ViewBag.OeErrorMessage = null;
            var model = new PrintCalculateExpensesVM();
            try
            {
                string footer = "--footer-center \"  Printed Date: " +
                      DateTime.Now.Date.ToString("dd/MM/yyyy") + " - " + "  Page: [page] to [toPage]\"" +
                      " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Courier New\"";
                var result = _ExpensesServ.PrintGetExpensesList();
                var list = new List<PrintCalculateExpensesVM_Expenses>();
                foreach (var item in result._Expenses.ToList())
                {
                    var temp = new PrintCalculateExpensesVM_Expenses()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Amount = item.Amount,
                        Date = item.Date,
                        ExpenseTypeId = item.ExpenseTypeId,
                        ExpenseTypeName = item.ExpenseTypeName
                    };
                    list.Add(temp);
                };
                var currentInstitution = new PrintCalculateExpensesVM_Institutions()
                {
                    Id = result.Institution.Id,
                    Name = result.Institution.Name,
                    IsActive = result.Institution.IsActive,
                    LogoPath = result.Institution.LogoPath,
                    FaviconPath = result.Institution.FaviconPath,
                    Email = result.Institution.Email,
                    ContactNo = result.Institution.ContactNo,
                    Address = result.Institution.Address
                };
                model = new PrintCalculateExpensesVM()
                {
                    _Expenses = list,
                    Institution = currentInstitution
                };
                return new ViewAsPdf("PrintExpensesList", model)
                {
                    CustomSwitches = footer
                };
            }
            catch (Exception ex)
            {
                ViewBag.OeErrorMessage = "ERROR101:ExamTypes/PrintExamTypes -" + ex.Message;
                return View("PrintExpensesList");
            }
        }
        public async Task<IActionResult> PrintCalculateExpenses(string StartDate, string EndDate)
        {
            ViewBag.OeErrorMessage = null;
            try
            {
                if (String.IsNullOrEmpty(StartDate) && String.IsNullOrEmpty(EndDate))
                {
                    string footer = "--footer-center \"  Printed Date: " +
                      DateTime.Now.Date.ToString("dd/MM/yyyy") + " - " + "  Page: [page] to [toPage]\"" +
                      " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Courier New\"";
                    var model = new PrintIndexExpensesListVM()
                    {
                        _Expenses = null,
                        StartDate = null,
                        EndDate = null,
                    };
                    return new ViewAsPdf("PrintCalculateExpenses", model)
                    {
                        CustomSwitches = footer
                    };
                }
                else
                {
                    string footer = "--footer-center \"  Printed Date: " +
                      DateTime.Now.Date.ToString("dd/MM/yyyy") + " - " + "  Page: [page] to [toPage]\"" +
                      " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Courier New\"";
                    var result = new PrintSearchExpenses()
                    {
                        StartDate = StartDate,
                        EndDate = EndDate
                    };
                    var PrintSearchExpenses = await Task.Run(() => _ExpensesServ.PrintSearchExpenses(result));
                    var list = new List<PrintIndexExpensesListVM_Expenses>();
                    foreach (var item in PrintSearchExpenses._Expenses.ToList())
                    {
                        var temp = new PrintIndexExpensesListVM_Expenses()
                        {
                            Id = item.Id,
                            Name = item.Name,
                            Amount = item.Amount,
                            Date = item.Date,
                            ExpenseTypeId = item.ExpenseTypeId,
                            ExpenseTypeName = item.ExpenseTypeName
                        };
                        list.Add(temp);
                    };
                    var currentInstitution = new PrintIndexExpensesListVM_Institutions()
                    {
                        Id = PrintSearchExpenses.Institution.Id,
                        Name = PrintSearchExpenses.Institution.Name,
                        IsActive = PrintSearchExpenses.Institution.IsActive,
                        LogoPath = PrintSearchExpenses.Institution.LogoPath,
                        FaviconPath = PrintSearchExpenses.Institution.FaviconPath,
                        Email = PrintSearchExpenses.Institution.Email,
                        ContactNo = PrintSearchExpenses.Institution.ContactNo,
                        Address = PrintSearchExpenses.Institution.Address
                    };
                    var model = new PrintIndexExpensesListVM()
                    {
                        _Expenses = list,
                        ammount = PrintSearchExpenses.DateRangeAmount,
                        StartDate = StartDate,
                        EndDate = EndDate,
                        Institution = currentInstitution
                    };
                    //return View("CalculateExpenses", model);
                    return new ViewAsPdf("PrintCalculateExpenses", model)
                    {
                        CustomSwitches = footer
                    };
                }
            }
            catch (Exception ex)
            {
                ViewBag.OeErrorMessage = "ERROR101:ExamTypes/PrintExamTypes -" + ex.Message;
                return View("PrintCalculateExpenses");
            }
        }
        #endregion "Report Methods"
        
    }
}
