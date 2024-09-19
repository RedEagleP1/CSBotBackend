using AutoMapper;
using P1_Api.Models;
using P1_Api.Models.Conditions;
using P1_Api.Models.Rules;
using P1_Application.UseCases.Conditions.CreateCondition;
using P1_Application.UseCases.Conditions.GetAllConditions;
using P1_Application.UseCases.Conditions.UpdateCondition;
using P1_Application.UseCases.Rules.CreateRule;
using P1_Application.UseCases.Rules.GetAllRules;
using P1_Application.UseCases.Rules.UpdateRule;

namespace P1_Api.Util
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<CreateConditionCommand, CreateConditionRequestModel>().ReverseMap();
            CreateMap<GetAllConditionsQuery, GetAllConditionsRequestModel>().ReverseMap();
            CreateMap<UpdateConditionCommand, UpdateConditionRequestModel>().ReverseMap();

            CreateMap<CreateRuleCommand, CreateRuleRequestModel>().ReverseMap();
            CreateMap<GetAllRulesQuery, GetAllRulesRequestModel>().ReverseMap();
            CreateMap<UpdateRuleCommand, UpdateRuleRequestModel>().ReverseMap();
        }
    }
}