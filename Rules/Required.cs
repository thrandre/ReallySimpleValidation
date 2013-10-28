using System;
using System.Linq.Expressions;

namespace ReallySimpleValidation.Rules
{
	public class Required<T> : ValidationSelectorRule<T> where T : class
	{
		public Required(Expression<Func<T, object>> selectorExpression, string errorMessage = null) 
			: base(selectorExpression, errorMessage)
		{
		}

		protected override Func<T, ValidationResult> GetValidationFunction()
		{
			return o =>
			{
				var ret = CompiledExpression(o);
				var retString = ret as string;

				return new ValidationResult
				{
					Valid = retString != null
						? !String.IsNullOrWhiteSpace(retString)
						: ret != null,
					Result = ret
				};
			};
		}

		protected override string GetDefaultErrorMessage(string memberName, object result)
		{
			return String.Format("{0} is required.", memberName);
		}
	}
}