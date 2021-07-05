using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels.StaffsServ;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace OE.Service
{
    public class StaffsServ : IStaffsServ
    {
        #region "Variables"
        private readonly IStaffsRepo<Staffs> _StaffsRepo;
        private readonly IDesignationsRepo<Designations> _DesignationsRepo;
        private readonly IInstitutionsRepo<Institutions> _InstitutionsRepo; 
        private readonly ICommonServ _commonServ;
        private readonly IGendersRepo<Genders> _GendersRepo;
        #endregion "Variables"

        #region "Constructor"
        public StaffsServ(IStaffsRepo<Staffs> StaffsRepo, IDesignationsRepo<Designations> DesignationsRepo,            
            ICommonServ commonServ,
            IGendersRepo<Genders> GendersRepo,
            IInstitutionsRepo<Institutions> InstitutionsRepo)
        {
            _StaffsRepo = StaffsRepo;
            _DesignationsRepo = DesignationsRepo;
            _InstitutionsRepo = InstitutionsRepo;           
            _commonServ = commonServ;
            _GendersRepo = GendersRepo;
          
        }
        #endregion "Constructor"

        #region "Get Methods"
        public getStaffsList getStaffsList(getStaffsList obj)        
        {
            var model = new getStaffsList();
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

                var list = new List<getStaffsList_Staffs>();
                foreach (var item in query)
                {                    
                    string path = string.IsNullOrEmpty(item._Staffs.IP300X200) ? "" : item._Staffs.IP300X200;                    
                    var temp = new getStaffsList_Staffs()
                    {
                        Id = item._Staffs.Id,
                        DesignationId = item._Staffs.DesignationId,
                        FirstName = item._Staffs.FirstName,
                        LastName = item._Staffs.LastName,
                        Name = item._Staffs.FirstName + " " + item._Staffs.LastName,                       
                        GenderId=item._Staffs.GenderId,
                        GenderName=item._genders.Name,
                        IP300X200 = _commonServ.CommImage_WrapperDefaultImage(path, obj.WebRootPath, item._Staffs.GenderId),
                        Designation = item._Designations.Name,
                        Cell = item._Staffs.Cell,
                        Email = item._Staffs.Email,
                        Education = item._Staffs.Education,
                        Address = item._Staffs.Address

                    };
                    list.Add(temp);
                };


                model = new getStaffsList()
                {
                    _Staffs = list
                };

            }
            catch (Exception ex)
            {
                var test = ex.Message;
            }
            return model;
        }
        public IEnumerable<dropdown_Staffs> dropdown_Staffs()
        {
            var queryAll = _StaffsRepo.GetAll().ToList();            
            var desgnationList = _DesignationsRepo.GetAll().ToList();
            var getStaffs = from p in queryAll                                
                 join d in desgnationList on p.DesignationId equals d.Id
                select new { p, d };
           
            var queryResult = new List<dropdown_Staffs>();

            foreach (var item in getStaffs)
            {
                var d = new dropdown_Staffs()
                {                   
                    Id = item.p.Id,                  
                    Name = item.p.FirstName+ "" + item.p.LastName +"(" + item.d.Name + ")"                    
                };
                queryResult.Add(d);
            }

            return queryResult;

        }
        public StaffDetails StaffDetails(StaffDetails obj)
        {
            var model = (dynamic)null;
            try
            {
                var StaffsList = _StaffsRepo.GetAll().ToList();
                var DesignationsList = _DesignationsRepo.GetAll().ToList();
                var query = (from _Staffs in StaffsList
                             where _Staffs.Id == obj.StaffId
                             join _Designations in DesignationsList on _Staffs?.DesignationId equals _Designations?.Id
                             orderby _Staffs.FirstName ascending
                             select new { _Staffs, _Designations }).SingleOrDefault();


                var temp = new StaffDetails_Staffs()
                {
                    Id = query._Staffs.Id,
                    DesignationId = query._Staffs.DesignationId,
                    FirstName = query._Staffs.FirstName,
                    LastName = query._Staffs.LastName,
                    Name = query._Staffs.FirstName + " " + query._Staffs.LastName,
                    Designation = query._Designations.Name,
                    Cell = query._Staffs.Cell,
                    Email = query._Staffs.Email,
                    Education= query._Staffs.Education,
                    Address = query._Staffs.Address
                };

                model = new StaffDetails()
                {
                    Staffs = temp
                };
            }
            catch (Exception)
            {

            }
            return model;
        }
        #endregion "Get Methods" 

        
        #region "Insert update and delete Function"  
        public string InsertStaff(InsertStaff obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    //[Note: insert 'states' table]
                    if (obj.Staffs != null)
                    {
                        var Staffs = new InsertStaff_Staffs()
                        {
                            GenderId = obj.Staffs.GenderId,
                            IP300X200 = obj.Staffs.IP300X200,
                            DesignationId = obj.Staffs.DesignationId,
                            FirstName = obj.Staffs.FirstName,
                            LastName = obj.Staffs.LastName,
                            Cell = obj.Staffs.Cell,
                            Email = obj.Staffs.Email,
                            Education = obj.Staffs.Education,
                            Address = obj.Staffs.Address
                        };

                        _StaffsRepo.Insert(Staffs);
                        if (obj.Staffs.fleImage != null)
                        {
                            string imagePathIP300X200 = "ClientDictionary/Staffs/IP300X200/";
                            string extension = Path.GetExtension(obj.Staffs.fleImage.FileName);
                            var lastAddingRecord = _StaffsRepo.GetAll().Last();
                            if (_commonServ.CommImage_ImageFormat(lastAddingRecord.Id.ToString(), obj.Staffs.fleImage, obj.WebRootPath, imagePathIP300X200, 200, 300, extension).Equals(true))
                            {
                                //[NOTE:Update image file]
                                var imgStaff = _StaffsRepo.Get(lastAddingRecord.Id);
                                imgStaff.IP300X200 = imagePathIP300X200 + lastAddingRecord.Id + extension;
                                _StaffsRepo.Update(imgStaff);
                            }
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

        public string UpdateStaff(UpdateStaff obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {

                    if (obj.Staffs != null)
                    {
                        var currentItem = _StaffsRepo.Get(obj.Staffs.Id);
                        currentItem.Id = obj.Staffs.Id;
                        currentItem.DesignationId = obj.Staffs.DesignationId;
                        currentItem.FirstName = obj.Staffs.FirstName;
                        currentItem.LastName = obj.Staffs.LastName;
                        currentItem.Cell = obj.Staffs.Cell;
                        currentItem.Email = obj.Staffs.Email;
                        currentItem.Address = obj.Staffs.Address;
                        currentItem.Education = obj.Staffs.Education;
                        currentItem.GenderId = obj.Staffs.GenderId;
                        if (obj.Staffs.fleImage == null)
                        {
                            if (obj.Staffs.IP300X200 != null)
                            {
                                currentItem.IP300X200 = obj.Staffs.IP300X200;
                            }
                            else
                            {
                                //[NOTE: delete image from 'ClientDictionary']
                                string targetImageLocation = Path.Combine(obj.WebRootPath, currentItem.IP300X200);
                                _commonServ.DelFileFromLocation(targetImageLocation);
                            }

                        }
                        else
                        {
                            //[NOTE: delete image from 'ClientDictionary-if extensions are different']
                            if (currentItem.IP300X200 != null)
                            {
                                string targetImageLocation = Path.Combine(obj.WebRootPath, currentItem.IP300X200);
                                _commonServ.DelFileFromLocation(targetImageLocation);
                            }

                            //[NOTE: Upddate image]
                            string imagePathIP300X200 = "ClientDictionary/Staffs/IP300X200/";
                            string extension = Path.GetExtension(obj.Staffs.fleImage.FileName);
                            if (_commonServ.CommImage_ImageFormat(obj.Staffs.Id.ToString(), obj.Staffs.fleImage, obj.WebRootPath, imagePathIP300X200, 200, 300, extension).Equals(true))
                            {
                                currentItem.IP300X200 = imagePathIP300X200 + obj.Staffs.Id + extension;

                            }
                        }

                        _StaffsRepo.Update(currentItem);
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
        public DeleteStaff DeleteStaff(DeleteStaff obj)
        {
            var returnModel = new DeleteStaff();
            var Staffs = _StaffsRepo.Get(obj.StaffId);

            if (Staffs != null)
            {
                _StaffsRepo.Delete(Staffs);
                if (Staffs.IP300X200 != null)
                {
                    string DelImgofIP300X200 = Path.Combine(obj.WebRootPath, Staffs.IP300X200);
                    _commonServ.DelFileFromLocation(DelImgofIP300X200);
                }

            }
            return returnModel;
        }
        #endregion "Insert update and delete Function"  

        #region "Report Method"
        public PrintGetStaffsList PrintGetStaffsList()
        {
            var model = new PrintGetStaffsList();
            try
            {
                var StaffsList = _StaffsRepo.GetAll().ToList();
                var DesignationsList = _DesignationsRepo.GetAll().ToList();
                var institution = _InstitutionsRepo.GetAll().FirstOrDefault();

                var query = (from _Staffs in StaffsList
                             join _Designations in DesignationsList on _Staffs?.DesignationId equals _Designations?.Id
                             orderby _Staffs.FirstName ascending
                             select new { _Staffs, _Designations });

                var list = new List<PrintGetStaffsList_Staffs>();
                foreach (var item in query)
                {
                    var temp = new PrintGetStaffsList_Staffs()
                    {
                        Id = item._Staffs.Id,
                        DesignationId = item._Staffs.DesignationId,
                        FirstName = item._Staffs.FirstName,
                        LastName = item._Staffs.LastName,
                        Name = item._Staffs.FirstName + " " + item._Staffs.LastName,
                        Designation = item._Designations.Name,
                        Cell = item._Staffs.Cell,
                        Email = item._Staffs.Email,
                        Education = item._Staffs.Education,
                        Address = item._Staffs.Address
                    };
                    list.Add(temp);
                };

                //[NOTE: map institutions]
                var currentInstitution = new PrintGetStaffsList_Institutions()
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


                model = new PrintGetStaffsList()
                {
                    _Staffs = list,
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

