using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageBordingFeeses.Classes
{
    public class FirebaseManager
    {
        private static FirebaseManager _instance;
        private readonly IFirebaseConfig _config;
        private IFirebaseClient _firebaseClient;


        private FirebaseManager()
        {
            _config = new FirebaseConfig
            {
                AuthSecret = "0iRBf7YZsv9Jzzr3ltNj8Xv23USPX5JVRgRb69iv",
                BasePath = "https://bording-data-default-rtdb.firebaseio.com/"
            };
        }

        public static FirebaseManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new FirebaseManager();
                }
                return _instance;
            }
        }

        public IFirebaseClient GetFirebaseClient()
        {
            if (_firebaseClient == null)
            {
                _firebaseClient = new FireSharp.FirebaseClient(_config);
            }

            return _firebaseClient;
        }


    }
}
