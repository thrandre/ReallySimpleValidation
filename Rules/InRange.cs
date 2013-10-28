using System;
using System.Linq.Expressions;

namespace ReallySimpleValidation.Rules
{
	public class InRange<T> : ValidationSelectorRule<T> where T : class
	{
		private readonly double _lower;
		private readonly double _upper;

		public InRange(Expression<Func<T, object>> selectorExpression, double lower, double upper, string errorMessage = null) 
			: base(selectorExpression, errorMessage)
		{
			_lower = lower;
			_upper = upper;
		}

		protected override Func<T, ValidationResult> GetValidationFunction()
		{
			return o =>
			{
				var ret = Convert.ToDouble(CompiledExpression(o));

				return new ValidationResult
				{
					Valid = ret >= _lower && ret <= _upper,
					Result = ret
				};
			};
		}

		protected override string GetDefaultErrorMessage(string memberName, object result)
		{
			return String.Format("{0} is not in range [{1}-{2}]. Was {3}.",
				memberName, _lower, _upper, result);
		}
	}
}