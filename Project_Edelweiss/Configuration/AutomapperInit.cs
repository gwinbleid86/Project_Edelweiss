using AutoMapper;
using AutoMapper.EquivalencyExpression;
using Edelweiss.BLL.Configuration;

namespace Project_Edelweiss.Configuration
{
    public static class AutomapperInit
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new WebAutomapperConfiguration());
                cfg.AddProfile(new DbMapperConfiguration());
                cfg.AddCollectionMappers();
                //cfg.CreateMap<SysTransaction, SysTransactionDTO>()
                //    .EqualityComparison((st, stDTO) => st.Id == stDTO.Id);
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}
