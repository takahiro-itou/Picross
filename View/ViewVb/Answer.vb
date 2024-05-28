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
        ByVal nLevel As Ling, _
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

End Function

Public Function SetupCallback() As Boolean
'------------------------------------------------------------------------------
' コールバック関数を登録する
'------------------------------------------------------------------------------

End Function

End Module
