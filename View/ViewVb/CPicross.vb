Public Class CPicross

'ゲームID
Private mlngGameID As Long

'背理法モード
Private mlngTestModeLevel As Long

'フィールド
Private mlngFieldCols As Long
Private mlngFieldRows As Long
Private mlngSquares() As Long

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

End Class
