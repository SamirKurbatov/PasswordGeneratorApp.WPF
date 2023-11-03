using PasswordGeneratorApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordGeneratorApp.WPF.Commands
{
    public class GenerateCommand : BaseCommand
    {
        private readonly PasswordViewModel passwordViewModel;

        public GenerateCommand(PasswordViewModel passwordViewModel)
        {
            this.passwordViewModel = passwordViewModel;
        }

        public override void Execute(object? parameter)
        {
            var random = new Random();

            for (int i = 1; i < passwordViewModel.PasswordLength; i++)
            {
                var randomChar = (char)('a' + random.Next(0, 26));
                int randomNumber = random.Next(0, 20);

                passwordViewModel.GeneratedPassword += $"{randomChar}{randomNumber}";
            }
        }
    }
}
