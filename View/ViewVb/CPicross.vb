Public Class CPicross

'ゲームID
Private mlngGameID As Long

'背理法モード
Private mlngTestModeLevel As Long

'フィールド
Private mlngFieldCols As Long
Private mlngFieldRows As Long
Private mlngSquares(,) As Long

'ヒントデータ
Private mutTateHints() As tPicrossHint       '縦方向のヒント
Private mutYokoHints() As tPicrossHint       '横方向のヒント

'もっとも長いヒントデータ
Private mlngMaxTateHintsLength As Long
Private mlngMaxYokoHintsLength As Long

Private mlngRestSquares As Long

Private Const mlngFieldLeftMargin As Long = 2
Private Const mlngFieldTopMargin As Long = 2
Private mlngSquareWidth As Long
Private mlngSquareHeight As Long

'ヒントを表示するのに必要な領域
Private mlngHintAreaWidth As Long
Private mlngHintAreaHeight As Long

Public Function AutoAnswerOneCol(ByVal nCol As Long, _
        ByVal nLevel As Long, ByVal bMsg As Boolean) As Boolean
'------------------------------------------------------------------------------
' 指定された(縦方向の)列の解答をする
'------------------------------------------------------------------------------
Dim Y As Long, lngResult As Long
Dim utCurrent As tPicrossLine
Dim utResult As tPicrossLine
Dim lngCount As Long

    'パターン数を計算する
    lngCount = 0
    With mutTateHints(nCol)
        For Y = 0 To .nCount - 1
            lngCount = lngCount + .nNumbers(Y)
        Next Y
        lngCount = lngCount + (.nCount - 1)
        lngCount = mlngFieldRows - lngCount

        glngNextShowFrame = 0
        gstrCurrentCursorType = "現在の列 = "
        glngCurrentCursorPos = nCol
        glngLastLinePatterns = glngCurrentPatterns
        glngCurrentPatterns = 0
    End With

    '指定された列のデータを収集する
    With utCurrent
        For Y = 0 To mlngFieldRows - 1
            .nSquares(Y) = mlngSquares(nCol, Y)
            If .nSquares(Y) = 0 Then .nSquares(Y) = SQUARE_BLANK
        Next Y
    End With

    Select Case nLevel
        Case 1:
            lngResult = stepLineLv1(mlngFieldRows, mutTateHints(nCol), utCurrent, utResult)
        Case Else:
            lngResult = stepLineLv2(mlngFieldRows, mutTateHints(nCol), utCurrent, utResult)
    End Select

    If (lngResult < 0) Then
        If (bMsg) Then
            MessageBox.Show(
                "エラーが発生しました。問題と現在の局面を確かめてください。")
        End If
        AutoAnswerOneCol = False
        Exit Function
    End If

    '結果を転送する
    With utResult
        For Y = 0 To mlngFieldRows - 1
            If (.nSquares(Y) = SQUARE_BLANK) Then .nSquares(Y) = 0
            If (mlngSquares(nCol, Y) = 0) And (.nSquares(Y) <> 0) Then
                mlngRestSquares = mlngRestSquares - 1
            End If
            mlngSquares(nCol, Y) = .nSquares(Y)
        Next Y
    End With

    '正常終了
    AutoAnswerOneCol = True
End Function

Public Function AutoAnswerOneRow(ByVal nRow As Long, _
    ByVal nLevel As Long, ByVal bMsg As Boolean) As Boolean
'------------------------------------------------------------------------------
'指定された(横方向の)行の解答をする
'------------------------------------------------------------------------------
Dim X As Long, lngResult As Long
Dim utCurrent As tPicrossLine
Dim utResult As tPicrossLine
Dim lngCount As Long

    'パターン数を計算する
    lngCount = 0
    With mutYokoHints(nRow)
        For X = 0 To .nCount - 1
            lngCount = lngCount + .nNumbers(X)
        Next X
        lngCount = lngCount + (.nCount - 1)
        lngCount = mlngFieldCols - lngCount

        glngNextShowFrame = 0
        gstrCurrentCursorType = "現在の行 = "
        glngCurrentCursorPos = nRow
        glngLastLinePatterns = glngCurrentPatterns
        glngCurrentPatterns = 0
    End With

    '指定された行のデータを収集する
    With utCurrent
        For X = 0 To mlngFieldCols - 1
            .nSquares(X) = mlngSquares(X, nRow)
        Next X
    End With

    Select Case nLevel
        Case 1:
            lngResult = stepLineLv1(mlngFieldCols, mutYokoHints(nRow), utCurrent, utResult)
        Case Else:
            lngResult = stepLineLv2(mlngFieldCols, mutYokoHints(nRow), utCurrent, utResult)
    End Select

    If (lngResult < 0) Then
        If (bMsg) Then MsgBox "エラーが発生しました。問題と現在の局面を確かめてください。"
        AutoAnswerOneRow = False
        Exit Function
    End If

    '結果を転送する
    With utResult
        For X = 0 To mlngFieldCols - 1
            If (.nSquares(X) = SQUARE_BLANK) Then .nSquares(X) = 0
            If (mlngSquares(X, nRow) = 0) And (.nSquares(X) <> 0) Then
                mlngRestSquares = mlngRestSquares - 1
            End If
            mlngSquares(X, nRow) = .nSquares(X)
        Next X
    End With

    '正常終了
    AutoAnswerOneRow = True
End Function

Public Function ChangeSquare( _
        ByVal nCol As Long, ByVal nRow As Long, _
        ByVal nState As Long) As Long
'------------------------------------------------------------------------------
' 指定されたピクチャーボックスに、カーソルを表示する
' bNoHintsをTrue にするとヒントを表示する為の領域を空けない
'------------------------------------------------------------------------------
Dim lngPrev As Long

    lngPrev = mlngSquares(nCol, nRow)
    If (lngPrev And SQUARE_BLANK) Then lngPrev = 0

    If (nState And SQUARE_BLANK) Then nState = 0

    If (nState = 0) Then
        mlngSquares(nCol, nRow) = 0
        If (lngPrev <> 0) Then mlngRestSquares = mlngRestSquares + 1
    Else
        mlngSquares(nCol, nRow) = (nState And &H2F&)
        If (lngPrev = 0) Then mlngRestSquares = mlngRestSquares - 1
    End If

    ChangeSquare = mlngRestSquares
End Function

Public Function DrawCursor(ByRef lpTarget As PictureBox, _
    ByVal nCol As Long, ByVal nRow As Long, ByVal bNoHints As Boolean) As Boolean
'------------------------------------------------------------------------------
'指定されたピクチャーボックスに、カーソルを表示する
'bNoHintsをTrue にするとヒントを表示する為の領域を空けない
'------------------------------------------------------------------------------

End Function

Public Function DrawGameField(ByRef lpTarget As PictureBox, ByVal nMargin As Long, _
    ByVal bNoCheckMarks As Boolean, ByVal bNoHints As Boolean, _
    ByVal nLeftCol As Long, ByVal nTopRow As Long, _
    ByVal nShowCols As Long, ByVal nShowRows As Long) As Boolean
'------------------------------------------------------------------------------
'指定されたピクチャーボックスに、現在の局面を表示する
'bNoHintsをTrue にするとヒントを表示する為の領域を空けない
'------------------------------------------------------------------------------

End Function

Public Function DrawHintNumbers(ByRef lpTarget As PictureBox) As Boolean
'------------------------------------------------------------------------------
'指定されたピクチャーボックスに、ヒント数字を描画する
'------------------------------------------------------------------------------

End Function

Public Function EnterTestMode(ByVal nCursorX As Long, ByVal nCursorY As Long) As Long
'------------------------------------------------------------------------------
'テストモード（背理法モード）に入る
'------------------------------------------------------------------------------

End Function

Public Function ExitTestMode(ByVal bFlagSet As Boolean, ByRef lpCursorX As Long, ByRef lpCursorY As Long) As Long
'------------------------------------------------------------------------------
'テストモード（背理法モード）から抜ける
'------------------------------------------------------------------------------

End Function

Public Function GetScreenHeight() As Long
'------------------------------------------------------------------------------
'フィールドを表示するのに最低限必要な高さを取得する
'------------------------------------------------------------------------------

End Function

Public Function GetScreenWidth() As Long
'------------------------------------------------------------------------------
'フィールドを表示するのに最低限必要な幅を取得する
'------------------------------------------------------------------------------

End Function

Public Function InitializeGame(ByVal nGameID As Long, ByVal nCols As Long, ByVal nRows As Long, _
    ByVal nSquareWidth As Long, ByVal nSquareHeight As Long) As Boolean
'------------------------------------------------------------------------------
'ゲームを初期化する
'------------------------------------------------------------------------------

End Function

Public Function PicrossLoadStatus(ByVal lngFileNumber As Long, ByVal lngStartOffset As Long) As Boolean
'------------------------------------------------------------------------------
'ファイルから情報を読み取って、保存されている状態を復元する
'------------------------------------------------------------------------------

End Function

Public Function PicrossSaveStatus(ByVal lngFileNumber As Long, ByVal lngStartOffset As Long) As Boolean
'------------------------------------------------------------------------------
'ファイルに現在の状態に復元するのに必要なすべての情報を保存する
'------------------------------------------------------------------------------

End Function

Public Sub SetTateHint(ByVal X As Long, ByVal nLength As Long, ByRef lpNumbers() As Long, ByRef lpColors() As Long)
'------------------------------------------------------------------------------
'指定した列の、縦方向のヒントをセットする
'------------------------------------------------------------------------------

End Sub

Public Sub SetYokoHint(ByVal Y As Long, ByVal nLength As Long, ByRef lpNumbers() As Long, ByRef lpColors() As Long)
'------------------------------------------------------------------------------
'指定した行の、横方向のヒントをセットする
'------------------------------------------------------------------------------

End Sub

End Class
