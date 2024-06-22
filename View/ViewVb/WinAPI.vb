''************************************************************************
''                                                                      ''
''                  ---   Picross Solver   View.   ---                  ''
''                                                                      ''
''          Copyright (C), 2024, Takahiro Itou                          ''
''          All Rights Reserved.                                        ''
''                                                                      ''
''          License: (See COPYING and LICENSE files)                    ''
''          GNU Affero General Public License (AGPL) version 3,         ''
''          or (at your option) any later version.                      ''
''                                                                      ''
''************************************************************************

Imports System.Runtime.InteropServices

Module WinAPI

''  設定をファイルから読み込む。
<DllImport("KERNEL32.DLL", CharSet:=CharSet.Auto)>
Public Function GetPrivateProfileString(
        ByVal lpAppName As String,
        ByVal lpKeyName As String,
        ByVal lpDefault As String,
        ByVal lpReturnedString As System.Text.StringBuilder,
        ByVal nSize As Integer,
        ByVal lpFileName As String) As Integer
End Function

''  設定をファイルに保存する。
<DllImport("KERNEL32.DLL")>
Public Function WritePrivateProfileString(
        ByVal lpAppName As String,
        ByVal lpKeyName As String,
        ByVal lpString As String,
        ByVal lpFileName As String) As Integer
End Function

Public Const SRCAND As Integer = &H8800C6
Public Const SRCCOPY As Integer = &HCC0020
Public Const SRCPAINT As Integer = &HEE0086

<DllImport("gdi32.dll")> _
Public Function BitBlt(ByVal hDestDC As IntPtr, _
        ByVal X As Integer, ByVal Y As Integer, _
        ByVal nWidth As Integer, ByVal nHeight As Integer, _
        ByVal hSrcDC As IntPtr, _
        ByVal xSrc As Integer, ByVal ySrc As Integer, _
        ByVal dwRop As Integer) As Integer
End Function

<DllImport("gdi32.dll")> _
Public Function CreateCompatibleDC(ByVal hDC As IntPtr) As IntPtr
End Function

<DllImport("gdi32.dll")> _
Public Function DeleteDC(ByVal hDC As IntPtr) As Integer
End Function


<DllImport("user32.dll")> _
Public Function GetDC(ByVal hWnd As IntPtr) As IntPtr
End Function

<DllImport("user32.dll")> _
Public Function ReleaseDC(ByVal hWnd As IntPtr, _
    ByVal hDC As IntPtr) As IntPtr
End Function


End Module
