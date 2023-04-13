using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FitnessTest
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InputPage : ContentPage
    {
        string apiKey;
        public InputPage()
        {
            InitializeComponent();
            
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            double height = double.Parse(txtHeight.Text);
            double weight = double.Parse(txtWeight.Text);
            int age = int.Parse(txtAge.Text);
            bool isMale = rbMale.IsChecked;

            double calorieIntake = CalculateCalorieIntake(height, weight, age, isMale);

            lblCalorieIntake.Text = $"Estimated daily calorie intake: {calorieIntake.ToString("0")} calories";
            lblCalorieIntake.IsVisible = true;
        }
        private double CalculateCalorieIntake(double height, double weightInKG, int age, bool isMale)
        {

            double heightInMeters = height;
            double weight = weightInKG; //Kg
            // Calculate basal metabolic rate (BMR) using the Harris-Benedict equation
            double bmr = 0;
            if (isMale) //Automatically translate to centimeter
            {
                bmr = 88.362 + (13.397 * weight) + (4.799 * heightInMeters * 100) - (5.677 * age);
            }
            else
            {
                bmr = 447.593 + (9.247 * weight) + (3.098 * heightInMeters * 100) - (4.330 * age);
            }

            // Calculate daily calorie intake by multiplying BMR by activity level
            double calorieIntake = bmr * 1.2; // assuming sedentary activity level

            return calorieIntake;
        }
    }
}