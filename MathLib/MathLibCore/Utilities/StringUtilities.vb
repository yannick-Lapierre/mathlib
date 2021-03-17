Imports System.Text
Imports System.Diagnostics.Contracts

Namespace Utilities
    Module StringUtilities

        Public Function EnumerableToString(Of T)(ByVal items As IEnumerable(Of T), separator As String) As String
            Contract.Requires(Of ArgumentNullException)(items IsNot Nothing, "items")
            Contract.Requires(Of ArgumentNullException)(separator IsNot Nothing, "separator")
            Return EnumerableToCommaSeparatedString(items.ToList().ConvertAll(Of String)(Function(its) its.ToString), separator, String.Empty, String.Empty)
        End Function

        Private Function EnumerableToCommaSeparatedString(ByVal items As IEnumerable(Of String), ByVal itemSeparator As String, ByVal itemPrefix As String, ByVal itemSuffix As String) As String
            Contract.Requires(Of ArgumentNullException)(items IsNot Nothing, "items")
            Contract.Requires(Of ArgumentNullException)(itemSeparator IsNot Nothing, "itemSeparator")
            Contract.Requires(Of ArgumentNullException)(itemPrefix IsNot Nothing, "itemPrefix")
            Contract.Requires(Of ArgumentNullException)(itemSuffix IsNot Nothing, "itemSuffix")

            Dim stringBuilder As New StringBuilder

            For Each item As String In items
                If Not String.IsNullOrEmpty(stringBuilder.ToString()) Then
                    stringBuilder.Append(itemSeparator)
                End If

                stringBuilder.Append(itemPrefix & item & itemSuffix)
            Next

            Return stringBuilder.ToString()
        End Function
    End Module
End Namespace