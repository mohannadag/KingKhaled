using API.ViewModels.Branch;
using API.ViewModels.StaffPerformanceEvaluation;
using AutoMapper;
using Core.Models.General;
using Core.Models.StaffPerformanceEvaluation;

namespace API.Profiles
{
    public class StaffPerfomanceEvaluation : Profile
    {
        public StaffPerfomanceEvaluation()
        {
            CreateMap<EmploymentPerformanceEvaluation, EmploymentPerformanceEvaluationVM>().ReverseMap();
            CreateMap<Evaluation, EvaluationVM>().ReverseMap();
            CreateMap<Evaluation, UpdateEvaluationVM>().ReverseMap();
            CreateMap<EmployeePerfomanc, EmployeePerfomancVM>().ReverseMap();
            
            //.ForMember(viewModel => viewModel.EvaluationsID, model => model.MapFrom(x => x.Evaluations));

        }
    }
}
