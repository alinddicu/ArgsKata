namespace ArgsKata
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net.Http.Headers;

	public class Args
	{
		private readonly string _schema;
		private readonly string[] _arguments;
		private readonly Dictionary<string, ArgNameValuePair> _argNameValuePairs;

		public Args(string schema, string[] arguments)
		{
			_schema = schema;
			_arguments = arguments;

			_argNameValuePairs = string
				.Join(" ", arguments)
				.Split('-')
				.Where(a => a != string.Empty)
				.Select(a => a.Split(' '))
				.Select(args => new ArgNameValuePair(args[0], args.Length > 1 ? args[1] : null))
				.ToDictionary(p => p.Name);
		}

		public TValue GetValue<TValue>(string argName)
		{
			var valueTypePair = GetValueTypePair<TValue>(argName);
			return (TValue)Convert.ChangeType(valueTypePair.Value, valueTypePair.Type);
		}

		private ValueTypePair GetValueTypePair<TValue>(string argName)
		{
			if (!_argNameValuePairs.Keys.Contains(argName))
			{
				return new ValueTypePair("false", typeof(bool));
			}

			var val = _argNameValuePairs[argName].Value;
			if (val == null)
			{
				return new ValueTypePair("true", typeof(bool));
			}

			return new ValueTypePair(val, typeof(TValue));
		}
	}

	public class ValueTypePair
	{
		public ValueTypePair(string value, Type type)
		{
			Value = value;
			Type = type;
		}

		public string Value { get; private set; }

		public Type Type { get; private set; }
	}
}
