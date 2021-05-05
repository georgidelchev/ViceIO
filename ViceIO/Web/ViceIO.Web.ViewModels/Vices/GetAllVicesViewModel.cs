namespace ViceIO.Web.ViewModels.Vices
{
    public class GetAllVicesViewModel : GetViceBaseViewModel
    {
        public double AverageVote { get; set; }

        public string ShortName
            => this.Content.Substring(0, this.Content.Length >= 10 ? 10 : this.Content.Length);
    }
}
