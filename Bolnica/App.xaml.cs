using Class_Diagram___Hospital.Controller.Abstract;
using Class_Diagram___Hospital.Repository;
using Class_Diagram___Hospital.Repository.IdGenerator;
using Class_Diagram___Hospital.Repository.Streams;
using Class_Diagram___Hospital.Repository.UserRepositories;
using Controller.PatientControllers;
using Controller.UserControllers;
using Model.User;
using Repository.UserRepositories;
using Service.PatientService;
using Service.UserServices;
using System.Windows;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>  
    public partial class App : Application
    {
        public IUnatuhenticatedUserController UnatuhenticatedUserController { get; private set; }
        public IUserProfileController UserProfileController { get; private set; }
        public IPatientController PatientController { get; private set; }

        public App()
        {
            var userRepository = new UserRepository(new BinaryStream<User>(Constants.userFilePath), new IdLongGenerator());
            var patientRepository = new PatientRepository(new BinaryStream<Patient>(Constants.patientFilePath), new IdLongGenerator());

            var unauthenticatedUserService = new UnauthenticatedUserService(userRepository, patientRepository);
            var userProfileService = new UserProfileService(userRepository);
            var patientService = new PatientService(userRepository, patientRepository);

            UnatuhenticatedUserController = new UnauthenticatedUserController(unauthenticatedUserService);
            UserProfileController = new UserProfileController(userProfileService);
            PatientController = new PatientController(patientService);
        }
    }
}
