namespace ArgsKata
{
	public class ArgNameValuePair
	{
		public ArgNameValuePair(string name, string value)
		{
			Name = name;
			Value = value == string.Empty ? null : value;
		}

		public string Name { get; private set; }

		public string Value { get; private set; }
	}
}