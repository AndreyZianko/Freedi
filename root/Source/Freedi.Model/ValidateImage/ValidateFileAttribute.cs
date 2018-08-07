using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Freedi.Model.ValidateImage
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FileTypeAttribute : ValidationAttribute
    {
        private const string _DefaultErrorMessage = "Only the following file types are allowed: {0}";
        private IEnumerable<string> _ValidTypes { get; set; }

        public FileTypeAttribute(string validTypes)
        {
            _ValidTypes = validTypes.Split(',').Select(s => s.Trim().ToLower());
            ErrorMessage = string.Format(_DefaultErrorMessage, string.Join(" or ", _ValidTypes));
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<HttpPostedFileBase> files = value as List<HttpPostedFileBase>;
            if (files != null)
            {
                foreach (HttpPostedFileBase file in files)
                {
                    if (file != null && !_ValidTypes.Any(e => file.FileName.EndsWith(e)))
                    {
                        return new ValidationResult(ErrorMessageString);
                    }
                }
            }
            return ValidationResult.Success;
        }

       
    }
}
