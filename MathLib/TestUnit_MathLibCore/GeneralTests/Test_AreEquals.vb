Namespace General

    <TestClass()>
  Public Class AreEquals

        <TestInitialize()>
        Public Sub SetUp()

        End Sub

        <TestCleanup()>
        Public Sub TearDown()

        End Sub

        <TestMethod()> <Description("0.21; 0.22; accuracy = 1 -> true")> _
        Public Sub Test_01()

            Assert.IsTrue(MathLib.General.AreEquals(0.21#, 0.22#, 1))

        End Sub

        <TestMethod()> <Description("0.21; 0.22; accuracy = 2 -> false")> _
        Public Sub Test_02()

            Assert.IsFalse(MathLib.General.AreEquals(0.21#, 0.22#, 2))

        End Sub

    End Class

End Namespace
