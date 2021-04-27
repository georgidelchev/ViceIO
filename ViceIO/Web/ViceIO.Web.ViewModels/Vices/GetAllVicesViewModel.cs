using System;
using System.Linq;

using AutoMapper;
using ViceIO.Data.Models;
using ViceIO.Services.Mapping;

namespace ViceIO.Web.ViewModels.Vices
{
    public class GetAllVicesViewModel : GetViceBaseViewModel
    {
        public double AverageVote { get; set; }

        public string ShortName
            => this.Content.Substring(0, this.Content.Length >= 20 ? 20 : this.Content.Length);
    }
}
