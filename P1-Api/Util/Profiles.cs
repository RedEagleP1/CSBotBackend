using AutoMapper;
using P1_Api.Models;
using P1_Api.Models.Conditions;
using P1_Api.Models.Rules;
using P1_Api.Models.Teams;
using P1_Application.UseCases;
using P1_Application.UseCases.Rules.AddConditionToRule;
using P1_Application.UseCases.Rules.AddResultToRule;
using P1_Application.UseCases.Rules.AddTriggerToRule;
using P1_Application.UseCases.Rules.RemoveConditionFromRule;
using P1_Application.UseCases.Rules.RemoveResultFromRule;
using P1_Application.UseCases.Rules.RemoveTriggerFromRule;
using P1_Application.UseCases.Teams.AddMemberToTeam;
using P1_Application.UseCases.Teams.RemoveMemberFromTeam;
using P1_Application.UseCases.Teams.AddMemberToOrganization;
using P1_Application.UseCases.Teams.RemoveMemberFromOrganization;
using P1_Application.UseCases.Teams.AddMemberToLegion;
using P1_Application.UseCases.Teams.RemoveMemberFromLegion;
using P1_Core.Interfaces;
using P1_Api.Models.Organizations;
using P1_Api.Models.Legions;
using P1_Application.UseCases.Teams.AddGameToTeam;
using P1_Application.UseCases.Teams.RemoveGameFromTeam;
using P1_Api.Controllers;


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

            CreateMap<AddMemberToOrganizationRequestModel, AddMemberToOrganizationCommand>();
            CreateMap<RemoveMemberFromOrganizationRequestModel, RemoveMemberFromOrganizationCommand>();

            CreateMap<AddMemberToLegionRequestModel, AddMemberToLegionCommand>();
            CreateMap<RemoveMemberFromLegionRequestModel, RemoveMemberFromLegionCommand>();


            CreateMap<CreateCommandRequest, CreateCommandCommand>();
        }
    }

}