using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using AutoMapper;
using Edelweiss.BLL.DTO;
using Edelweiss.BLL.Infrastructure;
using Edelweiss.BLL.Interfaces;
using Edelweiss.DAL.Entities;
using Edelweiss.DAL.Interfaces;

namespace Edelweiss.BLL.Services
{
    public class CountryService : ICountryService
    {
        IUnitOfWork Database { get; set; }

        public CountryService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<CountryDTO> GetAll()
        {
            var country = Database.Countries.GetAll();
            return Mapper.Map<IEnumerable<Country>, List<CountryDTO>>(country);
        }

        public CountryDTO Get(int id)
        {
            var country = Database.Countries.Get(id);
            if (country == null)
                throw new ValidationException("Страна не найдена", "");

            return Mapper.Map<CountryDTO>(country);
        }

        public CountryDTO GetDetached(int id)
        {
            var country = Database.Countries.GetDetached(id);
            if (country == null)
                throw new ValidationException("Страна не найдена", "");

            return Mapper.Map<CountryDTO>(country);
        }

        public CountryDTO SingleOrDefault(Func<Country, bool> predicate)
        {
            return Mapper.Map<CountryDTO>(Database.Countries.SingleOrDefault(predicate));
        }

        public IQueryable<CountryDTO> Find(Expression<Func<Country, bool>> predicate)
        {
            return Mapper.Map<IQueryable<CountryDTO>>(Database.Countries.Find(predicate));
        }

        public void Create(CountryDTO item)
        {
            Database.Countries.Create(Mapper.Map<Country>(item));
            Database.Save();
        }

        public void Update(CountryDTO item)
        {
            Database.Countries.Update(Mapper.Map<Country>(item));
            Database.Save();
        }

        public void Delete(int id)
        {
            Database.Countries.Delete(id);
            Database.Save();
        }

        public void UpdatePopularity(int countryId)
        {
            CountryDTO countryDto = GetDetached(countryId);
            ++countryDto.CountQTY;
            Update(countryDto);
        }

        public IEnumerable<CountryDTO> SortByPopularity()
        {
            var countries = Database.Countries.GetAll();
            countries = countries.OrderByDescending(s => s.CountQty);
            return Mapper.Map<IEnumerable<Country>, List<CountryDTO>>(countries);
        }

        public IEnumerable<CountryDTO> SortByName()
        {
            var countries = Database.Countries.GetAll();
            countries = countries.OrderByDescending(s => s.Name);
            return Mapper.Map<IEnumerable<Country>, List<CountryDTO>>(countries);
        }
    }
}
