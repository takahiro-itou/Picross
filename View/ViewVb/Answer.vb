Module Answer

Public Const SQUARE_BLANK As Long = &H80&
Public Const SQUARE_ASSUM As Long = &H40&
Public Const SQUARE_CHECK As Long = &H20&
Public Const SQUARE_COLOR As Long = &HF&

Public Const MAX_HINTS_PER_LINE As Long = 64
Public Const MAX_SQUARES_PER_LINE As Long = 256

Public Type tPicrossHint
    nCount As Long
    nNumbers(0 To MAX_HINTS_PER_LINE - 1) As Long
    nColors(0 To MAX_HINTS_PER_LINE - 1) As Long
End Type

Public Type tPicrossLine
    nSquares(0 To MAX_SQUARES_PER_LINE - 1) As Byte
    nBlockIndex(0 To MAX_SQUARES_PER_LINE - 1) As Long
End Type

End Module
