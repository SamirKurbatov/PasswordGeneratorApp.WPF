using PasswordGeneratorApp.WPF.Commands;
using PasswordGeneratorApp.WPF.Models;
using System.Windows.Input;

namespace PasswordGeneratorApp.WPF.ViewModels
{
    public class PasswordViewModel : BaseViewModel
    {
        private Password password;

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

        public bool IsUpperLetter { get; set; }

        public bool IsLowerLetter { get; set; }

        public ICommand GenerateCommand { get; }

        public PasswordViewModel()
        {
            password = new();
            GenerateCommand = new GenerateCommand(this);
        }
    }
}
