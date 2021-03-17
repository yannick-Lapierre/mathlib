Option Strict Off

Namespace Algebra

  Public Class Binary

    ' Convertie un tableau de byte (ou une partie) en entier
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Convertie un tableau de bytes (ou une partie) en un entier
    ''' </summary>
    ''' <param name="Tab_Byte">Tableau de bytes a convertire</param>
    ''' <param name="Start_Cel">Debut de la partie a convertire</param>
    ''' <param name="End_Cel">Fin de la partie a convertire</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	01/06/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function From_TabBytes(ByVal Tab_Byte() As Byte, Optional ByVal Start_Cel As Byte = Nothing, Optional ByVal End_Cel As Byte = Nothing) As Integer

      Dim i, j As Integer
      Dim Result As Integer
      Dim Temp_Byte As Byte

      Result = 0
      j = 0

      If Start_Cel = Nothing Then
        Start_Cel = 0
      End If

      If End_Cel = Nothing Then
        End_Cel = CByte(Tab_Byte.Length - 1)
      End If

      If Start_Cel > End_Cel Then
        Temp_Byte = Start_Cel
        Start_Cel = End_Cel
        End_Cel = Temp_Byte
      End If

      If Tab_Byte.Length - 1 < End_Cel Then ReDim Preserve Tab_Byte(End_Cel)

      For i = Start_Cel To End_Cel
        Result = Result + (Tab_Byte(i) * CInt(2 ^ j))
        j += 1
      Next
      Return Result


    End Function

    ''' <summary>
    '''     Informe si la valeur est une valeur Binaire correct.
    ''' </summary>
    ''' <param name="Value" type="String">
    '''     <para>
    '''         Valeur à analyser
    '''     </para>
    ''' </param>
    ''' <returns>
    '''     A Boolean value...
    ''' </returns>
    Public Shared Function IsBinary(ByVal Value As String) As Boolean

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
      For i = 0 To CShort(Value.Length - 1)
        Select Case Value.Chars(i)
          Case "0"c, "1"c
          Case "."c
            Sep += 1S
            If Sep > 1 Then Return False ' Trop de separateur.
          Case Else
            Return False
        End Select
      Next

      Return True

    End Function


    ' Retourne true si Tested_Value appartient a Global_Value
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Permet de calculer un mask binaire. Un mask binaire est habituellement utiliser pour coder une ou plusieurs valeurs dans un seul nombre.
    ''' </summary>
    ''' <param name="Tested_Value">Valeur a rechercher</param>
    ''' <param name="Global_Value">Valeur dans laquelle on doit chercher.</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	01/06/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function Shadow(ByVal Tested_Value As Object, ByVal Global_Value As Object) As Boolean

      Dim Result As Boolean

      ' Si les valeur ne sont pas numerique on quitte
      If Not (IsNumeric(Tested_Value)) Or Not (IsNumeric(Global_Value)) Then Exit Function

      Result = False

      If Tested_Value = (Tested_Value And Global_Value) Then Result = True

      Return Result

    End Function

    ' Convertie un entier en tableau de Byte
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Convertie un entier en tableau de bytes
    ''' </summary>
    ''' <param name="Value">Laleur a convertire</param>
    ''' <returns>Tableau de bytes</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	01/06/2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function To_TabBytes(ByVal Value As Integer) As Byte()

      Dim Result() As Byte
      ' Dim Result2() As Byte
      Dim Q As Integer
      Dim R As Byte
      Dim i As Integer

      ReDim Result(0)

      Result(0) = 0
      Q = Value
      i = 0
      Do While Q > 1
        R = CByte(Q Mod 2)
        Q = Q \ 2
        ReDim Preserve Result(i)
        Result(i) = R
        i = i + 1
      Loop

      ' Dans la derniere etape on pass le Quotien (0 ou 1)
      If i > 0 Then   ' Si on est dans le cas d'un seul bit, on ne doit pas redim le tableau
        ReDim Preserve Result(Result.Length)
      End If
      Result(Result.Length - 1) = CByte(Q)

      Return Result

    End Function

  End Class

End Namespace
