using Class_Diagram___Hospital.Controller.Abstract;
using Class_Diagram___Hospital.Controller.DoctorControllers;
using Class_Diagram___Hospital.Controller.DoctorControllers.Abstract;
using Class_Diagram___Hospital.Controller.EquipmentAndRoomsController.Abstract;
using Class_Diagram___Hospital.Controller.LocationControllers;
using Class_Diagram___Hospital.Controller.LocationControllers.Abstract;
using Class_Diagram___Hospital.Controller.MedicalInfoControllers.Abstract;
using Class_Diagram___Hospital.Controller.MedicalServiceControllers.Abstract;
using Class_Diagram___Hospital.Dto.LocationDTOs;
using Class_Diagram___Hospital.Dto.UserDTOs;
using Class_Diagram___Hospital.Repository;
using Class_Diagram___Hospital.Repository.Abstract;
using Class_Diagram___Hospital.Repository.DoctorServicesRepositories;
using Class_Diagram___Hospital.Repository.DoctorServicesRepositories.Abstract;
using Class_Diagram___Hospital.Repository.EquipmentAndRoomsRepositories.Abstract;
using Class_Diagram___Hospital.Repository.IdGenerator;
using Class_Diagram___Hospital.Repository.LocationRepositories.Abstract;
using Class_Diagram___Hospital.Repository.LocationServices;
using Class_Diagram___Hospital.Repository.LocationServices.Abstract;
using Class_Diagram___Hospital.Repository.MedicalInfoRepositories.Abstract;
using Class_Diagram___Hospital.Repository.MedicalServicesRepositories.Abstract;
using Class_Diagram___Hospital.Repository.Streams;
using Class_Diagram___Hospital.Repository.UserRepositories;
using Class_Diagram___Hospital.Repository.UserRepositories.Abstract;
using Class_Diagram___Hospital.Service.Abstract;
using Class_Diagram___Hospital.Service.DoctorServices;
using Class_Diagram___Hospital.Service.DoctorServices.Abstract;
using Class_Diagram___Hospital.Service.EquipmentAndRoomsServices;
using Class_Diagram___Hospital.Service.EquipmentAndRoomsServices.Abstract;
using Class_Diagram___Hospital.Service.LocationServices;
using Class_Diagram___Hospital.Service.LocationServices.Abstract;
using Class_Diagram___Hospital.Service.MedicalInfoServices.Abstract;
using Class_Diagram___Hospital.Service.MedicalServices.Abstract;
using Controller.DoctorControllers;
using Controller.EquipmentAndRoomsController;
using Controller.MedicalInfoControllers;
using Controller.MedicalServiceControllers;
using Controller.PatientControllers;
using Controller.UserControllers;
using Dto.UserDTOs;
using Model.Doctor;
using Model.Doctor.InstructionAndPrescription;
using Model.EquipmentAndRooms;
using Model.MedicalService;
using Model.Patient;
using Model.Rating;
using Model.User;
using Repository.DoctorServicesRepositories;
using Repository.EquipmentAndRoomsRepositories;
using Repository.MedicalInfoRepositories;
using Repository.MedicalServicesRepositories;
using Repository.UserRepositories;
using Service.DoctorServices;
using Service.EquipmentAndRoomsServices;
using Service.MedicalInfoServices;
using Service.MedicalServices;
using Service.PatientService;
using Service.UserServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace Bolnica
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>  
    public partial class App : Application
    {
        private readonly IUserRepository userRepository;
        private readonly IPatientRepository patientRepository;
        private readonly IPatientService patientService;

        private readonly IServiceRoomService serviceRoomService;
        private readonly IServiceRoomRepository serviceRoomRepository;

        private readonly IMedicalRecordRepository medicalRecordRepository;
        private readonly IMedicalRecordService medicalRecordService;

        private readonly IUserProfileService userProfileService;
        private readonly IUnatuhenticatedUserService unauthenticatedUserService;

        private readonly HospitalizationRepository hospitalizationRepository;
        private readonly HospitalizationService hospitalizationService;


        private readonly HospitalizationRoomRepository hospitalizationRoomRepository;
        
        private readonly HospitalizationRoomService hospitalizationRoomService;

        private readonly EquipmentReservationTimeRepository equipmentReservationTimeRepository;
        private readonly EquipmentReservationTimeService equipmentReservationTimeService;

        private readonly MedicalEquipmentRepository medicalEquipmentRepository;

        private readonly OperationTypeRepository operationTypeRepository;
        private readonly OperationRepository operationRepository;
        private readonly OperationService operationService;

        private readonly ServiceTypeRepository serviceTypeRepository;
        private readonly ServiceTypeService serviceTypeService;

        private readonly ICityService cityService;
        private readonly ICityRepository cityRepository;

        private readonly ICountryService countryService;
        private readonly ICountryRepository countryRepository;

        private readonly IAppointmentRepository appointmentRepository;
        private readonly IAppointmentService appointmentService;

        private readonly IDurationPeriodRepository durationPeriodRepository;
        private readonly IDurationPeriodService durationPeriodService;

        private readonly IDoctorRepository doctorRepository;
        private readonly IDoctorsService doctorService;

        private readonly IShiftRepository shiftRepository;
        private readonly IShiftService shiftService;

        private readonly IRatingService ratingService;
        private readonly IRatingRepository ratingRepository;

        private readonly IReportService reportService;

        private readonly IAllergyRepository allergyRepository;

        private readonly IAnalysisTypeRepository analysisTypeRepository;

        private readonly IDrugRepository drugRepository;

        private readonly IVacationRepository vacationRepository;
        private readonly IVacationService vacationService;

        private readonly IReportRepository reportRepository;
        private readonly IDiagnosisRepository diagnosisRepository;



        public IUnatuhenticatedUserController UnauthenticatedUserController { get; private set; }
        public IHospitalizationController HospitalizationController { get; private set; }
        public IHospitalizationRoomController HospitalizationRoomController { get; private set; }
        public IOperationController OperationController { get; private set; }
        public IServiceTypeController ServiceTypeController { get; private set; }
        public IPatientController PatientController { get; private set; }
        public IServiceRoomController ServiceRoomController { get; private set; }
        public IMedicalRecordController MedicalRecordController { get; private set; }
        public IUserProfileController UserProfileController { get; private set; }
        public IUnatuhenticatedUserController UnatuhenticatedUserController { get; private set; }
        public ICityController CityController { get; private set; }
        public ICountryController CountryController { get; private set; }
        public IAppointmentController AppointmentController { get; private set; }
        public IDoctorsController DoctorController { get; private set; }
        public IRatingController RatingController { get; private set; }
        public IReportController ReportController { get; private set; }


        private List<User> users = new List<User>();
        private List<Patient> patients = new List<Patient>();
        private List<Doctor> doctors = new List<Doctor>();
        private List<SpecialistDoctor> specialistDoctors = new List<SpecialistDoctor>();
        private List<Hospitalization> hospitalizations = new List<Hospitalization>();
        private List<MedicalRecord> medicalRecords = new List<MedicalRecord>();
        private List<Room> rooms = new List<Room>();
        private List<HospitalizationRoom> hRooms = new List<HospitalizationRoom>();
        private List<MedicalEquipment> meList = new List<MedicalEquipment>();
        private List<ServiceType> stList = new List<ServiceType>();
        private List<City> cities = new List<City>();
        private List<Country> countries = new List<Country>();
        private List<DurationPeriod> durationPeriods = new List<DurationPeriod>();


        public App()
        {
            cityRepository = new CityRepository(new BinaryStream<City>(Constants.dbPath + Constants.cityFilePath), new IdLongGenerator());
            cityService = new CityService(cityRepository);
            CityController = new CityController(cityService);

            countryRepository = new CountryRepository(new BinaryStream<Country>(Constants.dbPath + Constants.countryFilePath), new IdLongGenerator());
            countryService = new CountryService(countryRepository);
            CountryController = new CountryController(countryService);

            

            serviceRoomRepository = new ServiceRoomRepository(new BinaryStream<ServiceRoom>(Constants.dbPath + Constants.serviceRoomFilePath), new IdLongGenerator());

            userRepository = new UserRepository(new BinaryStream<User>(Constants.dbPath + Constants.userFilePath), new IdLongGenerator());

            medicalRecordRepository = new MedicalRecordRepository(new BinaryStream<MedicalRecord>(Constants.dbPath + Constants.medicalRecordFilePath), new IdLongGenerator());
            appointmentRepository = new AppointmentRepository(new BinaryStream<Appointment>(Constants.dbPath + Constants.appointmentFilePath), new IdLongGenerator());

            operationRepository = new OperationRepository(new BinaryStream<Operation>(Constants.dbPath + Constants.operationFilePath), new IdLongGenerator());
            hospitalizationRepository = new HospitalizationRepository(new BinaryStream<Hospitalization>(Constants.dbPath + Constants.hospitalizationFilePath), new IdLongGenerator(), medicalRecordRepository);
            durationPeriodRepository = new DurationPeriodRepository(new BinaryStream<DurationPeriod>(Constants.dbPath + Constants.durationPeriodFilePath), new IdLongGenerator());
            durationPeriodService = new DurationPeriodService(durationPeriodRepository);
            shiftService = new ShiftService(durationPeriodService);
            doctorRepository = new DoctorRepository(new BinaryStream<Doctor>(Constants.dbPath + Constants.doctorFilePath), new IdLongGenerator());
            doctorService = new DoctorsService(doctorRepository, shiftService, appointmentRepository, durationPeriodService);

            allergyRepository = new AllergyRepository(new BinaryStream<Allergy>(Constants.dbPath + Constants.allergyFilePath), new IdLongGenerator());
            drugRepository = new DrugRepository(new BinaryStream<Drug>(Constants.dbPath + Constants.drugFilePath), new IdLongGenerator());

            medicalRecordService = new MedicalRecordService(medicalRecordRepository, drugRepository, doctorRepository, allergyRepository, analysisTypeRepository);
            MedicalRecordController = new MedicalRecordController(medicalRecordService);

            vacationService = new VacationService(operationRepository, appointmentRepository, vacationRepository);

            appointmentService = new AppointmentService(serviceRoomRepository, doctorService, medicalRecordRepository, appointmentRepository, operationRepository, doctorRepository, durationPeriodService, vacationService);
            AppointmentController = new AppointmentController(appointmentService);

            patientRepository = new PatientRepository(new BinaryStream<Patient>(Constants.dbPath + Constants.patientFilePath), new IdLongGenerator(), medicalRecordRepository);
            patientService = new PatientService(userRepository, patientRepository, cityRepository, appointmentRepository, medicalRecordRepository, operationRepository, appointmentService, doctorRepository, serviceRoomRepository, hospitalizationRepository);
            PatientController = new PatientController(patientService);

            unauthenticatedUserService = new UnauthenticatedUserService(userRepository, patientRepository, cityRepository);
            UnatuhenticatedUserController = new UnauthenticatedUserController(unauthenticatedUserService);


            DoctorController = new DoctorsController(doctorService);

            serviceRoomService = new ServiceRoomService(serviceRoomRepository, operationRepository, appointmentRepository);

            ratingRepository = new RatingRepository(new BinaryStream<Rating>(Constants.dbPath + Constants.ratingFilePath), new IdLongGenerator());
            ratingService = new RatingService(ratingRepository, patientRepository, doctorRepository);
            RatingController = new RatingController(ratingService);

            hospitalizationRoomRepository = new HospitalizationRoomRepository(new BinaryStream<HospitalizationRoom>(Constants.dbPath + Constants.hospitalizationRoomFilePath), new IdLongGenerator());
            hospitalizationService = new HospitalizationService(hospitalizationRepository, hospitalizationRoomRepository, medicalRecordRepository);
            HospitalizationController = new HospitalizationController(hospitalizationService);

            userProfileService = new UserProfileService(userRepository);
            UserProfileController = new UserProfileController(userProfileService);

            hospitalizationRoomService = new HospitalizationRoomService(hospitalizationRepository, hospitalizationRoomRepository);
            HospitalizationRoomController = new HospitalizationRoomController(hospitalizationRoomService);

            medicalEquipmentRepository = new MedicalEquipmentRepository(new BinaryStream<MedicalEquipment>(Constants.dbPath + Constants.medicalEquipmentFilePath), new IdLongGenerator());
            equipmentReservationTimeRepository = new EquipmentReservationTimeRepository(new BinaryStream<EquipmentReservationTime>(Constants.dbPath + Constants.equipmentReservationTimeFilePath), new IdLongGenerator());
            equipmentReservationTimeService = new EquipmentReservationTimeService(equipmentReservationTimeRepository, medicalEquipmentRepository);


            ServiceRoomController = new ServiceRoomController(serviceRoomService);

            operationTypeRepository = new OperationTypeRepository(new BinaryStream<OperationType>(Constants.dbPath + Constants.operationTypeFilePath), new IdLongGenerator());

            operationService = new OperationService(operationRepository, serviceRoomRepository, operationTypeRepository, doctorRepository, medicalRecordRepository, equipmentReservationTimeService, durationPeriodService, vacationService);
            OperationController = new OperationController(operationService);

            serviceTypeRepository = new ServiceTypeRepository(new BinaryStream<ServiceType>(Constants.dbPath + Constants.serviceTypeFilePath), new IdLongGenerator());
            serviceTypeService = new ServiceTypeService(serviceTypeRepository);
            ServiceTypeController = new ServiceTypeController(serviceTypeService);

            diagnosisRepository = new DiagnosisRepository(new BinaryStream<Diagnosis>(Constants.dbPath + Constants.diagnosisFilePath), new IdLongGenerator());
            reportRepository = new ReportRepository(new BinaryStream<Report>(Constants.dbPath + Constants.reportFilePath), new IdLongGenerator());

            reportService = new ReportService(appointmentRepository, reportRepository, diagnosisRepository);
            ReportController = new ReportController(reportService);

            initData();
        }



        public void initData()
        {
            deleteRepo();
            loadCitiesAndCountries();
            loadPatients();
            loadDoctors();
            loadDurationPeriods();
            loadMedicalRecords();
            loadRooms();
            loadPassedServices();
            loadPassedAppointments();
            loadUpcommingServices();
        }

        public void loadCitiesAndCountries()
        {
            Country srb = new Country("Srbija", 3);
            Country bih = new Country("Bosna", 333);

            countryRepository.Create(srb, srb.GetId());
            countryRepository.Create(bih, bih.GetId());

            countries.Add(srb);
            countries.Add(bih);

            City ns = new City(srb, "Novi Sad", 21000);
            City bg = new City(srb, "Beograd", 13000);
            City sr = new City(bih, "Sarajevo", 10);
            City tr = new City(bih, "Trebinje", 4);

            cityRepository.Create(ns, ns.GetId());
            cityRepository.Create(bg, bg.GetId());
            cityRepository.Create(sr, sr.GetId());
            cityRepository.Create(tr, tr.GetId());

            cities.Add(ns);
            cities.Add(bg);
            cities.Add(sr);
            cities.Add(tr);
        }

        public void loadRooms()
        {
            //Console.WriteLine("\n------------ Rooms ------------\n");
            Room r1 = new Room(null, 1, "Neka soba1");
            Room r2 = new Room(null, 2, "Neka soba2");
            rooms.Add(r1);
            rooms.Add(r2);

            HospitalizationRoom hr1 = hospitalizationRoomRepository.Create(new HospitalizationRoom(1, rooms[0]));
            HospitalizationRoom hr2 = hospitalizationRoomRepository.Create(new HospitalizationRoom(5, rooms[1]));
            hRooms.Add(hr1);
            hRooms.Add(hr2);

            //ServiceRoom sr1 = serviceRoomRepository.Create(new ServiceRoom(stList[0], ))

            //Console.WriteLine("\n------------ Rooms - End ------------\n");
        }

        public void loadMedicalRecords()
        {
            //Console.WriteLine("\n------------ Medical Records ------------\n");
            foreach (Patient p in patients)
                medicalRecords.Add(medicalRecordRepository.Create(new MedicalRecord(p)));
            //Console.WriteLine("\n------------ Medical Records - End ------------\n");
        }

        public void loadPatients()
        {
            //Console.WriteLine("\n------------ Patients ------------\n");
            PatientDTO patientDTO1 = new PatientDTO(Sex.Female, new DateTime(), null, "p1", "p1", "0509878905401", "pacijent", "pacijent1@smt.com", "0574567898", "Address 1", 15);
            Patient p1 = new Patient(patientDTO1);
            p1.SetBitrhPlace(cities[0]);

            PatientDTO patientDTO2 = new PatientDTO(Sex.Male, new DateTime(), null, "p2", "p2", "0509878905401", "ppacijent", "pacijent2@smt.com", "0574567898", "Address 1", 15);
            Patient p2 = new Patient(patientDTO2);
            p2.SetBitrhPlace(cities[3]);

            User user1 = userRepository.Create(new User((UserDTO)patientDTO1));
            User user2 = userRepository.Create(new User((UserDTO)patientDTO2));
            patientRepository.Create(p1, user1.GetId());
            patientRepository.Create(p2, user2.GetId());

            patients.Add(p1);
            patients.Add(p2);

            //Console.WriteLine("\n------------ Patients - End ------------\n");
        }

        public void loadDoctors()
        {
            Console.WriteLine("\n------------ Doctors ------------\n");

            UserDTO uDoctorDTO1 = new UserDTO("Prvi", "PrviPrez", "0509878905401", "drname1", "drname1@smt.com", "0574567898", "Address 1", 15);
            Doctor doctor1 = new Doctor(uDoctorDTO1);
            User uDoctor1 = userRepository.Create(new User(uDoctorDTO1));
            doctorRepository.Create(doctor1, uDoctor1.GetId());

            UserDTO uDoctorDTO2 = new UserDTO("DoctorSpec", "DocPrez", "0509878905401", "drname2", "drname2@smt.com", "0574567898", "Address 1", 15);
            Speciality spec = new Speciality("Oftamolog");
            SpecialistDoctor doctor2spec = new SpecialistDoctor(spec, uDoctorDTO2);
            //User proba = new SpecialistDoctor(spec, uDoctorDTO2);
            User uDoctor2 = userRepository.Create((User)doctor2spec);
            doctorRepository.Create(doctor2spec, uDoctor2.GetId());
            specialistDoctors.Add(doctor2spec);

            Console.WriteLine("\n-- Users and Specialist Doctors --\n");
            IList<User> usersList = userRepository.GetAll();
            foreach (User u in usersList)
            {
                users.Add(u);
                Console.WriteLine("UserName: " + u.Name + " - UserId: " + u.GetId().ToString());
                if (u is SpecialistDoctor)
                {
                    Console.WriteLine("UserDoctorSpecialityName: " + ((SpecialistDoctor)u).Speciality.SpecialityName + "\n");
                }
            }
            Console.WriteLine("\n-- Users and Specialist Doctors - End --\n");

            Console.WriteLine("\n-- Adding doctors to list --\n");
            IList<Doctor> doctorsList = doctorRepository.GetAll();
            foreach (Doctor d in doctorsList)
            {
                doctors.Add(d);
                Console.WriteLine("Doctor name: " + d.Name + " - DoctorId: " + d.GetId().ToString());
            }
            Console.WriteLine("\n-- End --\n");

            Console.WriteLine("\n-- Get only oftamolozi --\n");
            IList<Doctor> specialityList = doctorRepository.GetAllDoctorsBySpeciality(spec);
            foreach (Doctor d in specialityList)
            {
                Console.WriteLine("Doctor name: " + d.Name + " - DoctorId: " + d.GetId().ToString());
            }
            Console.WriteLine("\n-- End --\n");

            Console.WriteLine("\n------------ Doctors - End ------------\n");
        }


        public void loadDurationPeriods()
        {
            Shift s = new Shift("Prva", new TimeSpan(7, 0, 0), new TimeSpan(17, 0, 0));
            DurationPeriod dp1 = new DurationPeriod(s, doctors[0], DateTime.Now, new DateTime(2020, 7, 20));
            durationPeriodRepository.Create(dp1);
        }

        public void loadPassedAppointments() {
            

            Diagnosis d = new Diagnosis("Sapun u ruke", "Sapunjaj");

            List<Diagnosis> diagnoses = new List<Diagnosis>() { d };
            Report report = new Report("Veliki problemi", "Pacijent se ne kupa", diagnoses);
            Appointment pa1 = new Appointment(report, doctors[0], true, 30, Priority.Doctor, serviceRoomRepository.Create(new ServiceRoom(new ServiceType("Pregledanje"), rooms[0])), medicalRecords[0], new DateTime(2020, 6, 10));
            appointmentRepository.Create(pa1);
        }

        public void loadPassedServices()
        {
            Hospitalization passedHospitalization1 = new Hospitalization(hRooms[0], new DateTime(2020, 6, 16), medicalRecords[0], new DateTime(2020, 6, 10));
            Hospitalization passedHospitalization2 = new Hospitalization(hRooms[0], new DateTime(2020, 6, 9), medicalRecords[0], new DateTime(2020, 6, 6));

            hospitalizationRepository.Create(passedHospitalization1);
            hospitalizationRepository.Create(passedHospitalization2);

            Operation passedOp = new Operation(new OperationType("Operisan", new Speciality("Kardio")), specialistDoctors[0], 30, new ServiceRoom(new ServiceType("Oftamoloska"), rooms[0]), medicalRecords[0], new DateTime(2020, 6, 20));
            operationRepository.Create(passedOp);
        }

        public void loadUpcommingServices()
        {
            Hospitalization uppcomingHospitalization1 = new Hospitalization(hRooms[0], new DateTime(2020, 7, 16), medicalRecords[0], new DateTime(2020, 7, 10));
            Hospitalization uppcomingHospitalization2 = new Hospitalization(hRooms[0], new DateTime(2020, 7, 9), medicalRecords[0], new DateTime(2020, 7, 6));

            hospitalizationRepository.Create(uppcomingHospitalization1);
            hospitalizationRepository.Create(uppcomingHospitalization2);

            Operation uppcomingOp = new Operation(new OperationType("Operisan", new Speciality("Kardio")), specialistDoctors[0], 30, new ServiceRoom(new ServiceType("Oftamoloska"), rooms[0]), medicalRecords[0], new DateTime(2020, 7, 20));
            operationRepository.Create(uppcomingOp);

            Appointment appointment = new Appointment(null, doctors[0], false, 30, Priority.Doctor, new ServiceRoom(new ServiceType("Pregledanje"), rooms[0]), medicalRecords[0], new DateTime(2020, 6, 29, 20, 0, 0));
            Appointment appointment1 = new Appointment(null, doctors[0], false, 30, Priority.Doctor, new ServiceRoom(new ServiceType("Pregledanje"), rooms[0]), medicalRecords[0], new DateTime(2020, 6, 30, 20, 0, 0));
            appointmentRepository.Create(appointment);
            appointmentRepository.Create(appointment1);
        }

        public void deleteRepo()
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(Constants.dbPath);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
        }
    }
}
