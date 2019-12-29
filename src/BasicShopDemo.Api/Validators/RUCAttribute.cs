using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BasicShopDemo.Api.Validators
{
    public class RUCAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var ruc = value?.ToString();
            if (ruc == null || ruc.Length != 13)
            {
                return new ValidationResult("RUC must have 13 digits");
            }

            Regex regex = new Regex("^[0-2][0-9]{9}001$");
            if (!regex.IsMatch(ruc))
            {
                return new ValidationResult("RUC's format is invalid");
            }

            return this.ValidateRUC(ruc) ? ValidationResult.Success : new ValidationResult("Invalid RUC");
        }

        private bool ValidateRUC(string ruc)
        {
            int peers = 0, odd = 0;
            for (int i = 0; i < 9; i++)
            {
                int digit = int.Parse(ruc[i].ToString());

                if (i % 2 == 0)
                {
                    var multi = digit * 2;
                    if (multi < 10)
                    {
                        peers += multi;
                    }
                    else
                    {
                        peers += multi - 9;
                    }
                }
                else
                {
                    odd += digit;
                }
            }

            int sum = peers + odd;
            int checkDigit = -1;
            for (int j = 10; j <= 60; j = j + 10)
            {
                if (sum <= j)
                {
                    checkDigit = j - sum;
                    break;
                }
            }

            return int.Parse(ruc[9].ToString()) == checkDigit;
        }
    }
}
