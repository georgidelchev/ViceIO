using System.ComponentModel.DataAnnotations;

namespace ViceIO.Web.ViewModels.VicesVotes
{
    public class PostViceVoteInputModel
    {
        public int ViceId { get; set; }

        [Range(1, 5)]
        public byte Value { get; set; }
    }
}
