using AutoMapper;
using P1_Api.Models.Rules;
using P1_Api.Models.Teams;
using P1_Application.UseCases.Rules.AddConditionToRule;
using P1_Application.UseCases.Rules.AddResultToRule;
using P1_Application.UseCases.Rules.AddTriggerToRule;
using P1_Application.UseCases.Rules.RemoveConditionFromRule;
using P1_Application.UseCases.Rules.RemoveResultFromRule;
using P1_Application.UseCases.Rules.RemoveTriggerFromRule;
using P1_Application.UseCases.Teams.AddMemberToTeam;
using P1_Application.UseCases.Teams.RemoveMemberFromTeam;
using P1_Application.UseCases.Teams.AddGameToTeam;
using P1_Application.UseCases.Teams.RemoveGameFromTeam;
using P1_Api.Models.ContainerRegistry;
using P1_Application.UseCases.ContainerRegistry.CreateContainer;


namespace P1_Api.Util
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<AddConditionToRuleRequestModel, AddConditionToRuleCommand>();
            CreateMap<RemoveConditionFromRuleRequestModel, RemoveConditionFromRuleCommand>();

            CreateMap<AddResultToRuleRequestModel, AddResultToRuleCommand>();
            CreateMap<RemoveResultFromRuleRequestModel, RemoveResultFromRuleCommand>();

            CreateMap<AddTriggerToRuleRequestModel, AddTriggerToRuleCommand>();
            CreateMap<RemoveTriggerFromRuleRequestModel, RemoveTriggerFromRuleCommand>();


            CreateMap<AddGameToTeamRequestModel, AddGameToTeamCommand>();
            CreateMap<RemoveGameFromTeamRequestModel, RemoveGameFromTeamCommand>();

            CreateMap<AddMemberToTeamRequestModel, AddMemberToTeamCommand>();
            CreateMap<RemoveMemberFromTeamRequestModel, RemoveMemberFromTeamCommand>();

            CreateMap<ContainerRequestModel, ContainerRequestCommand>();

        }
    }
}