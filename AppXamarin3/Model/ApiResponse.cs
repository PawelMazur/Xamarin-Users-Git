using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace AppXamarin3.Model
{
    class ApiResponse
    {
        [JsonProperty(PropertyName = "total_count")]
        public string TotalCount { get; set; }
        [JsonProperty(PropertyName = "incomplete_results")]
        public string IncompleteResults { get; set; }
        [JsonProperty(PropertyName = "items")]
        public List<User> Items { get; set; }

        public override string ToString()
        {
            return TotalCount;
        }
    }
}