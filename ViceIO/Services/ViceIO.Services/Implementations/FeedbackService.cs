using System.Threading.Tasks;

using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;
using ViceIO.Web.ViewModels.Feedback;

namespace ViceIO.Services.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IDeletableEntityRepository<Feedback> feedbackRepository;

        public FeedbackService(
            IDeletableEntityRepository<Feedback> feedbackRepository)
        {
            this.feedbackRepository = feedbackRepository;
        }

        public async Task CreateAsync(CreateFeedbackInputModel input, string userId)
        {
            var feedback = new Feedback()
            {
                Content = input.Content,
                Email = input.Email,
                FullName = input.FullName,
                Subject = input.Subject,
                UserId = userId,
            };

            await this.feedbackRepository.AddAsync(feedback);
            await this.feedbackRepository.SaveChangesAsync();
        }
    }
}
