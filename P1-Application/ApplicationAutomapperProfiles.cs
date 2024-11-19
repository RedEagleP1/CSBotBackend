using AutoMapper;
using P1_Application.UseCases.ContainerRegistry.GetContainerByType;
using P1_Core.Entities;

namespace P1_Application
{
    public class ApplicationAutomapperProfiles : Profile
    {
        public ApplicationAutomapperProfiles()
        {
            CreateMap<Container, ContainerQueryResponse>().ReverseMap();
        }

    }
}