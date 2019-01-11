using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.Models.ValidationAttributes
{
    public class YearAttribute : ValidationAttribute
    {
        public int year;
        public YearAttribute(int year)
        {
            this.year = year;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int year = (int) value;
            if (year < this.year || year > DateTime.Now.Year)
            {
                return new ValidationResult(GetErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage(string memberName)
        {
            return $"The {memberName} must be in boundaries between {year} and current year.";
        }
    }

    public class CapitalLetterAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string word = (string) value;
            if(word.ToCharArray()[0] < 65 || word.ToCharArray()[0] > 90)
            {
                return new ValidationResult(GetErrorMessage(validationContext.DisplayName));
            }

            return ValidationResult.Success;
        }
        private string GetErrorMessage(string memberName)
        {
            return $"First letter in {memberName} must be capital.";
        }
    }

    public class SerialCodeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string code = (string)value;
            Movie movie = (Movie)validationContext.ObjectInstance;
            string movieName = movie.Title;
            char[] arr1 = code.ToCharArray();
            char[] arr2 = movieName.ToCharArray();
            for (int i = 0; i < 3; i++) {
                if (arr1[i+1]!=arr2[i])
                {
                    return new ValidationResult(GetErrorMessage(validationContext.DisplayName));
                }
            }

            return ValidationResult.Success;
        }
        private string GetErrorMessage(string memberName)
        {
            return $"Positions 2-4 in {memberName} must be the first letters of the movie.";
        }
    }
}
