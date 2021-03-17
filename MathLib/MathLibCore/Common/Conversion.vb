Option Strict On

Namespace Common

  Public Class Conversion

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Convertie un angle
    ''' </summary>
    ''' <param name="Value">Valeu de l'angle</param>
    ''' <param name="In_Unit">Unité de l'angle d'entré</param>
    ''' <param name="Out_Unit">Unité de sortie de l'angle</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	27/03/2006	Created
    '''   [lap_y] 27/03/2006  Passage en "Shared"
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function Angle(ByVal Value As Double, _
                                 ByVal In_Unit As MathLib.UnitAngle, _
                                 ByVal Out_Unit As MathLib.UnitAngle) _
                                 As Double

      Dim Result As Double

      'Convertir la valeur en Deg
      Select Case In_Unit
        Case MathLib.UnitAngle.Degree
          Result = Value
        Case MathLib.UnitAngle.Gradian
          Result = Value * (360.0# / 400.0#)
        Case MathLib.UnitAngle.Radian
          Result = 180 * Value / MathLib.Constant.PI
        Case MathLib.UnitAngle.Pourcent
          Result = MathLib.Geometry.trigonometry.ATan(100.0# / Value)
      End Select

      'Convertir en unité demandé
      Select Case Out_Unit
        Case MathLib.UnitAngle.Degree
          ' Rien
        Case MathLib.UnitAngle.Gradian
          Result = Value * (400.0# / 360.0#)
        Case MathLib.UnitAngle.Radian
          Result = MathLib.Constant.PI * Result / 180.0#
        Case MathLib.UnitAngle.Pourcent
          Result = (100.0# / MathLib.Geometry.trigonometry.Tan(Value))
      End Select

      Return Result
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' COnversion d'unité de mesure
    ''' </summary>
    ''' <param name="Value">Valeur a convertir</param>
    ''' <param name="In_Unit">Unité de la valeur</param>
    ''' <param name="Out_Unit">Unité desiré</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Administrateur]	27/03/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function Metric(ByVal Value As Double, _
                                  ByVal In_Unit As General.UnitMetric, _
                                  ByVal Out_Unit As General.UnitMetric) _
                                  As Double
      Dim Result As Double
      'Convertir la valeur en Metre
      Select Case In_Unit
        Case General.UnitMetric.Centimetre
          Result = Value * 0.01#
        Case General.UnitMetric.foot
          Result = Value * 0.3048#
        Case General.UnitMetric.hectometre
          Result = Value * 100.0#
        Case General.UnitMetric.inch
          Result = Value * 0.0254#
        Case General.UnitMetric.Kilometre
          Result = Value * 1000.0#
        Case General.UnitMetric.meter
          Result = Value
        Case General.UnitMetric.micrometre
          Result = Value * 0.000001#
        Case General.UnitMetric.Millimetre
          Result = Value * 0.001#
        Case General.UnitMetric.NanoMetre
          Result = Value * 0.000000001#
        Case General.UnitMetric.PicoMetre
          Result = Value * 0.000000000001#
        Case General.UnitMetric.yard
          Result = Value * 0.9144#
      End Select

      'Convertir en unité demandé
      Select Case Out_Unit
        Case General.UnitMetric.Centimetre
          Result = Result / 0.01#
        Case General.UnitMetric.foot
          Result = Result / 0.3048#
        Case General.UnitMetric.hectometre
          Result = Result / 100.0#
        Case General.UnitMetric.inch
          Result = Result / 0.0254#
        Case General.UnitMetric.Kilometre
          Result = Result / 1000.0#
        Case General.UnitMetric.meter
          Result = Result
        Case General.UnitMetric.micrometre
          Result = Result / 0.000001#
        Case General.UnitMetric.Millimetre
          Result = Result / 0.001#
        Case General.UnitMetric.NanoMetre
          Result = Result / 0.000000001#
        Case General.UnitMetric.PicoMetre
          Result = Result / 0.000000000001#
        Case General.UnitMetric.yard
          Result = Result / 0.9144#
      End Select

      Return Result

    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Conversion de volume
    ''' </summary>
    ''' <param name="Value">Valeur a convertir</param>
    ''' <param name="In_Unit">Unité d'entré</param>
    ''' <param name="Out_Unit">Unité de sortie</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[lap_y]	27/03/2006	Created
    '''   [lap_y] 27/03/2006  Passage en "Shared"
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Shared Function Volumetry(ByVal Value As Double, _
                                     ByVal In_Unit As General.Volumetry, _
  ByVal Out_Unit As General.Volumetry) _
  As Double

      Dim Result As Double
      'Convertir la valeur en litre
      Select Case In_Unit

        Case General.Volumetry.Centilitre
          Result = Value * 0.01#
        Case General.Volumetry.Centimetre
          Result = Value * 0.001#
        Case General.Volumetry.Foot
          Result = Value * 28.3#
        Case General.Volumetry.Hectolitre
          Result = Value * 100.0#
        Case General.Volumetry.Hectometre
          Result = Value * 1000000000.0#
        Case General.Volumetry.Inch
          Result = Value * 0.01639#
        Case General.Volumetry.Kilometre
          Result = Value * 1000000000000.0#
        Case General.Volumetry.Litre
          Result = Value
        Case General.Volumetry.Meter
          Result = Value * 1000.0#
        Case General.Volumetry.Micrometre
          Result = Value * 0.000000000000001#
        Case General.Volumetry.Mililitre
          Result = Value * 0.001#
        Case General.Volumetry.Millimetre
          Result = Value * 0.000001#
        Case General.Volumetry.NanoMetre
          Result = Value * 1.0E-27#
        Case General.Volumetry.PicoMetre
          Result = Value * 1.0E-36#
        Case General.Volumetry.Yard
          Result = Value * 765.0#
      End Select

      'Convertir dans l'unité demandé
      Select Case Out_Unit
        Case General.Volumetry.Centilitre
          Result = Value / 0.01#
        Case General.Volumetry.Centimetre
          Result = Value / 0.001#
        Case General.Volumetry.Foot
          Result = Value / 28.3#
        Case General.Volumetry.Hectolitre
          Result = Value / 100.0#
        Case General.Volumetry.Hectometre
          Result = Value / 1000000000.0#
        Case General.Volumetry.Inch
          Result = Value / 0.01639#
        Case General.Volumetry.Kilometre
          Result = Value / 1000000000000.0#
        Case General.Volumetry.Litre
          Result = Value
        Case General.Volumetry.Meter
          Result = Value / 1000.0#
        Case General.Volumetry.Micrometre
          Result = Value / 0.000000000000001#
        Case General.Volumetry.Mililitre
          Result = Value / 0.001#
        Case General.Volumetry.Millimetre
          Result = Value / 0.000001#
        Case General.Volumetry.NanoMetre
          Result = Value / 1.0E-27#
        Case General.Volumetry.PicoMetre
          Result = Value / 1.0E-36#
        Case General.Volumetry.Yard
          Result = Value / 765.0#
      End Select

      Return Result

    End Function

    ''' <summary>
    '''     'Conversion des valeurs numerique des differentes bases en elles.
    ''' </summary>
    ''' <remarks>
    '''     Base 2 (Binaire), Base 10 (Decimal), ...
    ''' </remarks>
    Public Class Bases


      ''' <summary>
      '''     Format une valeur Binaire, pour qu'elle correspondent au format hexadecimal (4 éléments)
      ''' </summary>
      ''' <param name="Value" type="String">
      '''     <para>
      '''         
      '''     </para>
      ''' </param>
      ''' <returns>
      '''     A String value...
      ''' </returns>
      Private Shared Function Format_Binary2Hex(ByVal Value As String) As String

        Dim TmpShort As Short
        Dim i As Short
        Dim Result As String

        Result = Value
        TmpShort = CShort(Value.Length Mod 4)
        If TmpShort > 0 Then TmpShort = CShort(4) - TmpShort

        For i = 1 To TmpShort
          Result = "0" & Result
        Next

        Return Result

      End Function

      ''' <summary>
      '''     Decoupe une valeur en Hexadecimal en un tableau d'hexadédimal
      ''' </summary>
      ''' <param name="Value" type="String">
      '''     <para>
      '''         Valeur a Spliter
      '''     </para>
      ''' </param>
      ''' <returns>
      '''     A String value...
      ''' </returns>
      Private Shared Function Format_HexSplit(ByVal Value As String) As String()

        Dim TabBinary() As Char
        Dim Result As String()
        Dim i As Integer
        Dim j As Integer
        Dim k As Short

        Value = Format_Binary2Hex(Value)
        TabBinary = Value.ToCharArray

        k = 0
        ReDim Result(CInt(((TabBinary.LongLength - 1) / 4) - 1))
        j = Result.Length - 1
        For i = 0 To TabBinary.Length - 1
          Result(j) &= TabBinary(i)
          k += CShort(1)
          If k = 4 Then
            k = 0
            j -= 1
          End If
        Next

        Return Result

      End Function
#Region "Hex"

      ''' <summary>
      '''     Conversion d'un Byte en Hexadecimale 
      ''' </summary>
      ''' <param name="Value" type="Byte">
      '''     <para>
      '''         Valeur à convertir.
      '''     </para>
      ''' </param>
      ''' <returns>
      '''     A String value...
      ''' </returns>
      Public Shared Function Hex(ByVal Value As Byte) As String

        Return Hex(CInt(Value))

      End Function

      ''' <summary>
      '''     Conversion D'un entier en Hexadecimale 
      ''' </summary>
      ''' <param name="Value" type="Integer">
      '''     <para>
      '''         Valeur à convertir.
      '''     </para>
      ''' </param>
      ''' <returns>
      '''     A String value...
      ''' </returns>
      Public Shared Function Hex(ByVal Value As Integer) As String

        Dim BinaryValue As String
        Dim TabHex() As String
        Dim i As Integer
        Dim Result As String = ""
        Dim TmpHex As String
        Dim Neg As Boolean = False

        If Value < 0 Then
          Neg = True
          Value = Math.Abs(Value)
        End If

        BinaryValue = Binary(Value)
        BinaryValue = Format_Binary2Hex(BinaryValue)

        TabHex = Format_HexSplit(BinaryValue)

        For i = 0 To TabHex.Length - 1
          Select Case TabHex(i)
            Case "0000"
              TmpHex = "0"
            Case "0001"
              TmpHex = "1"
            Case "0010"
              TmpHex = "2"
            Case "0011"
              TmpHex = "3"
            Case "0100"
              TmpHex = "4"
            Case "0101"
              TmpHex = "5"
            Case "0110"
              TmpHex = "6"
            Case "0111"
              TmpHex = "7"
            Case "1000"
              TmpHex = "8"
            Case "1001"
              TmpHex = "9"
            Case "1010"
              TmpHex = "A"
            Case "1011"
              TmpHex = "B"
            Case "1100"
              TmpHex = "C"
            Case "1101"
              TmpHex = "D"
            Case "1110"
              TmpHex = "E"
            Case "1111"
              TmpHex = "F"
            Case Else
              'erreur
              Throw New MathLib.Exception(13, "Value = '" & Value & "'")
          End Select

          Result = TmpHex & Result

        Next

        If Neg Then Result = "-" & Result

        Return Result

      End Function

#End Region

#Region "Decimal"

      ''' <summary>
      '''     Convertir une Hexadécimal en valeur decimal (Base 16 vers Base 10)
      ''' </summary>
      ''' <param name="Value" type="String">
      '''     <para>
      '''         Valeur Hexadecimal (base 16) à convertir
      '''     </para>
      ''' </param>
      ''' <returns>
      '''     A Integer value...
      ''' </returns>
      Public Shared Function DecimalFromHex(ByVal Value As String) As Integer

        Dim i, j As Short
        Dim Result As Integer
        Dim Neg As Boolean = False
        Dim TmpVal As Integer

        If Not Algebra.Hexadecimal.IsHex(Value) Then Throw New MathLib.Exception(9, "Value : '" & Value & "'")

        If Value.Chars(0) = "-" Then
          Neg = True
          Value = Value.Remove(0, 1)
        End If

        Result = 0
        j = 0
        For i = CShort(Value.Length - 1) To 0 Step -1
          Select Case Value.Chars(i)
            Case CChar("0") : TmpVal = 0
            Case CChar("1") : TmpVal = 1
            Case CChar("2") : TmpVal = 2
            Case CChar("3") : TmpVal = 3
            Case CChar("4") : TmpVal = 4
            Case CChar("5") : TmpVal = 5
            Case CChar("6") : TmpVal = 6
            Case CChar("7") : TmpVal = 7
            Case CChar("8") : TmpVal = 8
            Case CChar("9") : TmpVal = 9
            Case CChar("a"), CChar("A") : TmpVal = 10
            Case CChar("b"), CChar("B") : TmpVal = 11
            Case CChar("c"), CChar("C") : TmpVal = 12
            Case CChar("d"), CChar("D") : TmpVal = 13
            Case CChar("e"), CChar("E") : TmpVal = 14
            Case CChar("f"), CChar("F") : TmpVal = 15
            Case Else : TmpVal = 0
          End Select

          ' Calcul : 3E8 = 3*16^2 + 14*16^1 + 8*16^0
          Result += TmpVal * CInt(MathLib.General.Sqr(16, j))
          j += CShort(1)
        Next

        If Neg Then Result = -Result

        Return Result

      End Function

#End Region

#Region "Binary"

      ''' <summary>
      '''     Convertie une valeur Byte en chaine binaire correspondante
      ''' </summary>
      ''' <param name="Value" type="Byte">
      '''     <para>
      '''         Valeur a convertir en binaire.
      '''     </para>
      ''' </param>
      ''' <returns>
      '''     A String value...
      ''' </returns>
      Public Shared Function Binary(ByVal Value As Byte) As String

        Return Binary(CInt(Value))

      End Function

      ''' <summary>
      '''     Convertie une valeur Integer en chaine binaire correspondante
      ''' </summary>
      ''' <param name="Value" type="Integer">
      '''     <para>
      '''         Valeur a convertir en binaire.
      '''     </para>
      ''' </param>
      ''' <returns>
      '''     A String value...
      ''' </returns>
      Public Shared Function Binary(ByVal Value As Integer) As String

        Dim Result As String = ""
        Dim div As Integer
        Dim Rest As Integer
        Dim Neg As Boolean = False

        If Value < 0 Then
          Value = Math.Abs(Value)
          Neg = True
        End If

        Do While Value > 1
          div = Value \ 2
          Rest = Value Mod 2
          Result = Rest & Result
          Value = div
        Loop

        Result = (Value Mod 2) & Result

        If Neg = True Then Result = "-" & Result

        Return Result

      End Function

      Public Shared Function BinaryFromHex(ByVal Value As String) As String

        Dim Result As String = ""
        Dim TmpStr As String
        Dim i As Short
        Dim Neg As Boolean = False

        If Value.Chars(i) = "-" Then
          Neg = True
          Value = Value.Remove(0, 1)
        End If

        For i = 0 To CShort(Value.Length - 1)
          Select Case Value.Chars(i)
            Case CChar("0") : TmpStr = "0000"
            Case CChar("1") : TmpStr = "0001"
            Case CChar("2") : TmpStr = "0010"
            Case CChar("3") : TmpStr = "0011"
            Case CChar("4") : TmpStr = "0100"
            Case CChar("5") : TmpStr = "0101"
            Case CChar("6") : TmpStr = "0110"
            Case CChar("7") : TmpStr = "0111"
            Case CChar("8") : TmpStr = "1000"
            Case CChar("9") : TmpStr = "1001"
            Case CChar("A"), CChar("a") : TmpStr = "1010"
            Case CChar("B"), CChar("b") : TmpStr = "1011"
            Case CChar("C"), CChar("c") : TmpStr = "1100"
            Case CChar("D"), CChar("d") : TmpStr = "1101"
            Case CChar("E"), CChar("e") : TmpStr = "1110"
            Case CChar("F"), CChar("f") : TmpStr = "1111"
            Case Else
              Throw New MathLib.Exception(9, "Value = '" & Value & "'")
          End Select

          Result &= TmpStr

        Next

        ' on supprime les 0 non significatifs
        Do While Result.Chars(0) = "0" And Result.Length > 1
          Result = Result.Remove(0, 1)
        Loop

        If Neg Then Result = "-" & Result

        Return Result

      End Function

#End Region


    End Class

  End Class

End Namespace
