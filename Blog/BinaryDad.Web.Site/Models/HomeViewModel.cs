using BinaryDad.Models;
using System.Collections.Generic;

namespace BinaryDad.Web.Site.Models
{
    public class HomeViewModel
    {
        public Page Page { get; set; }
        public IEnumerable<BlogEntry> Entries { get; set; }
    }
}