using System;
using System.Linq.Expressions;

namespace ReallySimpleValidation
{
	public class ExpressionUtils
	{
		public static string GetName<T>(Expression<Func<T, object>> exp)
		{
			var body = exp.Body as MemberExpression;

			if (body != null)
			{
				return body.Member.Name;
			}
			
			var ubody = (UnaryExpression) exp.Body;
			body = ubody.Operand as MemberExpression;

			return body != null ? body.Member.Name : String.Empty;
		}
	}
}