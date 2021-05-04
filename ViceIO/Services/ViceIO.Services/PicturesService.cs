using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;
using ViceIO.Web.ViewModels.Pictures;

namespace ViceIO.Services
{
    public class PicturesService : IPicturesService
    {
        private readonly string[] allowedExtensions = { "jpg", "png" };
        private readonly IDeletableEntityRepository<Picture> picturesRepository;
        private readonly Random random;

        public PicturesService(IDeletableEntityRepository<Picture> picturesRepository, Random random)
        {
            this.picturesRepository = picturesRepository;
            this.random = random;
        }

        public async Task CreateAsync(CreatePictureInputModel input, string userId, string imagePath)
        {
            Directory.CreateDirectory($"{imagePath}/Pictures/");

            var extension = Path
                .GetExtension(input.Picture.FileName)
                .TrimStart('.');

            if (!this.allowedExtensions
                .Any(e => e.EndsWith(e)))
            {
                throw new Exception($"Invalid image extension {extension}.");
            }

            var picture = new Picture()
            {
                AddedByUserId = userId,
                CategoryId = input.CategoryId,
                Name = input.Name,
                LocalUrl = input.Url,
                SourceUrl = input.SourceUrl,
                Extension = extension,
            };

            await this.picturesRepository.AddAsync(picture);
            await this.picturesRepository.SaveChangesAsync();

            var physicalPath = $"{imagePath}/Pictures/{picture.Id}.{extension}";

            using var fileStream = new FileStream(physicalPath, FileMode.Create);
            await input.Picture.CopyToAsync(fileStream);
        }

        public IEnumerable<GetPictureBaseViewModel> GetAll(int page, int itemsPerPage = 12)
        {
            var pictures = this.picturesRepository
                .All()
                .Select(p => new GetPictureBaseViewModel()
                {
                    AddedByUserEmail = p.AddedByUser.Email,
                    CategoryName = p.Category.Name,
                    Url = p.LocalUrl,
                    SourceUrl = p.SourceUrl,
                    CreatedOn = p.CreatedOn,
                    Id = p.Id,
                    AddedByUserId = p.AddedByUserId,
                    Extension = p.Extension,
                    Name = p.Name,
                })
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

            return pictures;
        }

        public GetPictureBaseViewModel GetRandom()
        {
            var randomPicture = this.picturesRepository
                .All()
                .OrderBy(p => Guid.NewGuid())
                .Skip(this.random.Next(0, this.picturesRepository.All().Count()))
                .Select(p => new GetPictureBaseViewModel()
                {
                    AddedByUserEmail = p.AddedByUser.Email,
                    CategoryName = p.Category.Name,
                    Url = p.LocalUrl,
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
                    Url = p.LocalUrl,
                    SourceUrl = p.SourceUrl,
                    CreatedOn = p.CreatedOn,
                    Id = p.Id,
                    AddedByUserId = p.AddedByUserId,
                })
                .FirstOrDefault();

            return picture;
        }

        public GetPictureDetailsViewModel Details(int pictureId)
        {
            var pictureDetails = this.picturesRepository
                .All()
                .Where(p => p.Id == pictureId)
                .Select(p => new GetPictureDetailsViewModel()
                {
                    AddedByUserEmail = p.AddedByUser.Email,
                    AverageVote = 0.0, // TODO: Implement average.
                    CategoryName = p.Category.Name,
                    CreatedOn = p.CreatedOn,
                    Name = p.Name,
                    Id = p.Id,
                    AddedByUserId = p.AddedByUserId,
                    Extension = p.Extension,
                })
                .FirstOrDefault();

            return pictureDetails;
        }
    }
}
