using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExercisePage : ContentPage
    {
        string pageType = "Exercise";
        string passForAPI = "santa maria";
        public ExercisePage()
        {
            InitializeComponent();
        }
        public async Task GetExercises(string muscle)
        {


            string apiKey = "ViGEWR4sqcv9iyB8zDL+5Q==9Qn1BYDXebUkkSX4";
            string api_url = $"https://api.api-ninjas.com/v1/exercises?muscle={muscle}";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

            HttpResponseMessage response = await client.GetAsync(api_url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                JArray exercises = JArray.Parse(responseBody);

                if (exercises.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("Exercises for " + muscle + ":");
                    sb.Append(Environment.NewLine);
                    foreach (JObject exercise in exercises)
                    {
                        sb.Append("• " + exercise["name"].ToString());
                        sb.Append(Environment.NewLine);
                    }
                    txtExercise.Text = sb.ToString();
                    txtExercise.IsVisible = true;
                }
                else
                {
                    txtExercise.Text = "No exercises found for this muscle group.";
                    txtExercise.IsVisible = true;
                }
            }
            else
            {
                txtExercise.Text = $"Error: {response.StatusCode}, {response.ReasonPhrase}";
                txtExercise.IsVisible = true;
            }
        }
        private async void OnSearchClicked(object sender, EventArgs e)
        {
            string muscle = txtMuscleGroup.Text;
            await GetExercises(muscle);
        }
    }
}