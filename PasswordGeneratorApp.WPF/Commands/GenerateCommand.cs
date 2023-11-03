using PasswordGeneratorApp.WPF.Models;
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

            var list = new List<string>();

            var resultSb = new StringBuilder();

            bool hasUpperLetter = passwordViewModel.IsUpperLetter;
            bool hasLowerLetter = passwordViewModel.IsLowerLetter;
            bool hasDigit = passwordViewModel.IsDigit;
            bool hasSpecialSign = passwordViewModel.IsSpecialSign;

            var passwordLength = passwordViewModel.PasswordLength;

            
            try
            {
                if (passwordLength == 0)
                {
                    throw new ArgumentNullException(nameof(passwordLength));
                }

                for (int i = 0; i < passwordLength; i++)
                {
                    if (hasUpperLetter)
                    {
                        var randomChar = (char)('a' + random.Next(0, 26));
                        list.Add(char.ToUpper(randomChar).ToString());
                    }

                    if (hasLowerLetter)
                    {
                        var randomChar = (char)('a' + random.Next(0, 26));
                        list.Add(char.ToLower(randomChar).ToString());
                    }

                    if (hasDigit)
                    {
                        int randomNumber = random.Next(0, 10);
                        list.Add(randomNumber.ToString());
                    }

                    if (hasSpecialSign)
                    {
                        char[] symbols = new char[] { '$', '#', '?', '*', };
                        var symbol = (char)symbols[random.Next(0, symbols.Length)];
                        list.Add(symbol.ToString());
                    }

                }

                int totalCharacter = passwordLength;
                int charactersPerSet = totalCharacter / list.Count;

                foreach (var set in list)
                {
                    for (int i = 0; i < charactersPerSet; i++)
                    {
                        int randomIndex = random.Next(set.Length);
                        resultSb.Append(set[randomIndex]);
                    }
                }

                int remainingCharacter = totalCharacter - resultSb.Length;

                for (int i = 0; i < remainingCharacter; i++)
                {
                    string randomSet = list[random.Next(list.Count)];
                    int randomIndex = random.Next(randomSet.Length);
                    resultSb.Append(randomSet[randomIndex]);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
            passwordViewModel.GeneratedPassword = new string(resultSb.ToString().ToCharArray().OrderBy(c => random.Next()).ToArray());
        }

    }
}
