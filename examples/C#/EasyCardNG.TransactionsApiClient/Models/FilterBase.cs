using Shared.Helpers.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace Shared.Api.Models
{
    public class FilterBase
    {
        [Range(-1, double.MaxValue)]
        public int? Take { get; set; }

        [Range(0, double.MaxValue)]
        public int? Skip { get; set; }

        public string SortBy { get; set; }

        public bool? SortDesc { get; set; }

        public ShowDeletedEnum ShowDeleted { get; set; }
    }
}
