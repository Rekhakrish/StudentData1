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
        Dim con As SqlConnection = New SqlConnection("Data Source=NLTI155\SQLEXPRESS;Initial Catalog=Studentdata;Integrated Security=True")

        'Path for threee folserd in D drive
        Dim unprocesspath As String = "D:\StudentData\Unprocesssed\StudentMarks.csv"
        Dim processpath As String = "D:\StudentData\Processed\StudentMarks.csv"
        Dim errorpath As String = "D:\StudentData\ErrorFolder\StudentMarks.csv"
        Dim success As Boolean = False
        Dim rowcount As Integer


        'creating a list for Dictionary
        Dim studentlist As New List(Of Dictionary(Of String, List(Of String)))

        'check folder is exist or not
        Try

            If Not File.Exists(unprocesspath) Then
                MessageBox.Show("File is not available in Folder")
                Return
                'IF exist  read the data in CSV
            Else
                Dim csvReader As New TextFieldParser("D:\StudentData\Unprocesssed\StudentMarks.csv")
                csvReader.Delimiters = New String() {","}
                csvReader.TextFieldType = FieldType.Delimited

                rowcount = 0

                'Emptylist created for unique value in key
                Dim StudentEmptyList As New List(Of String)


                While csvReader.EndOfData() = False
                    Dim fields = csvReader.ReadFields()

                    If fields(0) <> "StudentName" Then
                        If StudentEmptyList.Contains(fields(1)) Then
                            Dim countpurpose As String = "check count"

                        Else
                            StudentEmptyList.Add(fields(1))
                        End If

                    End If

                    rowcount += 1

                End While
                csvReader.Close()

                'While Reading CSV File split and read field by field 
                For Each S As String In StudentEmptyList
                    Dim csvReader1 As New TextFieldParser("D:\StudentData\Unprocesssed\StudentMarks.csv")
                    csvReader1.Delimiters = New String() {","}
                    csvReader1.TextFieldType = FieldType.Delimited
                    While csvReader1.EndOfData() = False
                        Dim fields = csvReader1.ReadFields()

                        'Creating Dictionary for get key and values
                        Dim myDictionary As New Dictionary(Of String, List(Of String))
                        If fields(1) = S Then
                            myDictionary.Add(fields(1), New List(Of String) From {fields(0), fields(2), fields(3)})
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
                                        File.Delete(errorpath)
                                    End If
                                    File.Move(unprocesspath, errorpath)
                                    isfilehaserror = True
                                    GoTo endofcode
                                    'Else
                                    '    Dim cmd As SqlCommand = New SqlCommand($" insert into studentmarks(subjectid,studentid,studentmark) values({subjectID},{studentID},{Studentkeyvalue.Value(1)})", con)
                                    '    cmd.ExecuteNonQuery()

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
                        File.Delete(processpath)
                    End If

                    File.Move(unprocesspath, processpath)
                    success = True
                Else
                    MessageBox.Show($"Row count is :{rowcount} - Row Count should not be zero")
                    If File.Exists(errorpath) Then
                        File.Delete(errorpath)
                    End If
                    File.Move(unprocesspath, errorpath)

                End If
            End If

        Catch ex As Exception
            'Move to error folder

            MessageBox.Show(ex.Message)
            success = False

        End Try



        'Show message
        If success Then
            MessageBox.Show("Successfully Processed :" & rowcount & " Rows  ")
            'Else
            '    MessageBox.Show("Error")
        End If
    End Sub
End Class
