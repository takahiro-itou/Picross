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

End Module
