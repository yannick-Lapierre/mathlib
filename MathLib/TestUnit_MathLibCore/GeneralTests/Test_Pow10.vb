Namespace General

    <TestClass()>
    Public Class Pow10

        <TestInitialize()>
        Public Sub SetUp()

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

        End Sub

        <TestMethod()>
        <Description("2*10e1 = 20")>
        Public Sub Test_01()


            Assert.AreEqual(20.0#, MathLib.General.Pow10(2.0#, 1.0#))

        End Sub

        <TestMethod()>
        <Description("2*10e-1 = 0.2")>
        Public Sub Test_02()

            Assert.AreEqual(0.2#, MathLib.General.Pow10(2.0#, -1.0#))

        End Sub

        <TestMethod()>
        <Description("2*10e0 = 2")>
        Public Sub Test_03()

            Assert.AreEqual(2.0#, MathLib.General.Pow10(2.0#, 0.0#))

        End Sub

    End Class

End Namespace
