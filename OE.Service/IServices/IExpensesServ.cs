
using OE.Service.ServiceModels.ExpensesServ;

namespace OE.Service
{
    public interface IExpensesServ
    {
        #region "Get Function Definitions"
        getExpensesList getExpensesList();
        #endregion "Get Function Definitions"

        #region "Insert update and delete Function Definitions"

       
        string InsertExpense(InsertExpense obj);
        string UpdateExpense(UpdateExpense obj);
        DeleteExpense DeleteExpense(DeleteExpense obj);

        
        allExpenses allExpenses();
        SearchExpenses SearchExpenses(SearchExpenses obj);
        #endregion "Insert update and delete Function Definitions"  

        
        #region "Report Function Definitions"
        PrintGetExpensesList PrintGetExpensesList();
        PrintSearchExpenses PrintSearchExpenses(PrintSearchExpenses obj);
        #endregion "Report Function Definitions"       
        
    }
}
