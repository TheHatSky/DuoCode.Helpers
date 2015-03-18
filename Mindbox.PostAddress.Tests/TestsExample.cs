using System.Collections.Generic;

using DuoCode.Dom;
using System;
using System.Reflection;

using DuoCode.Helpers;
using DuoCode.JQuery;

using Console = System.Console;

namespace Mindbox.PostAddress.Tests
{
	[TestFixture]
	public sealed class TestsExample // your tests goes here, here are just a few samples
	{
		[TestInitialize]
		public void TestInitialize()
		{
		}

		[Test]
		public void AssemblyNameIsUnitTest()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			Assert.AreEqual(assembly.FullName, "Mindbox.PostAddress.Tests");
		}

		[Test]
		public void ArraySortAndSearch()
		{
			byte[] array = { 6, 4, 2, 1, 5, 0, 3, 7 };
			Array.Sort(array);
			Assert.DeepEqual(array, new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 });
			Assert.AreEqual(Array.BinarySearch<byte>(array, 4), 4);
			Assert.IsTrue(Array.BinarySearch<byte>(array, 8) < 0);
		}

		[Test]
		public void GenericTypeInfo()
		{
			var tuple2Type = typeof(Tuple<int, string>);
			Assert.AreEqual(tuple2Type.GetGenericTypeDefinition(), typeof(Tuple<,>));
			Assert.AreEqual(tuple2Type.GenericTypeArguments.Length, 2);
			var tuple2TypeArgs = tuple2Type.GetGenericArguments();
			Assert.AreEqual(tuple2TypeArgs.Length, 2);
			Assert.AreEqual(tuple2TypeArgs[0], typeof(int));
			Assert.AreEqual(tuple2TypeArgs[1], typeof(string));
		}

		[Test]
		public void IntegerMath()
		{
			int x = 200;
			Assert.AreEqual(x + x * 2, 600);
			Assert.AreEqual(x / 3, 66);
			Assert.AreEqual((byte)x, 200);
			Assert.AreEqual((sbyte)x, -56);
		}

		[Test]
		public void InvalidCastThrowsException()
		{
			object doc = Global.document;
			Window window;

			Assert.IsTrue(typeof(Node).IsAssignableFrom(doc.GetType()));
			QUnitUtils.Throws<InvalidCastException>(() => window = (Window)doc); // try to cast Document to Window
		}

		[Test]
		public void JQuery_Md5()
		{
			Assert.Expect(2);
			var done = Assert.GetAsyncFinalizer();

			var settings = new JsonAjaxSettings<Md5HashInfo>
			{
				Url = "http://md5.jsontest.com/",
				Method = Method.GET,
				Data = new Dictionary<string, string>
				{
					{
						"text", "ex"
					}
				},
				IsCrossDomain = true,
				DataType = AjaxDataType.jsonp,
				OnSuccess = (info, status, jqXhr) =>
				{
					Assert.AreEqual(info.Text, "ex");
					Assert.AreEqual(info.Md5Hash, "54d54a126a783bc9cba8c06137136943");

					done();
				},
				OnError = (xhr, status, arg3) => QUnitUtils.Fail("Ajax request failed")
			};

			JQuery.Ajax(settings);
		}
	}
}