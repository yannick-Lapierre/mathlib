Namespace Algebra

  Public Class Hexadecimal

    ''' <summary>
    '''     Formate une valeur
    ''' </summary>
    ''' <param name="Value" type="String">
    '''     <para>
    '''         Valeur à formater
    '''     </para>
    ''' </param>
    ''' <param name="Format" type="Byte">
    '''     <para>
    '''         Nb de digit.
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     A Object value...
    ''' </returns>
    Public Shared Function HexFormat(ByVal Value As String, ByVal Format As Byte) As String

      Dim Result As String

      If Not IsHex(Value) Then
        ' erreur
      End If

      Result = Value
      Do While Result.Length < Format
        Result = "0" & Result
      Loop

      Return Result

    End Function

    ''' <summary>
    '''     Informe si la valeur est une valeur Hexadecimal correct.
    ''' </summary>
    ''' <param name="Value" type="String">
    '''     <para>
    '''         Valeur à analyser
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     A Boolean value...
    ''' </returns>
    Public Shared Function IsHex(ByVal Value As String) As Boolean

      Dim i As Short
      ' Compte le Nb de separateur entier/reel "."
      Dim Sep As Short

      If IsNothing(Value) Then Return False
      If Value.Length = 0 Then Return False
      ' On enleve le signe de negation s'il existe
      If Value.Chars(0) = "-" Then
        Value = Value.Remove(0, 1)
        ' On test qu'il y ai bien des éléments apres la néagation
        If Value.Length = 0 Then Return False
      End If

      Sep = 0
      For i = 0 To Value.Length - 1
        Select Case Value.Chars(i)
          Case "a", "A", "b", "B", "c", "C", "d", "D", "e", "E", "f", "F", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
          Case "."
            Sep += 1
            If Sep > 1 Then Return False ' Trop de separateur.
          Case Else
            Return False
        End Select
      Next

      Return True

    End Function

  End Class

End Namespace
