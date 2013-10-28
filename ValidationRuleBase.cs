using System;

namespace ReallySimpleValidation
{
	public abstract class ValidationRuleBase<T> where T : class
	{
		protected string ErrorMessage { get; set; }

		public ValidationResult Execute(T validateable, bool silent = false)
		{
			var validationFunction = GetValidationFunction();
			var result = validationFunction(validateable);

			if (!result.Valid && !silent)
			{
				throw new ValidationException(
					GetErrorMessage(result.Result));
			}

			return result;
		}

		protected string GetErrorMessage(object result)
		{
			return !String.IsNullOrWhiteSpace(ErrorMessage) ? ErrorMessage : GetDefaultErrorMessage(GetMemberName(), result);
		}

		protected abstract Func<T, ValidationResult> GetValidationFunction(); 
		protected abstract string GetMemberName();
		protected abstract string GetDefaultErrorMessage(string memberName, object result);
	}
}