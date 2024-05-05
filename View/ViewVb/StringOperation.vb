Module StringOperation

Public Function ByteToString(ByRef lpBuffer() As Byte, _
    ByVal lngStart As Long, ByVal lngEnd As Long, _
    Optional ByVal blnNullTerm As Boolean = True) As String
'--------------------------------------------------------------------
'バイト列を文字列に変換する
'lngStartから、lngEnd までの範囲を(システムで使用している文字コードで)
'文字列に変換する
'--------------------------------------------------------------------
Dim i As Long
Dim lpTemp() As Byte
Dim strText As String

    '指定された範囲を文字列に変換する
    ReDim lpTemp(lngEnd - lngStart + 1)
    For i = lngStart To lngEnd
        lpTemp(i - lngStart) = lpBuffer(i)
    Next i
    strText = StrConv(lpTemp(), vbUnicode)

    'NULL終端文字で文字列を切る
    If blnNullTerm Then
        i = InStr(strText, vbNullChar)
        If (i > 0) Then
            strText = Left$(strText, i - 1)
        End If
    End If

    '変換結果を返す
    ByteToString = strText
End Function

End Module
