using System.Threading.Tasks;

using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;
using ViceIO.Web.ViewModels.Pictures;

namespace ViceIO.Services
{
    public class PicturesService : IPicturesService
    {
        private readonly IDeletableEntityRepository<Picture> picturesRepository;

        public PicturesService(IDeletableEntityRepository<Picture> picturesRepository)
        {
            this.picturesRepository = picturesRepository;
        }

        public async Task CreateAsync(CreatePictureInputModel input, string userId)
        {
            var picture = new Picture()
            {
                AddedByUserId = userId,
                CategoryId = input.CategoryId,
                Name = input.Name,
                Url = input.Url,
                SourceUrl = input.SourceUrl,

            };

            await this.picturesRepository.AddAsync(picture);
            await this.picturesRepository.SaveChangesAsync();
        }
    }
}
