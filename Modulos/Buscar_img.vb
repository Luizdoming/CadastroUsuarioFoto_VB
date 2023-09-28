Module Buscar_img

    Public Function Buscar()

        Dim file As New OpenFileDialog

        If file.ShowDialog <> DialogResult.Cancel Then
            formUser.img.Image = Image.FromFile(file.FileName)
        Else
            formUser.img.Image = Nothing
        End If

        Return file

    End Function

End Module
