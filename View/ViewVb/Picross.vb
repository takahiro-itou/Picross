''************************************************************************
''                                                                      ''
''                  ---   View of Picross Solver   ---                  ''
''                                                                      ''
''          Copyright (C), 2024, Takahiro Itou                          ''
''          All Rights Reserved.                                        ''
''                                                                      ''
''          License: (See COPYING and LICENSE files)                    ''
''          GNU Affero General Public License (AGPL) version 3,         ''
''          or (at your option) any later version.                      ''
''                                                                      ''
''************************************************************************

Module Picross

'アプリケーション情報
Public gstrAppPath As String

'メインフォーム
' Public gobjfMainForm As frmGame
Public gobjfMainForm As System.Windows.Forms.Form


Public Function getAppPath() As String
''--------------------------------------------------------------------
''    アプリケーションの実行ディレクトリを取得する。
''--------------------------------------------------------------------
    getAppPath = System.IO.Path.GetDirectoryName(
        System.Reflection.Assembly.GetExecutingAssembly().Location)
End Function


Public Function LoadGameData(
        ByRef lpGame As CPicross,
        ByVal strFileName As String) As Boolean
''--------------------------------------------------------------------
''    ファイルから問題データを読み込む
''
''    ファイルのフォーマットは１行目を見て自動的に識別する
''--------------------------------------------------------------------
Dim FN As Integer
Dim strLine As String
Dim strHeader As String

    FN = FreeFile()
    FileOpen(FN, strFileName, OpenMode.Input, OpenAccess.Read)

    strLine = LineInput(FN)
    strHeader = ParseString(strLine, "=")
    If (strHeader <> "Picross Game Data") Then
        MessageBox.Show(
            "このファイルは読み込めません。" & vbCrLf & _
            "ピクロスの問題データではないか、ファイルが壊れています。" &
            vbCrLf & strFileName)
        LoadGameData = False
        FileClose(FN)
        Exit Function
    End If

    If (strLine = "Standard") Then
        ' 標準形式
        LoadGameData = LoadGameDataFromStandardFile(lpGame, FN)
        FileClose(FN)
        Exit Function
    ElseIf (strLine = "INI") Then
        ' INI 形式
        FileClose(FN)
        LoadGameData = LoadGameDataFromIniFile(lpGame, strFileName)
        Exit Function
    End If

    FileClose(FN)

    ' 読み取り失敗。不明なファイル形式
    MessageBox.Show(
        "不明なファイル形式、又はファイル形式が指定されていません。" &
        vbCrLf & strLine & vbCrLf & strFileName)
    LoadGameData = False
End Function


Public Function LoadGameDataFromIniFile(
        ByRef lpGame As CPicross,
        ByVal strFileName As String) As Boolean
''--------------------------------------------------------------------
''    INI 形式のファイルから問題データを読み込む
''--------------------------------------------------------------------
Dim i As Long, lngLine As Long, lngCount As Long
Dim lngCols As Long, lngRows As Long
Dim strLine As String, strKey As String
Dim lngNumbers(0 To MAX_HINTS_PER_LINE - 1) As Long
Dim lngColors(0 To MAX_HINTS_PER_LINE - 1) As Long

    '問題のサイズを読み取る
    lngCols = GetSettingINI(strFileName, "Head", "Cols", 5)
    lngRows = GetSettingINI(strFileName, "Head", "Rows", 5)

    If lpGame.InitializeGame(0, lngCols, lngRows, 14, 14) = False Then
        LoadGameDataFromIniFile = False
        Exit Function
    End If

    '横方向のヒントデータを読み出す
    For lngLine = 0 To lngRows - 1
        strKey = Trim$(Str$(lngLine))
        strLine = GetSettingINI(strFileName, "Yoko", strKey, "0:")

        lngCount = Val(ParseString(strLine, ":"))
        For i = 0 To MAX_HINTS_PER_LINE - 1
            lngNumbers(i) = Val(ParseString(strLine, ","))
            lngColors(i) = 1
            If (lngNumbers(i) = 0) Then
                lngCount = i
                Exit For
            End If
        Next i
        lpGame.SetYokoHint(lngLine, lngCount, lngNumbers, lngColors)
    Next lngLine

    '縦方向のヒントデータを読み出す
    For lngLine = 0 To lngCols - 1
        strKey = Trim$(Str$(lngLine))
        strLine = GetSettingINI(strFileName, "Tate", strKey, "0:")

        lngCount = Val(ParseString(strLine, ":"))
        For i = 0 To MAX_HINTS_PER_LINE - 1
            lngNumbers(i) = Val(ParseString(strLine, ","))
            lngColors(i) = 1
            If (lngNumbers(i) = 0) Then
                lngCount = i
                Exit For
            End If
        Next i
        lpGame.SetTateHint(lngLine, lngCount, lngNumbers, lngColors)
    Next lngLine

    'ロード完了
    LoadGameDataFromIniFile = True
End Function


Public Function LoadGameDataFromStandardFile(
        ByRef lpGame As CPicross,
        ByVal lngFileNumber As Integer) As Boolean
''--------------------------------------------------------------------
''    標準形式のファイルから、問題データを読み込む
''--------------------------------------------------------------------
Dim i As Long, lngLine As Long, lngCount As Long
Dim lngCols As Long, lngRows As Long
Dim strLine As String, strTemp As String
Dim lngNumbers(0 To MAX_HINTS_PER_LINE - 1) As Long
Dim lngColors(0 To MAX_HINTS_PER_LINE - 1) As Long
Dim lngLineSum As Long, lngLineCheckSum As Long
Dim lngCheckLeftSum As Long, lngCheckTopSum As Long

    '問題のサイズを読み取る
    strLine = readNextLine(lngFileNumber)

    lngCols = Val(ParseString(strLine, " "))
    lngRows = Val(strLine)
    If lpGame.InitializeGame(0, lngCols, lngRows, 14, 14) = False Then
        LoadGameDataFromStandardFile = False
        Exit Function
    End If

    '横方向のヒントデータを読み出す
    lngCheckLeftSum = 0
    For lngLine = 0 To lngRows - 1
        strLine = readNextLine(lngFileNumber)

        lngLineSum = 0
        lngLineCheckSum = 0
        For i = 0 To MAX_HINTS_PER_LINE - 1
            If (Left$(strLine, 1) = "=") Then
                lngLineCheckSum = Val(Mid$(strLine, 2))
            End If

            lngNumbers(i) = Val(ParseString(strLine, " "))
            strLine = Trim$(strLine)

            lngLineSum = lngLineSum + lngNumbers(i)
            If (lngLineSum > lngCols) Then
                MessageBox.Show(
                    "上から" & lngLine + 1 &
                    "行目の、横方向のヒントにエラーがあります。" & vbCrLf &
                    "数値の合計が、フィールドの横幅を超えました。")
                LoadGameDataFromStandardFile = False
                Exit Function
            End If

            lngColors(i) = 1
            If (lngNumbers(i) = 0) Then
                lngCount = i
                Exit For
            End If
        Next i

        If (lngLineSum <> lngLineCheckSum) And (lngLineCheckSum > 0) Then
            MessageBox.Show(
                "上から" & lngLine + 1 &
                "行目の、横方向のヒントにエラーがあります。" & vbCrLf &
                "チェックサムエラーです。" & vbCrLf &
                "記録値 = " & lngLineCheckSum &
                " , 計算値 = " & lngLineSum)
            LoadGameDataFromStandardFile = False
'            Exit Function
        End If
        lngCheckLeftSum = lngCheckLeftSum + lngLineSum
        lpGame.SetYokoHint(lngLine, lngCount, lngNumbers, lngColors)
    Next lngLine

    '縦方向のヒントデータを読み出す
    lngCheckTopSum = 0
    For lngLine = 0 To lngCols - 1
        strLine = readNextLine(lngFileNumber)

        lngLineSum = 0
        lngLineCheckSum = 0
        For i = 0 To MAX_HINTS_PER_LINE - 1
            If (Left$(strLine, 1) = "=") Then
                lngLineCheckSum = Val(Mid$(strLine, 2))
            End If

            lngNumbers(i) = Val(ParseString(strLine, " "))
            strLine = Trim$(strLine)

            lngLineSum = lngLineSum + lngNumbers(i)
            If (lngLineSum > lngRows) Then
                MessageBox.Show(
                    "左から" & lngLine + 1 &
                    "列目の、縦方向のヒントにエラーがあります。" & vbCrLf &
                    "数値の合計が、フィールドの高さを超えました。")
                LoadGameDataFromStandardFile = False
                Exit Function
            End If

            lngColors(i) = 1
            If (lngNumbers(i) = 0) Then
                lngCount = i
                Exit For
            End If
        Next i

        If (lngLineSum <> lngLineCheckSum) And (lngLineCheckSum > 0) Then
            MessageBox.Show(
                "左から" & lngLine + 1 &
                "列目の、縦方向のヒントにエラーがあります。" & vbCrLf &
                "チェックサムエラーです。" & vbCrLf &
                "記録値 = " & lngLineCheckSum &
                " , 計算値 = " & lngLineSum)
'            LoadGameDataFromStandardFile = False
'            Exit Function
        End If
        lngCheckTopSum = lngCheckTopSum + lngLineSum
        lpGame.SetTateHint(lngLine, lngCount, lngNumbers, lngColors)
    Next lngLine

    If (lngCheckLeftSum <> lngCheckTopSum) Then
        MessageBox.Show(
            "この問題は解けません。問題に誤りがあります。" & vbCrLf &
            "横方向のヒント数字の合計と、縦方向のヒント数字の合計が一致しません。" & vbCrLf &
            "横方向の合計=" & lngCheckLeftSum &
            " , 縦方向の合計=" & lngCheckTopSum)
    End If

    'ロード完了
    LoadGameDataFromStandardFile = True
End Function


Public Function LoadGameStatus(ByRef lpGame As CPicross, ByVal strFileName As String, _
    ByRef lpCursorX As Long, ByRef lpCursorY As Long) As Boolean
'------------------------------------------------------------------------------
'ファイルから局面をロードする
'------------------------------------------------------------------------------

End Function

Public Sub Main()
'------------------------------------------------------------------------------
' プログラムのエントリポイント
'------------------------------------------------------------------------------
Dim lngVersion As Long

    'アプリケーション情報を初期化する
    gstrAppPath = getAppPath()
    If Right$(gstrAppPath, 1) = "\" Then gstrAppPath = Left$(gstrAppPath, Len(gstrAppPath) - 1)

    'コールバック関数を登録する
    If SetupCallback() = False Then
        MessageBox.Show("Error : Could not setup callback!")
        End
    End If

    'メインフォームを起動する
    gobjfMainForm = New Form1
    gobjfMainForm.Show

    'コマンドラインを解析する
    If ParseCommandLine(Command$()) = False Then
        MessageBox.Show("アプリケーションの初期化に失敗しました。")
        End
    End If
End Sub

Public Function ParseCommandLine(ByVal strCommandLine As String) As Boolean
'------------------------------------------------------------------------------
'コマンドライン引数を解析する
'------------------------------------------------------------------------------

End Function


Public Function readNextLine(
        ByVal fileNumber As Integer)
''--------------------------------------------------------------------
''    次の空ではない行を読み込む。
''--------------------------------------------------------------------
Dim strLine As String
Dim strTemp As String

    Do Until EOF(fileNumber)
        strTemp = LineInput(fileNumber)
        strLine = Trim$(ParseString(strTemp, "//"))
        If (strLine <> "") Then Exit Do
    Loop

    readNextLine = strLine
End Function


Public Function SaveGameStatus(ByRef lpGame As CPicross, ByVal strFileName As String, _
    ByVal nCursorX As Long, ByVal nCursorY As Long) As Boolean
'------------------------------------------------------------------------------
'現在の局面をファイルにセーブする
'------------------------------------------------------------------------------

End Function

End Module
