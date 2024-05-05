Module StringOperation

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

Public Function DeleteFileExt(ByVal strFileName As String) As String
'--------------------------------------------------------------------
'ファイル名から、拡張子のみを除いた部分を取得する
'返される結果には、パス名が含まれる
'--------------------------------------------------------------------
Dim i As Long

    i = Len(strFileName)
    For i = Len(strFileName) To 1 Step -1
        If Mid$(strFileName, i, 1) = "." Then
            'この "." の前までを取り出す
            DeleteFileExt = Left$(strFileName, i - 1)
            Exit Function
        End If
    Next i

    '"." が見つからないので、このファイル名には拡張子がない
    DeleteFileExt = strFileName
End Function

Public Function DeleteFilePath(ByVal strFileName As String) As String
'--------------------------------------------------------------------
'ファイル名から、パス名を除いた部分を取得する
'返される結果には、拡張子も含むが、パスの区切りを示す \ は含まない
'--------------------------------------------------------------------
Dim i As Long

    i = Len(strFileName)
    For i = Len(strFileName) To 1 Step -1
        If Mid$(strFileName, i, 1) = "\" Then
            'この ".\" の後ろを取り出す
            DeleteFilePath = Mid$(strFileName, i + 1)
            Exit Function
        End If
    Next i

    ' \ が見つからないので、このファイル名はパスを含んでいない
    DeleteFilePath = strFileName
End Function

Public Function GetFileExt(ByVal strFileName As String) As String
'--------------------------------------------------------------------
'ファイルの拡張子を取得する
'この拡張子には、先頭の "." を含まない
'--------------------------------------------------------------------

End Function

Public Function GetFilePath(ByVal strFileName As String) As String
'--------------------------------------------------------------------
'ファイルのパスを取得する
'このパス名には、最後の \ を含まない
'--------------------------------------------------------------------

End Function

Public Function GetFileTitle(ByVal strFileName As String) As String
'--------------------------------------------------------------------
'ファイルのタイトル、つまりファイル名から
'パスと拡張子を除いた残りの部分を取得する
'--------------------------------------------------------------------

End Function

Public Function GetFullPathName(ByVal strPathName As String, ByVal strFileName As String) As String
'--------------------------------------------------------------------
'strPathNameを基準とした、相対パスから、フルパスを取得する
'--------------------------------------------------------------------

End Function

Public Function GetRelativePath(ByVal strFileName As String, ByVal strPathName As String) As String
'--------------------------------------------------------------------
'フルパスから、strPathNameを基準とした、相対パスを取得する
'--------------------------------------------------------------------

End Function

Public Function HexToLong(ByVal strHex As String) As Long
'--------------------------------------------------------------------
'文字列として書かれた16進数を整数に変換する
'--------------------------------------------------------------------

End Function

Public Function HexToSingle(ByVal strHex As String) As Single
'--------------------------------------------------------------------
'文字列として書かれた16進数を単精度浮動小数点(Single)に変換する
'--------------------------------------------------------------------

End Function

Public Function MakeHex(ByVal X As Long, ByVal nLen As Long, _
        Optional ByVal chDigit As String = " ") As String
'--------------------------------------------------------------------
'Xを16進数に変換し、余った桁はchDigitで埋めてnLen文字分にする
'--------------------------------------------------------------------

End Function

Public Function ParseString(ByRef lpszText As String, ByVal strSep As String) As String
'--------------------------------------------------------------------
'文字列を解析する
'lpszTextを先頭から走査し、strSepで区切る。
'strSepの手前までを返し、lpszTextをstrSep以降から始まるように調整する
'--------------------------------------------------------------------

End Function

Public Sub Pause(ByVal sngSeconds As Single)
'--------------------------------------------------------------------
'指定した時間だけ待機する
'メッセージは処理する
'--------------------------------------------------------------------

End Sub

Public Function ProcessEscapeSequence(ByVal strText As String) As String
'--------------------------------------------------------------------
'文字列中のエスケープシーケンスを処理する
'--------------------------------------------------------------------

End Function

Public Function ReplaceConstant(ByVal strText As String, ByRef strConstName() As String, ByRef ConstValue() As String) As String
'--------------------------------------------------------------------
'文字列中の定数名に値を代入して返す
'--------------------------------------------------------------------

End Function

Public Function ReplaceSpaceChar(ByVal strText As String, Optional ByVal strChar As String = " ", Optional ByVal blnWideSpace As Boolean = False) As String
'--------------------------------------------------------------------
'文字列の先頭から、空白文字(連続する、半角スペース、タブ)を
'指定された文字列に置き換える。デフォルトでは半角スペースに置き換える
'blnWideSpaceがTrueならば、全角スペースも対象にする
'--------------------------------------------------------------------

End Function

Public Function ReplaceValueToConstantName(
        ByVal strText As String, ByVal strConstValue As String, _
        ByVal strConstName As String, _
        ByVal blnCheckCase As Boolean) As String
'------------------------------------------------------------------------------
'文字列中の特定の文字列を、定数名で置き換える
'CheckCaseがTrueならば、大文字と小文字を異なるものとして扱う
'------------------------------------------------------------------------------

End Function

Public Function SetDefaultText(ByVal strDefaultFile As String) As String
'--------------------------------------------------------------------
'ファイルからデフォルトのテキストを読み込む
'--------------------------------------------------------------------

End Function

Public Function StringToByte(ByVal strText As String, _
        ByRef lpBuf() As Byte,
        ByVal lngStart As Long, ByVal lngEnd As Long, _
        Optional ByVal blnAllocBuffer As Boolean = False) As Long
'--------------------------------------------------------------------
'文字列をバイト列に変換する
'余ったバイトは、0で埋められる
'--------------------------------------------------------------------
Dim i As Long
Dim lpTemp() As Byte
Dim lngTempStart As Long
Dim lngSize As Long

    lpTemp = System.Text.Encoding.GetEncoding("utf8").GetBytes(strText)
    lngTempStart = LBound(lpTemp)
    lngSize = UBound(lpTemp) - lngTempStart + 1

    If blnAllocBuffer Then
        ReDim Preserve lpBuf(lngEnd)
    End If

    If (lngEnd - lngStart + 1) < lngSize Then
        lngSize = lngEnd - lngStart + 1
    End If

    For i = lngStart To lngEnd
        lpBuf(i) = 0
    Next i

    For i = 0 To lngSize - 1
        lpBuf(lngStart + i) = lpTemp(i)
    Next i

    StringToByte = lngSize
End Function

End Module
