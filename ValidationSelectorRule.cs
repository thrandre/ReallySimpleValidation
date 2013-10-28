using System;
using System.Linq.Expressions;

namespace ReallySimpleValidation
{
	public abstract class ValidationSelectorRule<T> : ValidationRuleBase<T> where T : class
	{
		protected Expression<Func<T, object>> SelectorExpression { get; set; }
		protected Func<T, object> CompiledExpression { get; set; }

		protected ValidationSelectorRule(Expression<Func<T, object>> selectorExpression, string errorMessage = null)
		{
			SelectorExpression = selectorExpression;
			CompiledExpression = SelectorExpression.Compile();
			ErrorMessage = errorMessage;
		}

		protected override string GetMemberName()
		{
			return ExpressionUtils.GetName(SelectorExpression);
		}

		protected override string GetDefaultErrorMessage(string memberName, object result)
		{
			return memberName;
		}
	}
}