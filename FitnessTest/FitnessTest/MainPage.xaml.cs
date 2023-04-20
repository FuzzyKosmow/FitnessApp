using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using Newtonsoft.Json.Linq;

namespace FitnessTest
{
    public partial class MainPage :  Shell
    {
        string apiKeyForExercise;
        public MainPage()
        {
            InitializeComponent();
        }

        //Api call function to get exercise
        
        public string GetAPIKey(string page, string password) 
        {
            string passCheck = "santa maria";
            switch(page)
            {
                case "Exercise":
                    if (password == passCheck)
                        return apiKeyForExercise;
                    else
                        Console.WriteLine("Wrong password");
                        return "";
                    
                default:
                    Console.WriteLine("Undefined page type");
                    return "";
            }
        }
    }
}
