using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Refit;

namespace AppXamarin3.Model
{

    [Headers("User-Agent: :request:")]
    interface IGitHubApi
    {
        [Get("/search/users?q=location:lagos")]
        Task<ApiResponse> GetUsers();
    }
}