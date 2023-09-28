Imports System.Data.SQLite

Module conexao_sqlite
    '*****************************************************************************************************
    Public con As SQLiteConnection ' variavel para conexao com database
    Public sql As String           ' variavel para comandos sql 
    Public DT As DataTable         ' variavel para criação de um datatable 
    Public Da As SQLiteDataAdapter ' para preencher os dados do datatable
    Public dr As SQLiteDataReader  ' para carregar os dados do banco
    Public cmd As SQLiteCommand
    '*****************************************************************************************************

    Public Sub Conectar()

        Dim base_name As String = "myUser.db"
        Dim caminho As String = Application.StartupPath & "\" & base_name

        Try
            con = New SQLiteConnection("Data Source = " & caminho & "; Version = 3")
            con.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub

    Public Sub Desconect()
        Try
            con.Close()
            con.Dispose()
            con = Nothing
            cmd = Nothing

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

End Module
