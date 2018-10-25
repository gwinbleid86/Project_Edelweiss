using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Edelweiss.BLL.DTO;
using Edelweiss.DAL.Entities;

namespace Edelweiss.BLL.Interfaces
{
    public interface ICountryService
    {
        IEnumerable<CountryDTO> GetAll();
        IEnumerable<CountryDTO> SortByPopularity();
        IEnumerable<CountryDTO> SortByName();
        CountryDTO Get(int id);
        CountryDTO GetDetached(int id);
        CountryDTO SingleOrDefault(Func<Country, bool> predicate);
        IQueryable<CountryDTO> Find(Expression<Func<Country, bool>> predicate);
        void Create(CountryDTO item);
        void Update(CountryDTO item);
        void Delete(int id);
        void UpdatePopularity(int country);
    }
}
