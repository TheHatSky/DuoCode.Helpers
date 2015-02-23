using DuoCode.Runtime;
using System;

namespace UnitTest
{
    // href: http://api.qunitjs.com/category/assert/
    [Js(Extern = true, Name = "QUnit")]
    public static class QUnit
    {
        [Js(Name = "test")]
        public static extern void RunTest(string testName, Action action);

        [Js(Name = "equal")]
        public static extern void AreEqual(object actual, object expected);

        [Js(Name = "equal", OmitGenericArgs = true)]
        public static extern void AreEqualT<T>(T actual, T expected) // prevents boxing for enums and value-types
          where T : struct;

        [Js(Name = "deepEqual")]
        public static extern void DeepEqual(object actual, object expected);

        [Js(Name = "ok")]
        public static extern void IsTrue(bool condition);

        [Js(Name = "throws")]
        public static extern void Throws(Action block);

        [Js(Name = "throws")]
        public static extern void Throws(Action block, Func<object, bool> expected);
    }

    public static class QUnitUtils
    {
        public static void Throws<T>(Action block)
          where T : Exception
        {
            QUnit.Throws(block, (error) => typeof(T).IsAssignableFrom(error.GetType()));
        }
    }
}
