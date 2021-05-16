using System.Linq;

using AutoMapper;
using ViceIO.Data.Models;
using ViceIO.Services.Mapping;

namespace ViceIO.Web.ViewModels.Riddles
{
    public class GetAllRiddlesViewModel : GetRiddleBaseViewModel, IHaveCustomMappings
    {
        public double AverageVote { get; set; }

        public string ShortName
            => this.Content.Substring(0, this.Content.Length >= 20 ? 20 : this.Content.Length);

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Riddle, GetAllRiddlesViewModel>()
                .ForMember(m => m.AverageVote, opt => opt.MapFrom(r => r.RiddleVotes.Count == 0 ? 0 : r.RiddleVotes.Average(rv => rv.Value)));
        }
    }
}
