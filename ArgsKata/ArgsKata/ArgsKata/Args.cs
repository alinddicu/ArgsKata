namespace ArgsKata
{
	using System.Net.Http.Headers;

	public class Args
    {
	    private readonly string _schema;
		private readonly string[] _arguments;

	    public Args(string schema, string[] arguments)
	    {
		    _schema = schema;
		    _arguments = arguments;
	    }

	    public TValue GetValue<TValue>(string argName)
	    {
		    throw new System.NotImplementedException();
	    }
    }
}
