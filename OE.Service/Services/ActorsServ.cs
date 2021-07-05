using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OE.Service
{
    public class ActorsServ : IActorsServ
    {
        #region "Variables"
        private IActorsRepo<Actors> _actorsRepo;
        #endregion "Variables"

        #region "Constructor"
        public ActorsServ(IActorsRepo<Actors> actorsRepo)
        {
            _actorsRepo = actorsRepo;
        }
        #endregion "Constructor"

        #region "Get Methods"
        
        #endregion "Get Methods"

        #region "Dropdown Methods"
        public IEnumerable<dropdown_Actors> Dropdown_Actors(Int64 actorId)
        {
            var actorss = _actorsRepo.GetAll().ToList();
            var query = from a in actorss
                        orderby a.Name
                        select a;

            var filterQuery = (dynamic)null;
            if (actorId == 1)
            {
                filterQuery = query.Where(a => a.Id == 2 || a.Id == 3);
            }
            else if (actorId == 11)
            {
                filterQuery = query.Where(a => a.Id == 12 || a.Id == 13);
            }
            else
            {
                filterQuery = query;
            }
            if (actorId == 14)
            {
                filterQuery = query.Where(a => a.Id == 14);
            }

            //[NOTE: add new record]
            var queryResult = new List<dropdown_Actors>();            

            foreach (var item in filterQuery)
            {
                var d = new dropdown_Actors()
                {
                    Id = item.Id,
                    Name = item.Name
                };
                queryResult.Add(d);
            }
            return queryResult;

        }

        public IEnumerable<dropdown_Actors> Dropdown_Actors()
        {
            var actorss = _actorsRepo.GetAll().ToList();
            var query = from a in actorss

                        select a;


            var queryResult = new List<dropdown_Actors>();

            foreach (var item in query)
            {
                var d = new dropdown_Actors()
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
