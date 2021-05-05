using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViceIO.Web.ViewModels.Feedback;

namespace ViceIO.Services
{
  public  class FeedbackService:IFeedbackService
    {
        public Task CreateAsync(CreateFeedbackInputModel input, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
