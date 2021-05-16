using System.Linq;

using AutoMapper;
using ViceIO.Data.Models;
using ViceIO.Services.Mapping;

namespace ViceIO.Web.ViewModels.Vices
{
    public class GetViceDetailsViewModel : GetViceBaseViewModel, IHaveCustomMappings
    {
        public double AverageVote { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Vice, GetViceDetailsViewModel>()
                .ForMember(m => m.AverageVote, opt => opt.MapFrom(v => v.ViceVotes.Count == 0 ? 0 : v.ViceVotes.Average(vv => vv.Value)));
        }
    }
}