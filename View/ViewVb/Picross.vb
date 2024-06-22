Module Picross

'アプリケーション情報
Public gstrAppPath As String

'メインフォーム
' Public gobjfMainForm As frmGame
Public gobjfMainForm As System.Windows.Forms.Form

Public Function LoadGameData(ByRef lpGame As CPicross, ByVal strFileName As String) As Boolean
'------------------------------------------------------------------------------
'ファイルから問題データを読み込む
'ファイルのフォーマットは１行目を見て自動的に識別する
'------------------------------------------------------------------------------

End Function

Public Function LoadGameDataFromIniFile(ByRef lpGame As CPicross, ByVal strFileName As String) As Boolean
'------------------------------------------------------------------------------
'INI 形式のファイルから問題データを読み込む
'------------------------------------------------------------------------------

End Function

Public Function LoadGameDataFromStandardFile(ByRef lpGame As CPicross, ByVal lngFileNumber As Long) As Boolean
'------------------------------------------------------------------------------
'標準形式のファイルから、問題データを読み込む
'------------------------------------------------------------------------------

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
    gstrAppPath = App.Path
    If Right$(gstrAppPath, 1) = "\" Then gstrAppPath = Left$(gstrAppPath, Len(gstrAppPath) - 1)

    'コールバック関数を登録する
    If SetupCallback() = False Then
        MsgBox "Error : Could not setup callback!"
        End
    End If

    'メインフォームを起動する
    gobjfMainForm = New frmGame
    gobjfMainForm.Show

    'コマンドラインを解析する
    If ParseCommandLine(Command$()) = False Then
        MsgBox "アプリケーションの初期化に失敗しました。"
        End
    End If
End Sub

Public Function ParseCommandLine(ByVal strCommandLine As String) As Boolean
'------------------------------------------------------------------------------
'コマンドライン引数を解析する
'------------------------------------------------------------------------------

End Function

Public Function SaveGameStatus(ByRef lpGame As CPicross, ByVal strFileName As String, _
    ByVal nCursorX As Long, ByVal nCursorY As Long) As Boolean
'------------------------------------------------------------------------------
'現在の局面をファイルにセーブする
'------------------------------------------------------------------------------

End Function

End Module
