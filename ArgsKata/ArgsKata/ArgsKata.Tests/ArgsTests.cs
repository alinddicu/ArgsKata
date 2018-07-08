namespace ArgsKata.Tests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using NFluent;

	[TestClass]
	public class ArgsTests
	{
		[TestMethod]
		public void ExampleTestCase()
		{
			var args = new Args("l,p#,d*", new[] { "-l", "-p", "8080", "-d", "/usr/logs" });
			var l = args.GetValue<bool>("l");
			var p = args.GetValue<int>("p");
			var d = args.GetValue<string>("d");

			Check.That(l).IsTrue();
			Check.That(p).IsInstanceOf<int>().And.IsEqualTo(8080);
			Check.That(d).IsInstanceOf<string>().And.IsEqualTo("/usr/logs");
		}

		[TestMethod]
		public void BooleanArgumentAbsent()
		{
			var args = new Args("l,p#,d*", new[] { "-p", "8080", "-d", "/usr/logs" });
			var l = args.GetValue<bool>("l");
			var p = args.GetValue<int>("p");
			var d = args.GetValue<string>("d");

			Check.That(l).IsFalse();
			Check.That(p).IsInstanceOf<int>().And.IsEqualTo(8080);
			Check.That(d).IsInstanceOf<string>().And.IsEqualTo("/usr/logs");
		}
	}
}
