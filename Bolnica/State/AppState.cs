using Class_Diagram___Hospital.Dto.UserDTOs;
using Dto.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.State
{
    class AppState
    {
        private UserDTO currentUser;

        public UserDTO CurrentUser
        {
            get
            {
                return currentUser;
            }
            set { currentUser = value; }
        }

        private PatientDTO currentPatient;

        public PatientDTO CurrentPatient
        {
            get { return currentPatient; }
            set { currentPatient = value; }
        }


        private AppState() { }

        private static AppState instance = new AppState();

        public static AppState GetInstance()
        {
            return instance;
        }

        public void restart() {
            CurrentPatient = null;
            CurrentUser = null;
        }
    }
}
