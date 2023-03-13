Public Class Frmmain
    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Application.Exit()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LoadDataToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim formloaddata As FrmloadStudentdata = New FrmloadStudentdata()
        formloaddata.MdiParent = Me
        formloaddata.Show()
    End Sub

    Private Sub SearchScreenToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim formsearchdata As SearchStudent = New SearchStudent()
        formsearchdata.MdiParent = Me
        formsearchdata.Show()
    End Sub

    Private Sub LoadDataToolStripMenuItem_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub LoadDataToolStripMenuItem_Click_2(sender As Object, e As EventArgs)

    End Sub

    Private Sub SearchScreenToolStripMenuItem_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub LoadDataToolStripMenuItem_Click_3(sender As Object, e As EventArgs) Handles LoadDataToolStripMenuItem.Click
        Dim formloaddata As FrmloadStudentdata = New FrmloadStudentdata()
        formloaddata.MdiParent = Me
        formloaddata.Show()
    End Sub

    Private Sub SearchScreenToolStripMenuItem_Click_2(sender As Object, e As EventArgs) Handles SearchScreenToolStripMenuItem.Click
        Dim formsearchdata As SearchStudent = New SearchStudent()
        formsearchdata.MdiParent = Me
        formsearchdata.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub
End Class