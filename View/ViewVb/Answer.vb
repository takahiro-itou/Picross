Module Answer

Public Const SQUARE_BLANK As Long = &H80&
Public Const SQUARE_ASSUM As Long = &H40&
Public Const SQUARE_CHECK As Long = &H20&
Public Const SQUARE_COLOR As Long = &HF&

Public Const MAX_HINTS_PER_LINE As Long = 64
Public Const MAX_SQUARES_PER_LINE As Long = 256

Public Structure tPicrossHint
    Public nCount As Long
    Public nNumbers() As Integer    '(0 To MAX_HINTS_PER_LINE - 1) As Long
    Public nColors() As Integer     '(0 To MAX_HINTS_PER_LINE - 1) As Long
End Structure

Public Structure tPicrossLine
    Public nSquares() As Byte       '(0 To MAX_SQUARES_PER_LINE - 1) As Byte
    Public nBlockIndex() As Integer '(0 To MAX_SQUARES_PER_LINE - 1) As Long
End Structure

Public Const MINLEVEL As Long = 1
Public Const MAXLEVEL As Long = 2

Public glngMinLevel As Long
Public glngMaxLevel As Long

Public Const PROGRESS_START As Long = 0
Public Const PROGRESS_CREATE As Long = 1
Public Const PROGRESS_PROCEED As Long = 2
Public Const PROGRESS_END As Long = 3

' Public gobjfProgress As frmProgress
Public gobjfProgress As System.Windows.Forms.Form
Public gblnCancel As Boolean
Public glngShowIntervals As Long
Public glngNextShowFrame As Long

Public gstrCurrentCursorType As String
Public glngCurrentCursorPos As Long
Public glngCurrentPatterns As Long
Public glngLastLinePatterns As Long

Public glngStartProgressCurrent As Long
Public glngStartProgressTasks As Long
Public glngProceedProgressCurrent As Long
Public glngProceedProgressTasks As Long
Public glngEndProgressCurrent As Long
Public glngEndProgressTasks As Long

Public Delegate Function ShowingProgressDelegate( _
        ByVal nLevel As Long, _
        ByVal nProgress As Long, _
        ByRef lpTest As tPicrossLine, ByRef lpCurrent As tPicrossLine, _
        ByVal nCurrent As Long, ByVal nTasks As Long) As Long

Public Function FuncShowingProgress(ByVal nLevel As Long, _
        ByVal nProgress As Long, _
        ByRef lpTest As tPicrossLine, ByRef lpCurrent As tPicrossLine, _
        ByVal nCurrent As Long, ByVal nTasks As Long) As Long
'------------------------------------------------------------------------------
' 現在の進行状況を報告する機会を与えられるコールバック関数
'------------------------------------------------------------------------------
Dim strCaption As String
Dim strInfo As String

    Application.DoEvents()
    If gobjfProgress Is Nothing Then
        gobjfProgress = New System.Windows.Forms.Form()
        gobjfProgress.Show
        ' @todo
        ' gobjfMainForm.SetFocus
    End If

    If (gblnCancel) Then
        FuncShowingProgress = 0
        Exit Function
    End If

    Select Case nProgress
        Case PROGRESS_START:
            glngStartProgressCurrent = nCurrent
            glngStartProgressTasks = nTasks
        Case PROGRESS_CREATE, PROGRESS_PROCEED:
            glngProceedProgressCurrent = nCurrent
            glngProceedProgressTasks = nTasks
        Case PROGRESS_END:
            glngEndProgressCurrent = nCurrent
            glngEndProgressTasks = nTasks
            glngNextShowFrame = 0
    End Select

    If (glngNextShowFrame <= 0) Then
        strCaption = "ゲーム [自動解答中] [Lv:" & nLevel & "] " & _
            gstrCurrentCursorType & glngCurrentCursorPos

        strInfo = "開始時の状態:" & vbCrLf
        strInfo = strInfo & "(" & glngStartProgressCurrent & "/" & glngStartProgressTasks & ")"

        strInfo = strInfo & vbCrLf & "現在の状態:" & vbCrLf
        strInfo = strInfo & "調べたパターン=" & Format$(glngCurrentPatterns, "#,##0") & _
            vbCrLf & "(" & nCurrent & "/" & nTasks & ")"
        strInfo = strInfo & vbCrLf & "一つ前の列または行の結果：" & vbCrLf & _
            "調べたパターン=" & Format$(glngLastLinePatterns, "#,##0") & vbCrLf & _
            "(" & glngEndProgressCurrent & "/" & glngEndProgressTasks & ")"
        ' @todo
        ' gobjfProgress.lblInfo.Caption = strCaption & vbCrLf & strInfo
        ' @todo
        ' gobjfMainForm.Caption = strCaption
        glngNextShowFrame = glngNextShowFrame + glngShowIntervals
    End If

    glngCurrentPatterns = glngCurrentPatterns + 1
    glngNextShowFrame = glngNextShowFrame - 1

    If (glngCurrentPatterns >= &H40000000) Then glngCurrentPatterns = 0
    Application.DoEvents()

    FuncShowingProgress = 1
End Function

Public Function SetupCallback() As Boolean
'------------------------------------------------------------------------------
' コールバック関数を登録する
'------------------------------------------------------------------------------
Dim lngResult As Long

    glngCurrentPatterns = 0
    lngResult = setCallbackShowingProgress(AddressOf FuncShowingProgress)
    SetupCallback = True
End Function

''============================================================================
''
''  従来はライブラリに定義されていた関数のスタブ
''

Public Function setCallbackShowingProgress( _
        ByVal lpfnCallback As ShowingProgressDelegate) As Long
'------------------------------------------------------------------------------
' 進捗表示を行うコールバック関数を設定する
'------------------------------------------------------------------------------
    setCallbackShowingProgress = 0
End Function

Public Function stepLineLv1 ( _
        ByVal nLength As Long, ByRef lpcInput As tPicrossHint, _
        ByRef lpcFixed As tPicrossLine, _
        ByRef lpResult As tPicrossLine) As Long

End Function

Public Function stepLineLv2 ( _
        ByVal nLength As Long, ByRef lpcInput As tPicrossHint, _
        ByRef lpcFixed As tPicrossLine, _
        ByRef lpResult As tPicrossLine) As Long

End Function

End Module
