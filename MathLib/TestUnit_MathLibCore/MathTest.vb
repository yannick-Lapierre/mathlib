Option Strict On
Option Explicit On

<TestClass()>
Public Class Gen

    <TestMethod()>
    Public Sub Sqr()

        Dim Value As Single
        Dim Level As Integer

        '-- Test ------------------------------------------------------------
        Value = 15
        Level = 0
        Assert.AreEqual(CDbl(1), MathLib.General.Sqr(Value, Level), "Value = " & Value & " | Level = " & Level)
        '-- Test ------------------------------------------------------------
        Value = 1
        Level = 2
        Assert.AreEqual(CDbl(1), MathLib.General.Sqr(Value, Level), "Value = " & Value & " | Level = " & Level)
        '-- Test ------------------------------------------------------------
        Value = 5
        Level = 5
        Assert.AreEqual(CDbl(3125), MathLib.General.Sqr(Value, Level), "Value = " & Value & " | Level = " & Level)

    End Sub

End Class

#Region "CLASS CONV"

'<TestClass()> _
'Public Class Conv

<TestClass()> _
Public Class Bases
#Region "Binary"

    <TestMethod()> _
    Public Sub Binary_byte()

        Dim Value As Byte

        '-- Test ------------------------------------------------------------
        Value = 0
        Assert.AreEqual("0", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 1
        Assert.AreEqual("1", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 77
        Assert.AreEqual("1001101", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 80
        Assert.AreEqual("1010000", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 255
        Assert.AreEqual("11111111", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

    End Sub

    <TestMethod()> _
    Public Sub Binary_Integer()

        Dim Value As Integer

        '-- Test ------------------------------------------------------------
        Value = 0
        Assert.AreEqual("0", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 1
        Assert.AreEqual("1", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 77
        Assert.AreEqual("1001101", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 80
        Assert.AreEqual("1010000", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = -0
        Assert.AreEqual("0", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = -1
        Assert.AreEqual("-1", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = -77
        Assert.AreEqual("-1001101", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = -80
        Assert.AreEqual("-1010000", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)


    End Sub

    <TestMethod()> _
    Public Sub Binary_Sbyte()

        Dim Value As SByte

        '-- Test ------------------------------------------------------------
        Value = 0
        Assert.AreEqual("0", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 1
        Assert.AreEqual("1", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 77
        Assert.AreEqual("1001101", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 80
        Assert.AreEqual("1010000", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = -0
        Assert.AreEqual("0", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = -1
        Assert.AreEqual("-1", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = -77
        Assert.AreEqual("-1001101", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = -80
        Assert.AreEqual("-1010000", MathLib.Common.Conversion.Bases.Binary(Value), "Value = " & Value)


    End Sub

    <TestMethod()> _
    Public Sub BinaryFromHex()

        Dim Value As String

        '-- Test ------------------------------------------------------------
        Value = "0"
        Assert.AreEqual("0", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "1"
        Assert.AreEqual("1", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "2"
        Assert.AreEqual("10", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "3"
        Assert.AreEqual("11", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "4"
        Assert.AreEqual("100", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "5"
        Assert.AreEqual("101", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "6"
        Assert.AreEqual("110", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "7"
        Assert.AreEqual("111", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "8"
        Assert.AreEqual("1000", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "9"
        Assert.AreEqual("1001", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "A"
        Assert.AreEqual("1010", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "a"
        Assert.AreEqual("1010", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "B"
        Assert.AreEqual("1011", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "b"
        Assert.AreEqual("1011", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "C"
        Assert.AreEqual("1100", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "c"
        Assert.AreEqual("1100", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "D"
        Assert.AreEqual("1101", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "d"
        Assert.AreEqual("1101", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "E"
        Assert.AreEqual("1110", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "e"
        Assert.AreEqual("1110", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "F"
        Assert.AreEqual("1111", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "f"
        Assert.AreEqual("1111", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "-F"
        Assert.AreEqual("-1111", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "2D"
        Assert.AreEqual("101101", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "2DA"
        Assert.AreEqual("1011011010", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "2DA4"
        Assert.AreEqual("10110110100100", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "2DA4A"
        Assert.AreEqual("101101101001001010", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "-2DA4A"
        Assert.AreEqual("-101101101001001010", MathLib.Common.Conversion.Bases.BinaryFromHex(Value), "Value = " & Value)

    End Sub

    <TestMethod()>
        <TestCategory("Math")>
        <ExpectedException(GetType(MathLib.Exception))>
    Public Sub BinaryFromHex_Exception_1009()

        Dim Value As String

        Value = "AD12K2"
        MathLib.Common.Conversion.Bases.BinaryFromHex(Value)

    End Sub

#End Region

#Region "Decimal"

    <TestMethod()> _
    Public Sub DecimalFromHex()

        Dim Value As String

        '-- Test ------------------------------------------------------------
        Value = "0"
        Assert.AreEqual(0, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "1"
        Assert.AreEqual(1, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "2"
        Assert.AreEqual(2, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "3"
        Assert.AreEqual(3, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "4"
        Assert.AreEqual(4, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "5"
        Assert.AreEqual(5, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "6"
        Assert.AreEqual(6, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "7"
        Assert.AreEqual(7, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "8"
        Assert.AreEqual(8, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "9"
        Assert.AreEqual(9, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "a"
        Assert.AreEqual(10, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "A"
        Assert.AreEqual(10, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "b"
        Assert.AreEqual(11, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "B"
        Assert.AreEqual(11, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "c"
        Assert.AreEqual(12, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "C"
        Assert.AreEqual(12, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "d"
        Assert.AreEqual(13, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "D"
        Assert.AreEqual(13, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "e"
        Assert.AreEqual(14, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "E"
        Assert.AreEqual(14, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "f"
        Assert.AreEqual(15, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "F"
        Assert.AreEqual(15, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "A09"
        Assert.AreEqual(2569, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)
        '-- Test ------------------------------------------------------------
        Value = "-A09"
        Assert.AreEqual(-2569, MathLib.Common.Conversion.Bases.DecimalFromHex(Value), "Value = " & Value)

    End Sub


#End Region

#Region "Hex"

    <TestMethod()> _
    Public Sub Hex_Byte()

        Dim Value As Byte

        '-- Test ------------------------------------------------------------
        Value = 0
        Assert.AreEqual("0", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 1
        Assert.AreEqual("1", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 2
        Assert.AreEqual("2", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 3
        Assert.AreEqual("3", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 4
        Assert.AreEqual("4", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 5
        Assert.AreEqual("5", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 6
        Assert.AreEqual("6", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 7
        Assert.AreEqual("7", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 8
        Assert.AreEqual("8", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 9
        Assert.AreEqual("9", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 10
        Assert.AreEqual("A", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 11
        Assert.AreEqual("B", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 12
        Assert.AreEqual("C", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 13
        Assert.AreEqual("D", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 14
        Assert.AreEqual("E", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 15
        Assert.AreEqual("F", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 127
        Assert.AreEqual("7F", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 255
        Assert.AreEqual("FF", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

    End Sub

    <TestMethod()> _
    Public Sub Hex_Integer()

        Dim Value As Integer

        '-- Test ------------------------------------------------------------
        Value = 0
        Assert.AreEqual("0", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = -0
        Assert.AreEqual("0", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 1
        Assert.AreEqual("1", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 2
        Assert.AreEqual("2", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 3
        Assert.AreEqual("3", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 4
        Assert.AreEqual("4", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 5
        Assert.AreEqual("5", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 6
        Assert.AreEqual("6", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 7
        Assert.AreEqual("7", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 8
        Assert.AreEqual("8", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 9
        Assert.AreEqual("9", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 10
        Assert.AreEqual("A", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 11
        Assert.AreEqual("B", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 12
        Assert.AreEqual("C", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 13
        Assert.AreEqual("D", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 14
        Assert.AreEqual("E", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 15
        Assert.AreEqual("F", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 410
        Assert.AreEqual("19A", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = -410
        Assert.AreEqual("-19A", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)
    End Sub

    <TestMethod()> _
    Public Sub Hex_SByte()

        Dim Value As SByte

        '-- Test ------------------------------------------------------------
        Value = 0
        Assert.AreEqual("0", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = -0
        Assert.AreEqual("0", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 1
        Assert.AreEqual("1", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 2
        Assert.AreEqual("2", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 3
        Assert.AreEqual("3", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 4
        Assert.AreEqual("4", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 5
        Assert.AreEqual("5", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 6
        Assert.AreEqual("6", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 7
        Assert.AreEqual("7", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 8
        Assert.AreEqual("8", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 9
        Assert.AreEqual("9", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 10
        Assert.AreEqual("A", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 11
        Assert.AreEqual("B", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 12
        Assert.AreEqual("C", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 13
        Assert.AreEqual("D", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 14
        Assert.AreEqual("E", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 15
        Assert.AreEqual("F", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = 127
        Assert.AreEqual("7F", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)

        '-- Test ------------------------------------------------------------
        Value = -127
        Assert.AreEqual("-7F", MathLib.Common.Conversion.Bases.Hex(Value), "Value = " & Value)
    End Sub

#End Region
End Class

'End Class

#End Region