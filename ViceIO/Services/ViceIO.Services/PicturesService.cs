using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;
using ViceIO.Web.ViewModels.Pictures;

namespace ViceIO.Services
{
    public class PicturesService : IPicturesService
    {
        private readonly IDeletableEntityRepository<Picture> picturesRepository;
        private readonly Random random;

        public PicturesService(IDeletableEntityRepository<Picture> picturesRepository, Random random)
        {
            this.picturesRepository = picturesRepository;
            this.random = random;
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

        public IEnumerable<GetPictureBaseViewModel> GetAll()
        {
            var pictures = this.picturesRepository
                .All()
                .Select(p => new GetPictureBaseViewModel()
                {
                    AddedByUserEmail = p.AddedByUser.Email,
                    CategoryName = p.Category.Name,
                    Url = p.Url,
                    SourceUrl = p.SourceUrl,
                    CreatedOn = p.CreatedOn,
                    Id = p.Id,
                    AddedByUserId = p.AddedByUserId,
                });

            return pictures;
        }

        public GetPictureBaseViewModel GetRandom()
        {
            var randomPicture = this.picturesRepository
                .All()
                .OrderBy(p => Guid.NewGuid())
                .Skip(this.random.Next(1, this.picturesRepository.All().Count()))
                .Select(p => new GetPictureBaseViewModel()
                {
                    AddedByUserEmail = p.AddedByUser.Email,
                    CategoryName = p.Category.Name,
                    Url = p.Url,
                    SourceUrl = p.SourceUrl,
                    CreatedOn = p.CreatedOn,
                    Id = p.Id,
                    AddedByUserId = p.AddedByUserId,
                })
                .FirstOrDefault();

            return randomPicture;
        }

        public int GetCount()
        {
            var picturesCount = this.picturesRepository
                .All()
                .Count();

            return picturesCount;
        }

        public GetPictureBaseViewModel GetById(int pictureId)
        {
            var picture = this.picturesRepository
                .All()
                .Where(p => p.Id == pictureId)
                .Select(p => new GetPictureBaseViewModel()
                {
                    AddedByUserEmail = p.AddedByUser.Email,
                    CategoryName = p.Category.Name,
                    Url = p.Url,
                    SourceUrl = p.SourceUrl,
                    CreatedOn = p.CreatedOn,
                    Id = p.Id,
                    AddedByUserId = p.AddedByUserId,
                })
                .FirstOrDefault();

            return picture;
        }
    }
}
