using OE.Data;
using OE.Repo;
using OE.Service;
using OE.Service.ServiceModels.DesignationsServ;
using System;
using System.Collections.Generic;
using System.Linq;
namespace OE.Service
{
    public class DesignationsServ : IDesignationsServ
    {
        #region "Variables"
        private readonly IDesignationsRepo<Designations> _DesignationsRepo;
        #endregion "Variables"

        #region "Constructor"
        public DesignationsServ(IDesignationsRepo<Designations> DesignationsRepo)
        {
            _DesignationsRepo = DesignationsRepo;
        }
        #endregion "Constructor"

        #region "Get Methods"  
        public getDesignationsList getDesignationsList()
        {
            var model = new getDesignationsList();
            try
            {
                var DesignationsList = _DesignationsRepo.GetAll().ToList();
                var list = new List<getDesignationsList_Designations>();
                foreach (var item in DesignationsList)
                {
                    var temp = new getDesignationsList_Designations()
                    {
                        Id = item.Id,
                        Name = item.Name
                    };
                    list.Add(temp);
                };
                model = new getDesignationsList()
                {
                    _Designations = list
                };
            }
            catch (Exception)
            {

            }
            return model;
        }

        
        public IEnumerable<dropdown_Designations> dropdown_Designations()
        {
            var queryAll = _DesignationsRepo.GetAll().ToList();
            var getDesignations = (from p in queryAll
                                   select p);
            var queryResult = new List<dropdown_Designations>();
            foreach (var item in getDesignations.ToList())
            {
                var d = new dropdown_Designations()
                {
                    Id = item.Id,
                    Name = item.Name
                };
                queryResult.Add(d);
            }
            return queryResult;
        }
       
        #endregion "Get Methods" 

        #region "Insert Update Delete"
       
        public string InsertDesignation(InsertDesignation obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    //[Note: insert 'states' table]
                    if (obj.Designations != null)
                    {
                        var Designations = new InsertDesignation_Designations()
                        {
                            Name = obj.Designations.Name
                        };
                        _DesignationsRepo.Insert(Designations);
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
      
        public string UpdateDesignation(UpdateDesignation obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    if (obj.Designations != null)
                    {
                        var currentItem = _DesignationsRepo.Get(obj.Designations.Id);
                        currentItem.Id = obj.Designations.Id;
                        currentItem.Name = obj.Designations.Name;
                        _DesignationsRepo.Update(currentItem);
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
        
        public DeleteDesignation DeleteDesignation(DeleteDesignation obj)
        {
            var returnModel = new DeleteDesignation();
            var Designations = _DesignationsRepo.Get(obj.DesignationId);

            if (Designations != null)
            {
                _DesignationsRepo.Delete(Designations);

                // returnModel.Message = "Delete Successful.";
            }
            return returnModel;
        }
        
        #endregion "Insert Update Delete"
    }
}
