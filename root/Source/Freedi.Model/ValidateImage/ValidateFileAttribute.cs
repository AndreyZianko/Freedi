using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Freedi.Model.ValidateImage
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FileTypeAttribute : ValidationAttribute
    {
        private const string _DefaultErrorMessage = "Only the following file types are allowed: {0}";

        public FileTypeAttribute(string validTypes)
        {
            _ValidTypes = validTypes.Split(',').Select(s => s.Trim().ToLower());
            ErrorMessage = string.Format(_DefaultErrorMessage, string.Join(" or ", _ValidTypes));
        }

        private IEnumerable<string> _ValidTypes { get; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is List<HttpPostedFileBase> files)
                foreach (var file in files)
                    if (file != null && !_ValidTypes.Any(e => file.FileName.EndsWith(e)))
                        return new ValidationResult(ErrorMessageString);
            return ValidationResult.Success;
        }
    }
}