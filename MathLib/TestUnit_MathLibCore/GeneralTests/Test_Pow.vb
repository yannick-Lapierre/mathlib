Namespace GeneralTests

    <TestClass()>
    Public Class Pow

        <TestInitialize()>
        Public Sub SetUp()

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

        End Sub

        <TestMethod()> <Description("2e1 = 2")> _
        Public Sub Test_01()


            Assert.AreEqual(2.0#, MathLib.General.Pow(2.0#, 1.0#))

        End Sub

        <TestMethod()> <Description("2e-1 = 0.5")> _
        Public Sub Test_02()

            Assert.AreEqual(0.5#, MathLib.General.Pow(2.0#, -1.0#))

        End Sub

        <TestMethod()> <Description("2e0 = 1")> _
        Public Sub Test_03()

            Assert.AreEqual(1.0#, MathLib.General.Pow(2.0#, 0.0#))

        End Sub

    End Class

End Namespace