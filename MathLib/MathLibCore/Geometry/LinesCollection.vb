Option Strict On

Namespace Geometry

    Public Class LinesCollection

        Inherits Collections.ObjectModel.Collection(Of MathLib.Line)

        ''' <summary>Importe des éléments dans la collection depuis un tableau</summary>
        ''' <param name="values">Eléments à ajouter au tableau</param>
        Public Sub FromArray(ByVal values() As MathLib.Line)

            '-- Parameter Validation ----------------------------
            If values Is Nothing Then Throw New NullReferenceException("values")
            '-- Internal Data Validation ------------------------
            '-- Exit Case ---------------------------------------
            If values.Length = 0 Then Exit Sub
            '----------------------------------------------------

            Dim i As Integer

            For i = 0 To values.Length - 1
                Me.Add(values(i))
            Next

        End Sub

        ''' <summary>Export les éléments de la collection vers un tableau</summary>
        Public Function ToArray() As MathLib.Line()

            Return MyBase.ToArray

        End Function

    End Class

End Namespace