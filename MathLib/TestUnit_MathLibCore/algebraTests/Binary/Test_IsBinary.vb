Namespace algebraTests.Binary

    <TestClass()>
    Public Class IsBinary

        <TestMethod()>
         <Description("0")>
        Public Sub Test_01()

            Dim Msg As String
            Dim Value As String

            '-- Initialisation des valeurs --------------------------------------
            Value = "0"
            '--------------------------------------------------------------------

            Msg = "Value = " & Value
            Assert.IsTrue(MathLib.Algebra.Binary.IsBinary(Value), Msg)

        End Sub

        <TestMethod()>
        <Description("1")>
        Public Sub Test_02()

            Dim Msg As String
            Dim Value As String

            '-- Initialisation des valeurs --------------------------------------
            Value = "1"
            '--------------------------------------------------------------------

            Msg = "Value = " & Value
            Assert.IsTrue(MathLib.Algebra.Binary.IsBinary(Value), Msg)

        End Sub

        <TestMethod()>
        <Description("010110")> _
        Public Sub Test_03()

            Dim Msg As String
            Dim Value As String

            '-- Initialisation des valeurs --------------------------------------
            Value = "010110"
            '--------------------------------------------------------------------

            Msg = "Value = " & Value
            Assert.IsTrue(MathLib.Algebra.Binary.IsBinary(Value), Msg)

        End Sub

        <TestMethod()>
        <Description("1.01")> _
        Public Sub Test_04()

            Dim Msg As String
            Dim Value As String

            '-- Initialisation des valeurs --------------------------------------
            Value = "1.01"
            '--------------------------------------------------------------------

            Msg = "Value = " & Value
            Assert.IsTrue(MathLib.Algebra.Binary.IsBinary(Value), Msg)

        End Sub

        <TestMethod()>
        <Description("101.001")> _
        Public Sub Test_05()

            Dim Msg As String
            Dim Value As String

            '-- Initialisation des valeurs --------------------------------------
            Value = "101.001"
            '--------------------------------------------------------------------

            Msg = "Value = " & Value
            Assert.IsTrue(MathLib.Algebra.Binary.IsBinary(Value), Msg)

        End Sub

        <TestMethod()>
        <Description("-101")> _
        Public Sub Test_06()

            Dim Msg As String
            Dim Value As String

            '-- Initialisation des valeurs --------------------------------------
            Value = "-101"
            '--------------------------------------------------------------------

            Msg = "Value = " & Value
            Assert.IsTrue(MathLib.Algebra.Binary.IsBinary(Value), Msg)

        End Sub

        <TestMethod()>
        <Description("-101.011")> _
        Public Sub Test_07()

            Dim Msg As String
            Dim Value As String

            '-- Initialisation des valeurs --------------------------------------
            Value = "-101.011"
            '--------------------------------------------------------------------

            Msg = "Value = " & Value
            Assert.IsTrue(MathLib.Algebra.Binary.IsBinary(Value), Msg)

        End Sub

        <TestMethod()>
        <Description("")> _
        Public Sub Test_08()

            Dim Msg As String
            Dim Value As String

            '-- Initialisation des valeurs --------------------------------------
            Value = ""
            '--------------------------------------------------------------------

            Msg = "Value = " & Value
            Assert.IsFalse(MathLib.Algebra.Binary.IsBinary(Value), Msg)

        End Sub

        <TestMethod()>
        <Description("102")> _
        Public Sub Test_09()

            Dim Msg As String
            Dim Value As String

            '-- Initialisation des valeurs --------------------------------------
            Value = "102"
            '--------------------------------------------------------------------

            Msg = "Value = " & Value
            Assert.IsFalse(MathLib.Algebra.Binary.IsBinary(Value), Msg)

        End Sub

        <TestMethod()>
        <Description("--1")> _
        Public Sub Test_10()

            Dim Msg As String
            Dim Value As String

            '-- Initialisation des valeurs --------------------------------------
            Value = "--1"
            '--------------------------------------------------------------------

            Msg = "Value = " & Value
            Assert.IsFalse(MathLib.Algebra.Binary.IsBinary(Value), Msg)

        End Sub

        <TestMethod()>
        <Description("1.01.1")> _
        Public Sub Test_11()

            Dim Msg As String
            Dim Value As String

            '-- Initialisation des valeurs --------------------------------------
            Value = "1.01.1"
            '--------------------------------------------------------------------

            Msg = "Value = " & Value
            Assert.IsFalse(MathLib.Algebra.Binary.IsBinary(Value), Msg)

        End Sub

        <TestMethod()>
        <Description("10-1")> _
        Public Sub Test_12()

            Dim Msg As String
            Dim Value As String

            '-- Initialisation des valeurs --------------------------------------
            Value = "10-1"
            '--------------------------------------------------------------------

            Msg = "Value = " & Value
            Assert.IsFalse(MathLib.Algebra.Binary.IsBinary(Value), Msg)

        End Sub

        <TestMethod()>
        <Description("-0-1")> _
        Public Sub Test_13()

            Dim Msg As String
            Dim Value As String

            '-- Initialisation des valeurs --------------------------------------
            Value = "-0-1"
            '--------------------------------------------------------------------

            Msg = "Value = " & Value
            Assert.IsFalse(MathLib.Algebra.Binary.IsBinary(Value), Msg)

        End Sub

    End Class
End Namespace