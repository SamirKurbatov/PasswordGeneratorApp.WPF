using PasswordGeneratorApp.WPF.Commands;
using PasswordGeneratorApp.WPF.Models;
using System.Windows.Input;

namespace PasswordGeneratorApp.WPF.ViewModels
{
    public class PasswordViewModel : BaseViewModel
    {
        private Password password;
        public Password Password
        {
            get => password;
            set
            {
                password = value;
                OnProperetyChanged();
            }
        }

        public int PasswordLength
        {
            get => password.Length;
            set
            {
                password.Length = value;
                OnProperetyChanged();
            }
        }

        public string GeneratedPassword
        {
            get => password.Generated;
            set
            {
                password.Generated = value;
                OnProperetyChanged();
            }
        }

        private bool isUpperLetter;
        public bool IsUpperLetter
        {
            get => isUpperLetter;
            set
            {
                isUpperLetter = value;
                OnProperetyChanged();
            }
        }
        
        private bool isLowerLetter;
        public bool IsLowerLetter
        {
            get => isLowerLetter;
            set
            {
                isLowerLetter = value;
                OnProperetyChanged();
            }
        }
        
        private bool isDigit;
        public bool IsDigit
        {
            get => isDigit;
            set
            {
                isDigit = value;
                OnProperetyChanged();
            }
        }
        
        private bool isSpecialSign;
        public bool IsSpecialSign
        {
            get => isSpecialSign;
            set
            {
                isSpecialSign = value;
                OnProperetyChanged();
            }
        }

        public string ErrorMessage { get; set; } = "Проверьте заполненность всех полей!";

        public ICommand GenerateCommand { get; }

        public PasswordViewModel()
        {
            password = new();
            GenerateCommand = new GenerateCommand(this);
        }
    }
}
