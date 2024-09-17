using AutoMapper;
using P1_Api.Models;
using P1_Application.UseCases.Conditions.CreateCondition;

namespace P1_Api.Util
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<CreateConditionCommand, CreateConditionRequestModel>().ReverseMap();
        }
    }
}