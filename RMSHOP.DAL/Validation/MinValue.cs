using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMSHOP.DAL.Validation
{
    public class MinValue: ValidationAttribute
    {
        private readonly int _minValue;

        public MinValue(int minValue=10) {
            _minValue = minValue;
        }
        //value: القيمة المرسلة من اليوزر
        public override bool IsValid(object? value)
        {
            if(value is decimal val)
            {
                if (val >= _minValue)
                {
                    return true;
                }
            }
             return false;
        }
        //name : column name
        public override string FormatErrorMessage(string name)
        {
            return $"{name} is invalid";
        }
    }
}
