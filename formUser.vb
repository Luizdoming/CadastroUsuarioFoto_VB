Public Class formUser
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Conectar()
        Call Cad_user()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Application.Exit()
    End Sub

    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click
        Call Buscar()
    End Sub

    Private Sub frm_user_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.txt_pass.PasswordChar = Chr(42)
        Me.txt_nome.CharacterCasing = CharacterCasing.Upper
        Me.txt_cpf.Mask = "000,000,000-00"
        Me.txt_rg.Mask = "00,00,000"
        preencher_combobox()

    End Sub

    Private Sub txt_rg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_rg.KeyPress
        If Not IsNumeric(e.KeyChar) And Asc(e.KeyChar) <> 46 Then
            e.Handled = True
        End If
    End Sub

    Private Sub txt_cpf_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txt_cpf.KeyPress
        If Not IsNumeric(e.KeyChar) And Asc(e.KeyChar) <> 46 Then
            e.Handled = True
        End If
    End Sub

    Private Sub combo_name_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_name.SelectedIndexChanged
        convert_normal()
    End Sub
End Class
