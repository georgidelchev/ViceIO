using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using ViceIO.Common;
using ViceIO.Data.Common.Repositories;
using ViceIO.Data.Models;
using ViceIO.Services.Mapping;
using ViceIO.Web.ViewModels.Pictures;

namespace ViceIO.Services.Services
{
    public class PicturesService : IPicturesService
    {
        private const char PictureExtensionDelimiter = '.';

        private readonly string[] allowedExtensions = { "jpg", "png", "jfif", "exif", "gif", "bmp", "ppm", "pgm", "pbm", "pnm", "heif", "bat" };
        private readonly IDeletableEntityRepository<Picture> picturesRepository;
        private readonly Random random;

        public PicturesService(
            IDeletableEntityRepository<Picture> picturesRepository,
            Random random)
        {
            this.picturesRepository = picturesRepository;
            this.random = random;
        }

        public async Task CreateAsync(CreatePictureInputModel input, string userId, string imagePath)
        {
            Directory.CreateDirectory($"{imagePath}/Pictures/");

            var extension = Path
                .GetExtension(input.Picture.FileName)
                .TrimStart(PictureExtensionDelimiter);

            if (!this.allowedExtensions
                .Any(e => e.ToLower().EndsWith(extension.ToLower())))
            {
                throw new Exception($"Invalid image extension {extension}.");
            }

            var picture = new Picture()
            {
                AddedByUserId = userId,
                CategoryId = input.CategoryId,
                Name = input.Name,
                SourceUrl = input.SourceUrl,
                Extension = extension,
            };

            await this.picturesRepository.AddAsync(picture);
            await this.picturesRepository.SaveChangesAsync();

            var physicalPath = $"{imagePath}/Pictures/{picture.Id}.{extension}";

            await using var fileStream = new FileStream(physicalPath, FileMode.Create);
            await input.Picture.CopyToAsync(fileStream);
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage)
            => this.picturesRepository
                .All()
                .To<T>()
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage)
                .ToList();

        public T GetRandom<T>()
            => this.picturesRepository
                .All()
                .OrderBy(p => Guid.NewGuid())
                .Skip(this.random.Next(GlobalConstants.GetRandomStartingIndex, this.GetCount()))
                .To<T>()
                .FirstOrDefault();

        public int GetCount()
            => this.picturesRepository
                .All()
                .Count();

        public T GetById<T>(int pictureId)
            => this.picturesRepository
                .All()
                .Where(p => p.Id == pictureId)
                .To<T>()
                .FirstOrDefault();

        public T Details<T>(int pictureId)
            => this.picturesRepository
                .All()
                .Where(p => p.Id == pictureId)
                .To<T>()
                .FirstOrDefault();
    }
}
