Public Class Presentacion

    Private Sub Presentacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        Me.BackColor = Color.White
        Me.TransparencyKey = Color.White
        Me.StartPosition = FormStartPosition.CenterScreen

        Label1.BackColor = Color.Blue
        Label1.ForeColor = Color.White
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Hide()
        INICIO.Show()
        Timer1.Stop()
    End Sub
End Class