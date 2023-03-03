Imports System.Data.SqlClient

Public Class SearchStudent

    Dim connection As SqlConnection = New SqlConnection("Data Source=NLTI155\SQLEXPRESS;Initial Catalog=Studentdata;Integrated Security=True")
    Private Sub Btnsearch_Click(sender As Object, e As EventArgs)




    End Sub


    Private Sub SearchStudent_Load(sender As Object, e As EventArgs)
        'Put SQLConnection out of event and initialize the connection in any event of the page 
        Dim command As New SqlCommand(" SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark ,m.Id FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid;", connection)
        Dim sda As New SqlDataAdapter(command)
        Dim dt As New DataTable
        sda.Fill(dt)
        DataGridView1.DataSource = dt


        Dim dgcolEditButton As DataGridViewButtonColumn = New DataGridViewButtonColumn()
        dgcolEditButton.HeaderText = "Option Edit"
        DataGridView1.Columns.Add(dgcolEditButton)
        Dim dgcoldeletebutton As DataGridViewButtonColumn = New DataGridViewButtonColumn()
        dgcoldeletebutton.HeaderText = "Option Delete"
        DataGridView1.Columns.Add(dgcoldeletebutton)
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)
        'If DataGridView1.Columns(e.ColumnIndex).Name = "Edit" Then
        '    Dim r1 As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        '    Dim subject As String = r1.Cells(4).Value
        '    Dim roll As String = r1.Cells(5).Value
        '    Dim submarks As String = r1.Cells(3).Value
        '    ' Dim cmd6 As SqlCommand = New SqlCommand($"update studentdetails set  submarks='{submarks}' where subname='{subject}' And studentroll='{roll}';", Con1)
        '    'cmd6.Parameters.AddWithValue($"{mark}", Row.cellsValue)
        '    'Con1.Open()
        '    ' cmd6.ExecuteNonQuery()
        '    ' Con1.Close()
        '    ' Con1.Open()
        '    ' Dim adp As New SqlDataAdapter("select * from studentdetails", Con1)
        '    Dim table As New DataTable()
        '    ' adp.Fill(table)
        '    ' Con1.Close()
        '    DataGridView1.DataSource = table.DefaultView
        'End If

    End Sub

    Private Sub Btnsearch_Click_1(sender As Object, e As EventArgs) Handles Btnsearch.Click
        Dim studentName As String = TxtStudentName.Text
        Dim studentRollNo As String = TxtStudentrollno.Text
        Dim subject As String = TxtSubject.Text
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        Dim command As New SqlCommand(" SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark,m.Id FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid where Studentname='" & studentName & "' Or studentRollNo = '" & studentRollNo & "' or SubjectName='" & subject & "'", connection)
        Dim sda1 As New SqlDataAdapter(command)
        Dim dt1 As New DataTable
        sda1.Fill(dt1)
        DataGridView1.DataSource = dt1

        Dim dgcolEditButton As DataGridViewButtonColumn = New DataGridViewButtonColumn()
        dgcolEditButton.HeaderText = "Option Edit"
        dgcolEditButton.Name = "Edit"
        DataGridView1.Columns.Add(dgcolEditButton)
        Dim dgcoldeletebutton As DataGridViewButtonColumn = New DataGridViewButtonColumn()
        dgcoldeletebutton.HeaderText = "Option Delete"
        dgcolEditButton.Name = "Delete"
        DataGridView1.Columns.Add(dgcoldeletebutton)
        For Each datagridrow As DataGridViewRow In DataGridView1.Rows
            datagridrow.Cells(5).Value = "Edit"
            datagridrow.Cells(6).Value = "Delete"
        Next

    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.ColumnIndex = 5 Then

            Dim frmedit As Edit = New Edit()
            frmedit.studentobject.id = DataGridView1.Rows(e.RowIndex).Cells(4).Value
            frmedit.studentobject.Name = DataGridView1.Rows(e.RowIndex).Cells(0).Value
            frmedit.studentobject.subject = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            frmedit.studentobject.marks = DataGridView1.Rows(e.RowIndex).Cells(3).Value
            frmedit.ShowDialog()
            DataGridView1.Rows(e.RowIndex).Cells(3).Value = frmedit.studentobject.marks

            Dim id As Integer = DataGridView1.Rows(e.RowIndex).Cells(4).Value
            Dim command As New SqlCommand(" Update Studentmarks  set studentmark=" + frmedit.studentobject.marks.ToString() + " where Id=" + id.ToString(), connection)
            connection.Open()
            command.ExecuteNonQuery()
            connection.Close()


        ElseIf e.ColumnIndex = 6 Then
            Dim userdelete As MessageBoxButtons
            userdelete = MessageBox.Show("Do you want to delete this row?", "Confirm Delete", MessageBoxButtons.OKCancel)
            If userdelete.OK = MessageBoxButtons.OK Then
                'Delete the row from database
                'Delete from student marks where id=datagridview.rows 
                Dim id As Integer = DataGridView1.Rows(e.RowIndex).Cells(4).Value
                Dim command As New SqlCommand(" Delete  Studentmarks where Id=" + id.ToString(), connection)
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
                DataGridView1.Rows.RemoveAt(e.RowIndex)
            End If
        End If
    End Sub

    Private Sub BtnShowAll_Click(sender As Object, e As EventArgs) Handles BtnShowAll.Click
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()

        Dim command As New SqlCommand(" SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark,m.Id FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid order by m.Id", connection)
        Dim sda1 As New SqlDataAdapter(command)
        Dim dt1 As New DataTable
        sda1.Fill(dt1)
        DataGridView1.DataSource = dt1

        Dim dgcolEditButton As DataGridViewButtonColumn = New DataGridViewButtonColumn()
        dgcolEditButton.HeaderText = "Option Edit"
        dgcolEditButton.Name = "Edit"
        DataGridView1.Columns.Add(dgcolEditButton)
        Dim dgcoldeletebutton As DataGridViewButtonColumn = New DataGridViewButtonColumn()
        dgcoldeletebutton.HeaderText = "Option Delete"
        dgcolEditButton.Name = "Delete"
        DataGridView1.Columns.Add(dgcoldeletebutton)
        For Each datagridrow As DataGridViewRow In DataGridView1.Rows
            datagridrow.Cells(5).Value = "Edit"
            datagridrow.Cells(6).Value = "Delete"
        Next

    End Sub
End Class