using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TABFMVC5.ViewModels
{
    public class TestErrorViewModel : IValidatableObject
    {
        public int Id { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Id == 1)
            {
                throw new ArgumentException("Id 不得為 1");
            }
            throw new NotImplementedException();
        }
    }
}