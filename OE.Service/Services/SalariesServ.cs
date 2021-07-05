using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels.SalariesServ;
using OE.Service.ServiceModels.SalarysServ;
using System;
using System.Collections.Generic;
using System.Linq;
namespace OE.Service
{
    public class SalariesServ : ISalariesServ
    {
        #region "Variables"
        private readonly ISalariesRepo<Salaries> _SalariesRepo;
        private readonly IStaffsRepo<Staffs> _StaffsRepo;       
        private readonly IDesignationsRepo<Designations> _DesignationsRepo;
        private readonly IGendersRepo<Genders> _GendersRepo;
        private readonly ICommonServ _commonServ;
        private readonly IPayScalesRepo<PayScales> _PayScalesRepo;     
        #endregion "Variables"

        #region "Constructor"
        public SalariesServ(ISalariesRepo<Salaries> SalariesRepo,           
            IDesignationsRepo<Designations> DesignationsRepo,
            IGendersRepo<Genders> GendersRepo,
            ICommonServ commonServ,
            IPayScalesRepo<PayScales> PayScalesRepo,            
            IStaffsRepo<Staffs> StaffsRepo)
        {
            _SalariesRepo = SalariesRepo;
            _StaffsRepo = StaffsRepo;           
            _DesignationsRepo = DesignationsRepo;
            _GendersRepo = GendersRepo;
            _commonServ = commonServ;
            _PayScalesRepo = PayScalesRepo;           
        }
        #endregion "Constructor"

        #region "Get Methods"            
        public getSalariesList getSalariesList(long staffId,long salaryYear)
        {
            var model = new getSalariesList();
            try
            {
                var SalariesList = _SalariesRepo.GetAll().ToList();
                var StaffsList = _StaffsRepo.GetAll().ToList();
                var DesignationsList = _DesignationsRepo.GetAll().ToList();
                var getPayScale = _PayScalesRepo.GetAll().ToList();
                //[NOTE: get staff details of particular staff]
                var staffDetails = (from _Staffs in StaffsList
                                     where _Staffs.Id == staffId 
                                     join _Designations in DesignationsList on _Staffs?.DesignationId equals _Designations?.Id
                                     orderby _Staffs.FirstName ascending
                                     select new { _Staffs, _Designations }).SingleOrDefault();
                var staffs = new getSalariesList_Staffs()
                {
                    Id = staffDetails._Staffs.Id,
                    DesignationId = staffDetails._Staffs.DesignationId,
                    FirstName = staffDetails._Staffs.FirstName,
                    LastName = staffDetails._Staffs.LastName,
                    Name = staffDetails._Staffs.FirstName + " " + staffDetails._Staffs.LastName,
                    Designation = staffDetails._Designations.Name,
                    Cell = staffDetails._Staffs.Cell,
                    Email = staffDetails._Staffs.Email,
                    Address = staffDetails._Staffs.Address
                };
                //[NOTE: get staff salaries by Id]
                var query = (from _Salaries in SalariesList
                             join _Staffs in StaffsList on _Salaries.StaffId equals _Staffs.Id                            
                             where _Salaries.Date.Year == salaryYear                            
                             select new { _Salaries, _Staffs });             
                                var payScale = (from p in getPayScale                                  
                                where p.StaffId == staffId && p.SalaryYear.Year == salaryYear                                
                                select p).SingleOrDefault();               
                var list = new List<getSalariesList_Salaries>();
                foreach (var item in query)
                {
                    var temp = new getSalariesList_Salaries()
                    {
                        Id = item._Salaries.Id,
                        StaffId = item._Salaries.StaffId,
                        StaffName = item._Staffs.FirstName + " " + item._Staffs.LastName,                       
                        Date = item._Salaries.Date,                       
                        TermNo = item._Salaries.TermNo,
                        SalaryTypeId = item._Salaries.SalaryTypeId,                       
                        Amount = item._Salaries.Amount,
                        Remark = item._Salaries.Remark
                    };
                    list.Add(temp);
                };
                model = new getSalariesList()
                {
                    Staffs = staffs,                   
                    Amount = payScale.BasicSalary,
                    BonusAmount = payScale.BonusSalary,                 
                    _Salaries = list
                };
            }
            catch (Exception)
            {

            }
            return model;
        }       
        public getStaffList getStaffList(string currentPath)
        {
            var model = new getStaffList();
            try
            {
                var StaffsList = _StaffsRepo.GetAll().ToList();
                var DesignationsList = _DesignationsRepo.GetAll().ToList();                
                var getPayScales = _PayScalesRepo.GetAll().ToList();              
                var genders = _GendersRepo.GetAll().ToList();
                var query = (from _Staffs in StaffsList
                             join _Designations in DesignationsList on _Staffs?.DesignationId equals _Designations?.Id
                             join _genders in genders on _Staffs?.GenderId equals _genders.Id
                             orderby _Staffs.FirstName ascending                             
                             join payScales in getPayScales on _Staffs.Id equals payScales.StaffId    
                             select new { _Staffs, _Designations, _genders, payScales });                            
                var list = new List<getStaffList_Staffs>();
                foreach (var item in query)
                {
                    string path = string.IsNullOrEmpty(item._Staffs.IP300X200) ? "" : item._Staffs.IP300X200;
                    var temp = new getStaffList_Staffs()
                    {
                        Id = item._Staffs.Id,
                        DesignationId = item._Staffs.DesignationId,
                        FirstName = item._Staffs.FirstName,
                        LastName = item._Staffs.LastName,
                        Name = item._Staffs.FirstName + " " + item._Staffs.LastName,
                        GenderId = item._Staffs.GenderId,
                        SalaryYear = item.payScales.SalaryYear,
                       
                        IP300X200 = _commonServ.CommImage_WrapperDefaultImage(path, currentPath, item._Staffs.GenderId),
                        Designation = item._Designations.Name,                      
                        NetSalary= netSallary(item._Staffs.Id, item.payScales.SalaryYear.Year),
                        
                        YearlyTermNo = item.payScales.BasicSalaryTermNo,                       
                        Cell = item._Staffs.Cell,
                        Email = item._Staffs.Email,
                        Address = item._Staffs.Address
                    };
                    list.Add(temp);
                };
                model = new getStaffList()
                {
                    _Staffs = list
                };
            }
            catch (Exception e)
            {
                var test = e.Message;
            }
            return model;
        }
        public ProduceStaffsSalary ProduceStaffsSalary(ProduceStaffsSalary obj)
        {
            var model = new ProduceStaffsSalary();
            try
            {
                var StaffsList = _StaffsRepo.GetAll().ToList();
                var DesignationsList = _DesignationsRepo.GetAll().ToList();
                var genders = _GendersRepo.GetAll().ToList();
                var query = (from _Staffs in StaffsList
                             join _Designations in DesignationsList on _Staffs?.DesignationId equals _Designations?.Id
                             join _genders in genders on _Staffs?.GenderId equals _genders.Id
                             orderby _Staffs.FirstName ascending
                             select new { _Staffs, _Designations, _genders });
                var list = new List<ProduceStaffsSalary_Staffs>();
                foreach (var item in query)
                {
                    string path = string.IsNullOrEmpty(item._Staffs.IP300X200) ? "" : item._Staffs.IP300X200;
                    var temp = new ProduceStaffsSalary_Staffs()
                    {
                        Id = item._Staffs.Id,
                        DesignationId = item._Staffs.DesignationId,
                        FirstName = item._Staffs.FirstName,
                        LastName = item._Staffs.LastName,
                        Name = item._Staffs.FirstName + " " + item._Staffs.LastName,
                        GenderId = item._Staffs.GenderId,
                        GenderName = item._genders.Name,
                        IP300X200 = _commonServ.CommImage_WrapperDefaultImage(path, obj.WebRootPath, item._Staffs.GenderId),
                        Designation = item._Designations.Name,
                        Cell = item._Staffs.Cell,
                        Email = item._Staffs.Email,
                        Address = item._Staffs.Address
                    };
                    list.Add(temp);
                };
                model = new ProduceStaffsSalary()
                {
                    _Staffs = list
                };
            }
            catch (Exception)
            {

            }
            return model;
        }
        #endregion "Get Methods"         

        #region "Dropdown Methods"      
        public IEnumerable<dropdown_TermNo> dropdown_TermNo(long StaffId, long salaryYear)      
        {
            var queryAll = _PayScalesRepo.GetAll().ToList();
            var getPayScale = from p in queryAll                             
                              where p.StaffId == StaffId && p.SalaryYear.Year == salaryYear                              
                              select p.BasicSalaryTermNo;
            var queryResult = new List<dropdown_TermNo>();
            foreach (var item in getPayScale)
            {
                for (int j = 1; j <= item; j++)
                {
                    var d = new dropdown_TermNo()
                    {
                        Id = j,
                        Number = j
                    };
                    queryResult.Add(d);
                }
            }
            return queryResult;
        }       
        public IEnumerable<dropdown_BonusTermNo> dropdown_BonusTermNo(long StaffId,long salaryYear)
        {
            var queryAll = _PayScalesRepo.GetAll().ToList();
            var getPayScale = from p in queryAll                             
                              where p.StaffId == StaffId && p.SalaryYear.Year == salaryYear                            
                              select p.BonusSalaryTermNo;
            var queryResult = new List<dropdown_BonusTermNo>();
            foreach (var item in getPayScale)
            {
                for (int j = 1; j <= item; j++)
                {
                    var d = new dropdown_BonusTermNo()
                    {
                        Id = j,
                        Number = j
                    };
                    queryResult.Add(d);
                }
            }
            return queryResult;
        }        
        #endregion "Dropdown Methods"     
        private decimal netSallary(long staffid, long Year)      
        {
            decimal model = 0;
            var PayScalesList = _PayScalesRepo.GetAll().ToList();
            var DesignationsList = _DesignationsRepo.GetAll().ToList();
            var StaffsList = _StaffsRepo.GetAll().ToList();
            var query = (from _PayScales in PayScalesList
                         join _Staffs in StaffsList on _PayScales.StaffId equals _Staffs.Id                         
                         where _PayScales.StaffId== staffid && _PayScales.SalaryYear.Year == Year                         
                         select new { _PayScales, _Staffs }).SingleOrDefault();           
            var Basicsalary = query._PayScales.BasicSalary * query._PayScales.BasicSalaryTermNo;
            var BonusSalary = query._PayScales.BonusSalary * query._PayScales.BonusSalaryTermNo;
            var totalSalary = Basicsalary + BonusSalary;
            model = totalSalary;
            return model;
        }
                
        #region "Insert update and delete Function"  
        public string InsertSalary(InsertSalary obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    //[Note: insert 'states' table]
                    if (obj.Salaries != null)
                    {
                        var getSalaries = _SalariesRepo.GetAll().ToList();
                        var isExists = (from s in getSalaries
                                        where s.StaffId == obj.Salaries.StaffId && s.TermNo == obj.Salaries.TermNo && s.SalaryTypeId == obj.Salaries.SalaryTypeId && s.Date.Year == DateTime.Now.Year
                                        select s).SingleOrDefault();
                        if (isExists != null)
                        {
                            isExists.Date = obj.Salaries.Date;
                            isExists.Amount = obj.Salaries.Amount;
                            isExists.Remark = obj.Salaries.Remark;
                            _SalariesRepo.Update(isExists);
                        }
                        else
                        {
                            var Salaries = new InsertSalary_Salaries()
                            {
                                StaffId = obj.Salaries.StaffId,
                                Date = obj.Salaries.Date,
                                Amount = obj.Salaries.Amount,
                                TermNo = obj.Salaries.TermNo,
                                SalaryTypeId = obj.Salaries.SalaryTypeId,
                                Remark = obj.Salaries.Remark
                            };
                            _SalariesRepo.Insert(Salaries);
                        }
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
        public string UpdateSalary(UpdateSalary obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    if (obj.Salaries != null)
                    {
                        var currentItem = _SalariesRepo.Get(obj.Salaries.Id);
                        currentItem.Id = obj.Salaries.Id;
                        currentItem.StaffId = obj.Salaries.StaffId;
                        currentItem.Date = obj.Salaries.Date;
                        currentItem.TermNo = obj.Salaries.TermNo;
                        currentItem.SalaryTypeId = obj.Salaries.SalaryTypeId;
                        currentItem.Amount = obj.Salaries.Amount;
                        currentItem.Remark = obj.Salaries.Remark;
                        _SalariesRepo.Update(currentItem);
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
        public string DeleteSalary(DeleteSalary obj)
        {
            var returnModel = (dynamic)null;
            var Salaries = _SalariesRepo.Get(obj.SalaryId);
            if (Salaries != null)
            {
                _SalariesRepo.Delete(Salaries);
            }
            return returnModel;
        }
        #endregion "Insert update and delete Function"  
        
    }
}

