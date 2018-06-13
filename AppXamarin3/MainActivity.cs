using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using System.Collections.Generic;
using AppXamarin3.Model;
using System;
using Refit;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;

namespace AppXamarin3
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {

        IGitHubApi gitHubApi;
        List<User> users = new List<User>();
        List<String> user_names = new List<String>();
        Button cake_button;
        IListAdapter ListAdapter;
        ListView listView;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);

                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.activity_main);

                gitHubApi = RestService.For<IGitHubApi>("https://api.github.com");

                cake_button = FindViewById<Button>(Resource.Id.btn_list_users);
                listView = FindViewById<ListView>(Resource.Id.listview_users);

                cake_button.Click += Cake_Button_Click;

                JsonConvert.DefaultSettings =()=> new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    Converters = { new StringEnumConverter() }
                };
            }catch
            {
                Toast.MakeText(this, "Error", ToastLength.Short).Show();
            }
        }

        private void Cake_Button_Click(object sender, EventArgs e)
        {
            GetUsers();
        }

         


        private async void GetUsers()
        {
            
            //try
            //{

                ApiResponse response = await gitHubApi.GetUsers();
                users = response.Items;

                foreach (User user in users)
                {
                    Console.WriteLine(user.userName);
                    user_names.Add(user.ToString());
                }

                ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, user_names);
                listView.Adapter = ListAdapter;
            //} catch
            //{
            //    Toast.MakeText(this, "Error", ToastLength.Short).Show();
            //}
        }
    }
}

