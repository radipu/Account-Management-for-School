using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels.ClassesServ;
using System;
using System.Collections.Generic;
using System.Linq;
using getClassList = OE.Service.ServiceModels.ClassesServ.getClassList;

namespace OE.Service
{
    public class ClassesServ : IClassesServ
    {
        #region "Variables"
        private readonly IClassesRepo<Classes> _classesRepo;
        #endregion "Variables"

        #region "Constructor"
        public ClassesServ(IClassesRepo<Classes> classesRepo)
        {
            _classesRepo = classesRepo;
        }
        #endregion "Constructor"

        #region "Get Methods"  
        public getClassList.getClassList2 getClassList()
        {
            var model = new getClassList.getClassList2();
            try
            {
                var classList = _classesRepo.GetAll().ToList();
                var list = new List<getClassList.getClassList_Classes>();
                foreach (var item in classList)
                {
                    var temp = new getClassList.getClassList_Classes()
                    {
                        Id = item.Id,
                        Name = item.Name
                    };
                    list.Add(temp);
                };
                model = new getClassList.getClassList2()
                {
                    _Classes = list
                };
            }
            catch (Exception ex)
            {
                var test = ex.Message;
            }
            return model;
        }
        public IEnumerable<dropdown_Class2> dropdown_Class()
        {
            var queryAll = _classesRepo.GetAll().ToList();
            var getClasses = from p in queryAll
                             select p;
            var queryResult = new List<dropdown_Class2>();
            foreach (var item in getClasses)
            {
                var d = new dropdown_Class2()
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
        public string InsertClass(InsertClass2 obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    //[Note: insert 'states' table]
                    if (obj.Classes != null)
                    {
                        var Classes = new InsertClass_Classes()
                        {
                            Id = obj.Classes.Id,
                            Name = obj.Classes.Name
                        };
                        _classesRepo.Insert(Classes);
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
        public string UpdateClass(UpdateClass obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    if (obj.Classes != null)
                    {
                        var currentItem = _classesRepo.Get(obj.Classes.Id);
                        currentItem.Id = obj.Classes.Id;
                        currentItem.Name = obj.Classes.Name;
                        _classesRepo.Update(currentItem);
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
        public DeleteClass2 DeleteClass(DeleteClass2 obj)
        {
            var returnModel = new DeleteClass2();
            var classes = _classesRepo.Get(obj.ClassId);
            if (classes != null)
            {
                _classesRepo.Delete(classes);
                returnModel.Message = "Delete Successful.";
            }
            return returnModel;
        }
        #endregion "Insert update and delete Function"        
    }
}