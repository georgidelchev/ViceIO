using ViceIO.Data.Models;
using ViceIO.Services.Mapping;

namespace ViceIO.Web.ViewModels.Vices
{
    public class GetAllVicesViewModel : IMapFrom<Vice>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string ShortName
            => this.Content.Substring(0, this.Content.Length >= 15 ? 15 : this.Content.Length);
    }
}
