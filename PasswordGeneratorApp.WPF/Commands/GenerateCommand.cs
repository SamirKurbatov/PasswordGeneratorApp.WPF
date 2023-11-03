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
            passwordViewModel.GeneratedPassword = GetGeneratedPassword();
        }

        private void GenerateCharacter(bool shouldGenerate, List<string> list, Random random, string characterSet)
        {
            if (shouldGenerate)
            {
                int randomIndex = random.Next(0, characterSet.Length);
                char randomChar = characterSet[randomIndex];
                list.Add(randomChar.ToString());
            }
        }

        private string GetGeneratedPassword()
        {
            var random = new Random();

            var list = new List<string>();

            var resultSb = new StringBuilder();

            bool hasUpperLetter = passwordViewModel.IsUpperLetter;
            bool hasLowerLetter = passwordViewModel.IsLowerLetter;
            bool hasDigit = passwordViewModel.IsDigit;
            bool hasSpecialSign = passwordViewModel.IsSpecialSign;
            int passwordLength = passwordViewModel.PasswordLength;
            string letters = "abcdefghijklmnopqrstuvwxyz";

            try
            {
                if (passwordLength == 0) throw new ArgumentNullException(nameof(passwordLength));

                for (int i = 0; i < passwordLength; i++)
                {
                    GenerateCharacter(hasUpperLetter, list, random, letters.ToUpper());
                    GenerateCharacter(hasLowerLetter, list, random, letters);
                    GenerateCharacter(hasDigit, list, random, "0123456789");
                    GenerateCharacter(hasSpecialSign, list, random, "$#?*");
                }

                ShuffleCharacter(random, list, resultSb, passwordLength);

            }
            catch (Exception ex)
            {
                passwordViewModel.ErrorMessage = ex.Message;
            }


            var generatedPassword = new string(resultSb.ToString().ToCharArray().OrderBy(c => random.Next()).ToArray());

            return generatedPassword;
        }

        private void ShuffleCharacter(Random random, List<string> list, StringBuilder resultSb, int passwordLength)
        {
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
    }
}
