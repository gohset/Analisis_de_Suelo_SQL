Imports System.Data.SqlClient
Public Class INICIO
    Dim cmd As SqlCommand
    Dim adaptador As New SqlDataAdapter
    Dim registro As New DataSet
    Dim consulta As String
    Dim lista As Byte
    Dim respuesta As Byte

    Dim neliminado, codeliminado As Integer
    'Dim n1 = 1
    'Dim n2 = 0
    '-----------------------------------------------------
    Dim n1, n2, n3, n4
    '-----------------------------------------------------
    Dim plantas = 1111
    Dim a, urea, sft, mk, t1, t2, t3 As Integer
    Dim ureav = 46
    Dim sftv = 36
    Dim mkv = 46
    Dim area As Integer    '1 Hectaria=10.000 m2---> 1111 plantas

    '--------------------- ARRASTRAR OBJETO -----------------------
    Dim movimiento1 As Boolean
    Dim primovi1 As Boolean = False
    Dim posicionX1 = 0
    Dim posicionY1 = 0
    '--------------------------------------------------------------
    '------------------- VARIABLE ALEATORIO -----------------------
    Dim a1, a2, a3 As Integer

    Private Sub INICIO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        conectar()
        txtfecha.Text = Date.Now.Date
        btnatras3.Visible = False
        '----------------------------------------------
        GroupBox15.Parent = PictureBox1
        GroupBox15.BackColor = Color.Transparent
        '----------------------------------------------
        color_etiquetas()
        color_eti_analisis()

        oculto_label()
        transparencia_labels()
        Label78.Visible = False
        Label79.Visible = False
        '----------------------------------------------
        P_cultivo.Visible = False
        P_canton.Visible = False
        P_provincia.Visible = False
        '----------------------------------------------
        GroupBox4.Visible = False
        GroupBox6.Visible = False
        GroupBox7.Visible = False
        '----------------------------------------------


        Me.WindowState = FormWindowState.Maximized
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        GroupBox1.Parent = PictureBox1
        GroupBox1.BackColor = Color.Transparent

        Panel_posicion.Visible = False
        Panel_posicion.BackColor = Color.Lime
        Label2.ForeColor = Color.White
        '----------------------------------------------------
        Canton.Parent = PictureBox1
        Panel_analisis.Parent = PictureBox1
        Provincia.Parent = PictureBox1

        Canton.BackColor = Color.Transparent
        Provincia.BackColor = Color.Transparent
        Panel_analisis.BackColor = Color.Transparent
        '-----------------------------------------------------
        P_canton.Parent = PictureBox1
        P_provincia.Parent = PictureBox1
        P_cultivo.Parent = PictureBox1

        P_canton.BackColor = Color.Transparent
        P_provincia.BackColor = Color.Transparent
        P_cultivo.BackColor = Color.Transparent
        '-----------------------------------------------------
        ' Canton.BackColor = Color.DarkSlateGray
        Label1.ForeColor = Color.White
        Label1.BackColor = Color.Transparent
        lbl_provincia.ForeColor = Color.White
        lbl_provincia.BackColor = Color.Transparent
        '-----------------------------------------------------
        Panel_atras1.Parent = PictureBox1
        Panel_atras2.Parent = PictureBox1
        Panel_atras1.BackColor = Color.Transparent
        Panel_atras2.BackColor = Color.Transparent

        Panel_guardar.Parent = GroupBox1
        Panel_cerrar.Parent = GroupBox1
        Panel_eliminar.Parent = GroupBox1
        Panel_actualizar.Parent = GroupBox1
        Panel_conton.Parent = GroupBox1
        Panel_provincia.Parent = GroupBox1
        Panel_cancelar.Parent = GroupBox1
        Panel_buscar.Parent = GroupBox1
        Panel_opciones.Parent = GroupBox1
        Panel_ayuda.Parent = GroupBox1

        Panel_guardar.BackColor = Color.Transparent
        Panel_cerrar.BackColor = Color.Transparent
        Panel_eliminar.BackColor = Color.Transparent
        Panel_actualizar.BackColor = Color.Transparent
        Panel_conton.BackColor = Color.Transparent
        Panel_provincia.BackColor = Color.Transparent
        Panel_cancelar.BackColor = Color.Transparent
        Panel_buscar.BackColor = Color.Transparent
        Panel_opciones.BackColor = Color.Transparent
        Panel_ayuda.BackColor = Color.Transparent
        '-----------------------------------------------------
        txtnombre_c.Text = "Ingrese el Cantón"
        txtnombre_p.Text = "Ingrese la Provincia"

        txtnombre.Text = "Ingrese el Cultivo"
        txtnombre.ForeColor = Color.Silver
        '-----------------------------------------------------
        '           ----------ANÁLISIS ---------------
        '-----------------------------------------------------
        llenar_canton()
        llenar_cultivo()
        llenar_provincia()

        lbltfranca.Visible = False
        lbltfranca.ForeColor = Color.White
        pictbtierrafranca.Visible = False
        lbldetalles.ForeColor = Color.White

        lblanalisar.Visible = False
        P_analisis.Parent = PictureBox1
        P_analisis.BackColor = Color.Transparent

        P_analisis.Visible = False
        GroupBox8.Visible = False
        GroupBox14.Visible = False
        P_analisis.Location = New Point(365, 249)
        '-----------------------------------------------------
        Panel_configuracion.Visible = False
    End Sub

    Sub color_etiquetas()
        Label13.ForeColor = Color.White
        Label14.ForeColor = Color.White
        Label15.ForeColor = Color.White
        Label17.ForeColor = Color.White
        Label18.ForeColor = Color.White
        Label19.ForeColor = Color.White
        Label20.ForeColor = Color.White
        Label21.ForeColor = Color.White
        Label22.ForeColor = Color.White
        Label23.ForeColor = Color.White
        Label24.ForeColor = Color.White
        Label25.ForeColor = Color.White
        Label26.ForeColor = Color.White
        Label27.ForeColor = Color.White

        Label28.ForeColor = Color.White
        Label29.ForeColor = Color.White
        Label30.ForeColor = Color.White
        Label31.ForeColor = Color.White
        Label32.ForeColor = Color.White
        Label33.ForeColor = Color.White
        Label34.ForeColor = Color.White
        Label35.ForeColor = Color.White
        Label36.ForeColor = Color.White
        Label37.ForeColor = Color.White
        Label38.ForeColor = Color.White
        Label39.ForeColor = Color.White
        Label40.ForeColor = Color.White
        Label41.ForeColor = Color.White
        Label42.ForeColor = Color.White

        Label3.ForeColor = Color.White
        Label12.ForeColor = Color.White
        Label16.ForeColor = Color.White

        GroupBox2.ForeColor = Color.White
        GroupBox5.ForeColor = Color.White
    End Sub
    Sub color_eti_analisis()
        lblanalisar.ForeColor = Color.White
        Label43.ForeColor = Color.White
        Label44.ForeColor = Color.White
        Label45.ForeColor = Color.White
        Label46.ForeColor = Color.White
        Label47.ForeColor = Color.White
        Label48.ForeColor = Color.White
        Label49.ForeColor = Color.White
        Label50.ForeColor = Color.White
        Label51.ForeColor = Color.White
        Label52.ForeColor = Color.White
        Label53.ForeColor = Color.White
        Label54.ForeColor = Color.White
        Label55.ForeColor = Color.White
        Label56.ForeColor = Color.White
        Label57.ForeColor = Color.White
        Label58.ForeColor = Color.White
        Label59.ForeColor = Color.White
        Label60.ForeColor = Color.White
        Label61.ForeColor = Color.White
        Label62.ForeColor = Color.White
        Label63.ForeColor = Color.White
        Label64.ForeColor = Color.White
        Label65.ForeColor = Color.White
        Label66.ForeColor = Color.White
        Label67.ForeColor = Color.White
        Label68.ForeColor = Color.White
        Label69.ForeColor = Color.White
        Label70.ForeColor = Color.White
        Label71.ForeColor = Color.White
        Label72.ForeColor = Color.White


    End Sub
    Sub oculto_label()
        lblc.Visible = False
        lblp.Visible = False
        lblg.Visible = False
        lbla.Visible = False
        lble.Visible = False
        lblcanc.Visible = False
        lblbus.Visible = False
        lblacerca.Visible = False
        lblconf.Visible = False
        lblsalir.Visible = False
    End Sub
    Sub transparencia_labels()
        lblc.Parent = PictureBox1
        lblp.Parent = PictureBox1
        lblg.Parent = PictureBox1
        lbla.Parent = PictureBox1
        lble.Parent = PictureBox1
        lblcanc.Parent = PictureBox1
        lblbus.Parent = PictureBox1
        lblacerca.Parent = PictureBox1
        lblconf.Parent = PictureBox1
        lblsalir.Parent = PictureBox1

        lblc.BackColor = Color.Transparent
        lblp.BackColor = Color.Transparent
        lblg.BackColor = Color.Transparent
        lbla.BackColor = Color.Transparent
        lble.BackColor = Color.Transparent
        lblcanc.BackColor = Color.Transparent
        lblbus.BackColor = Color.Transparent
        lblacerca.BackColor = Color.Transparent
        lblconf.BackColor = Color.Transparent
        lblsalir.BackColor = Color.Transparent
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    '---------------------------------------------------- << ..... SONIDOS .... >>------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Sub sonido()
        Dim seta As String
        Dim sonido As System.Media.SoundPlayer

        seta = My.Application.Info.DirectoryPath
        sonido = New System.Media.SoundPlayer(seta + "\star.wav")
        sonido.Play()

    End Sub
    Sub sonido2()
        Dim seta2 As String
        Dim sonido As System.Media.SoundPlayer

        seta2 = My.Application.Info.DirectoryPath
        sonido = New System.Media.SoundPlayer(seta2 + "\click_02.wav")
        sonido.Play()
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    '---------------------------------- << ..... GENERADOR DE UN NUMERO [NUEVO] EN CUALQUIER TABLA.... >>-------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Public Sub generar_nuevo()
        If n1 = 1 Then
            Dim otabla As New DataTable
            Try
                consulta = "SELECT MAX(cod_canton) FROM tb_canton"
                adaptador = New SqlDataAdapter(consulta, conexion)
                registro = New DataSet
                adaptador.Fill(registro, "tb_canton")
                txtcodigo_c.Text = registro.Tables(0).Rows(0).Item(0) + 1
                ' txtnombre.Focus()
            Catch ex As Exception
                If otabla.Rows.Count = 0 Then
                    txtcodigo_c.Text = 1
                    ' txtnombre.Focus()
                End If
            End Try
        End If
        '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        If n2 = 2 Then
            Dim otabla As New DataTable
            Try
                consulta = "SELECT MAX(cod_provincia) FROM tb_provincia"
                adaptador = New SqlDataAdapter(consulta, conexion)
                registro = New DataSet
                adaptador.Fill(registro, "tb_provincia")
                txtcodigo_p.Text = registro.Tables(0).Rows(0).Item(0) + 1
                ' txtnombre.Focus()
            Catch ex As Exception
                If otabla.Rows.Count = 0 Then
                    txtcodigo_p.Text = 1
                    ' txtnombre.Focus()
                End If
            End Try
        End If

        '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        If n3 = 3 Then
            Dim otabla As New DataTable
            Try
                consulta = "SELECT MAX(codigo) FROM tb_tipo_cultivo"
                adaptador = New SqlDataAdapter(consulta, conexion)
                registro = New DataSet
                adaptador.Fill(registro, "tb_tipo_cultivo")
                txtcod_cultivo.Text = registro.Tables(0).Rows(0).Item(0) + 1
                ' txtnombre.Focus()
            Catch ex As Exception
                If otabla.Rows.Count = 0 Then
                    txtcod_cultivo.Text = 1
                    ' txtnombre.Focus()
                End If
            End Try
        End If
        '>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        If n4 = 4 Then
            Dim otabla As New DataTable
            Try
                consulta = "SELECT MAX(codigo) FROM tb_analisis"
                adaptador = New SqlDataAdapter(consulta, conexion)
                registro = New DataSet
                adaptador.Fill(registro, "tb_analisis")
                txtcodigoana.Text = registro.Tables(0).Rows(0).Item(0) + 1
                ' txtnombre.Focus()
            Catch ex As Exception
                If otabla.Rows.Count = 0 Then
                    txtcodigoana.Text = 1
                    ' txtnombre.Focus()
                End If
            End Try
        End If


    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    '--------------------------------------------------- PROCEDIMIENTO [LIMPIAR] -------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Sub limpiar_canton()
        ' txtcodigo_c.Clear()
        txtnombre_c.ForeColor = Color.Silver
        txtnombre_c.Text = "Ingrese el Cantón"
    End Sub
    Sub limpiar_provincia()
        '  txtcodigo_p.Clear()
        txtnombre_p.ForeColor = Color.Silver
        txtnombre_p.Text = "Ingrese la Provincia"
    End Sub
    Sub limpiar_cultivo()
        'txtcodigo.Clear()
        txtnombre.Text = "Ingrese el Cultivo"
        txtnombre.ForeColor = Color.Silver
        txtn.Clear()
        txtp.Clear()
        txtk.Clear()
        txtca.Clear()
        txtmg.Clear()
        txts.Clear()
        txtfe.Clear()
        txtmn.Clear()
        txtcu.Clear()
        txtb.Clear()
        txtzn.Clear()
        txtmo.Clear()
    End Sub
    Sub limpiar_analisis()
        cmbcanton.SelectedIndex = 0
        cmbprovincia.SelectedIndex = 0
        cmbcultivo.SelectedIndex = 0
        txtkpm.Clear()
        txtpr.Clear()
        txtnpm.Clear()
        'txtnpi.Clear()
        txtkpm.Clear()
        'txtppi.Clear()
        txtppm.Clear()
        txtnr.Clear()
        txtntp.Clear()
        ' txtkpi.Clear()
        txtkpm.Clear()
        txtkr.Clear()
        txtarea.Clear()
        txtplantas.Clear()
        txtsft.Text = 0
        txturea.Text = 0
        txtntp.Text = 0
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    '---------------------------------------------<<.. PROCEDIMIENTOS PARA [GUARDAR] DATOS ..>>-----------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Sub guardar_canton()
        If txtcodigo_c.Text = "" Or txtnombre_c.Text = "Ingrese el Cantón" Or txtnombre_c.Text = "" Then
            Exit Sub
        End If
        Dim comando As New SqlCommand("SELECT * FROM tb_canton WHERE canton='" & txtnombre_c.Text & "' ", conexion)
        Dim dr As SqlDataReader
        dr = comando.ExecuteReader

        If dr.Read Then
            MsgBox("Datos duplicados...", MsgBoxStyle.Information, "Error")
            txtcodigo_c.Focus()
            txtnombre_c.Text = "Ingrese el Cantón"
            txtnombre_c.ForeColor = Color.Silver
            dr.Close()
        Else
            dr.Close()
            Try

                Dim cmd As New SqlCommand("INSERT INTO tb_canton VALUES(@cod_canton,@canton)", conexion)
                cmd.Parameters.AddWithValue("@cod_canton", SqlDbType.Int).Value = txtcodigo_c.Text
                cmd.Parameters.AddWithValue("@canton", SqlDbType.VarChar).Value = UCase(txtnombre_c.Text)

                cmd.ExecuteNonQuery()
                MsgBox("Datos Guardados con Exito...", MsgBoxStyle.Information, "Guardado")
                txtcodigo_c.Focus()
                limpiar_canton()
                generar_nuevo()
            Catch ex As Exception
                'MsgBox(ex.ToString)
                'MsgBox("No puede volver a gruadar el mismo dato", MsgBoxStyle.Exclamation, "Error")
                MsgBox("Se le recomienda Actualizar, no Guardar", MsgBoxStyle.Exclamation, "Error")
            End Try
        End If
    End Sub
    Sub guardar_provincia()
        If txtnombre_p.Text = "Ingrese la Provincia" Or txtnombre_p.Text = "" Or txtcodigo_p.Text = "" Then
            Exit Sub
        End If
        Dim comando As New SqlCommand("SELECT * FROM tb_provincia WHERE provincia='" & txtnombre_p.Text & "' ", conexion)
        Dim dr As SqlDataReader
        dr = comando.ExecuteReader

        If dr.Read Then
            MsgBox("Datos duplicados...", MsgBoxStyle.Information, "Error")
            txtcodigo_p.Focus()
            txtnombre_p.Text = "Ingrese la Provincia"
            txtnombre_p.ForeColor = Color.Silver
            dr.Close()
        Else
            dr.Close()
            Try

                Dim cmd As New SqlCommand("INSERT INTO tb_provincia VALUES(@cod_provincia,@provincia)", conexion)
                cmd.Parameters.AddWithValue("@cod_provincia", SqlDbType.Int).Value = txtcodigo_p.Text
                cmd.Parameters.AddWithValue("@provincia", SqlDbType.VarChar).Value = UCase(txtnombre_p.Text)

                cmd.ExecuteNonQuery()
                MsgBox("Datos Guardados con Exito...", MsgBoxStyle.Information, "Guardado")
                txtcodigo_p.Focus()
                limpiar_provincia()
                generar_nuevo()
            Catch ex As Exception
                ' MsgBox(ex.ToString)
                'MsgBox("No puede volver a gruadar el mismo dato", MsgBoxStyle.Exclamation, "Error")
                MsgBox("Se le recomienda Actualizar, no Guardar", MsgBoxStyle.Exclamation, "Error")
            End Try
        End If
    End Sub
    Sub guardar_cultivo()
        If txtcod_cultivo.Text = "" Or txtnombre.Text = "Ingrese el Cultivo" Or txtnombre.Text = "" Then
            Exit Sub
        End If
        Dim comando As New SqlCommand("SELECT * FROM tb_tipo_cultivo WHERE cultivo='" & txtnombre.Text & "' ", conexion)
        Dim dr As SqlDataReader
        dr = comando.ExecuteReader

        If dr.Read Then
            MsgBox("Datos duplicados...", MsgBoxStyle.Information, "Error")
            txtnombre.Clear()
            dr.Close()
        Else
            dr.Close()
            Try

                Dim cmd As New SqlCommand("INSERT INTO tb_tipo_cultivo VALUES(@codigo,@cultivo,@nitrogeno,@fosforo,@potasio,@calcio,@magnesio,@azufre,@hierro,@manganeso,@cobre,@boro,@zinc,@molibdemo)", conexion)
                cmd.Parameters.AddWithValue("@codigo", SqlDbType.Int).Value = txtcod_cultivo.Text
                cmd.Parameters.AddWithValue("@cultivo", SqlDbType.VarChar).Value = UCase(txtnombre.Text)
                cmd.Parameters.AddWithValue("@nitrogeno", SqlDbType.Int).Value = txtn.Text
                cmd.Parameters.AddWithValue("@fosforo", SqlDbType.Int).Value = txtp.Text
                cmd.Parameters.AddWithValue("@potasio", SqlDbType.Int).Value = txtk.Text
                cmd.Parameters.AddWithValue("@calcio", SqlDbType.Int).Value = txtca.Text
                cmd.Parameters.AddWithValue("@magnesio", SqlDbType.Int).Value = txtmg.Text
                cmd.Parameters.AddWithValue("@azufre", SqlDbType.Int).Value = txts.Text
                cmd.Parameters.AddWithValue("@hierro", SqlDbType.Int).Value = txtfe.Text
                cmd.Parameters.AddWithValue("@manganeso", SqlDbType.Int).Value = txtmn.Text
                cmd.Parameters.AddWithValue("@cobre", SqlDbType.Int).Value = txtcu.Text
                cmd.Parameters.AddWithValue("@boro", SqlDbType.Int).Value = txtb.Text
                cmd.Parameters.AddWithValue("@zinc", SqlDbType.Int).Value = txtzn.Text
                cmd.Parameters.AddWithValue("@molibdemo", SqlDbType.Int).Value = txtmo.Text

                cmd.ExecuteNonQuery()
                MsgBox("Datos Guardados con Exito...", MsgBoxStyle.Information, "Guardado")

                limpiar_cultivo()
                generar_nuevo()
            Catch ex As Exception
                'MsgBox(ex.ToString)
                MsgBox("Se le recomienda Actualizar, no Guardar", MsgBoxStyle.Exclamation, "Error")
            End Try
        End If
    End Sub
    Sub guaradar_analisis()
        If txtnpm.Text = "" Or txtppm.Text = "" Or txtkpm.Text = "" Then
            Exit Sub
        End If
        Try

            Dim cmd As New SqlCommand("INSERT INTO tb_analisis VALUES(@codigo,@tipo_cultivo,@provincia,@canton,@nitrogeno,@fosforo,@potasio,@area,@plantas,@urea,@superfosfato_triple,@nuriato_potasio,@fecha)", conexion)
            cmd.Parameters.AddWithValue("@codigo", SqlDbType.Int).Value = txtcodigoana.Text
            cmd.Parameters.AddWithValue("@tipo_cultivo", SqlDbType.Int).Value = cmbcultivo.SelectedIndex + 1
            cmd.Parameters.AddWithValue("@provincia", SqlDbType.Int).Value = cmbprovincia.SelectedIndex + 1
            cmd.Parameters.AddWithValue("@canton", SqlDbType.Int).Value = cmbcanton.SelectedIndex + 1
            cmd.Parameters.AddWithValue("@nitrogeno", SqlDbType.Int).Value = txtnr.Text
            cmd.Parameters.AddWithValue("@fosforo", SqlDbType.Int).Value = txtpr.Text
            cmd.Parameters.AddWithValue("@potasio", SqlDbType.Int).Value = txtkr.Text
            cmd.Parameters.AddWithValue("@area", SqlDbType.VarChar).Value = txtarea.Text
            cmd.Parameters.AddWithValue("@plantas", SqlDbType.VarChar).Value = txtplantas.Text
            cmd.Parameters.AddWithValue("@urea", SqlDbType.VarChar).Value = txturea.Text
            cmd.Parameters.AddWithValue("@superfosfato_triple", SqlDbType.VarChar).Value = txtsft.Text
            cmd.Parameters.AddWithValue("@nuriato_potasio", SqlDbType.VarChar).Value = txtntp.Text
            cmd.Parameters.AddWithValue("@fecha", SqlDbType.Date).Value = txtfecha.Text
            ' cmd.Parameters.AddWithValue("@descripcion", SqlDbType.VarChar).Value = ListBox1.Text

            'cmd.Parameters.AddWithValue(("@codigo"), txtcodigoana.Text)
            'cmd.Parameters.AddWithValue(("@tipo_cultivo"), cmbcultivo.SelectedIndex + 1)
            'cmd.Parameters.AddWithValue("@provincia", cmbprovincia.SelectedIndex + 1)
            'cmd.Parameters.AddWithValue("@canton", cmbcanton.SelectedIndex + 1)
            'cmd.Parameters.AddWithValue("@nitrogeno", txtnr.Text)
            'cmd.Parameters.AddWithValue("@fosforo", txtpr.Text)
            'cmd.Parameters.AddWithValue("@potasio", txtkr.Text)
            'cmd.Parameters.AddWithValue("@area", txtarea.Text)
            'cmd.Parameters.AddWithValue("@plantas", txtplantas.Text)
            'cmd.Parameters.AddWithValue("@urea", txturea.Text)
            'cmd.Parameters.AddWithValue("@superfosfato_triple", txtsft.Text)
            'cmd.Parameters.AddWithValue("@nuriato_potasio", txtntp.Text)
            'cmd.Parameters.AddWithValue("@fecha", txtfecha.Text)
            ''cmd.Parameters.AddWithValue("@descripcion", ListBox1.Text)

            cmd.ExecuteNonQuery()
            MsgBox("Datos Guardados con Exito...", MsgBoxStyle.Information, "Guardado")

            generar_nuevo()
        Catch ex As Exception
            MsgBox(ex.ToString)
            'MsgBox("No puede volver a gruadar el mismo dato", MsgBoxStyle.Exclamation, "Error")
            'MsgBox("Se le recomienda Actualizar, no Guardar", MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    '---------------------------------------------<<.. PROCEDIMIENTOS PARA [EDITAR] DATOS ..>>------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Sub editar_canton()
        If txtcodigo_c.Text = "" Or txtnombre_c.Text = "Ingrese el Cantón" Or txtnombre_c.Text = "" Then
            Exit Sub
        End If
        Try
            Dim cmd As New SqlCommand("UPDATE tb_canton SET canton='" & UCase(txtnombre_c.Text) & "' WHERE cod_canton=" & txtcodigo_c.Text & "", conexion)
            cmd.ExecuteNonQuery()
            MsgBox("Datos Actualizados correctamente...", MsgBoxStyle.Information, "Actulizar")

            limpiar_canton()
            generar_nuevo()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Sub editar_provincia()
        If txtcodigo_p.Text = "" Or txtnombre_p.Text = "Ingrese la Provincia" Or txtnombre_p.Text = "" Then
            Exit Sub
        End If
        Try
            Dim cmd As New SqlCommand("UPDATE tb_provincia SET provincia='" & UCase(txtnombre_p.Text) & "' WHERE cod_provincia=" & txtcodigo_p.Text & "", conexion)
            cmd.ExecuteNonQuery()
            MsgBox("Datos Actualizados correctamente...", MsgBoxStyle.Information, "Actulizar")

            limpiar_provincia()
            generar_nuevo()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Sub editar_cultivo()
        If txtcod_cultivo.Text = "" Or txtnombre.Text = "Ingrese el Cultivo" Or txtnombre.Text = "" Then
            Exit Sub
        End If
        Try
            Dim cmd As New SqlCommand("UPDATE tb_tipo_cultivo SET cultivo='" & UCase(txtnombre.Text) & "',nitrogeno=" & _
                                   txtn.Text & ",fosforo=" & txtp.Text & ",potasio=" & txtk.Text & ",calcio=" & _
                                   txtca.Text & ",magnesio=" & txtmg.Text & ",azufre=" & txts.Text & ",hierro=" & _
                                   txtfe.Text & ",manganeso=" & txtmn.Text & ",cobre=" & txtcu.Text & ",boro=" & _
                                   txtb.Text & ",zinc=" & txtzn.Text & ",molibdemo=" & txtmo.Text & " WHERE codigo=" & txtcod_cultivo.Text & "", conexion)
            cmd.ExecuteNonQuery()
            MsgBox("Datos Actualizados correctamente...", MsgBoxStyle.Information, "Actulizar")
            limpiar_cultivo()
            generar_nuevo()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Sub editar_analisis()
        MsgBox("No esta permitida la modificacion de los datos", MsgBoxStyle.Information, "Alerta!")
        'Try
        ' Dim cmd As New SqlCommand("UPDATE tb_analisis SET tipo_cultivo='" & cmbcultivo.SelectedIndex + 1 & "',provincia='" & cmbprovincia.SelectedIndex + 1 & "', canton='" & cmbcanton.SelectedIndex + 1 & "',nitrogeno='" & txtnpi.Text & "' WHERE codigo=" & txtcodigo.Text & "", conexion)
        '    cmd.ExecuteNonQuery()
        '    MsgBox("Datos Actualizados correctamente...", MsgBoxStyle.Information, "Actulizar")
        '    limpiar()
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    '--------------------------------------------<<.. PROCEDIMIENTOS PARA [ELIMINAR] DATOS ..>>-----------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Sub eliminar_canton()
        If txtcodigo_c.Text = "" Or txtnombre_c.Text = "Ingrese el Cantón" Or txtnombre_c.Text = "" Then
            Exit Sub
        End If
        respuesta = MsgBox("¿Esta seguro que desea eliminar el registro?", vbYesNo, "Eliminar")
        If respuesta = vbYes Then
            Try
                'eliminar()'Utilizado para optener el Nº elimnado para luego utilizarlo...
                Dim cmd As New SqlCommand("DELETE  FROM tb_canton WHERE cod_canton=" & txtcodigo_c.Text & "", conexion)
                cmd.ExecuteNonQuery()
                MsgBox("Datos Eliminados con Exito...", MsgBoxStyle.Information, "Eliminado")
                limpiar_canton()
                generar_nuevo()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub
    Sub eliminar_provincia()
        ' Dim respuesta As Byte
        If txtcodigo_p.Text = "" Or txtnombre_p.Text = "Ingrese la Provincia" Or txtnombre_p.Text = "" Then
            Exit Sub
        End If
        respuesta = MsgBox("¿Esta seguro que desea eliminar el registro?", vbYesNo, "Eliminar")
        If respuesta = vbYes Then
            ' eliminar()
            Dim cmd As New SqlCommand("DELETE  FROM tb_provincia WHERE cod_provincia=" & txtcodigo_p.Text & "", conexion)
            cmd.ExecuteNonQuery()
            MsgBox("Datos Eliminados con Exito...", MsgBoxStyle.Information, "Eliminado")
            limpiar_provincia()
            generar_nuevo()
        End If
    End Sub
    Sub eliminar_cultivo()
        ' Dim respuesta As Byte
        If txtcod_cultivo.Text = "" Or txtnombre.Text = "Ingrese el Cultivo" Or txtnombre.Text = "" Then
            Exit Sub
        End If
        respuesta = MsgBox("¿Esta seguro que desea eliminar el registro?", vbYesNo, "Eliminar")
        If respuesta = vbYes Then
            Dim cmd As New SqlCommand("DELETE  FROM tb_tipo_cultivo WHERE codigo=" & txtcod_cultivo.Text & "", conexion)
            cmd.ExecuteNonQuery()
            MsgBox("Datos Eliminados con Exito...", MsgBoxStyle.Information, "Eliminado")
            limpiar_cultivo()
            generar_nuevo()
        End If
    End Sub
    Sub eliminar_analisis()
        If txtnpm.Text = "" Or txtppm.Text = "" Or txtkpm.Text = "" Then
            Exit Sub
        End If
        Dim respuesta As Byte
        respuesta = MsgBox("¿Esta seguro que desea eliminar el registro?", vbYesNo, "Eliminar")
        If respuesta = vbYes Then
            Try

                Dim cmd As New SqlCommand("DELETE  FROM tb_analisis WHERE codigo=" & txtcodigoana.Text & " and fecha='" & txtfecha.Text & "'", conexion)
                cmd.ExecuteNonQuery()
                MsgBox("Datos Eliminados con Exito...", MsgBoxStyle.Information, "Eliminado")
                'limpiar()
                generar_nuevo()
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    '---------------------------------------------<<.. PROCEDIMIENTOS PARA [BUSACAR] DATOS ..>>-----------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Sub buscar_canton()
        If txtcodigo_c.Text = "" Or txtnombre_c.Text = "Ingrese el Canton" Then
            Exit Sub
        End If
        Dim buscar As String
        Dim consulta As String
        Dim lista As Byte
        buscar = InputBox("Ingrese el Cantón")

        If buscar <> "" Then
            consulta = "SELECT * FROM tb_canton WHERE canton like '" & buscar & "%'"
            adaptador = New SqlDataAdapter(consulta, conexion)
            registro = New DataSet
            adaptador.Fill(registro, "tb_canton")

            lista = registro.Tables("tb_canton").Rows.Count

        Else
            MsgBox("Ingrese un dato a buscar", , "Error")
            btnsalirc.Visible = True
        End If
        If lista <> 0 Then
            DataGridView1.DataSource = registro
            DataGridView1.DataMember = "tb_canton"
        Else
            btnsalirc.Visible = True
        End If
        GroupBox4.Visible = True
    End Sub
    Sub buscar_provinvia()
        Dim buscar As String
        Dim consulta As String
        Dim lista As Byte

        If txtcodigo_p.Text = "" Or txtnombre_p.Text = "Ingrese la Provincia" Then
            Exit Sub
        End If
        buscar = InputBox("Ingrese la Provincia")

        If buscar <> "" Then
            consulta = "SELECT * FROM tb_provincia WHERE provincia like '" & buscar & "%'"
            adaptador = New SqlDataAdapter(consulta, conexion)
            registro = New DataSet
            adaptador.Fill(registro, "tb_provincia")

            lista = registro.Tables("tb_provincia").Rows.Count

        Else
            MsgBox("Ingrese un dato a buscar", , "Error")
            btnsalirp.Visible = True
        End If
        If lista <> 0 Then
            DataGridView2.DataSource = registro
            DataGridView2.DataMember = "tb_provincia"
        Else
            btnsalirp.Visible = True
        End If
        GroupBox6.Visible = True
    End Sub
    Sub buscar_cultivo2()
        Dim buscar As String
        Dim consulta As String
        Dim lista As Byte
        buscar = InputBox("Ingrese una el Cultivo")

        If buscar <> "" Then
            consulta = "SELECT * FROM tb_tipo_cultivo WHERE cultivo like '" & buscar & "%'"
            adaptador = New SqlDataAdapter(consulta, conexion)
            registro = New DataSet
            adaptador.Fill(registro, "tb_tipo_cultivo")

            lista = registro.Tables("tb_tipo_cultivo").Rows.Count

        Else
            MsgBox("Ingrese un dato a buscar", , "Error")
            btnsalirct.Visible = True
        End If
        If lista <> 0 Then
            DataGridView3.DataSource = registro
            DataGridView3.DataMember = "tb_tipo_cultivo"
        Else
            btnsalirct.Visible = True
        End If
        GroupBox7.Visible = True
    End Sub
    Sub buscar_analisis()
        Dim buscar As String
        Dim consulta As String
        Dim lista As Byte
        buscar = InputBox("Ingrese la fecha")

        If buscar <> "" Then
            consulta = "SELECT * FROM tb_analisis WHERE fecha like '" & buscar & "%'"
            adaptador = New SqlDataAdapter(consulta, conexion)
            registro = New DataSet
            adaptador.Fill(registro, "tb_analisis")

            lista = registro.Tables("tb_analisis").Rows.Count
            Timer3.Stop()
            GroupBox8.Visible = False
            PictureBox3.Visible = False
            PictureBox2.Visible = False
            PictureBox4.Visible = False
            lblanalisar.Visible = False
            GroupBox13.Visible = False
            GroupBox12.Visible = False
            GroupBox11.Visible = False
        Else
            MsgBox("Ingrese un dato a buscar", , "Error")
            btnsalira.Visible = True
        End If
        If lista <> 0 Then
            DataGridView4.DataSource = registro
            DataGridView4.DataMember = "tb_analisis"
        Else
            btnsalira.Visible = True
        End If
        GroupBox14.Visible = True
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    '--------------------------------- CLIC BOTONES [Guardar,Editar,Eliminar,Cancelar] -------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------

    Private Sub Panel_guardar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_guardar.Click
        'borrar_eliminar()
        'If n1 = 0 And n2 = 0 And n3 = 0 And n4 = 0 Then

        'Else
        If n1 = 1 Then
            guardar_canton()
        End If
        If n2 = 2 Then
            guardar_provincia()
        End If
        If n3 = 3 Then
            guardar_cultivo()
        End If
        If n4 = 4 Then
            guaradar_analisis()
        End If
        'End If

    End Sub

    Private Sub Panel_cancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_cancelar.Click

        If n1 = 1 Then
            generar_nuevo()
            limpiar_canton()
        ElseIf n2 = 2 Then
            generar_nuevo()
            limpiar_provincia()
        ElseIf n3 = 3 Then
            generar_nuevo()
            limpiar_cultivo()
        ElseIf n4 = 4 Then

            generar_nuevo()
            limpiar_analisis()
        End If
        btnsalir2.Visible = True
    End Sub

    Private Sub Panel_actualizar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_actualizar.Click
        If n1 = 1 Then
            editar_canton()
        ElseIf n2 = 2 Then
            editar_provincia()
        ElseIf n3 = 3 Then
            editar_cultivo()
        ElseIf n4 = 4 Then
            editar_analisis()
        End If
    End Sub

    Private Sub Panel_eliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_eliminar.Click
        If n1 = 1 Then
            eliminar_canton()
        ElseIf n2 = 2 Then
            eliminar_provincia()
        ElseIf n3 = 3 Then
            eliminar_cultivo()
        ElseIf n4 = 4 Then
            eliminar_analisis()
        End If
    End Sub

    Private Sub Panel_buscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_buscar.Click
        If n1 = 1 Then
            buscar_canton()
        ElseIf n2 = 2 Then
            buscar_provinvia()
        ElseIf n3 = 3 Then
            buscar_cultivo2()
        ElseIf n4 = 4 Then
            buscar_analisis()
        End If
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    '-------------------------------------------------------<<.. DATAGRIEVIEW ..>>------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        If n1 = 1 Then
            txtcodigo_c.Text = DataGridView1.CurrentRow.Cells.Item(0).Value.ToString
            txtnombre_c.Text = DataGridView1.CurrentRow.Cells.Item(1).Value.ToString

            txtnombre_c.ForeColor = Color.Black
            GroupBox4.Visible = False
        End If

    End Sub

    Private Sub DataGridView2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView2.DoubleClick
        If n2 = 2 Then
            txtcodigo_p.Text = DataGridView2.CurrentRow.Cells.Item(0).Value.ToString
            txtnombre_p.Text = DataGridView2.CurrentRow.Cells.Item(1).Value.ToString

            txtnombre_p.ForeColor = Color.Black
            GroupBox6.Visible = False
        End If

    End Sub

    Private Sub DataGridView3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView3.DoubleClick
        If n3 = 3 Then
            txtcod_cultivo.Text = DataGridView3.CurrentRow.Cells.Item(0).Value.ToString
            txtnombre.Text = DataGridView3.CurrentRow.Cells.Item(1).Value.ToString
            txtn.Text = DataGridView3.CurrentRow.Cells.Item(2).Value.ToString
            txtp.Text = DataGridView3.CurrentRow.Cells.Item(3).Value.ToString
            txtk.Text = DataGridView3.CurrentRow.Cells.Item(4).Value.ToString
            txtca.Text = DataGridView3.CurrentRow.Cells.Item(5).Value.ToString
            txtmg.Text = DataGridView3.CurrentRow.Cells.Item(6).Value.ToString
            txts.Text = DataGridView3.CurrentRow.Cells.Item(7).Value.ToString
            txtfe.Text = DataGridView3.CurrentRow.Cells.Item(8).Value.ToString
            txtmn.Text = DataGridView3.CurrentRow.Cells.Item(9).Value.ToString
            txtcu.Text = DataGridView3.CurrentRow.Cells.Item(10).Value.ToString
            txtb.Text = DataGridView3.CurrentRow.Cells.Item(11).Value.ToString
            txtzn.Text = DataGridView3.CurrentRow.Cells.Item(12).Value.ToString
            txtmo.Text = DataGridView3.CurrentRow.Cells.Item(13).Value.ToString

            txtnombre.ForeColor = Color.Black
            GroupBox7.Visible = False
        End If

    End Sub

    Private Sub DataGridView4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView4.DoubleClick
        If n4 = 4 Then
            Panel1.Visible = False
            PictureBox2.Left = 90
            PictureBox2.Top = 185

            PictureBox4.Left = 90
            PictureBox4.Top = 225

            'PictureBox3.Visible = True
            'PictureBox2.Visible = True
            'PictureBox4.Visible = True
            'GroupBox13.Visible = True
            'GroupBox12.Visible = True
            'GroupBox11.Visible = True
            ' Timer3.Start()
            GroupBox8.Visible = True
            ' Timer3.Stop()
            Try
                txtcodigoana.Text = DataGridView4.CurrentRow.Cells.Item(0).Value.ToString
                cmbcultivo.SelectedIndex = (DataGridView4.CurrentRow.Cells.Item(1).Value.ToString) - 1
                cmbprovincia.SelectedIndex = (DataGridView4.CurrentRow.Cells.Item(2).Value.ToString) - 1
                cmbcanton.SelectedIndex = (DataGridView4.CurrentRow.Cells.Item(3).Value.ToString) - 1
                txtnr.Text = DataGridView4.CurrentRow.Cells.Item(4).Value.ToString
                ' txtnpm.Text = DataGridView4.CurrentRow.Cells.Item(4).Value.ToString
                txtpr.Text = DataGridView4.CurrentRow.Cells.Item(5).Value.ToString
                ' txtppm.Text = DataGridView4.CurrentRow.Cells.Item(5).Value.ToString
                txtkr.Text = DataGridView4.CurrentRow.Cells.Item(6).Value.ToString
                ' txtkpm.Text = DataGridView4.CurrentRow.Cells.Item(6).Value.ToString
                txtarea.Text = DataGridView4.CurrentRow.Cells.Item(7).Value.ToString
                txtplantas.Text = DataGridView4.CurrentRow.Cells.Item(8).Value.ToString
                txturea.Text = DataGridView4.CurrentRow.Cells.Item(9).Value.ToString
                txtsft.Text = DataGridView4.CurrentRow.Cells.Item(10).Value.ToString
                txtntp.Text = DataGridView4.CurrentRow.Cells.Item(11).Value.ToString
                txtfecha.Text = DataGridView4.CurrentRow.Cells.Item(12).Value.ToString

                GroupBox14.Visible = False

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    '------------------------------------------- CLIC BOTONES [CERRAR FORMULARIOS] -----------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Private Sub btncerrarc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncerrarc.Click
        n1 = 0
        P_canton.Visible = False
        limpiar_canton()
        aparecer_formularios()
    End Sub

    Private Sub btncerrarp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncerrarp.Click
        n2 = 0
        P_provincia.Visible = False
        limpiar_provincia()
        aparecer_formularios()
    End Sub
    Private Sub btncerrarana_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncerrarana.Click
        n4 = 0
        GroupBox8.Visible = False
        GroupBox14.Visible = False
        P_analisis.Visible = False
        limpiar_analisis()
        Timer1.Stop()
        Timer2.Stop()
        Timer3.Stop()
        otrosvisualizar()
        aparecer_formularios()

        txtnr.Clear()
        txtpr.Clear()
        txtkr.Clear()
        txturea.Clear()
        txtsft.Clear()
        txtntp.Clear()
        txtarea.Clear()
        txtplantas.Clear()
    End Sub

    Private Sub btncerrarct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncerrarct.Click
        n3 = 0
        P_cultivo.Visible = False
        limpiar_cultivo()
        aparecer_formularios()
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    '------------------------------------------- << ........EVENTOS .......>>-----------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    '----------------------------------------------<< .... FORMULARIOS ... >>-----------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Private Sub Panel_cerrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_cerrar.Click
        Me.Close()
        Presentacion.Close()
        sonido2()
    End Sub

    Private Sub Panel_conton_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_conton.MouseHover
        Panel_conton.Size = New Size(107, 90)
        sonido()
        Panel_posicion.Location = New Point(102, 39)
        Panel_posicion.Visible = True

        lblc.Visible = True
    End Sub

    Private Sub Panel_conton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_conton.MouseLeave
        Panel_conton.Size = New Size(73, 70)
        Panel_posicion.Visible = False

        lblc.Visible = False
    End Sub

    Private Sub Panel_provincia_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_provincia.MouseHover
        sonido()
        Panel_provincia.Size = New Size(107, 90)
        Panel_posicion.Location = New Point(105, 99)
        Panel_posicion.Visible = True

        lblp.Visible = True
    End Sub

    Private Sub Panel_provincia_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_provincia.MouseLeave
        Panel_provincia.Size = New Size(73, 70)
        Panel_posicion.Visible = False

        lblp.Visible = False
    End Sub


    Private Sub Panel_guardar_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_guardar.MouseHover
        sonido()
        Panel_guardar.Size = New Size(107, 90)
        Panel_posicion.Location = New Point(105, 181)
        Panel_posicion.Visible = True

        lblg.Visible = True
    End Sub

    Private Sub Panel_guardar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_guardar.MouseLeave
        Panel_guardar.Size = New Size(73, 70)
        Panel_posicion.Visible = False

        lblg.Visible = False
    End Sub

    Private Sub Panel_actualizar_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_actualizar.MouseHover
        sonido()
        Panel_actualizar.Size = New Size(107, 90)
        Panel_posicion.Location = New Point(105, 248)
        Panel_posicion.Visible = True

        lbla.Visible = True
    End Sub

    Private Sub Panel_actualizar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_actualizar.MouseLeave
        Panel_actualizar.Size = New Size(73, 70)
        Panel_posicion.Visible = False

        lbla.Visible = False
    End Sub

    Private Sub Panel_eliminar_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_eliminar.MouseHover
        sonido()
        Panel_eliminar.Size = New Size(107, 90)
        Panel_posicion.Location = New Point(105, 306)
        Panel_posicion.Visible = True

        lble.Visible = True
    End Sub

    Private Sub Panel_eliminar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_eliminar.MouseLeave
        Panel_eliminar.Size = New Size(73, 70)
        Panel_posicion.Visible = False

        lble.Visible = False
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    '--------------------------------------------------<< .... BOTONES ... >>-----------------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Private Sub Panel_cancelar_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_cancelar.MouseHover
        sonido()
        Panel_cancelar.Size = New Size(107, 90)
        Panel_posicion.Location = New Point(105, 372)
        Panel_posicion.Visible = True

        lblcanc.Visible = True
    End Sub

    Private Sub Panel_cancelar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_cancelar.MouseLeave
        Panel_cancelar.Size = New Size(73, 70)
        Panel_posicion.Visible = False

        lblcanc.Visible = False
    End Sub

    Private Sub Panel_ayuda_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_ayuda.MouseHover
        sonido()
        Panel_ayuda.Size = New Size(107, 90)
        'Panel_posicion.Location = New Point(105, 437)
        Panel_posicion.Location = New Point(105, 556)
        Panel_posicion.Visible = True
        lblacerca.Visible = True
    End Sub

    Private Sub Panel_ayuda_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_ayuda.MouseLeave
        Panel_ayuda.Size = New Size(73, 70)
        Panel_posicion.Visible = False

        lblacerca.Visible = False
    End Sub

    Private Sub Panel_opciones_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_opciones.MouseHover
        sonido()
        Panel_opciones.Size = New Size(107, 90)
        Panel_posicion.Location = New Point(105, 492)
        Panel_posicion.Visible = True

        lblconf.Visible = True
    End Sub

    Private Sub Panel_opciones_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_opciones.MouseLeave
        Panel_opciones.Size = New Size(73, 70)
        Panel_posicion.Visible = False

        lblconf.Visible = False
    End Sub

    Private Sub Panel_buscar_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_buscar.MouseHover
        sonido()
        Panel_buscar.Size = New Size(107, 90)
        'Panel_posicion.Location = New Point(105, 556)
        Panel_posicion.Location = New Point(105, 437)
        Panel_posicion.Visible = True

        lblbus.Visible = True
    End Sub

    Private Sub Panel_buscar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_buscar.MouseLeave
        Panel_buscar.Size = New Size(73, 70)
        Panel_posicion.Visible = False

        lblbus.Visible = False
    End Sub

    Private Sub Panel_cerrar_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_cerrar.MouseHover
        sonido()
        Panel_cerrar.Size = New Size(107, 90)
        Panel_posicion.Location = New Point(105, 619)
        Panel_posicion.Visible = True

        lblsalir.Visible = True
    End Sub

    Private Sub Panel_cerrar_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_cerrar.MouseLeave
        Panel_cerrar.Size = New Size(73, 70)
        Panel_posicion.Visible = False

        lblsalir.Visible = False
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    '------------------------------------<< .... BOTON ADELANTE - ATRAS MOVIMIENTO ... >>-----------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------

    Private Sub Panel_atras1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_atras1.MouseHover
        sonido()
        Panel_atras1.Size = New Size(100, 70)
    End Sub

    Private Sub Panel_atras1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_atras1.MouseLeave
        Panel_atras1.Size = New Size(82, 53)
    End Sub

    Private Sub Panel_atras2_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_atras2.MouseHover
        sonido()
        Panel_atras2.Size = New Size(100, 70)
    End Sub

    Private Sub Panel_atras2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_atras2.MouseLeave
        Panel_atras2.Size = New Size(82, 53)
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    '-----------------------------------------------<< LÓGICA MOVIMIENTO FORMULARIOS >>-------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Private Sub Panel_atras1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel_atras1.Click
        sonido2()
        If Canton.Left = 211 Then

            Canton.Size = New Size(255, 122)
            Canton.Location = New Point(549, 153)

            Provincia.Location = New Point(211, 275)

            Panel_analisis.Location = New Point(810, 275)
            Panel_analisis.Size = New Size(332, 142)
            '-------------------------------------------------
        ElseIf Provincia.Left = 211 Then
            Provincia.Location = New Point(549, 153)
            Provincia.Size = New Size(255, 122)

            Canton.Location = New Point(810, 275)
            Canton.Size = New Size(332, 142)

            Panel_analisis.Location = New Point(211, 275)
            'Panel_analisis.Size = New Size(255, 122)
            '-------------------------------------------------
        ElseIf Panel_analisis.Left = 211 Then

            Panel_analisis.Location = New Point(549, 153)
            Panel_analisis.Size = New Size(255, 122)

            Provincia.Location = New Point(810, 275)
            Provincia.Size = New Size(332, 142)

            ' Canton.Size = New Size(255, 122)
            Canton.Location = New Point(211, 275)
        End If
    End Sub

    Private Sub Panel_atras2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel_atras2.Click
        sonido2()
        If Provincia.Left = 211 Then

            Provincia.Location = New Point(810, 275)

            Canton.Size = New Size(332, 142)
            Canton.Location = New Point(211, 275)

            Panel_analisis.Location = New Point(549, 153)
            Panel_analisis.Size = New Size(255, 122)

        ElseIf Panel_analisis.Left = 211 Then

            Panel_analisis.Location = New Point(810, 275)
            ' Panel_analisis.Size = New Size(255, 122)

            Provincia.Location = New Point(211, 275)
            Provincia.Size = New Size(332, 142)

            Canton.Size = New Size(255, 122)
            Canton.Location = New Point(549, 153)

        ElseIf Canton.Left = 211 Then

            'Canton.Size = New Size(255, 122)
            Canton.Location = New Point(810, 275)

            Provincia.Location = New Point(549, 153)
            Provincia.Size = New Size(255, 122)

            Panel_analisis.Location = New Point(211, 275)
            Panel_analisis.Size = New Size(332, 142)
            '-------------------------------------------------
        End If
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    '-----------------------------<< ... CLIC FORMULARIOS MOVIMIENTO..ALMACENAR Nº DEL FORMULARIO ... >>--------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Sub ocultar_formularios()
        Canton.Visible = False
        Provincia.Visible = False
        Panel_analisis.Visible = False
        Panel_atras1.Visible = False
        Panel_atras2.Visible = False
    End Sub

    Sub aparecer_formularios()
        Canton.Visible = True
        Provincia.Visible = True
        Panel_analisis.Visible = True
        Panel_atras1.Visible = True
        Panel_atras2.Visible = True
    End Sub

    Private Sub Canton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Canton.Click
        ' conectar()
        If Canton.Left = 549 And Canton.Top = 153 Then

        Else
            n1 = 1
            n2 = 0
            n3 = 0

            P_canton.Visible = True
            ocultar_formularios()
            generar_nuevo()
        End If
       
    End Sub

    Private Sub Provincia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Provincia.Click
        ' conectar()
        If Provincia.Left = 549 And Provincia.Top = 153 Then

        Else
            n2 = 2
            n1 = 0
            n3 = 0

            P_provincia.Visible = True
            ocultar_formularios()
            generar_nuevo()
        End If
       
    End Sub

    Private Sub Panel_analisis_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel_analisis.Click
        'conectar()
        If Panel_analisis.Left = 549 And Panel_analisis.Top = 153 Then

        Else
            n3 = 3
            n1 = 0
            n2 = 0

            P_cultivo.Visible = True
            ocultar_formularios()
            generar_nuevo()
        End If
      
    End Sub

    '-----------------------------------------------------------------------------------------------------------------------------------
    '------------------------------------------------<< ... MENSAJES EN CAJA ... >>-----------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Private Sub txtnombre_c_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnombre_c.Click

        If txtnombre_c.ForeColor = Color.Silver Then
            txtnombre_c.Text = ""
            txtnombre_c.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtnombre_c_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnombre_c.LostFocus
        If Len(txtnombre_c.Text) < 1 Then
            txtnombre_c.ForeColor = Color.Silver
            txtnombre_c.Text = "Ingrese el Cantón"
            txtcodigo_c.Focus()
        End If
    End Sub

    Private Sub txtnombre_p_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnombre_p.Click
        If txtnombre_p.ForeColor = Color.Silver Then
            txtnombre_p.Text = ""
            txtnombre_p.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtnombre_p_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnombre_p.LostFocus
        If Len(txtnombre_p.Text) < 1 Then
            txtnombre_p.ForeColor = Color.Silver
            txtnombre_p.Text = "Ingrese el Cantón"
            txtcodigo_p.Focus()
        End If
    End Sub

    Private Sub txtnombre_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnombre.Click
        If txtnombre.Text = "Ingrese el Cultivo" Then
            txtnombre.Clear()
            txtnombre.ForeColor = Color.Black
        Else
            txtnombre.Text = "Ingrese el Cultivo"
            txtnombre.ForeColor = Color.Silver
        End If
    End Sub

    Private Sub txtnombre_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtnombre.LostFocus
        If Len(txtnombre.Text) < 1 Then
            txtnombre.ForeColor = Color.Silver
            txtnombre.Text = "Ingrese el Cultivo"
            txtcodigo.Focus()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    '---------------------------------------------<< .. CLIC FUERA MENSAJE EN CAJA .. >>------------------------------------------------
    '-----------------------------------------------------------------------------------------------------------------------------------
    Private Sub P_canton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles P_canton.Click
        If Len(txtnombre_c.Text) < 1 Then
            txtnombre_c.ForeColor = Color.Silver
            txtnombre_c.Text = "Ingrese el Cantón"
            txtcodigo_c.Focus()
        End If
    End Sub

    Private Sub P_provincia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles P_provincia.Click
        If Len(txtnombre_p.Text) < 1 Then
            txtnombre_p.ForeColor = Color.Silver
            txtnombre_p.Text = "Ingrese la provincia"
            txtcodigo_p.Focus()
        End If
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------------------
    Private Sub GroupBox3_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Len(txtnombre.Text) < 1 Then
            txtnombre.ForeColor = Color.Silver
            txtnombre.Text = "Ingrese el Cultivo"
            txtcod_cultivo.Focus()
        End If
    End Sub

    Private Sub P_cultivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles P_cultivo.Click
        If Len(txtnombre.Text) < 1 Then
            txtnombre.ForeColor = Color.Silver
            txtnombre.Text = "Ingrese el Cultivo"
            txtcod_cultivo.Focus()
        End If
    End Sub



    Private Sub btnsalirct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalirct.Click
        GroupBox7.Visible = False
    End Sub

    Private Sub btnsalirp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsalirp.Click
        GroupBox6.Visible = False
    End Sub

    Private Sub btnsalirc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalirc.Click
        GroupBox4.Visible = False
    End Sub



    '----------------------------------------------------------------------------------------------------------------------
    '                       ------------------------- LLENAR COMBOBOX ---------------------------
    '----------------------------------------------------------------------------------------------------------------------
    Sub llenar_cultivo()
        Dim dt As DataTable = New DataTable("tb_tipo_cultivo")

        consulta = "SELECT * FROM tb_tipo_cultivo "
        adaptador = New SqlDataAdapter(consulta, conexion)
        cmbcultivo.ValueMember = "cultivo"
        adaptador.Fill(dt)
        cmbcultivo.DataSource = dt
    End Sub
    Sub llenar_provincia()
        Dim dt As DataTable = New DataTable("tb_provincia")

        consulta = "SELECT * FROM tb_provincia "
        adaptador = New SqlDataAdapter(consulta, conexion)
        cmbprovincia.ValueMember = "provincia"
        adaptador.Fill(dt)
        cmbprovincia.DataSource = dt
    End Sub
    Sub llenar_canton()
        Dim dt As DataTable = New DataTable("tb_canton")

        consulta = "SELECT * FROM tb_canton "
        adaptador = New SqlDataAdapter(consulta, conexion)
        cmbcanton.ValueMember = "canton"
        adaptador.Fill(dt)
        cmbcanton.DataSource = dt
    End Sub

    Sub buscar_cultivo()
        Try
            Dim cmd As New SqlCommand("SELECT * FROM tb_tipo_cultivo WHERE codigo=" & a & "", conexion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader

            If dr.Read Then
                txtnpi.Text = dr(2)
                txtppi.Text = dr(3)
                txtkpi.Text = dr(4)

                dr.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub cmbcultivo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbcultivo.SelectedIndexChanged
        a = cmbcultivo.SelectedIndex + 1
        buscar_cultivo()
    End Sub

    '----------------------------------------------------------------------------------------------------------------------
    '             ------------------------------------** CALCULOS A REALIZAR **---------------------------------
    '----------------------------------------------------------------------------------------------------------------------
    Sub calculoNPK()
        txtnr.Text = Val(txtnpi.Text) - Val(txtnpm.Text)
        txtpr.Text = Val(txtppi.Text) - Val(txtppm.Text)
        txtkr.Text = Val(txtkpi.Text) - Val(txtkpm.Text)
        If Val(txtnr.Text) < 0 Then
            txtnr.Text = "0"
        End If
        If Val(txtpr.Text) < 0 Then
            txtpr.Text = "0"
        End If
        If Val(txtkr.Text) < 0 Then
            txtkr.Text = "0"
        End If
    End Sub
    Sub calculosacos()
        '---------------------------------
        'Urea = 46% N                    -
        'Sulfato triple (sft) = 36% P    -
        'Muriato de patasio (mk) = 46% K -
        '---------------------------------
        'Una vez obtenido la resta enter los dos elementos N1-N2, este resultado
        'es multiplicado por el Nº de "Plantas" para luego obtener la cantidad 
        'de <Nitrogeno> total, luego se aplica la formula requerida....
        'Sea dejar la << Urea >> en porcentaje o saco, kg, lib, k, etc....

        '--------------------- EN SACOS ---------------------
        urea = Val(txtnr.Text) * Val(txtplantas.Text)
        t1 = urea / 46 'ureav 'ureav=46 ....SI QUEREMOS EN SACOS SE UTILIA ESTE VALOR
        txturea.Text = t1 / 50 'ureav 'ureav=46......SI QUEREMOS EN KG..

        sft = Val(txtpr.Text) * Val(txtplantas.Text)
        t2 = sft / sftv 'sftv=36
        txtsft.Text = t2 / 50 'sftv=36

        mk = Val(txtkr.Text) * Val(txtplantas.Text)
        t3 = mk / mkv 'mkv=46
        txtntp.Text = t3 / 50

    End Sub
    Sub otros()
        '    lblanalisar.Visible = True
        Panel1.Visible = False
        PictureBox2.Left = 90
        PictureBox2.Top = 185

        PictureBox4.Left = 90
        PictureBox4.Top = 225

        PictureBox3.Visible = False
        PictureBox2.Visible = False
        PictureBox4.Visible = False
        GroupBox13.Visible = False
        GroupBox12.Visible = False
        GroupBox11.Visible = False
    End Sub
    Sub otrosvisualizar()
        '    lblanalisar.Visible = True
        Panel1.Visible = False
        PictureBox2.Left = 90
        PictureBox2.Top = 185

        PictureBox4.Left = 90
        PictureBox4.Top = 225

        PictureBox3.Visible = True
        PictureBox2.Visible = True
        PictureBox4.Visible = True
        GroupBox13.Visible = True
        GroupBox12.Visible = True
        GroupBox11.Visible = True
    End Sub

    '----------------------------------------------------------------------------------------------------------------------
    '                                  ----------------- VALIDAR AL MOVER -----------------
    '----------------------------------------------------------------------------------------------------------------------
    Sub mover1()
        If PictureBox2.Top >= 263 Then
            MsgBox("No se encuentra en los rangos establesidos...", MsgBoxStyle.Exclamation, "Error")
        Else
            '---------------------------------------
            Panel1.Visible = True
            Panel1.Location = New Point(90, 185)
            '---------------------------------------
            ListBox1.ClearSelected()
            PictureBox2.Visible = False
            Timer1.Start()
            Timer2.Start()
        End If
    End Sub
    Sub mover2()
        If PictureBox4.Top >= 263 Then
            MsgBox("No se encuentra en los rangos establesidos...", MsgBoxStyle.Exclamation, "Error")
        Else
            '---------------------------------------
            Panel1.Visible = True
            Panel1.Location = New Point(90, 185)
            '---------------------------------------
            ListBox1.ClearSelected()
            PictureBox4.Visible = False
            Timer1.Start()
            Timer2.Start()
        End If
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '                                 ------------------- Nº ALEATORIOS --------------------
    '----------------------------------------------------------------------------------------------------------------------
    Sub aleatorio1()
        Dim aleatorio1 As New Random
        a1 = aleatorio1.Next(1, 20)
        txtnpm.Text = a1
        Timer1.Stop()
    End Sub
    Sub aleatorio2()
        Dim aleatorio1 As New Random
        a2 = aleatorio1.Next(1, 20)
        txtppm.Text = a2
        Timer2.Stop()
    End Sub
    Sub aleatorio3()
        'Dim aleatorio1 As New Random
        'a3 = aleatorio1.Next(1, 20)
        a3 = Int((9) * Rnd(0) + 1)
        txtkpm.Text = a3
        Timer1.Stop()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        aleatorio1()
        aleatorio3()
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        aleatorio2()
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '          ------------------------------ EVENDO AL MOVER EL OBJETO -----------------------------------
    '----------------------------------------------------------------------------------------------------------------------

    Private Sub PictureBox2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseDown
        movimiento1 = True
    End Sub

    Private Sub PictureBox2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseMove
        If (movimiento1 = True) Then
            If (primovi1 = False) Then
                primovi1 = True
                posicionX1 = e.X
                posicionY1 = e.Y
            End If
            PictureBox2.Location = New Point(e.X + PictureBox2.Location.X - posicionX1, e.Y + PictureBox2.Location.Y - posicionY1)

            'If PictureBox2.Left = 123 And PictureBox2.Left = 208 And PictureBox2.Top = 134 And PictureBox2.Top = 171 Then
            '    'calculoNPK()
            'End If
        End If
    End Sub

    Private Sub PictureBox2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseUp
        movimiento1 = False
        primovi1 = False
        mover1()
    End Sub

    Private Sub PictureBox4_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseDown
        movimiento1 = True
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    Private Sub PictureBox4_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseMove
        If (movimiento1 = True) Then
            If (primovi1 = False) Then
                primovi1 = True
                posicionX1 = e.X
                posicionY1 = e.Y
            End If
            PictureBox4.Location = New Point(e.X + PictureBox4.Location.X - posicionX1, e.Y + PictureBox4.Location.Y - posicionY1)
            'If PictureBox2.Location.X = 44 And PictureBox2.Location.Y = 134 Then
            'If PictureBox4.Left = 123 And PictureBox4.Left = 208 And PictureBox4.Top = 134 And PictureBox4.Top = 171 Then
            '    'calculoNPK()
            'End If
        End If
    End Sub

    Private Sub PictureBox4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox4.MouseUp
        movimiento1 = False
        primovi1 = False
        mover2()
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '-------------------------------------------------<< .. TIMER3 .. >>---------------------------------------------------
    '----------------------------------------------------------------------------------------------------------------------

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        GroupBox8.Visible = True
        lblanalisar.Visible = False
        ' otros()
    End Sub

    Private Sub btnsalir2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir2.Click
        Timer3.Stop()
        GroupBox8.Visible = False
        otrosvisualizar()
        btnatras3.Visible = True
        sonido2()
    End Sub


    Private Sub lbldetalles_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbldetalles.MouseHover
        pictbtierrafranca.Visible = True
        lbltfranca.Visible = True
    End Sub

    Private Sub lbldetalles_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbldetalles.MouseLeave
        pictbtierrafranca.Visible = False
        lbltfranca.Visible = False
    End Sub
    '----------------------------------------------------------------------------------------------------------------------
    '             ------------------------------------** CALCULOS A REALIZAR **---------------------------------
    '----------------------------------------------------------------------------------------------------------------------
    Sub analizar()
        Timer3.Start()
        lblanalisar.Visible = True
        otros()

        If Val(txtnpm.Text) > Val(txtnpi.Text) And Val(txtppm.Text) > Val(txtppi.Text) And Val(txtkpm.Text) > Val(txtkpi.Text) Then

            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("El suelo no esta acto para")
            ListBox1.Items.Add("este tipo de cultivo sobre-")
            ListBox1.Items.Add("pasa los límites requeridos")
            ListBox1.Items.Add("----------------------------------------------")
            lbltfranca.Text = "T. arenosa"
            pictbtierrafranca.Image = My.Resources.tierraarenosa
            ListBox1.Visible = True


        ElseIf Val(txtnpm.Text) > Val(txtnpi.Text) And Val(txtppm.Text) < Val(txtppi.Text) And Val(txtkpm.Text) < Val(txtkpi.Text) Then
            Dim an = Val(txtnpm.Text)
            ListBox1.Visible = True
            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("El suelo exede de Nitrogeno")
            ListBox1.Items.Add("con un porcentaje de")
            ListBox1.Items.Add(an)
            ListBox1.Items.Add("----------------------------------------------")

            calculoNPK()
            calculosacos()
            lbltfranca.Text = "T. organicas"
            pictbtierrafranca.Image = My.Resources.tierraorganicas

        ElseIf Val(txtppm.Text) > Val(txtppi.Text) And Val(txtnpm.Text) < Val(txtnpi.Text) And Val(txtkpm.Text) < Val(txtkpi.Text) Then
            Dim ap = Val(txtppm.Text)

            ListBox1.Visible = True
            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("El suelo exede de Fosforo")
            ListBox1.Items.Add("con un porcentaje de")
            ListBox1.Items.Add(ap)
            ListBox1.Items.Add("----------------------------------------------")

            calculoNPK()
            calculosacos()
            lbltfranca.Text = "T. organicas"
            pictbtierrafranca.Image = My.Resources.tierraorganicas

        ElseIf Val(txtkpm.Text) > Val(txtkpi.Text) And Val(txtnpm.Text) < Val(txtnpi.Text) And Val(txtppm.Text) < Val(txtppi.Text) Then
            Dim ak = Val(txtkpm.Text)
            Dim ak2 = Val(txtnpm.Text)

            ListBox1.Visible = True
            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("El suelo exede de Potasio")
            ListBox1.Items.Add("y nitrogeno con un porcentaje")
            ListBox1.Items.Add(ak)
            ListBox1.Items.Add(ak2)
            ListBox1.Items.Add("----------------------------------------------")

            calculoNPK()
            calculosacos()
            lbltfranca.Text = "T. organicas"
            pictbtierrafranca.Image = My.Resources.tierraorganicas
            '----------------------------------------------------------------------------------------------------------------
            '                       --------------------- IGUALES -------------------------------
            '----------------------------------------------------------------------------------------------------------------
        ElseIf Val(txtkpm.Text) = Val(txtkpi.Text) And Val(txtnpm.Text) = Val(txtnpi.Text) And Val(txtppm.Text) = Val(txtppi.Text) Then
            Dim ak = Val(txtkpm.Text)

            ListBox1.Visible = True
            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("No es necesario tratar el suelo")
            ListBox1.Items.Add("cuenta  con  los  nutrientes ")
            ListBox1.Items.Add("ideales  para  que  el cultivo ")
            lbltfranca.Text = "T. francas"
            pictbtierrafranca.Image = My.Resources.tierrafranca

        ElseIf Val(txtnpm.Text) = Val(txtnpi.Text) And Val(txtppm.Text) = Val(txtppi.Text) And Val(txtkpm.Text) < Val(txtkpi.Text) Then

            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("Tiene buena aceptación para")
            ListBox1.Items.Add("poder sembrar este cultivo ")
            ListBox1.Items.Add("----------------------------------------------")
            lbltfranca.Text = "T. francas"
            pictbtierrafranca.Image = My.Resources.tierrafranca

            ListBox1.Visible = True
            calculoNPK()
            calculosacos()

        ElseIf Val(txtnpm.Text) = Val(txtnpi.Text) And Val(txtppm.Text) = Val(txtppi.Text) And Val(txtkpm.Text) > Val(txtkpi.Text) Then
            Dim pt1 = txtkpi.Text
            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("El suelo esta acto para")
            ListBox1.Items.Add("este tipo de cultivo ")
            ListBox1.Items.Add("aunque sobrepaso en potasio ")
            ListBox1.Items.Add(pt1)
            ListBox1.Items.Add("----------------------------------------------")
            lbltfranca.Text = "T. organicas"
            pictbtierrafranca.Image = My.Resources.tierraorganicas

            ListBox1.Visible = True
            calculoNPK()
            calculosacos()

        ElseIf Val(txtkpm.Text) = Val(txtkpi.Text) And Val(txtnpm.Text) = Val(txtnpi.Text) And Val(txtppm.Text) < Val(txtppi.Text) Then
            Dim ak = Val(txtkpm.Text)

            ListBox1.Visible = True
            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("El suelo requiere de fosforo")
            ListBox1.Items.Add("el resto se ajusta a las  ")
            ListBox1.Items.Add("necesidades requeridas  ")
            lbltfranca.Text = "T. organicas"
            pictbtierrafranca.Image = My.Resources.tierraorganicas
            ListBox1.Items.Add("----------------------------------------------")
            calculoNPK()
            calculosacos()

        ElseIf Val(txtkpm.Text) = Val(txtkpi.Text) And Val(txtnpm.Text) < Val(txtnpi.Text) And Val(txtppm.Text) = Val(txtppi.Text) Then

            ListBox1.Visible = True
            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("El suelo requiere de nitrogeno")
            ListBox1.Items.Add("el resto se ajusta a las  ")
            ListBox1.Items.Add("necesidades requeridas  ")
            lbltfranca.Text = "T. organicas"
            pictbtierrafranca.Image = My.Resources.tierraorganicas
            ListBox1.Items.Add("----------------------------------------------")
            calculoNPK()
            calculosacos()

        ElseIf Val(txtnpm.Text) = Val(txtnpi.Text) And Val(txtppm.Text) = Val(txtppi.Text) And Val(txtkpm.Text) < Val(txtkpi.Text) Then
            Dim ak = Val(txtkpm.Text)

            ListBox1.Visible = True
            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("El suelo requiere de Potasio")
            ListBox1.Items.Add("el resto se ajusta a las  ")
            ListBox1.Items.Add("necesidades requeridas  ")
            lbltfranca.Text = "T. organica"
            pictbtierrafranca.Image = My.Resources.tierraorganicas

            ListBox1.Items.Add("----------------------------------------------")
            calculoNPK()
            calculosacos()

        ElseIf Val(txtnpm.Text) < Val(txtnpi.Text) And Val(txtppm.Text) = Val(txtppi.Text) And Val(txtkpm.Text) < Val(txtkpi.Text) Then

            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("El suelo  esta acto para")
            ListBox1.Items.Add("este tipo de cultivo ")
            ListBox1.Items.Add("----------------------------------------------")
            lbltfranca.Text = "T. arcilloso"
            pictbtierrafranca.Image = My.Resources.tierraarcillosa

            ListBox1.Visible = True
            calculoNPK()
            calculosacos()

        ElseIf Val(txtnpm.Text) = Val(txtnpi.Text) And Val(txtppm.Text) > Val(txtppi.Text) And Val(txtkpm.Text) > Val(txtkpi.Text) Then

            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("El suelo  no esta acto para")
            ListBox1.Items.Add("este tipo de cultivo ")
            ListBox1.Items.Add("----------------------------------------------")
            lbltfranca.Text = "T. arenosa"
            pictbtierrafranca.Image = My.Resources.tierraarenosa

            ListBox1.Visible = True

        ElseIf Val(txtnpm.Text) > Val(txtnpi.Text) And Val(txtppm.Text) > Val(txtppi.Text) And Val(txtkpm.Text) = Val(txtkpi.Text) Then

            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("El suelo  no esta acto para")
            ListBox1.Items.Add("este tipo de cultivo ")
            ListBox1.Items.Add("----------------------------------------------")
            pictbtierrafranca.Image = My.Resources.tierraarenosa

            ListBox1.Visible = True

        ElseIf Val(txtnpm.Text) = Val(txtnpi.Text) And Val(txtppm.Text) > Val(txtppi.Text) And Val(txtkpm.Text) > Val(txtkpi.Text) Then

            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("El suelo no esta acto para")
            ListBox1.Items.Add("este tipo de cultivo sobre-")
            ListBox1.Items.Add("pasa los límites requeridos")
            ListBox1.Items.Add("----------------------------------------------")
            lbltfranca.Text = "T. arenosa"
            pictbtierrafranca.Image = My.Resources.tierraarenosa
            ListBox1.Visible = True

        ElseIf Val(txtnpm.Text) = Val(txtnpi.Text) And Val(txtppm.Text) > Val(txtppi.Text) And Val(txtkpm.Text) < Val(txtkpi.Text) Then

            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("El suelo no esta acto para")
            ListBox1.Items.Add("este tipo de cultivo sobre-")
            ListBox1.Items.Add("pasa los límites requeridos")
            ListBox1.Items.Add("----------------------------------------------")
            lbltfranca.Text = "T. arenosa"
            pictbtierrafranca.Image = My.Resources.tierraarenosa

            ListBox1.Visible = True
            '----------------------------------------------------------------------------------------------------------------
            '                       --------------------- MAYORES 2 -------------------------------
            '----------------------------------------------------------------------------------------------------------------
        ElseIf Val(txtnpm.Text) > Val(txtnpi.Text) And Val(txtppm.Text) > Val(txtppi.Text) And Val(txtkpm.Text) < Val(txtkpi.Text) Then
            ListBox1.Visible = True
            ListBox1.Items.Add("                Atención ")

            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("El suelo no esta acto para")
            ListBox1.Items.Add("este tipo de cultivo sobre-")
            ListBox1.Items.Add("pasa los límites requeridos")
            ListBox1.Items.Add("----------------------------------------------")
            lbltfranca.Text = "T. arenosa"
            pictbtierrafranca.Image = My.Resources.tierraarenosa

        ElseIf Val(txtnpm.Text) > Val(txtnpi.Text) And Val(txtkpm.Text) > Val(txtkpi.Text) And Val(txtkpm.Text) < Val(txtkpi.Text) Then
            ListBox1.Visible = True
            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("El suelo no esta acto para")
            ListBox1.Items.Add("este tipo de cultivo sobre-")
            ListBox1.Items.Add("pasa los límites requeridos")
            ListBox1.Items.Add("----------------------------------------------")
            lbltfranca.Text = "T. arenosa"
            pictbtierrafranca.Image = My.Resources.tierraarenosa

        ElseIf Val(txtnpm.Text) > Val(txtnpi.Text) And Val(txtkpm.Text) = Val(txtkpi.Text) And Val(txtkpm.Text) < Val(txtkpi.Text) Then
            ListBox1.Visible = True
            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("El suelo tiene que ser tratado")
            ListBox1.Items.Add("para cuidar el cultivo")
            ListBox1.Items.Add("----------------------------------------------")
            calculoNPK()
            calculosacos()
            lbltfranca.Text = "T. organicos"
            pictbtierrafranca.Image = My.Resources.tierraorganicas

        ElseIf Val(txtppm.Text) > Val(txtppi.Text) And Val(txtkpm.Text) > Val(txtkpi.Text) And Val(txtkpm.Text) < Val(txtkpi.Text) Then
            ListBox1.Visible = True
            ListBox1.Items.Add("                Atención ")
            ListBox1.Items.Add("----------------------------------------------")
            ListBox1.Items.Add("El suelo no esta acto para")
            ListBox1.Items.Add("este tipo de cultivo sobre-")
            ListBox1.Items.Add("pasa los límites requeridos")
            ListBox1.Items.Add("----------------------------------------------")
            lbltfranca.Text = "T. arenosa"
            pictbtierrafranca.Image = My.Resources.tierraarenosa

        Else
            calculoNPK()
            calculosacos()
            ListBox1.Visible = False
            ListBox2.Visible = True

            ListBox2.Visible = True
            ListBox2.Items.Add("                Atención ")
            ListBox2.Items.Add("----------------------------------------------")
            ListBox2.Items.Add("Tiene buena aceptación para")
            ListBox2.Items.Add("poder sembrar este cultivo ")
            lbltfranca.Text = "T. franca"
            pictbtierrafranca.Image = My.Resources.tierrafranca

        End If
    End Sub
    Private Sub PictureBox3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        analizar()
        txtcultivom.Text = cmbcultivo.Text
    End Sub

    Private Sub txtarea_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtarea.TextChanged
        area = Val(txtarea.Text) * plantas
        txtplantas.Text = (area / 10000)
        calculosacos()
    End Sub

    Private Sub Panel_conton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel_conton.Click
        n4 = 4
        P_analisis.Visible = True
        ocultar_formularios()
        generar_nuevo()
        GroupBox8.Visible = False
        GroupBox14.Visible = False
        llenar_canton()
        llenar_cultivo()
        llenar_provincia()
        Label78.Visible = False
        Label79.Visible = False
    End Sub

    '----------------------------------------------------------------------------------------------------------------------
    '                                  ----------------- <<<<<< REPORTES >>>>>> -----------------
    '----------------------------------------------------------------------------------------------------------------------
    Private Sub R_canton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_canton.Click
        Reporte_Canton.Show()
    End Sub

    Private Sub Panel_ayuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel_ayuda.Click
        AboutBox1.Show()
    End Sub

    Private Sub R_provincia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_provincia.Click
        Reporte_provincia.Show()
    End Sub

    Private Sub R_cultivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_cultivo.Click
        Reporte_cultivo.Show()
    End Sub

    Private Sub R_analisis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles R_analisis.Click
        Reporte_analisis.Show()
    End Sub


    '----------------------------------------------------------------------------------------------------------------------
    '                                  ----------------- CONFIGURACIONES -----------------
    '----------------------------------------------------------------------------------------------------------------------
    Sub configuracion()
        If rdbcolor1.Checked = True Then
            rdbcolor2.Checked = False
            rdbcolor3.Checked = False

            Panel_conton.BackgroundImage = My.Resources.boton_analisis
            Panel_provincia.BackgroundImage = My.Resources.boton_provincia2
            Panel_guardar.BackgroundImage = My.Resources.boton_gruadar3
            Panel_actualizar.BackgroundImage = My.Resources.boton_actualizar3_1
            Panel_eliminar.BackgroundImage = My.Resources.boton_cerrar3
            Panel_cancelar.BackgroundImage = My.Resources.boton_cancelar3
            Panel_buscar.BackgroundImage = My.Resources.boton_buscar3
            Panel_opciones.BackgroundImage = My.Resources.boton_configuracion2
            Panel_ayuda.BackgroundImage = My.Resources.boton_ayuda3
            Panel_cerrar.BackgroundImage = My.Resources.boton_apagar1

        End If
        '------------------------------------------------------------------------------------------------
        If rdbcolor2.Checked = True Then
            rdbcolor1.Checked = False
            rdbcolor3.Checked = False

            Panel_conton.BackgroundImage = My.Resources.boton_analisis2
            Panel_provincia.BackgroundImage = My.Resources.boton_provincia
            Panel_guardar.BackgroundImage = My.Resources.boton_gruadar3_1
            Panel_actualizar.BackgroundImage = My.Resources.boton_actualizar3
            Panel_eliminar.BackgroundImage = My.Resources.boton_cerrar3_1
            Panel_cancelar.BackgroundImage = My.Resources.boton_cancelar3_1
            Panel_buscar.BackgroundImage = My.Resources.boton_buscar3_2
            Panel_opciones.BackgroundImage = My.Resources.boton_configuracion2_1
            Panel_ayuda.BackgroundImage = My.Resources.boton_ayuda3_1
            Panel_cerrar.BackgroundImage = My.Resources.boton_apagar1_1

        End If
        '------------------------------------------------------------------------------------------------
        If rdbcolor3.Checked = True Then
            rdbcolor1.Checked = False
            rdbcolor2.Checked = False

            Panel_conton.BackgroundImage = My.Resources.boton_analisis3
            Panel_provincia.BackgroundImage = My.Resources.boton_provincia2_1
            Panel_guardar.BackgroundImage = My.Resources.boton_gruadar3_2
            Panel_actualizar.BackgroundImage = My.Resources.boton_actualizar3_2
            Panel_eliminar.BackgroundImage = My.Resources.boton_cerrar3_2
            Panel_cancelar.BackgroundImage = My.Resources.boton_cancelar3_2
            Panel_buscar.BackgroundImage = My.Resources.boton_buscar3_1
            Panel_opciones.BackgroundImage = My.Resources.boton_configuracion2_2
            Panel_ayuda.BackgroundImage = My.Resources.boton_ayuda3_2
            Panel_cerrar.BackgroundImage = My.Resources.boton_apagar1_2

        End If
    End Sub

    Private Sub rdbcolor1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbcolor1.CheckedChanged
        configuracion()
    End Sub

    Private Sub rdbcolor2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbcolor2.CheckedChanged
        configuracion()
    End Sub

    Private Sub rdbcolor3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbcolor3.CheckedChanged
        configuracion()
    End Sub
    '-----------------------------------------------------------------------------------------------------------------------

    Private Sub Cerrar_configuracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cerrar_configuracion.Click
        Panel_configuracion.Visible = False
    End Sub

    Private Sub Panel_opciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Panel_opciones.Click
        Panel_configuracion.Visible = True
        rdbcolor1.Checked = True
    End Sub

  
    Private Sub R_canton_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles R_canton.MouseHover
        R_canton.Size = New Size(93, 80)
        sonido()
    End Sub

    Private Sub R_canton_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles R_canton.MouseLeave
        R_canton.Size = New Size(73, 70)
    End Sub

    Private Sub R_provincia_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles R_provincia.MouseHover
        R_provincia.Size = New Size(93, 80)
        sonido()
    End Sub

    Private Sub R_provincia_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles R_provincia.MouseLeave
        R_provincia.Size = New Size(73, 70)
    End Sub

    Private Sub R_cultivo_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles R_cultivo.MouseHover
        R_cultivo.Size = New Size(93, 80)
        sonido()
    End Sub

    Private Sub R_cultivo_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles R_cultivo.MouseLeave
        R_cultivo.Size = New Size(73, 70)
    End Sub

    Private Sub R_analisis_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles R_analisis.MouseHover
        R_analisis.Size = New Size(93, 80)
        sonido()
    End Sub

    Private Sub R_analisis_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles R_analisis.MouseLeave
        R_analisis.Size = New Size(73, 70)
    End Sub

    Private Sub btnatras3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnatras3.Click
        otros()
        GroupBox8.Visible = True
        btnatras3.Visible = False
        sonido2()
    End Sub

    Private Sub btnsalir2_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir2.MouseHover
        btnsalir2.Size = New Point(69, 39)
        Label78.Visible = True
        sonido()
    End Sub

    Private Sub btnsalir2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsalir2.MouseLeave
        btnsalir2.Size = New Point(59, 29)
        Label78.Visible = False
        sonido()
    End Sub

    Private Sub btnatras3_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnatras3.MouseHover
        btnatras3.Size = New Point(69, 39)
        Label79.Visible = True
        sonido()
    End Sub

    Private Sub btnatras3_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnatras3.MouseLeave
        btnatras3.Size = New Point(59, 29)
        Label79.Visible = False
        sonido()
    End Sub
End Class
