﻿Module StringOperation

Public Function ByteToString(ByRef lpBuffer() As Byte, _
    ByVal lngStart As Long, ByVal lngEnd As Long, _
    Optional ByVal blnNullTerm As Boolean = True) As String
'--------------------------------------------------------------------
'バイト列を文字列に変換する
'lngStartから、lngEnd までの範囲を(システムで使用している文字コードで)
'文字列に変換する
'--------------------------------------------------------------------
Dim i As Long, cnvLastIndex As Long
Dim c As Byte
Dim lpTemp() As Byte
Dim strText As String

    '指定された範囲を文字列に変換する
    cnvLastIndex = lngEnd - lngStart
    ReDim lpTemp(cnvLastIndex)
    For i = 0 To cnvLastIndex
        c = lpBuffer(i + lngStart)
        If (blnNullTerm) And (c = 0) And (i > 0) Then
            ReDim Preserve lpTemp(i - 1)
            Exit For
        End If
        lpTemp(i) = c
    Next i
    strText = System.Text.Encoding.GetEncoding("utf8").GetString(lpTemp)

    '変換結果を返す
    ByteToString = strText
End Function

Public Sub StringToByte(ByVal strText As String, _
        ByRef lpBuf() As Byte, ByVal lngStart, ByVal lngEnd As Long, _
        Optional ByVal blnAllocBuffer As Boolean = False)
'--------------------------------------------------------------------
'文字列をバイト列に変換する
'余ったバイトは、0で埋められる
'--------------------------------------------------------------------
Dim i As Long
Dim lpTemp() As Byte
Dim lngTempStart As Long
Dim lngSize As Long

    lpTemp() = StrConv(strText, vbFromUnicode)
    lngTempStart = LBound(lpTemp)
    lngSize = UBound(lpTemp) - lngTempStart + 1

    If blnAllocBuffer Then
        ReDim Preserve lpBuf(lngStart To lngEnd)
    End If

    If (lngEnd - lngStart + 1) < lngSize Then
        lngSize = lngEnd - lngStart + 1
    End If

    For i = 0 To lngSize - 1
        lpBuf(lngStart + i) = lpTemp(i)
    Next i
End Sub

End Module
