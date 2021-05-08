using System.Threading.Tasks;

using ViceIO.Web.ViewModels.Feedback;

namespace ViceIO.Services
{
    public interface IFeedbackService
    {
        Task CreateAsync(CreateFeedbackInputModel input, string userId);
    }
}
