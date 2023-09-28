Module Cadastrar_users
    Public Sub Cad_user()
        ' [ x ] ->  verificar se os campos estão preenchidos
        ' [ x ] ->  realizar a conexão com o banco de dados
        ' [ x ] ->  verificar se o usuario ja está cadastrado
        ' [ x ] ->  verificar se a quantidade de caracteres digitados está correto
        ' [ x ] ->  realizar o cadastro
        '=====================================================================================================
        ' AQUI VAI UMA OBS: O BANCO DE DADOS TEM QUE ESTÁ DENTRO DA PASTA ONDE O APP - O EXECUTAVEL VAI ESTÁ
        ' CASO CONTRARIO IRA GERAR UM ERRO DE TABLE NO SUCH - TABELA NÃO ENCONTRADA
        '======================================================================================================


        'Verificando os campos se estão preenchidos
        Dim cont As Control

        For Each cont In formUser.GroupBox1.Controls
            If TypeOf cont Is TextBox Or TypeOf cont Is MaskedTextBox Then
                If cont.Text = String.Empty Then
                    MsgBox("Os campos são todos obrigatórios")
                    cont.Focus()
                    Exit Sub
                End If
            End If
        Next
        '-------------------------------------------------------------------------------------------

        Try
            'realizar a conexao com banco de dados
            Conectar()
            sql = "SELECT * FROM tbuser"

            'verificar se o usuario ja está cadastrado
            Dim user As String
            cmd = New SQLite.SQLiteCommand(sql, con)
            dr = cmd.ExecuteReader
            user = formUser.txt_cpf.Text

            While dr.Read
                If dr.GetString(1) = user Then
                    MsgBox("Usuário ja esta cadastrado...", MsgBoxStyle.Information, "Atenção")
                    Desconect()
                    Exit Sub
                End If
            End While

            'verificar a quantidade de caracter digitado na caixa de senha 000.000.000-00
            If formUser.txt_cpf.TextLength < 14 Then
                MsgBox("Digite uma quantidade válida de caracteres no campo CPF ", MsgBoxStyle.ApplicationModal)
                Desconect()
                Exit Sub
            ElseIf formUser.txt_pass.TextLength < 8 Then
                MsgBox("Digite no minimo 8 caracteres...", MsgBoxStyle.Information, "Atenção")
                Desconect()
                Exit Sub
            End If

            'realizar o cadastro
            Desconect()
            Conectar()
            sql = "INSERT INTO tbuser (Nome, RG, CPF, Senha, Img) VALUES(@Nome, @RG, @CPF, @Senha, @Img)"
            cmd = New SQLite.SQLiteCommand(sql, con)
            cmd.Parameters.AddWithValue("@Nome", formUser.txt_nome.Text)
            cmd.Parameters.AddWithValue("@RG", formUser.txt_rg.Text)
            cmd.Parameters.AddWithValue("@CPF", formUser.txt_cpf.Text)
            cmd.Parameters.AddWithValue("@Senha", formUser.txt_pass.Text)

            If formUser.img.Image Is Nothing Then
                cmd.Parameters.AddWithValue("@Img", Nothing)
                cmd.ExecuteNonQuery()
                MsgBox("Usuario cadastrado com sucesso!", MsgBoxStyle.Exclamation, "Salvo")
                Desconect()
            Else
                ConverterImg()
                cmd.ExecuteNonQuery()
                MsgBox("Usuario cadastrado com sucesso!", MsgBoxStyle.Exclamation, "Salvo")
                Desconect()
            End If

            Call Limpar()

        Catch ex As Exception
            MsgBox(ex.Message)
            Desconect()
            Exit Sub
        End Try

    End Sub
End Module
