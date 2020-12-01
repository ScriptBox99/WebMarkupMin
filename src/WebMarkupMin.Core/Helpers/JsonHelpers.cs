﻿using System;
using System.Text.RegularExpressions;

using WebMarkupMin.Core.Utilities;

namespace WebMarkupMin.Core.Helpers
{
	/// <summary>
	/// JSON helpers
	/// </summary>
	internal static class JsonHelpers
	{
		/// <summary>
		/// Regular expression for working with curly braces
		/// </summary>
		private static readonly Regex _valueInCurlyBracesRegex = new Regex(@"^\s*\{(?<value>[\s\S]*?)\}\s*$",
			TargetFrameworkShortcuts.PerformanceRegexOptions);


		/// <summary>
		/// Wraps a string value in curly braces
		/// </summary>
		/// <param name="value">String value</param>
		/// <returns>Wrapped value</returns>
		public static string WrapStringInCurlyBraces(string value)
		{
			string processedValue = value.Trim();
			if (!(processedValue.StartsWith("{", StringComparison.Ordinal)
				&& processedValue.EndsWith("}", StringComparison.Ordinal)))
			{
				processedValue = "{" + processedValue + "}";
			}

			return processedValue;
		}

		/// <summary>
		/// Unwraps a string value in curly braces
		/// </summary>
		/// <param name="value">String value</param>
		/// <returns>Unwrapped value</returns>
		public static string UnwrapStringInCurlyBraces(string value)
		{
			string processedValue = value;

			Match match = _valueInCurlyBracesRegex.Match(processedValue);
			if (match.Success)
			{
				processedValue = match.Groups["value"].Value;
			}

			return processedValue;
		}
	}
}