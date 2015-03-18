using DuoCode.Runtime;
using System;

namespace Mindbox.PostAddress.Tests
{
	// href: http://api.qunitjs.com/category/assert/
	[Js(Extern = true, Name = "QUnit")]
	public static class QUnit
	{
		[Js(Name = "test")]
		public static extern void RunTest(string testName, Action<JsObject> action);

		[Js(Name = "module")]
		public static extern void StartModule(string moduleName);

		[Js(Name = "config.testTimeout")]
		public static int TestTimeout;
	}

	[Js(Extern = true, Name = "assert")]
	public static class Assert
	{
		[Js(Name = "start")]
		public static extern void Start();

		[Js(Name = "equal")]
		public static extern void AreEqual(object actual, object expected, string message = null);

		[Js(Name = "equal", OmitGenericArgs = true)]
		public static extern void AreEqualT<T>(T actual, T expected) // prevents boxing for enums and value-types
			where T : struct;

		[Js(Name = "deepEqual")]
		public static extern void DeepEqual(object actual, object expected, string message = null);

		[Js(Name = "notDeepEqual")]
		public static extern void NotDeepEqual(object actual, object expected, string message = null);

		[Js(Name = "ok")]
		public static extern void IsTrue(bool condition, string message = null);

		[Js(Name = "throws")]
		public static extern void Throws(Action block, string message = null);

		[Js(Name = "throws")]
		public static extern void Throws(Action block, Func<object, bool> expected, string message = null);

		[Js(Name = "expect")]
		public static extern void Expect(int assertsCount, string message = null);

		[Js(Name = "async")]
		public static extern Action GetAsyncFinalizer();
	}

	public static class QUnitUtils
	{
		public static void Throws<T>(Action block, string message = null)
			where T : Exception
		{
			Assert.Throws(block, (error) => typeof(T).IsAssignableFrom(error.GetType()));
		}

		public static void Fail(string message)
		{
			Assert.IsTrue(false, message);
		}

		public static void SetTimeout(TimeSpan timeout)
		{
			QUnit.TestTimeout = (int)timeout.TotalMilliseconds;
		}
	}
}
