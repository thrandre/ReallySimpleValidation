using System;
using System.Collections.Generic;
using System.Linq;

namespace ReallySimpleValidation
{
	public class Validator<T> where T : class
	{
		private readonly ValidationRuleBase<T>[] _rulesBase;

		public Validator(params ValidationRuleBase<T>[] rulesBase)
		{
			_rulesBase = rulesBase;
		}

		public bool Validate(T validateable, bool silent = false)
		{
			return _rulesBase.All(r => r.Execute(validateable, silent).Valid);
		}
	}

	public class Validator
	{
		private static readonly IDictionary<Type, object> TypeMap = new Dictionary<Type, object>();

		public static Validator<T> For<T>() where T : class
		{
			try
			{
				return TypeMap[typeof (T)] as Validator<T>;
			}
			catch (Exception)
			{
				throw new ArgumentException("No validator found for type " + typeof(T).Name);
			}
		}

		public static void Register<T>(Validator<T> validator) where T : class
		{
			TypeMap[typeof (T)] = validator;
		}
	}
}