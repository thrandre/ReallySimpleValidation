﻿using System;

namespace ReallySimpleValidation
{
	public class ValidationException : Exception
	{
		public ValidationException(string errorMessage) : base(errorMessage) { }
	}
}