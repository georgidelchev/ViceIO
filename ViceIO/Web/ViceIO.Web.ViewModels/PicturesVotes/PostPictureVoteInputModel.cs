using System.ComponentModel.DataAnnotations;

namespace ViceIO.Web.ViewModels.PicturesVotes
{
    public class PostPictureVoteInputModel
    {
        public int PictureId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}