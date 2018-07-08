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
		private Dictionary<string, ArgNameValuePair> _argNameValuePairs;


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
			var type = typeof (TValue);
			var val = _argNameValuePairs[argName].Value;
			if (val == null)
			{
				type = typeof(bool);
				val = "true";
			}

			return (TValue)Convert.ChangeType(val, type);
		}
	}
}
