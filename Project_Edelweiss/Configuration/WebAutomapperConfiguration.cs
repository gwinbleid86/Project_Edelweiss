using AutoMapper;

namespace Project_Edelweiss.Configuration
{
    public class WebAutomapperConfiguration : Profile
    {
        public WebAutomapperConfiguration()
        {
            //CreateMap<AgentDTO, AgentViewModel>()
            //    .ForMember(x => x.ParentAgentViewModel, opt => opt.MapFrom(s => s.ParentAgentDto));
            //CreateMap<AgentViewModel, AgentDTO>()
            //    .ForMember(x => x.ParentAgentDto, opt => opt.MapFrom(s => s.ParentAgentViewModel));
            //CreateMap<ClientDTO, ClientViewModel>();
            //CreateMap<ClientViewModel, ClientDTO>();
            //CreateMap<CountryDTO, CountryViewModel>()
            //    .ForMember(x => x.AgentViewModels, opt => opt.MapFrom(s => s.AgentDTOs));

            //CreateMap<CountryViewModel, CountryDTO>()
            //    .ForMember(x => x.AgentDTOs, opt => opt.MapFrom(s => s.AgentViewModels));
            //CreateMap<SysTransactionDTO, SysTransactionViewModel>();
            //CreateMap<SysTransactionViewModel, SysTransactionDTO>();
            //CreateMap<UserDTO, UserViewModel>();

        }
    }
}
