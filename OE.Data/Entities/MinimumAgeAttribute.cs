//using System;
//using System.ComponentModel.DataAnnotations;

//namespace OE.Data
//{
//    public class MinimumAgeAttribute : ValidationAttribute
//    {
//        int _minumumAge;

//        public MinimumAgeAttribute(int minumumAge)
//        {
//            _minumumAge = minumumAge;
//        }
//        public override bool IsValid(object value)
//        {
//            DateTime date;
//            if(DateTime.TryParse(value.ToString(), out date))
//            {
//                return date.AddYears(_minumumAge) < DateTime.Now;
//            }
//            return false;
//        }
//    }
//}