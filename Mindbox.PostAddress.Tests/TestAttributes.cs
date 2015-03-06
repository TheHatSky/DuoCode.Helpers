using System;

namespace UnitTest
{
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class TestAttribute : Attribute
	{
	}

	[AttributeUsage(AttributeTargets.Class)]
	public sealed class TestFixtureAttribute : Attribute
	{
	}
}
