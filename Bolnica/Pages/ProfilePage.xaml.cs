﻿using Bolnica.Modals;
using Bolnica.State;
using Class_Diagram___Hospital.Dto.UserDTOs;
using Dto.UserDTOs;
using Model.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bolnica.Pages
{
    /// <summary>
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page, INotifyPropertyChanged
    {
        private AppState state = AppState.GetInstance();

        #region NotifyProperties
        private string _nameAndLastName;

        public string NameAndLastName
        {
            get
            {
                return _nameAndLastName;
            }
            set
            {
                if (value != _nameAndLastName)
                {
                    _nameAndLastName = value;
                    OnPropertyChanged("NameAndLastName");
                }
            }
        }


        private string _email;

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged("Email");
                }
            }
        }


        private string _telephone;

        public string Telephone
        {
            get
            {
                return _telephone;
            }
            set
            {
                if (value != _telephone)
                {
                    _telephone = value;
                    OnPropertyChanged("Telephone");
                }
            }
        }

        private string _dateOfBirth;

        public string DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                if (value != _dateOfBirth)
                {
                    _dateOfBirth = value;
                    OnPropertyChanged("DateOfBirth");
                }
            }
        }

        private Sex _sex;

        public Sex Sex
        {
            get
            {
                return _sex;
            }
            set
            {
                if (value != _sex)
                {
                    _sex = value;
                    OnPropertyChanged("Sex");
                }
            }
        }

        private string _jmbg;

        public string Jmbg
        {
            get
            {
                return _jmbg;
            }
            set
            {
                if (value != _jmbg)
                {
                    _jmbg = value;
                    OnPropertyChanged("Jmbg");
                }
            }
        }

        private string _country;

        public string Country
        {
            get
            {
                return _country;
            }
            set
            {
                if (value != _country)
                {
                    _country = value;
                    OnPropertyChanged("Country");
                }
            }
        }

        private string _city;

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                if (value != _city)
                {
                    _city = value;
                    OnPropertyChanged("City");
                }
            }
        }
        private string _address;

        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                if (value != _address)
                {
                    _address = value;
                    OnPropertyChanged("Address");
                }
            }
        }
        private string _addressNumber;

        public string AddressNumber
        {
            get
            {
                return _addressNumber;
            }
            set
            {
                if (value != _addressNumber)
                {
                    _addressNumber = value;
                    OnPropertyChanged("AddressNumber");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion


        public ProfilePage()
        {
            InitializeComponent();
            this.DataContext = this;
            PatientDTO currentPatient = state.CurrentPatient;
            NameAndLastName = currentPatient.getName() + " " + currentPatient.getLastName();
            Jmbg = currentPatient.getJmbg();
            Address = currentPatient.getAddress();
            AddressNumber = currentPatient.getAppartmentNumber().ToString();
            Email = currentPatient.getEmail();
            Telephone = currentPatient.getTelephone();
            DateOfBirth = currentPatient.getBirthDate().ToString();
            City = currentPatient.getBirthPlace().Name;
            Country = currentPatient.getBirthPlace().CountryName;
            Sex = currentPatient.getSex();
        }



        private void Go_Back_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new HomePage());
        }

        private void Open_ChangePass_Modal(object sender, RoutedEventArgs e)
        {
            ChangePasswordModal modalWindow = new ChangePasswordModal();
            modalWindow.ShowDialog();
        }

        private void Open_ChangeProfile_Handler(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new EditProfilePage());
        }
    }
}
