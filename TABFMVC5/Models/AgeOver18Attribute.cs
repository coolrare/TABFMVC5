using System;
using System.ComponentModel.DataAnnotations;

namespace TABFMVC5.Models
{
    public class AgeOver18Attribute : DataTypeAttribute
    {
        public AgeOver18Attribute() : base(DataType.Date)
        {

        }

        public override bool IsValid(object value)
        {
            var date = value as Nullable<System.DateTime>;

            if (date.HasValue)
            {
                return (date.Value.AddYears(18) < DateTime.Now.Date);
            }

            return true;
        }
    }
}