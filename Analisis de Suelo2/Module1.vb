Imports System.Data.SqlClient
Module Module1
    Public conexion As New SqlConnection("Data Source=SETA77\SQLEXPRESS;Initial Catalog=DB_SUELO;Integrated Security=True")

    Public Sub conectar()
        Try
            conexion.Open()
            'MsgBox("Conectado")
        Catch ex As Exception
            MsgBox(ex.ToString)
            'MsgBox("!Su conexion se encuentra abeirta", MsgBoxStyle.Information, "!Open conection")
        End Try
    End Sub
    Public Sub desconectar()
        conexion.Close()
    End Sub
End Module
