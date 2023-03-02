Public Class Frmmain
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OptionsToolStripMenuItem.Click

    End Sub

    Private Sub LoadDataToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadDataToolStripMenuItem.Click
        Dim frmloaddata As FrmloadStudentdata = New FrmloadStudentdata()
        frmloaddata.MdiParent = Me
        frmloaddata.Show()
    End Sub

    Private Sub SearchScreenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SearchScreenToolStripMenuItem.Click
        Dim frmsearchdata As SearchStudent = New SearchStudent()
        frmsearchdata.MdiParent = Me
        frmsearchdata.Show()
    End Sub
End Class