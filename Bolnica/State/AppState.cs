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
        private UserDTO currentUser = null;

        public UserDTO CurrentUser
        {
            get
            {
                return currentUser;
            }
            set { currentUser = value; }
        }

        private PatientDTO currentPatient = null;

        public PatientDTO CurrentPatient
        {
            get { return currentPatient; }
            set { currentPatient = value; }
        }

        public static PatientDTO Get { get; internal set; }

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
