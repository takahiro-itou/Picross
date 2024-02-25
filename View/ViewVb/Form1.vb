Public Class Form1

    Private Sub RunCount(ByVal message As String)
        Dim result As Integer
        Dim objWrapper As SampleWrapper.Common.SampleDocument = New SampleWrapper.Common.SampleDocument()

        objWrapper.setMessage(message)
        result = objWrapper.countAlphabet()
        MsgBox("入力した文字列中のアルファベットの個数は " & result, MsgBoxStyle.OkOnly)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RunCount(TextBox1.Text)
    End Sub

    Private Sub CountToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CountToolStripMenuItem.Click
        RunCount(TextBox1.Text)
    End Sub
End Class
