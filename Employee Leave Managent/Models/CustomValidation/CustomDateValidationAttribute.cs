using System.ComponentModel.DataAnnotations;
using System;

namespace Employee_Leave_Managent.Models.CustomValidation
{
    public class CustomDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var leaveTypeProperty = validationContext.ObjectType.GetProperty("LeaveType");
            var leaveTypeValue = leaveTypeProperty.GetValue(validationContext.ObjectInstance);

            if (leaveTypeValue != null && leaveTypeValue.ToString() != "طارئة")
            {
                if (value != null && value is DateTime startDate)
                {
                    DateTime currentDate = DateTime.Now.Date;
                    DateTime minimumDate = currentDate.AddDays(1);

                    if (startDate < minimumDate)
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                }
            }

            return ValidationResult.Success;
        }
    }
}
