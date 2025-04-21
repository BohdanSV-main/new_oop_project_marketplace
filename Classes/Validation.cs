using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace
{
    using System.ComponentModel.DataAnnotations;

    public static class Validation
    {
        public static List<string> ValidateObject<T>(T obj)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(obj);
            bool isValid = Validator.TryValidateObject(obj, context, results, true);

            return results.Select(r => r.ErrorMessage).ToList();
        }
    }
}
