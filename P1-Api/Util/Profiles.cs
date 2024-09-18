using AutoMapper;
using P1_Api.Models;
using P1_Application.UseCases.Conditions.CreateCondition;
using P1_Application.UseCases.Conditions.GetCondition;
using P1_Application.UseCases.Conditions.GetAllConditions;
using P1_Application.UseCases.Conditions.UpdateCondition;
using P1_Application.UseCases.Conditions.DeleteCondition;

namespace P1_Api.Util
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<CreateConditionCommand, CreateConditionRequestModel>().ReverseMap();
            CreateMap<GetConditionQuery, GetConditionRequestModel>().ReverseMap();
            CreateMap<GetAllConditionsQuery, GetAllConditionsRequestModel>().ReverseMap();
            CreateMap<UpdateConditionCommand, UpdateConditionRequestModel>().ReverseMap();
            CreateMap<DeleteConditionCommand, DeleteConditionRequestModel>().ReverseMap();
        }
    }
}