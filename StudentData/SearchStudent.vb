Imports System.Data.SqlClient

Public Class SearchStudent

    Dim connection As SqlConnection = New SqlConnection("Data Source=NLTI155\SQLEXPRESS;Initial Catalog=Studentdata;Integrated Security=True")
    Private Sub Btnsearch_Click(sender As Object, e As EventArgs) Handles Btnsearch.Click
        Dim studentName As String = TxtStudentName.Text
        Dim studentRollNo As String = TxtStudentrollno.Text
        Dim subject As String = TxtSubject.Text

        'If TxtStudentName Then
        '    Dim sda1 As New SqlDataAdapter(" SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid where Studentname='" & TxtStudentName.Text & "'", connection)
        '    Dim dt1 As New DataTable
        '    sda1.Fill(dt1)
        '    DataGridView1.DataSource = dt1
        'End If
        Dim command As New SqlCommand(" SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid where Studentname='" & studentName & "' Or studentRollNo = '" & studentRollNo & "' or SubjectName='" & subject & "'", connection)
        Dim sda1 As New SqlDataAdapter(command)
        Dim dt1 As New DataTable
        sda1.Fill(dt1)
        DataGridView1.DataSource = dt1



    End Sub


    Private Sub SearchStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Put SQLConnection out of event and initialize the connection in any event of the page 
        Dim command As New SqlCommand(" SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid;", connection)
        Dim sda As New SqlDataAdapter(command)
        Dim dt As New DataTable
        sda.Fill(dt)
        DataGridView1.DataSource = dt


        Dim dgcolEditButton As DataGridViewButtonColumn = New DataGridViewButtonColumn()
        dgcolEditButton.HeaderText = "Edit"
        DataGridView1.Columns.Add(dgcolEditButton)
        Dim dgcoldeletebutton As DataGridViewButtonColumn = New DataGridViewButtonColumn()
        dgcoldeletebutton.HeaderText = "Delete"
        DataGridView1.Columns.Add(dgcoldeletebutton)
    End Sub
End Class