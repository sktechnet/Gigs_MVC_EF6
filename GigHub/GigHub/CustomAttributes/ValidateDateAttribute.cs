using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHub.CustomAttributes
{
    public class ValidateDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;
            var isValid = DateTime.TryParseExact(Convert.ToString(value), 
                            "d MMM yyyy", 
                            CultureInfo.CurrentCulture, 
                            DateTimeStyles.None, out date);


            return (isValid && date > DateTime.Now);
        }
    }
}