Imports System.Configuration
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.WebRequestMethods
Imports Microsoft.VisualBasic.FileIO
Imports File = System.IO.File


Public Class FrmloadStudentdata

    Private Sub Btnstartprocess_Click(sender As Object, e As EventArgs)



    End Sub

    Private Sub btnsearchform_Click(sender As Object, e As EventArgs)
        SearchStudent.Show()
        Me.Hide()
    End Sub

    Private Sub Btnstartprocess_Click_1(sender As Object, e As EventArgs) Handles Btnstartprocess.Click
        'Connection For database
        Dim con As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("StudentDATABASE").ConnectionString)

        'Path for threee folserd in D drive
        Dim unprocesspath As String = ConfigurationManager.AppSettings("Unprocessed")
        Dim processpath As String = ConfigurationManager.AppSettings("Processed")
        Dim errorpath As String = ConfigurationManager.AppSettings("Error")
        Dim fileName As String = System.IO.Path.GetFileNameWithoutExtension(unprocesspath)

        Dim fileExt As String = System.IO.Path.GetExtension(unprocesspath)
        Dim currentDate As String = DateTime.Now.ToString("(ss/mm/H)+(d/M/yyyy)")

        Dim success As Boolean = False
        Dim rowcount As Integer


        'creating a list for Dictionary
        Dim studentlist As New List(Of Dictionary(Of String, List(Of String)))



        'Emptylist created for unique value in key
        Dim StudentEmptyList As New List(Of String)

        'check folder is exist or not
        Try

            If Not File.Exists(unprocesspath) Then
                MessageBox.Show("File is not available in Folder")
                Return
                'IF exist  read the data in CSV
            Else
                Dim csvReader As New TextFieldParser(unprocesspath)
                csvReader.Delimiters = New String() {","}
                csvReader.TextFieldType = FieldType.Delimited

                rowcount = 0


                While csvReader.EndOfData() = False
                    Dim fields = csvReader.ReadFields()
                    Dim studentName As String = fields(0)
                    Dim studentRollNo As String = fields(1)


                    If studentName <> "StudentName" Then
                        If StudentEmptyList.Contains(studentRollNo) Then
                            Dim countpurpose As String = "check count"

                        Else
                            StudentEmptyList.Add(studentRollNo)
                        End If

                    End If

                    rowcount += 1

                End While
                csvReader.Close()

                'While Reading CSV File split and read field by field 
                For Each list As String In StudentEmptyList
                    Dim csvReader1 As New TextFieldParser(unprocesspath)
                    csvReader1.Delimiters = New String() {","}
                    csvReader1.TextFieldType = FieldType.Delimited
                    While csvReader1.EndOfData() = False
                        Dim fields = csvReader1.ReadFields()
                        Dim studentName As String = fields(0)
                        Dim studentRollNo As String = fields(1)
                        Dim subjectMarks As String = fields(2)
                        Dim subjectName As String = fields(3)
                        'Creating Dictionary for get key and values
                        Dim myDictionary As New Dictionary(Of String, List(Of String))
                        If studentRollNo = list Then
                            myDictionary.Add(studentRollNo, New List(Of String) From {studentName, subjectMarks, subjectName})
                            studentlist.Add(myDictionary)
                        End If


                    End While
                    csvReader1.Close()

                Next
                'Connection open for database
                con.Open()

                Dim isfilehaserror As Boolean = False
                'Checking every list and keyvalue pair in list of Dictionary
                For Each student As String In StudentEmptyList
                    For Each dict As Dictionary(Of String, List(Of String)) In studentlist
                        For Each Studentkeyvalue As KeyValuePair(Of String, List(Of String)) In dict
                            If Studentkeyvalue.Key = student Then

                                'After reading the marks insert into studentmark table
                                Dim command As SqlCommand = New SqlCommand($"select studentid from student where StudentName = '{Studentkeyvalue.Value(0)}'", con)
                                Dim rd As SqlDataReader = command.ExecuteReader()
                                rd.Read()
                                Dim studentID As Integer = rd("Studentid")
                                rd.Close()

                                Dim command1 As SqlCommand = New SqlCommand($"select subjectID from Subject where SubjectName = '{Studentkeyvalue.Value(2)}'", con)
                                Dim rd1 As SqlDataReader = command1.ExecuteReader()
                                rd1.Read()
                                Dim subjectID As Integer = rd1("subjectId")
                                rd1.Close()

                                If studentID <= 0 Or subjectID <= 0 Then
                                    MessageBox.Show("File is having the invalid data,Moving the datafile to error Folder")
                                    If File.Exists(errorpath) Then

                                    End If
                                    File.Move(unprocesspath, errorpath + fileName + currentDate + fileExt)
                                    isfilehaserror = True
                                    GoTo endofcode


                                End If

                            End If
                        Next
                    Next
                Next
                'File is Good Save data to database
                For Each student As String In StudentEmptyList
                    For Each dict As Dictionary(Of String, List(Of String)) In studentlist
                        For Each Studentkeyvalue As KeyValuePair(Of String, List(Of String)) In dict
                            If Studentkeyvalue.Key = student Then

                                'After reading the marks insert into studentmark table
                                Dim command As SqlCommand = New SqlCommand($"select studentid from student where StudentName = '{Studentkeyvalue.Value(0)}'", con)
                                Dim rd As SqlDataReader = command.ExecuteReader()
                                rd.Read()
                                Dim studentID As Integer = rd("Studentid")
                                rd.Close()

                                Dim command1 As SqlCommand = New SqlCommand($"select subjectID from Subject where SubjectName = '{Studentkeyvalue.Value(2)}'", con)
                                Dim rd1 As SqlDataReader = command1.ExecuteReader()
                                rd1.Read()
                                Dim subjectID As Integer = rd1("subjectId")
                                rd1.Close()


                                Dim cmd As SqlCommand = New SqlCommand($" insert into studentmarks(subjectid,studentid,studentmark) values({subjectID},{studentID},{Studentkeyvalue.Value(1)})", con)
                                cmd.ExecuteNonQuery()



                            End If
                        Next
                    Next
                Next
endofcode:
                con.Close()
                If isfilehaserror Then


                ElseIf rowcount > 0 Then
                    MessageBox.Show($"Successfully processed student data csv total number of rows = {rowcount}")
                    ' File Move to processed folder
                    If File.Exists(processpath) Then

                    End If
                    File.Move(unprocesspath, processpath + fileName + currentDate + fileExt)
                    success = True
                Else
                    MessageBox.Show($"Row count is :{rowcount} - Row Count should not be zero")
                    'File Move to Error Path
                    If File.Exists(errorpath) Then

                    End If
                    File.Move(unprocesspath, errorpath + fileName + currentDate + fileExt)

                End If
            End If

        Catch ex As Exception
            'If any error while processing it will throw error message

            MessageBox.Show(ex.Message)
            success = False

        End Try



        'Show message
        If success Then
            MessageBox.Show("Successfully Processed :" & StudentEmptyList.count & " Rows  ")

        End If
    End Sub
End Class
