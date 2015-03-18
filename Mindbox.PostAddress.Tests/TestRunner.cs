using System;
using System.Reflection;

using DuoCode.Dom;
using DuoCode.Runtime;

using Console = System.Console;

// Set reflection-level (RTTI) for DuoCode compiler in order to find test methods using reflection
[assembly: CompilerOptions(ReflectionLevel = ReflectionLevel.Partial)]

namespace Mindbox.PostAddress.Tests
{
	public static class TestRunner
	{
		public static void Run() // HTML body.onload event entry point, see index.html
		{
			var assembly = typeof(TestRunner).Assembly;
			foreach (var type in assembly.GetTypes())
			{
				var testFixtureAttribute = type.GetCustomAttributes(typeof(TestFixtureAttribute), false)[0]
					as TestFixtureAttribute;

				if (testFixtureAttribute == null)
					continue;

				QUnit.StartModule(type.FullName);
				if (testFixtureAttribute.Timeout != default(int))
					QUnitUtils.SetTimeout(TimeSpan.FromMilliseconds(testFixtureAttribute.Timeout));

				var methods = type.GetMethods();
				MethodInfo testInitMethod = null;

				foreach (var methodInfo in methods)
				{
					if (methodInfo.GetCustomAttributes(typeof(TestInitializeAttribute), false).Count > 0)
					{
						testInitMethod = methodInfo;
						break;
					}
				}

				foreach (var currentMethod in type.GetMethods())
				{
					if (currentMethod.GetCustomAttributes(typeof(TestAttribute), false).Count > 0)
					{
						Console.WriteLine(currentMethod.Name);
						var instance = type.GetConstructors()[0].Invoke(new object[0]);

						var method = currentMethod;
						QUnit.RunTest(
							type.FullName + "." + currentMethod.Name,
							assert =>
								{
									Global.window.As<JsObject>()["assert"] = assert;

									if (testInitMethod != null)
										testInitMethod.Invoke(instance, new object[0]);

									method.Invoke(instance, new object[0]);
								}
							);
					}
				}
			}
		}
	}
}
