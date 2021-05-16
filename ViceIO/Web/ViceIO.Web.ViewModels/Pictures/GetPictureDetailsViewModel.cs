using System.Linq;

using AutoMapper;
using ViceIO.Data.Models;
using ViceIO.Services.Mapping;

namespace ViceIO.Web.ViewModels.Pictures
{
    public class GetPictureDetailsViewModel : GetPictureBaseViewModel, IHaveCustomMappings
    {
        public double AverageVote { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration
                .CreateMap<Picture, GetPictureDetailsViewModel>()
                .ForMember(m => m.AverageVote, opt => opt.MapFrom(o => o.PictureVotes.Count == 0 ? 0 : o.PictureVotes.Average(pv => pv.Value)));
        }
    }
}
