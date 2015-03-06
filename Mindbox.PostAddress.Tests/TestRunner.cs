using System;
using DuoCode.Runtime;

// Set reflection-level (RTTI) for DuoCode compiler in order to find test methods using reflection
[assembly: CompilerOptions(ReflectionLevel = ReflectionLevel.Partial)]

namespace UnitTest
{
	public static class TestRunner
	{
		public static void Run() // HTML body.onload event entry point, see index.html
		{
			var assembly = typeof(TestRunner).Assembly;
			foreach (var type in assembly.GetTypes())
			{
				if (type.GetCustomAttributes(typeof(TestFixtureAttribute), false).Count > 0)
				{
					Console.WriteLine(type.FullName);
					foreach (var currentMethod in type.GetMethods())
					{
						if (currentMethod.GetCustomAttributes(typeof(TestAttribute), false).Count > 0)
						{
							Console.WriteLine(currentMethod.Name);

							var instance = type.GetConstructors()[0].Invoke(new object[0]);
							QUnit.RunTest(type.FullName + "." + currentMethod.Name, () => currentMethod.Invoke(instance, new object[0]));
						}
					}
				}
			}
		}
	}
}
