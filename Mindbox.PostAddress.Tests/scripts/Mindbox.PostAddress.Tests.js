//
// Mindbox.PostAddress.Tests, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
//
// Generated by DuoCode Compiler 0.3.878.0 BETA
//
(function Mindbox_PostAddress_Tests() {
"use strict";
var $asm = {
    fullName: "Mindbox.PostAddress.Tests",
    anonymousTypes: [],
    types: [],
    $getAttrs: function() {
        return [new System.Reflection.AssemblyTitleAttribute.ctor("UniTest"), new System.Reflection.AssemblyDescriptionAttribute.ctor(""), 
            new System.Reflection.AssemblyConfigurationAttribute.ctor(""), new System.Reflection.AssemblyCompanyAttribute.ctor(""), 
            new System.Reflection.AssemblyProductAttribute.ctor("UnitTest"), new System.Reflection.AssemblyCopyrightAttribute.ctor("Copyright \xA9  2015"), 
            new System.Reflection.AssemblyTrademarkAttribute.ctor(""), new System.Reflection.AssemblyCultureAttribute.ctor(""), 
            new System.Reflection.AssemblyVersionAttribute.ctor("1.0.0.0"), new System.Reflection.AssemblyFileVersionAttribute.ctor("1.0.0.0"), 
            new DuoCode.Runtime.CompilerAttribute.ctor("0.3.878.0 BETA")];
    }
};
var $g = (typeof(global) !== "undefined" ? global : window);
var Mindbox = $g.Mindbox = $g.Mindbox || {};
Mindbox.PostAddress = Mindbox.PostAddress || {};
Mindbox.PostAddress.Tests = Mindbox.PostAddress.Tests || {};
var $d = DuoCode.Runtime;
$d.$assemblies["Mindbox.PostAddress.Tests"] = $asm;
Mindbox.PostAddress.Tests.QUnitUtils = $d.declare("Mindbox.PostAddress.Tests.QUnitUtils", System.Object, 
    0, $asm, function($t, $p) {
        $t.$typeInfo = function(t, p) { return [1, null, [["Throws", t.Throws, 22], ["Fail", t.Fail, 22], ["SetTimeout", t.SetTimeout, 22]]]; };
        $t.Throws = function QUnitUtils_Throws(T, block, message) {
            assert.throws(block, $d.delegate(function(error) {
                return $d.typeOf(T).IsAssignableFrom($d.getTypeFromInst(error));
            }, this));
        };
        $t.Fail = function QUnitUtils_Fail(message) {
            assert.ok(false, message);
        };
        $t.SetTimeout = function QUnitUtils_SetTimeout(timeout) {
            QUnit.config.testTimeout = (timeout.get_TotalMilliseconds() | 0);
        };
    });
Mindbox.PostAddress.Tests.TestAttribute = $d.declare("Mindbox.PostAddress.Tests.TestAttribute", System.Attribute, 
    0, $asm, function($t, $p) {
        $t.$typeInfo = function(t, p) { return [257, null, null, [["ctor", t.ctor, 6]], null, null, [new System.AttributeUsageAttribute.ctor(64)]]; };
        $t.ctor = function TestAttribute() {
            $t.$baseType.ctor.call(this);
        };
        $t.ctor.prototype = $p;
    });
Mindbox.PostAddress.Tests.TestInitializeAttribute = $d.declare("Mindbox.PostAddress.Tests.TestInitializeAttribute", 
    System.Attribute, 0, $asm, function($t, $p) {
        $t.$typeInfo = function(t, p) { return [257, null, null, [["ctor", t.ctor, 6]], null, null, [new System.AttributeUsageAttribute.ctor(64)]]; };
        $t.ctor = function TestInitializeAttribute() {
            $t.$baseType.ctor.call(this);
        };
        $t.ctor.prototype = $p;
    });
Mindbox.PostAddress.Tests.TestFixtureAttribute = $d.declare("Mindbox.PostAddress.Tests.TestFixtureAttribute", 
    System.Attribute, 0, $asm, function($t, $p) {
        $t.$typeInfo = function(t, p) { return [257, null, [["get_Timeout", p.get_Timeout, 6], ["set_Timeout", p.set_Timeout, 6]], [["ctor", t.ctor, 6]], [["Timeout", 45, ["get_Timeout", p.get_Timeout, 6], ["set_Timeout", p.set_Timeout, 6]]], null, [new System.AttributeUsageAttribute.ctor(4)]]; };
        $t.$ator = function() {
            this.$Timeout$k__BackingField = 0;
        };
        $p.get_Timeout = function TestFixtureAttribute_get_Timeout() { return this.$Timeout$k__BackingField; };
        $p.set_Timeout = function TestFixtureAttribute_set_Timeout(value) { this.$Timeout$k__BackingField = value;return value; };
        $t.ctor = function TestFixtureAttribute() {
            $t.$baseType.ctor.call(this);
            this.set_Timeout((System.TimeSpan.FromSeconds(15).get_TotalMilliseconds() | 0));
        };
        $t.ctor.prototype = $p;
    });
Mindbox.PostAddress.Tests.TestRunner = $d.declare("Mindbox.PostAddress.Tests.TestRunner", System.Object, 
    0, $asm, function($t, $p) {
        $t.$typeInfo = function(t, p) { return [1, null, [["Run", t.Run, 22]]]; };
        $t.Run = function TestRunner_Run() {
            var assembly = $d.typeOf(Mindbox.PostAddress.Tests.TestRunner).get_Assembly();
            for (var $i = 0, $a = assembly.GetTypes(), $length = $a.length; $i != $length; $i++) {
                var $loopResult = (function() {
                    var type = $a[$i];
                    var testFixtureAttribute = $d.as(type.GetCustomAttributes$1($d.typeOf(Mindbox.PostAddress.Tests.TestFixtureAttribute), 
                        false)[0], Mindbox.PostAddress.Tests.TestFixtureAttribute);

                    if (testFixtureAttribute == null)
                        return { type: 2, label: null, depth: 0 };

                    QUnit.module(type.get_FullName());
                    if (testFixtureAttribute.get_Timeout() != 0)
                        Mindbox.PostAddress.Tests.QUnitUtils.SetTimeout(System.TimeSpan.FromMilliseconds(testFixtureAttribute.get_Timeout()));

                    var methods = type.GetMethods();
                    var testInitMethod = null;
                    for (var $i2 = 0, $length2 = methods.length; $i2 != $length2; $i2++) {
                        var methodInfo = methods[$i2];
                        if (methodInfo.GetCustomAttributes$1($d.typeOf(Mindbox.PostAddress.Tests.TestInitializeAttribute), 
                            false).get_Count() > 0) {
                            testInitMethod = methodInfo;
                            break;
                        }
                    }
                    for (var $i3 = 0, $a2 = type.GetMethods(), $length3 = $a2.length; $i3 != $length3; $i3++)
                        (function() {
                            var currentMethod = $a2[$i3];
                            if (currentMethod.GetCustomAttributes$1($d.typeOf(Mindbox.PostAddress.Tests.TestAttribute), 
                                false).get_Count() > 0) {
                                System.Console.WriteLine$10(currentMethod.get_Name());
                                var instance = type.GetConstructors()[0].Invoke$2($d.array(System.Object, 
                                    0));

                                var method = currentMethod;
                                QUnit.test(type.get_FullName() + "." + currentMethod.get_Name(), $d.delegate(function(assert) {
                                    window["assert"] = assert;

                                    if (testInitMethod != null)
                                        testInitMethod.Invoke(instance, $d.array(System.Object, 0));

                                    method.Invoke(instance, $d.array(System.Object, 0));
                                }, this));
                            }
                        }).call(this);
                    return { type: 0 };
                }).call(this);
                if ($loopResult.type == 2)
                    continue;
            }
        };
    });
Mindbox.PostAddress.Tests.TestsExample = $d.declare("Mindbox.PostAddress.Tests.TestsExample", System.Object, 
    0, $asm, function($t, $p) {
        $t.$typeInfo = function(t, p) { return [257, null, [["TestInitialize", p.TestInitialize, 6, null, null, [new Mindbox.PostAddress.Tests.TestInitializeAttribute.ctor()]], ["AssemblyNameIsUnitTest", p.AssemblyNameIsUnitTest, 6, null, null, [new Mindbox.PostAddress.Tests.TestAttribute.ctor()]], ["ArraySortAndSearch", p.ArraySortAndSearch, 6, null, null, [new Mindbox.PostAddress.Tests.TestAttribute.ctor()]], ["GenericTypeInfo", p.GenericTypeInfo, 6, null, null, [new Mindbox.PostAddress.Tests.TestAttribute.ctor()]], ["IntegerMath", p.IntegerMath, 6, null, null, [new Mindbox.PostAddress.Tests.TestAttribute.ctor()]], ["InvalidCastThrowsException", p.InvalidCastThrowsException, 6, null, null, [new Mindbox.PostAddress.Tests.TestAttribute.ctor()]], ["JQuery_Md5", p.JQuery_Md5, 6, null, null, [new Mindbox.PostAddress.Tests.TestAttribute.ctor()]]], [["ctor", t.ctor, 6]], null, null, [new Mindbox.PostAddress.Tests.TestFixtureAttribute.ctor()]]; };
        $t.ctor = function TestsExample() {
            $t.$baseType.ctor.call(this);
        };
        $t.ctor.prototype = $p;
        $p.TestInitialize = function TestsExample_TestInitialize() {};
        $p.AssemblyNameIsUnitTest = function TestsExample_AssemblyNameIsUnitTest() {
            var assembly = $d.assemblyOf($asm);
            assert.equal(assembly.get_FullName(), "Mindbox.PostAddress.Tests");
        };
        $p.ArraySortAndSearch = function TestsExample_ArraySortAndSearch() {
            var array = $d.array(System.Byte, [6, 4, 2, 1, 5, 0, 3, 7]);
            Array.Sort$8(System.Byte, array);
            assert.deepEqual(array, $d.array(System.Byte, [0, 1, 2, 3, 4, 5, 6, 7]));
            assert.equal(Array.BinarySearch(System.Byte, array, 4), 4);
            assert.ok(Array.BinarySearch(System.Byte, array, 8) < 0);
        };
        $p.GenericTypeInfo = function TestsExample_GenericTypeInfo() {
            var tuple2Type = $d.typeOf(System.Tuple$2(System.Int32, String));
            assert.equal(tuple2Type.GetGenericTypeDefinition(), $d.typeOf(System.Tuple$2));
            assert.equal(tuple2Type.get_GenericTypeArguments().length, 2);
            var tuple2TypeArgs = tuple2Type.GetGenericArguments();
            assert.equal(tuple2TypeArgs.length, 2);
            assert.equal(tuple2TypeArgs[0], $d.typeOf(System.Int32));
            assert.equal(tuple2TypeArgs[1], $d.typeOf(String));
        };
        $p.IntegerMath = function TestsExample_IntegerMath() {
            var x = 200;
            assert.equal(x + x * 2, 600);
            assert.equal((x / 3 | 0), 66);
            assert.equal((x & 0xFF), 200);
            assert.equal($d.toInt8(x), -56);
        };
        $p.InvalidCastThrowsException = function TestsExample_InvalidCastThrowsException() {
            var doc = document;
            var window;

            assert.ok($d.typeOf(Node).IsAssignableFrom($d.getTypeFromInst(doc)));
            Mindbox.PostAddress.Tests.QUnitUtils.Throws(System.InvalidCastException, $d.delegate(function() {
                window = $d.cast(doc, Window);
            }, this), null); // try to cast Document to Window
        };
        $p.JQuery_Md5 = function TestsExample_JQuery_Md5() {
            assert.expect(2);
            var done = assert.async();

            var settings = (function() {
                var $obj = new (DuoCode.JQuery.JsonAjaxSettings$1(DuoCode.JQuery.Md5HashInfo).ctor)();
                $obj.set_Url("http://md5.jsontest.com/");
                $obj.set_Method(1 /* Method.GET */);
                $obj.set_Data((function() {
                    var $obj = new (System.Collections.Generic.Dictionary$2(String, String).ctor)();
                    $obj.Add$1("text", "ex");
                    return $obj;
                }).call(this));
                $obj.set_IsCrossDomain(true);
                $obj.set_DataType(4 /* AjaxDataType.jsonp */);
                $obj.set_OnSuccess($d.delegate(function(info, status, jqXhr) {
                    assert.equal(info.original, "ex");
                    assert.equal(info.md5, "54d54a126a783bc9cba8c06137136943");

                    done();
                }, this));
                $obj.set_OnError($d.delegate(function(xhr, status, arg3) {
                    Mindbox.PostAddress.Tests.QUnitUtils.Fail("Ajax request failed");
                }, this));
                return $obj;
            }).call(this);

            $.ajax(settings);
        };
    });
Mindbox.PostAddress.Tests.Tests = $d.declare("Mindbox.PostAddress.Tests.Tests", System.Object, 0, $asm, 
    function($t, $p) {
        $t.$typeInfo = function(t, p) { return [257, null, [["TestInitialize", p.TestInitialize, 6, null, null, [new Mindbox.PostAddress.Tests.TestInitializeAttribute.ctor()]], ["Autocomplete_PostIndex", p.Autocomplete_PostIndex, 6, null, null, [new Mindbox.PostAddress.Tests.TestAttribute.ctor()]]], [["ctor", t.ctor, 6]], null, null, [(function() { var $obj = new Mindbox.PostAddress.Tests.TestFixtureAttribute.ctor();$obj.set_Timeout(20000);return $obj; }).call(this)]]; };
        $t.ctor = function Tests() {
            $t.$baseType.ctor.call(this);
        };
        $t.ctor.prototype = $p;
        $p.TestInitialize = function Tests_TestInitialize() {
            Mindbox.PostAddress.PostAddress().set_ServerUrl("https://mindbox.staging.directcrm.ru");
        };
        $p.Autocomplete_PostIndex = function Tests_Autocomplete_PostIndex() {
            assert.expect(7);
            var done = assert.async();

            var expectation = (function() {
                var $obj = new Mindbox.PostAddress.SimpleSettlementAutocompleteViewModel.ctor();
                $obj.regionName = "\u041C\u043E\u0441\u043A\u0432\u0430 \u0413\u043E\u0440\u043E\u0434";
                $obj.postIndex = "115580";
                $obj.description = "\u0433\u043E\u0440\u043E\u0434";
                $obj.districtName = String.Empty;
                $obj.settlementName = "\u041C\u043E\u0441\u043A\u0432\u0430";
                $obj.settlementId = "388707";
                return $obj;
            }).call(this);

            Mindbox.PostAddress.PostAddress.Autocomplete("115580", $d.delegate(function(searchResult) {
                assert.equal(searchResult.get_Count(), 1, "\u0414\u043E\u043B\u0436\u0435\u043D \u043F\u0440\u0438\u0439\u0442\u0438 \u0442\u043E\u043B\u044C\u043A\u043E \u043E\u0434\u0438\u043D \u0440\u0435\u0437\u0443\u043B\u044C\u0442\u0430\u0442 \u043F\u043E\u0438\u0441\u043A\u0430 \u0430\u0432\u0442\u043E\u0434\u043E\u043F\u043E\u043B\u043D\u0435\u043D\u0438\u044F");

                var result = searchResult.get_Item(0);

                assert.equal(result.regionName, expectation.regionName, "\u0413\u043E\u0440\u043E\u0434 \u0434\u0435\u0439\u0441\u0442\u0432\u0438\u0442\u0435\u043B\u044C\u043D\u043E \u041C\u043E\u0441\u043A\u0432\u0430");
                assert.equal(result.postIndex, expectation.postIndex, "\u041F\u043E\u0447\u0442\u043E\u0432\u044B\u0439 \u0430\u0434\u0440\u0435\u0441 \u0438 \u0432\u043F\u0440\u044F\u043C\u044C 115580");
                assert.equal(result.description, expectation.description, "\u041E\u043F\u0438\u0441\u0430\u043D\u0438\u044F \u0441\u043E\u0432\u043F\u0430\u0434\u0430\u044E\u0442");
                assert.equal(result.districtName, expectation.districtName, "\u041D\u0430\u0437\u0432\u0430\u043D\u0438\u044F \u0440\u0430\u0439\u043E\u043D\u043E\u0432 \u0441\u043E\u043F\u0430\u0434\u0430\u044E\u0442");
                assert.equal(result.settlementId, expectation.settlementId, "Id \u043D\u0430\u0441\u0435\u043B\u0435\u043D\u043D\u044B\u0445 \u043F\u0443\u043D\u043A\u0442\u043E\u0432 \u0441\u043E\u0432\u043F\u0430\u0434\u0430\u044E\u0442");

                assert.equal(result.settlementName, expectation.settlementName, "\u041D\u0430\u0437\u0432\u0430\u043D\u0438\u0435 \u043D\u0430\u0441\u0435\u043B\u0435\u043D\u043D\u044B\u0445 \u043F\u0443\u043D\u043A\u0442\u043E\u0432 \u0441\u043E\u0432\u043F\u0430\u0434\u0430\u044E\u0442");

                done();
            }, this));
        };
    });
return $asm;
})();
//# sourceMappingURL=Mindbox.PostAddress.Tests.js.map