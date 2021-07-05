
using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels.GendersServ;
using System.Collections.Generic;
using System.Linq;

namespace OE.Service
{
    public class GendersServ : IGendersServ
    {
        #region "Variables"
        private readonly IGendersRepo<Genders> _GendersRepo;
        #endregion "Variables"

        #region "Constructor"
        public GendersServ(
            IGendersRepo<Genders> GendersRepo

            )
        {
            _GendersRepo = GendersRepo;
        }
        #endregion "Constructor"

        #region "Dropdown Methods"        
        public IEnumerable<dropdown_Genders> Dropdown_Genders()
        {
            var genders = _GendersRepo.GetAll().ToList();
            var query = from g in genders
                        orderby g.Name
                        select g;

            //[NOTE: add new record]
            var queryResult = new List<dropdown_Genders>() {
                new dropdown_Genders(){ Id=0, Name="Select Gender"}
            };

            foreach (var item in query)
            {
                var d = new dropdown_Genders()
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

