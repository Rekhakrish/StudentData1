Public Class Edit
    Public Class Student
        Public id As Integer
        Public Name As String
        Public marks As Integer
        Public subject As String
    End Class
    Public studentobject As Student = New Student
    Private Sub Edit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TxtID.Text = studentobject.id
        TxtStudentName.Text = studentobject.Name
        TxtSubject.Text = studentobject.subject
        TxtMark.Text = studentobject.marks
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub ButtonSave_Click(sender As Object, e As EventArgs) Handles ButtonSave.Click
        studentobject.marks = TxtMark.Text

        MessageBox.Show("Data saved")


    End Sub
End Class