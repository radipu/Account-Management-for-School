
using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels.FeeTermDescriptionsServ;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OE.Service
{
    public class FeeTermDescriptionsServ : IFeeTermDescriptionsServ
    {
        #region "Variables"
        private readonly IFeeTermDescriptionsRepo<FeeTermDescriptions> _FeeTermDescriptionsRepo;
        private readonly IFeeStructuresRepo<FeeStructures> _FeeStructuresRepo;
        private readonly IFeeTypesRepo<FeeTypes> _FeeTypesRepo;
        private readonly IClassesRepo<Classes> _classesRepo;
        private readonly IInstitutionsRepo<Institutions> _InstitutionsRepo;
        #endregion "Variables"

        #region "Constructor"
        public FeeTermDescriptionsServ(IFeeTermDescriptionsRepo<FeeTermDescriptions> FeeTermDescriptionsRepo,
            IFeeStructuresRepo<FeeStructures> FeeStructuresRepo,
            IFeeTypesRepo<FeeTypes> FeeTypesRepo,
            IInstitutionsRepo<Institutions> InstitutionsRepo,
            IClassesRepo<Classes> classesRepo)
        {
            _FeeTermDescriptionsRepo = FeeTermDescriptionsRepo;
            _FeeStructuresRepo = FeeStructuresRepo;
            _FeeTypesRepo = FeeTypesRepo;
            _classesRepo = classesRepo;
            _InstitutionsRepo = InstitutionsRepo;           
        }


        #endregion "Constructor"

        #region "Get Methods"  
        public GetFeeTermDescriptionsList GetFeeTermDescriptionsList()
        {
            var model = new GetFeeTermDescriptionsList();
            try
            {
                var FeeTermDescriptionsList = _FeeTermDescriptionsRepo.GetAll().ToList();
                var FeeStructures = _FeeStructuresRepo.GetAll().ToList();
                var FeeTypes = _FeeTypesRepo.GetAll().ToList();
                var classList = _classesRepo.GetAll().ToList();

                var query = (from _FeeTermDescriptions in FeeTermDescriptionsList
                             join feeStucture in FeeStructures on _FeeTermDescriptions.FeeStructureId equals feeStucture.Id
                             join feeTypes in FeeTypes on feeStucture.FeeTypeId equals feeTypes.Id
                             join cls in classList on feeStucture.ClassId equals cls.Id
                             
                             select new { _FeeTermDescriptions, feeStucture, feeTypes, cls });

                var list = new List<GetFeeTermDescriptionsList_FeeTermDescriptions>();
                foreach (var item in query)
                {
                    var temp = new GetFeeTermDescriptionsList_FeeTermDescriptions()
                    {
                        Id = item._FeeTermDescriptions.Id,
                        FeeStructureId = item._FeeTermDescriptions.FeeStructureId,
                        TermNo = item._FeeTermDescriptions.TermNo,
                        TermName = item._FeeTermDescriptions.TermName,
                        ClassName = item.cls.Name,
                        FeeType = item.feeTypes.Name,
                        ClassId = item.feeStucture.ClassId,
                        FeeTypeId = item.feeStucture.FeeTypeId

                    };
                    list.Add(temp);
                };


                model = new GetFeeTermDescriptionsList()
                {
                    _FeeTermDescriptions = list
                };

            }
            catch (Exception)
            {

            }
            return model;
        }




        #endregion "Get Methods"              

        
        #region "Insert update and delete Function"  
        public string InsertFeeTermDescriptions(InsertFeeTermDescriptions obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    var FeeStaructure = _FeeStructuresRepo.GetAll().ToList();
                    //[Note: insert 'states' table]
                    if (obj.FeeTermDescriptions != null)
                    {
                        var getFeeStructure = (from fs in FeeStaructure
                                               where fs.ClassId == obj.FeeTermDescriptions.ClassId && fs.FeeTypeId == obj.FeeTermDescriptions.FeeTypeId && fs.StartingYear.Value.Year <= DateTime.Now.Year && fs.EndingYear.Value.Year >= DateTime.Now.Year
                                               select fs).SingleOrDefault();
                        var FeeTermDescriptions = new InsertFeeTermDescriptions_FeeTermDescriptions()
                        {
                            TermName = obj.FeeTermDescriptions.TermName,
                            TermNo = obj.FeeTermDescriptions.TermNo,
                            FeeStructureId = getFeeStructure.Id,
                        };
                        _FeeTermDescriptionsRepo.Insert(FeeTermDescriptions);
                        returnResult = "Saved";
                    }
                }
            }
            catch (Exception ex)
            {
                returnResult = "ERROR102:FeeTermDescriptionsServ/InsertFeeTermDescriptionsList - " + ex.Message;
            }
            return returnResult;
        }
        public string UpdateFeeTermDescriptions(UpdateFeeTermDescriptions obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    var FeeStaructure = _FeeStructuresRepo.GetAll().ToList();
                    if (obj.FeeTermDescriptions != null)
                    {
                        var getFeeStructure = (from fs in FeeStaructure
                                               where fs.ClassId == obj.FeeTermDescriptions.ClassId && fs.FeeTypeId == obj.FeeTermDescriptions.FeeTypeId && fs.StartingYear.Value.Year <= DateTime.Now.Year && fs.EndingYear.Value.Year >= DateTime.Now.Year
                                               select fs).SingleOrDefault();
                        var currentItem = _FeeTermDescriptionsRepo.Get(obj.FeeTermDescriptions.Id);
                        currentItem.Id = obj.FeeTermDescriptions.Id;
                        currentItem.TermNo = obj.FeeTermDescriptions.TermNo;
                        currentItem.TermName = obj.FeeTermDescriptions.TermName;
                        currentItem.FeeStructureId = getFeeStructure.Id;
                        _FeeTermDescriptionsRepo.Update(currentItem);
                        returnResult = "Saved";
                    }
                }
            }
            catch (Exception ex)
            {
                returnResult = "ERROR102:FeeTermDescriptionsServ/UpdateFeeTermDescriptions - " + ex.Message;
            }
            return returnResult;
        }
        public DeleteFeeTermDescriptions DeleteFeeTermDescriptions(DeleteFeeTermDescriptions obj)
        {
            var returnModel = new DeleteFeeTermDescriptions();
            var FeeTermDescriptions = _FeeTermDescriptionsRepo.Get(obj.FeeTermDescriptions.Id);
            if (FeeTermDescriptions != null)
            {
                _FeeTermDescriptionsRepo.Delete(FeeTermDescriptions);
                returnModel.Message = "Delete Successful.";
            }
            return returnModel;
        }
        #endregion "Insert update and delete Function"  
        


    }
}
