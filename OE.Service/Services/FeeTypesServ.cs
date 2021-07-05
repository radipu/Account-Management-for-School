using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels.FeeTypesServ;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OE.Service
{
    public class FeeTypesServ : IFeeTypesServ
    {        
        #region "Variables"
        private readonly IFeeTypesRepo<FeeTypes> _FeeTypesRepo;
        private readonly IClassesRepo<Classes> _classesRepo;
        private readonly IInstitutionsRepo<Institutions> _InstitutionsRepo;
        #endregion "Variables"

        #region "Constructor"
        public FeeTypesServ(IFeeTypesRepo<FeeTypes> FeeTypesRepo,
            IInstitutionsRepo<Institutions> InstitutionsRepo,
            IClassesRepo<Classes> classesRepo)
        {
            _FeeTypesRepo = FeeTypesRepo;
            _classesRepo = classesRepo;
            _InstitutionsRepo = InstitutionsRepo;
        }


        #endregion "Constructor"

        #region "Get Methods"  
        public getFeeTypesList getFeeTypesList()
        {
            var model = new getFeeTypesList();
            try
            {
                var FeeTypesList = _FeeTypesRepo.GetAll().ToList();
                var classList = _classesRepo.GetAll().ToList();

                var query = (from _FeeTypes in FeeTypesList
                             join _Class in classList on _FeeTypes?.ClassId equals _Class?.Id
                             orderby _FeeTypes.ClassId ascending
                             select new { _FeeTypes, _Class });

                var list = new List<getFeeTypesList_FeeTypes>();
                foreach (var item in query)
                {
                    var temp = new getFeeTypesList_FeeTypes()
                    {
                        Id = item._FeeTypes.Id,
                        ClassId = item._FeeTypes.ClassId,
                        ClassName = item._Class.Name,
                        Name = item._FeeTypes.Name,
                        IsActive = item._FeeTypes.IsActive

                    };
                    list.Add(temp);
                };


                model = new getFeeTypesList()
                {
                    _FeeTypes = list
                };

            }
            catch (Exception)
            {

            }
            return model;
        }


        public SearchFeeTypes SearchFeeTypes(SearchFeeTypes obj)
        {
            var model = (dynamic)null;
            try
            {
                Int64 SearchFeetypeClassId = Convert.ToInt64(obj.SearchFeetypeClassId);
                var FeeTypesList = _FeeTypesRepo.GetAll().ToList();
                var classList = _classesRepo.GetAll().ToList();

                var query = (from _FeeTypes in FeeTypesList
                             join _class in classList on _FeeTypes?.ClassId equals _class?.Id
                             where _FeeTypes.ClassId == SearchFeetypeClassId
                             select new { _FeeTypes, _class }).ToList();
                var matchedClassName = (from p in FeeTypesList
                                        join c in classList on p.ClassId equals c.Id
                                        where p.ClassId == SearchFeetypeClassId
                                        select c.Name.Single()).ToString();
                var test = (from c in classList
                            where c.Id == SearchFeetypeClassId
                            select c).SingleOrDefault();

                var list = new List<SearchFeeTypes_FeeTypes>();
                foreach (var item in query)
                {
                    var temp = new SearchFeeTypes_FeeTypes()
                    {
                        Id = item._FeeTypes.Id,
                        ClassId = item._FeeTypes.ClassId,
                        ClassName = item._class.Name,
                        Name = item._FeeTypes.Name,
                        IsActive = item._FeeTypes.IsActive

                    };
                    list.Add(temp);
                };

                model = new SearchFeeTypes()
                {
                    _FeeTypes = list,
                    SearchClassName = test.Name

                };
            }
            catch (Exception)
            {

            }
            return model;
        }

        #endregion "Get Methods" 

       
        #region "Insert update and delete Function"  
        public string InsertFeeType(InsertFeeType obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    //[Note: insert 'states' table]
                    if (obj.FeeTypes != null)
                    {
                        var FeeTypes = new InsertFeeType_FeeTypes()
                        {

                            ClassId = obj.FeeTypes.ClassId,
                            Name = obj.FeeTypes.Name,
                            IsActive = obj.FeeTypes.IsActive


                        };

                        _FeeTypesRepo.Insert(FeeTypes);
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
        public string UpdateFeeType(UpdateFeeType obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {

                    if (obj.FeeTypes != null)
                    {
                        var currentItem = _FeeTypesRepo.Get(obj.FeeTypes.Id);
                        currentItem.Id = obj.FeeTypes.Id;
                        currentItem.ClassId = obj.FeeTypes.ClassId;
                        currentItem.Name = obj.FeeTypes.Name;
                        currentItem.IsActive = obj.FeeTypes.IsActive;
                        _FeeTypesRepo.Update(currentItem);
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
        public DeleteFeeType DeleteFeeType(DeleteFeeType obj)
        {
            var returnModel = new DeleteFeeType();
            var FeeType = _FeeTypesRepo.Get(obj.FeeTypeId);

            if (FeeType != null)
            {
                _FeeTypesRepo.Delete(FeeType);

                returnModel.Message = "Delete Successful.";
            }
            return returnModel;
        }
        #endregion "Insert update and delete Function"  

        #region "Report Method"
        public PrintGetFeeTypesList PrintGetFeeTypesList()
        {
            var model = new PrintGetFeeTypesList();
            try
            {

                var institution = _InstitutionsRepo.GetAll().FirstOrDefault();
                var FeeTypesList = _FeeTypesRepo.GetAll();
                var classList = _classesRepo.GetAll();

                var query = (from _FeeTypes in FeeTypesList
                             join _Class in classList on _FeeTypes?.ClassId equals _Class?.Id



                             select new { _FeeTypes, _Class });

                var list = new List<PrintGetFeeTypesList_FeeTypes>();
                foreach (var item in query)
                {
                    var temp = new PrintGetFeeTypesList_FeeTypes()
                    {
                        Id = item._FeeTypes.Id,
                        ClassId = item._FeeTypes.ClassId,
                        ClassName = item._Class.Name,
                        Name = item._FeeTypes.Name,
                        IsActive = item._FeeTypes.IsActive
                    };
                    list.Add(temp);
                };

                //[NOTE: map institutions]
                var currentInstitution = new PrintGetFeeTypesList_Institutions()
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


                model = new PrintGetFeeTypesList()
                {
                    _FeeTypes = list,
                    Institution = currentInstitution
                };

            }
            catch (Exception)
            {

            }
            return model;
        }
        #endregion "Report Method"
       

        #region "Dropdown Methods"
        public IEnumerable<dropdown_FeeType> dropdown_FeeType(long classId)
        {
            var queryAll = _FeeTypesRepo.GetAll().ToList();
            var getFeeTypes = from p in queryAll
                              where p.ClassId == classId
                              orderby p.Name
                              select p;

            var queryResult = new List<dropdown_FeeType>();

            foreach (var item in getFeeTypes)
            {
                var d = new dropdown_FeeType()
                {
                    Id = item.Id,
                    Name = item.Name
                };
                queryResult.Add(d);
            }

            return queryResult;

        }
        #endregion "Dropdown Methods"

    }
}
