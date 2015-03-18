using System;

namespace Mindbox.PostAddress.Tests
{
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class TestAttribute : Attribute
	{
	}

	[AttributeUsage(AttributeTargets.Method)]
	public sealed class TestInitializeAttribute : Attribute
	{
	}

	[AttributeUsage(AttributeTargets.Class)]
	public sealed class TestFixtureAttribute : Attribute
	{
		/// <summary>
		/// <para>Timeout for all tests in module in milliseconds.</para>
		/// <para>Default value will be 15 seconds (15 000 milliseconds).</para>
		/// </summary>
		public int Timeout { get; set; }

		public TestFixtureAttribute()
		{
			Timeout = (int)TimeSpan.FromSeconds(15).TotalMilliseconds;
		}
	}
}
