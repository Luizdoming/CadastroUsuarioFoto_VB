Imports System.IO

Module Converter_imagem

    Public Sub ConverterImg()

        Dim file As New Int32
        Dim mstream As New MemoryStream
        Dim picture() As Byte

        formUser.img.Image.Save(mstream, Imaging.ImageFormat.Jpeg)
        picture = mstream.GetBuffer
        file = mstream.Length
        mstream.Close()

    End Sub

    Public Sub Limpar()
        formUser.txt_cpf.Clear()
        formUser.txt_nome.Clear()
        formUser.txt_rg.Clear()
        formUser.txt_pass.Clear()
        formUser.img.Image = Nothing
    End Sub

    Public Sub convert_normal()

        'convertendo imagem de byte para formato jpg
        Dim img() As Byte
        Dim dt As DataTable
        formUser.img.Image = Nothing

        Try
            Conectar()
            sql = "SELECT Nome ,Img FROM tbuser WHERE Nome = @Nome"
            cmd = New SQLite.SQLiteCommand(sql, con)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Nome", formUser.combo_name.Text)
            Da = New SQLite.SQLiteDataAdapter
            dt = New DataTable
            Da.SelectCommand = cmd
            Da.Fill(dt)

            img = dt.Rows(0).Item("Img")

            Dim mstream As New System.IO.MemoryStream(img)
            formUser.img.Image = Image.FromStream(mstream)
            Desconect()

        Catch ex As Exception
            MsgBox("Erro ao converter imagem" & ex.Message, MsgBoxStyle.ApplicationModal)
            Desconect()
            Exit Sub
        End Try

    End Sub

    Public Sub preencher_combobox()
        Try
            Conectar()
            'limpando a combobox antes de iniciar a adção dos dados
            formUser.combo_name.Items.Clear()
            sql = "SELECT Nome FROM tbuser"
            cmd = New SQLite.SQLiteCommand(sql, con)
            dr = cmd.ExecuteReader

            'loop para adcionar os dados na combobox
            While dr.Read
                formUser.combo_name.Items.Add(dr.GetString(0))
            End While

            Desconect()

        Catch ex As Exception
            MsgBox("Erro a Adcionar os dados dentro da combobox!" & ex.Message, MsgBoxStyle.ApplicationModal)
            Desconect()
            Exit Sub
        End Try

    End Sub

End Module
