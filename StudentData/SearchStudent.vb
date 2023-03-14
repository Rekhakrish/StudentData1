Imports System.Configuration
Imports System.Data.Common
Imports System.Data.SqlClient

Public Class SearchStudent
    Dim pageRows As Integer
    Dim connection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("StudentDATABASE").ConnectionString)
    Private Sub SearchStudent_Load(sender As Object, e As EventArgs)
        Dim rowsPerPage As Integer = 10
        Dim currentPage As Integer = 2
        Dim offset As Integer = (currentPage - 1) * rowsPerPage
        'Put SQLConnection out of event and initialize the connection in any event of the page 
        Dim command As New SqlCommand(" SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark ,m.Id FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid ", connection)
        Dim dataAdapter As New SqlDataAdapter(command)
        Dim dataTable As New DataTable
        dataAdapter.Fill(dataTable)
        DataGridView1.DataSource = dataTable

        'create edit and delete button
        Dim dgcolEditButton As DataGridViewButtonColumn = New DataGridViewButtonColumn()
        dgcolEditButton.HeaderText = "Option Edit"
        DataGridView1.Columns.Add(dgcolEditButton)
        Dim dgcoldeletebutton As DataGridViewButtonColumn = New DataGridViewButtonColumn()
        dgcoldeletebutton.HeaderText = "Option Delete"
        DataGridView1.Columns.Add(dgcoldeletebutton)

    End Sub


    Private Sub Btnsearch_Click_1(sender As Object, e As EventArgs) Handles Btnsearch.Click

        'Get user input
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        Dim studentName As String = TxtStudentName.Text
        Dim studentRollNo As String = TxtStudentrollno.Text
        Dim subject As String = TxtSubject.Text


        If studentName <> Nothing And studentRollNo = Nothing And subject = Nothing Then

            Dim command As New SqlCommand(" SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark,m.Id FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid where Studentname='" & studentName & "' ", connection)
            Dim dataAdapter As New SqlDataAdapter(command)
            Dim dt1 As New DataTable
            dataAdapter.Fill(dt1)
            DataGridView1.DataSource = dt1
        ElseIf studentRollNo <> Nothing And studentName = Nothing And subject = Nothing Then

            Dim command As New SqlCommand("SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark,m.Id FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid where studentRollNo='" & studentRollNo & "'", connection)
            Dim dataAdapter As New SqlDataAdapter(command)
            Dim dt1 As New DataTable
            dataAdapter.Fill(dt1)
            DataGridView1.DataSource = dt1
        ElseIf subject <> Nothing And studentRollNo = Nothing And studentName = Nothing Then
            Dim command As New SqlCommand("SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark,m.Id FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid where SubjectName='" & subject & "'", connection)
            Dim dataAdapter As New SqlDataAdapter(command)
            Dim dt1 As New DataTable
            dataAdapter.Fill(dt1)
            DataGridView1.DataSource = dt1
        ElseIf studentName <> Nothing And subject <> Nothing And studentRollNo = Nothing Then
            Dim command As New SqlCommand("SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark,m.Id FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid where Studentname='" & studentName & "' And SubjectName ='" & subject & "'", connection)
            Dim dataAdapter As New SqlDataAdapter(command)
            Dim dt1 As New DataTable
            dataAdapter.Fill(dt1)
            DataGridView1.DataSource = dt1
        ElseIf studentRollNo <> Nothing And subject <> Nothing And studentName = Nothing Then
            Dim command As New SqlCommand("SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark,m.Id FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid where studentRollNo='" & studentRollNo & "' And SubjectName ='" & subject & "'", connection)
            Dim dataAdapter As New SqlDataAdapter(command)
            Dim dt1 As New DataTable
            dataAdapter.Fill(dt1)
            DataGridView1.DataSource = dt1
        ElseIf studentRollNo <> Nothing And subject <> Nothing And studentName <> Nothing Then
            'Query for search in database

            Dim command As New SqlCommand(" SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark,m.Id FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid where Studentname='" & studentName & "' And studentRollNo = '" & studentRollNo & "' And SubjectName='" & subject & "'", connection)
            Dim dataAdapter As New SqlDataAdapter(command)
            Dim dt1 As New DataTable
            dataAdapter.Fill(dt1)
            DataGridView1.DataSource = dt1
        ElseIf studentRollNo = Nothing AndAlso subject = Nothing AndAlso studentName = Nothing Then
            DataGridView1.DataSource = Nothing

            MessageBox.Show("Textbox Should not be Empty")

        End If


        'create edit and delete button
        Dim dgcoleditbutton As DataGridViewButtonColumn = New DataGridViewButtonColumn()
        dgcoleditbutton.HeaderText = "option edit"
        dgcoleditbutton.Name = "edit"
        DataGridView1.Columns.Add(dgcoleditbutton)
        Dim dgcoldeletebutton As DataGridViewButtonColumn = New DataGridViewButtonColumn()
        dgcoldeletebutton.HeaderText = "option delete"
        dgcoleditbutton.Name = "delete"
        DataGridView1.Columns.Add(dgcoldeletebutton)
        For Each datagridrow As DataGridViewRow In DataGridView1.Rows
            datagridrow.Cells(5).Value = "edit"
            datagridrow.Cells(6).Value = "delete"
        Next

    End Sub

    Private Sub DataGridView1_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        Dim formedit As Edit = New Edit()
        formedit.studentobject.id = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        formedit.studentobject.Name = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        formedit.studentobject.subject = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        formedit.studentobject.marks = DataGridView1.Rows(e.RowIndex).Cells(3).Value

        If e.ColumnIndex = 5 Then

            'callind the edit class using object

            formedit.ShowDialog()

            If formedit.studentobject.marks <= 100 Then
                DataGridView1.Rows(e.RowIndex).Cells(3).Value = formedit.studentobject.marks


                'edit the marks using update query
                Dim id As Integer = DataGridView1.Rows(e.RowIndex).Cells(4).Value
                Dim command As New SqlCommand(" Update Studentmarks  set studentmark=" + formedit.studentobject.marks.ToString() + " where Id=" + id.ToString(), connection)
                connection.Open()
                command.ExecuteNonQuery()
                connection.Close()
            Else
                MessageBox.Show("Marks should below 100")
            End If


            Dim command1 As New SqlCommand(" SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark,m.Id FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid where Studentname='" & formedit.studentobject.Name.ToString() & "' And Id = '" & formedit.studentobject.id & "' And SubjectName='" & formedit.studentobject.subject & "'", connection)

            Dim dataAdapter As New SqlDataAdapter(command1)
            Dim dataTable As New DataTable
            dataAdapter.Fill(dataTable)
            DataGridView1.DataSource = Nothing
            DataGridView1.Rows.Clear()
            DataGridView1.Columns.Clear()

            DataGridView1.DataSource = dataTable
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



        ElseIf e.ColumnIndex = 6 Then

            'delete the data from database using id
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
            DataGridView1.DataSource = Nothing
            DataGridView1.Rows.Clear()
            DataGridView1.Columns.Clear()

            Dim command1 As New SqlCommand(" SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark,m.Id FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid where Studentname='" & formedit.studentobject.Name.ToString() & "' And Id = '" & formedit.studentobject.id & "' And SubjectName='" & formedit.studentobject.subject & "'", connection)
            Dim dataAdapter As New SqlDataAdapter(command1)
            Dim dataTable As New DataTable
            dataAdapter.Fill(dataTable)
            DataGridView1.DataSource = Nothing
            DataGridView1.Rows.Clear()
            DataGridView1.Columns.Clear()
            DataGridView1.DataSource = dataTable
        End If



    End Sub

    Private Sub BtnShowAll_Click(sender As Object, e As EventArgs) Handles BtnShowAll.Click

        ' If the Then DataGridView Is bound To any datasource
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()


        Dim command As New SqlCommand(" SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark,m.Id FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid order by m.Id ", connection)
        Dim dataAdapter As New SqlDataAdapter(command)
        Dim dataSet As New DataSet()
        dataAdapter.Fill(dataSet, pageRows, 10, "1stIndex")

        Dim dataTable As New DataTable
        dataTable = dataSet.Tables("1stIndex")

        DataGridView1.DataSource = dataSet.Tables("1stIndex")

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


    Private Sub ButtonNextgrid_Click(sender As Object, e As EventArgs) Handles ButtonNextgrid.Click

        Dim cmd As SqlCommand = New SqlCommand("select count(*) From Studentmarks", connection)


        connection.Open()
        Dim count As Integer = cmd.ExecuteScalar
        connection.Close()
        Dim dataAdapter As New SqlDataAdapter("SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark,m.Id FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid order by m.Id", connection)
        Dim dataSet As New DataSet("1stIndex")

        pageRows = pageRows + 10
        If pageRows >= count Then
            pageRows = 10
            MessageBox.Show("Maximum value Reached")

        End If

        dataSet.Clear()
        dataAdapter.Fill(dataSet, pageRows, 10, "1stIndex")

        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        DataGridView1.DataSource = dataSet.Tables("1stIndex")
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

    Private Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click

        Dim command As SqlCommand = New SqlCommand("select count(*) From Studentmarks", connection)


        connection.Open()
        Dim count As Integer = command.ExecuteScalar
        connection.Close()
        Dim dataAdapter As New SqlDataAdapter("SELECT s.studentname, s.studentrollno, su.subjectname, m.studentmark,m.Id FROM student s INNER JOIN Studentmarks m ON s.studentid = m.studentid INNER JOIN subject su ON m.subjectid = su.subjectid order by m.Id", connection)
        Dim dataSet As New DataSet("1stIndex")

        pageRows = pageRows - 10
        If pageRows < 0 Then

            pageRows = 0
            MessageBox.Show("Minimum value is reached")

        End If

        dataSet.Clear()
        dataAdapter.Fill(dataSet, pageRows, 10, "1stIndex")
        DataGridView1.DataSource = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        DataGridView1.DataSource = dataSet.Tables("1stIndex")
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