using PasswordGeneratorApp.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PasswordGeneratorApp.WPF.Commands
{
    public class CopyCommand : BaseCommand
    {
        private PasswordViewModel passwordViewModel;

        public CopyCommand(PasswordViewModel passwordViewModel)
        {
            this.passwordViewModel = passwordViewModel;
        }

        public override void Execute(object? parameter)
        {
            Clipboard.SetText(passwordViewModel.Generated);
        }
    }
}
