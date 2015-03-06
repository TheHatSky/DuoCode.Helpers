using System.Collections.Generic;

using DuoCode.Dom;
using System;
using System.Reflection;

using DuoCode.Helpers;
using DuoCode.JQuery;

using Mindbox.PostAddress;

namespace UnitTest
{
	[TestFixture]
	public sealed class Tests // your tests goes here, here are just a few samples
	{
		[Test]
		public void AssemblyNameIsUnitTest()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			QUnit.AreEqual(assembly.FullName, "UnitTest");
		}

		[Test]
		public void ArraySortAndSearch()
		{
			byte[] array = { 6, 4, 2, 1, 5, 0, 3, 7 };
			Array.Sort(array);
			QUnit.DeepEqual(array, new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 });
			QUnit.AreEqual(Array.BinarySearch<byte>(array, 4), 4);
			QUnit.IsTrue(Array.BinarySearch<byte>(array, 8) < 0);
		}

		[Test]
		public void GenericTypeInfo()
		{
			var tuple2Type = typeof(Tuple<int, string>);
			QUnit.AreEqual(tuple2Type.GetGenericTypeDefinition(), typeof(Tuple<,>));
			QUnit.AreEqual(tuple2Type.GenericTypeArguments.Length, 2);
			var tuple2TypeArgs = tuple2Type.GetGenericArguments();
			QUnit.AreEqual(tuple2TypeArgs.Length, 2);
			QUnit.AreEqual(tuple2TypeArgs[0], typeof(int));
			QUnit.AreEqual(tuple2TypeArgs[1], typeof(string));
		}

		[Test]
		public void IntegerMath()
		{
			int x = 200;
			QUnit.AreEqual(x + x * 2, 600);
			QUnit.AreEqual(x / 3, 66);
			QUnit.AreEqual((byte)x, 200);
			QUnit.AreEqual((sbyte)x, -56);
		}

		[Test]
		public void InvalidCastThrowsException()
		{
			object doc = Global.document;
			Window window;

			QUnit.IsTrue(typeof(Node).IsAssignableFrom(doc.GetType()));
			QUnitUtils.Throws<InvalidCastException>(() => window = (Window)doc); // try to cast Document to Window
		}

		[Test]
		public void PostAddressInit()
		{
			var settlement = PostAddress.GetSettlementById();

			QUnit.AreEqual(settlement, "a");
		}

		[Test]
		public void JQuery_Md5()
		{
			QUnit.IsTrue(true); // Необходим хотя бы один ассерт для запуска

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
						QUnit.AreEqual(info.Text, "ex");
						QUnit.AreEqual(info.Md5Hash, "54d54a126a783bc9cba8c06137136943");
					},
				OnError = (xhr, status, arg3) => QUnitUtils.Fail("Ajax request failed")
			};

			JQuery.Ajax(settings);
		}
	}
}