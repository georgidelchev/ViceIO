using System;
using System.Collections.Generic;
using System.Text;

namespace ViceIO.Web.ViewModels.Riddles
{
    public class GetAllRiddlesViewModel : GetRiddleBaseViewModel
    {
        public double AverageVote { get; set; }

        public string ShortName
            => this.Content.Substring(0, this.Content.Length >= 20 ? 20 : this.Content.Length);
    }
}
