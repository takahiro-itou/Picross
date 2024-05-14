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
Dim i As Long

    i = Len(strFileName)
    For i = Len(strFileName) To 1 Step -1
        If Mid$(strFileName, i, 1) = "." Then
            'この "." の後ろを取り出す
            GetFileExt = Mid$(strFileName, i + 1)
            Exit Function
        End If
    Next i

    '. が見つからないので、このファイル名には拡張子がない
    GetFileExt = ""
End Function

Public Function GetFilePath(ByVal strFileName As String) As String
'--------------------------------------------------------------------
'ファイルのパスを取得する
'このパス名には、最後の \ を含まない
'--------------------------------------------------------------------
Dim i As Long

    i = Len(strFileName)
    For i = Len(strFileName) To 1 Step -1
        If Mid$(strFileName, i, 1) = "\" Then
            ' この "\"  の前までを取り出す
            GetFilePath = Left$(strFileName, i - 1)
            Exit Function
        End If
    Next i

    ' \ が見つからないので、このファイル名はパスを含んでいない
    GetFilePath = ""
End Function

Public Function GetFileTitle(ByVal strFileName As String) As String
'--------------------------------------------------------------------
'ファイルのタイトル、つまりファイル名から
'パスと拡張子を除いた残りの部分を取得する
'--------------------------------------------------------------------
Dim strTemp As String

    'ファイル名からパス名を除く
    strTemp = DeleteFilePath(strFileName)

    'さらに拡張子も除く
    GetFileTitle = DeleteFileExt(strTemp)
End Function

Public Function GetFullPathName(ByVal strPathName As String, _
        ByVal strFileName As String) As String
'--------------------------------------------------------------------
'strPathNameを基準とした、相対パスから、フルパスを取得する
'--------------------------------------------------------------------
Dim i As Long
Dim lngPos As Long
Dim strTemp As String
Dim strLeft As String

    strTemp = strPathName

    Do While Len(strFileName) > 0
        Application.DoEvents()
        lngPos = InStr(strFileName, "\")
        If (lngPos = 0) Then
            ' ディレクトリ指定がもうないので、ファイル名を最後にくっつける
            strTemp = strTemp & "\" & strFileName
            strFileName = ""
        Else
            strLeft = Left$(strFileName, lngPos)
            strFileName = Mid$(strFileName, lngPos + 1)
            If (strLeft = ".\") Then
                '現在のディレクトリ
            ElseIf (strLeft = "..\") Then
               '親ディレクトリに移動
                strTemp = DeleteFilePath(strTemp)
            Else
                '指定されたディレクトリに移動
                strTemp = strTemp & "\" & strLeft
            End If
        End If
    Loop

    GetFullPathName = strTemp
End Function

Public Function GetRelativePath(ByVal strFileName As String, _
        ByVal strPathName As String) As String
'--------------------------------------------------------------------
'フルパスから、strPathNameを基準とした、相対パスを取得する
'--------------------------------------------------------------------
Dim lngPos As Long
Dim strTemp As String
Dim strPathTemp As String
Dim strNameTemp As String

    If strPathName = "" Then
        GetRelativePath = strFileName
    End If

    strTemp = ""

    lngPos = 0
    Do While lngPos = 0
        strPathTemp = LCase$(strPathName)
        strNameTemp = LCase$(strFileName)
        lngPos = InStr(strNameTemp, strPathTemp)
        If lngPos = 0 Then
            strPathName = DeleteFilePath(strPathName)
            strTemp = strTemp & "..\"
        Else
            strTemp = strTemp & Mid$(strFileName, Len(strPathName) + 2)
        End If
    Loop

    GetRelativePath = strTemp
End Function

Public Function HexToLong(ByVal strHex As String) As Long
'--------------------------------------------------------------------
'文字列として書かれた16進数を整数に変換する
'--------------------------------------------------------------------

    If (Left$(strHex, 2) <> "&H") Or (Left$(strHex, 2) <> "0x") Then
        strHex = "&H" & strHex & "&"
    ElseIf (Left$(strHex, 2) = "0x") Then
        strHex = "&H" & Mid$(strHex, 3) & "&"
    End If

    HexToLong = CLng(Val(strHex))
End Function

Public Function HexToSingle(ByVal strHex As String) As Single
'--------------------------------------------------------------------
'文字列として書かれた16進数を単精度浮動小数点(Single)に変換する
'--------------------------------------------------------------------
Dim lngSgn As Long      '符号(Bit 0)
Dim lngExp As Long      '指数(Bit 1-8)
Dim sngMan As Single    '仮数(Bit 9-31)
Dim i As Long
Dim lngTemp As Long
Dim lngBase As Long

    If (Left$(strHex, 2) = "&H") Or (Left$(strHex, 2) = "0x") Then
        strHex = Mid$(strHex, 3)
    End If
    If (Right$(strHex, 1) = "&") Then
        strHex = Left$(strHex, Len(strHex) - 1)
    End If

    '不足している桁があれば、後ろに補う
    strHex = Left$(strHex & "00000000", 8)

    '各パートに変換する
    lngTemp = Val(strHex)
    If (lngTemp And &H80000000) Then
        lngSgn = -1
    Else
        lngSgn = 1
    End If

    lngExp = lngTemp \ &H800000

    lngBase = 1
    sngMan = 0
    For i = 0 To 22
        If (lngTemp And lngBase) Then
            sngMan = sngMan + 1
        End If
        sngMan = sngMan / 2
        lngBase = lngBase * 2
    Next i
    sngMan = sngMan + 1

    HexToSingle = lngSgn * (sngMan * 2 ^ (lngExp))
End Function

Public Function MakeHex(ByVal X As Long, ByVal nLen As Long, _
        Optional ByVal chDigit As Char = " "c) As String
'--------------------------------------------------------------------
'Xを16進数に変換し、余った桁はchDigitで埋めてnLen文字分にする
'--------------------------------------------------------------------
Dim repeatedString As New String(chDigit, nLen)

    MakeHex = Right$(repeatedString & Hex$(X), nLen)
End Function

Public Function ParseString(ByRef lpszText As String, _
        ByVal strSep As String) As String
'--------------------------------------------------------------------
'文字列を解析する
'lpszTextを先頭から走査し、strSepで区切る。
'strSepの手前までを返し、lpszTextをstrSep以降から始まるように調整する
'--------------------------------------------------------------------
Dim lngPos As Long

    lngPos = InStr(lpszText, strSep)
    If lngPos = 0 Then
        '区切り記号 strSep が見つからない
        ParseString = lpszText
        lpszText = ""
    ElseIf lngPos = 1 Then
        '先頭に区切り記号 strSep がある
        ParseString = ""
        lpszText = Mid$(lpszText, Len(strSep) + 1)
    Else
        '区切り記号 strSep の前後に分解する
        ParseString = Left$(lpszText, lngPos - 1)
        lpszText = Mid$(lpszText, lngPos + Len(strSep))
    End If
End Function

Public Sub Pause(ByVal sngSeconds As Single)
'--------------------------------------------------------------------
'指定した時間だけ待機する
'メッセージは処理する
'--------------------------------------------------------------------
Dim sngStartTime As Single
Dim sngEndTime As Single

    sngStartTime = Timer
    sngEndTime = sngStartTime + sngSeconds
    Do While (sngEndTime >= Timer)
        If (Timer < sngStartTime) Then Exit Do
        DoEvents
    Loop
End Sub

Public Function ProcessEscapeSequence(ByVal strText As String) As String
'--------------------------------------------------------------------
'文字列中のエスケープシーケンスを処理する
'--------------------------------------------------------------------
Dim strEscape(0 To 3) As String
Dim strChar(0 To 3) As String

    strEscape(0) = "\0": strChar(0) = vbNullChar
    strEscape(1) = "\r": strChar(1) = vbCr
    strEscape(2) = "\n": strChar(2) = vbLf
    strEscape(3) = "\t": strChar(3) = vbTab

    ProcessEscapeSequence = ReplaceConstant(strText, strEscape, strChar)
End Function

Public Function ReplaceConstant(ByVal strText As String, ByRef strConstName() As String, ByRef ConstValue() As String) As String
'--------------------------------------------------------------------
'文字列中の定数名に値を代入して返す
'--------------------------------------------------------------------
Dim i As Long
Dim lngPos As Long
Dim strTemp As String
Dim strName As String
Dim strValue As String

    strTemp = strText
    For i = LBound(strConstName) To UBound(strConstName)
        '定数名と値
        strName = strConstName(i)

        If i > UBound(ConstValue) Then
            strValue = ""
        ElseIf IsNumeric(ConstValue(i)) Then
            strValue = Trim$(Str$(ConstValue(i)))
        Else
            strValue = ConstValue(i)
        End If

        'すべて置換する
        Do While True
            lngPos = InStr(strTemp, strName)
            If (lngPos = 0) Or (Len(strTemp) = 0) Or (strValue = "") Then Exit Do
            If (lngPos = 1) Then
                strTemp = strValue & Mid$(strTemp, 1 + Len(strName))
            Else
                strTemp = Left$(strTemp, lngPos - 1) & strValue & Mid$(strTemp, lngPos + Len(strName))
            End If
        Loop
    Next i

    '置換した文字列を返す
    ReplaceConstant = strTemp
End Function

Public Function ReplaceSpaceChar(ByVal strText As String, Optional ByVal strChar As String = " ", Optional ByVal blnWideSpace As Boolean = False) As String
'--------------------------------------------------------------------
'文字列の先頭から、空白文字(連続する、半角スペース、タブ)を
'指定された文字列に置き換える。デフォルトでは半角スペースに置き換える
'blnWideSpaceがTrueならば、全角スペースも対象にする
'--------------------------------------------------------------------
Dim i As Long, L As Long
Dim blnFlag As Boolean
Dim strTemp As String
Dim strHead As String

    blnFlag = False
    strTemp = ""
    L = Len(strText)
    For i = 1 To L
        strHead = Mid$(strText, i, 1)
        If (strHead = " ") Or (strHead = vbTab) Then
            If blnFlag = False Then
                '指定された文字列に置き換える
                strTemp = strTemp & strChar
            End If
            blnFlag = True
        ElseIf (blnWideSpace = True) And (strHead = "　") Then
            '全角スペースも対象にする
            If blnFlag = False Then
                '指定された文字列に置き換える
                strTemp = strTemp & strChar
            End If
            blnFlag = True
        Else
            '空白以外の文字は、そのまま転送する
            strTemp = strTemp & strHead
            blnFlag = False
        End If
    Next i

    ReplaceSpaceChar = strTemp
End Function

Public Function ReplaceValueToConstantName(
        ByVal strText As String, ByVal strConstValue As String, _
        ByVal strConstName As String, _
        ByVal blnCheckCase As Boolean) As String
'------------------------------------------------------------------------------
'文字列中の特定の文字列を、定数名で置き換える
'CheckCaseがTrueならば、大文字と小文字を異なるものとして扱う
'------------------------------------------------------------------------------
Dim lngPos As Long
Dim strValue As String
Dim strTemp As String

    If blnCheckCase Then
        strTemp = strText
        strValue = strConstValue
    Else
        strTemp = UCase$(strText)
        strValue = UCase$(strConstValue)
    End If

    Do
        '文字列中から、定数名で置き換わる値を検索する
        lngPos = InStr(strTemp, strValue)
        If lngPos > 1 Then
            strTemp = Left$(strTemp, lngPos - 1) & strConstName & Mid$(strTemp, lngPos + Len(strValue))
        ElseIf lngPos = 1 Then
            strTemp = strConstName & Mid$(strTemp, 1 + Len(strValue))
        End If
    Loop Until lngPos = 0

    ReplaceValueToConstantName = strTemp
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
