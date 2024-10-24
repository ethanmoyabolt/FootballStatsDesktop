using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using System.Windows;
using SportsAnalysisSystem.Models;
using Newtonsoft.Json;

namespace SportsAnalysisSystem.Handlers
{
    public class FirebaseDBHandler
    {

        IFirebaseConfig ifc = new FirebaseConfig()
        {
            AuthSecret = "gjf30CccfuS94HrVTdwJ3lNyU5TkoquDlLNVzUy5",
            BasePath = "https://test-database-aa0d6-default-rtdb.europe-west1.firebasedatabase.app/"
        };

        public FirebaseDBHandler()
        {

        }

        public IFirebaseClient FireDBConnect()
        {
            try
            {
                IFirebaseClient client = new FirebaseClient(ifc);
                return client;
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to connect to database");
                return null;
            }
        }
    }
}
