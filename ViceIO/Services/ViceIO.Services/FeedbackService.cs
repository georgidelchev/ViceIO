using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;
using ViceIO.Web.ViewModels.Feedback;

namespace ViceIO.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IDeletableEntityRepository<Feedback> feedbackRepository;
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public FeedbackService(IDeletableEntityRepository<Feedback> feedbackRepository, IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.feedbackRepository = feedbackRepository;
            this.usersRepository = usersRepository;
        }

        public async Task CreateAsync(CreateFeedbackInputModel input, string userId)
        {
            var email = this.usersRepository
                .All()
                .FirstOrDefault(u => u.Id == userId)
                .Email;

            var feedback = new Feedback()
            {
                Content = input.Content,
                Email = email,
                FullName = input.FullName,
                Subject = input.Subject,
                UserId = userId,
            };

            await this.feedbackRepository.AddAsync(feedback);
            await this.feedbackRepository.SaveChangesAsync();
        }
    }
}
