Imports System.Data.SqlClient
Imports System.IO
Imports System.Net.WebRequestMethods
Imports Microsoft.VisualBasic.FileIO
Imports File = System.IO.File

Public Class Form1

    Private Sub Btnstartprocess_Click(sender As Object, e As EventArgs) Handles Btnstartprocess.Click
        Dim con As SqlConnection = New SqlConnection("Data Source=NLTI155\SQLEXPRESS;Initial Catalog=Studentdata;Integrated Security=True")
        Dim unprocesspath As String = "D:\StudentData\Unprocesssed\StudentMarks.csv"
        Dim processpath As String = "D:\StudentData\Processed\StudentMarks.csv"
        Dim errorpath As String = "D:\StudentData\ErrorFolder\StudentMarks.csv"
        Dim success As Boolean = False
        ' Dim filename As String
        Dim rowcount As Integer
        'Dim fstream As FileStream
        'Dim Swriter As StreamWriter
        'Dim sreader As StreamReader
        ' fstream = New FileStream("C:\Student Data\UnProcessed\StudentMarks.csv", FileMode.Open, FileAccess.Read)
        'Dim filepath As String = "C:\Student Data\UnProcessed\StudentMarks.csv"


        Dim studentlist As New List(Of Dictionary(Of String, List(Of String)))
        'check folder is exist or not
        Try

            If Not File.Exists(unprocesspath) Then
                MessageBox.Show("File is not available in Folder")
            Else

                Dim csvReader As New TextFieldParser("D:\StudentData\Unprocesssed\StudentMarks.csv")
                csvReader.Delimiters = New String() {","}
                csvReader.TextFieldType = FieldType.Delimited

                rowcount = 0
                Dim EmptyList As New List(Of String)
                ' Dim row As String

                While csvReader.EndOfData() = False
                    Dim fields = csvReader.ReadFields()

                    If fields(0) <> "StudentName" Then
                        If EmptyList.Contains(fields(1)) Then
                            Dim s As String = "Hiiiii"
                        Else
                            EmptyList.Add(fields(1))
                        End If
                        'If myDictionary.ContainsKey("Key1") Then
                        '    myDictionary.Add(fields(1), New List(Of String) From {fields(0), fields(2), fields(3)})
                        '    'studentlist.Add(myDictionary.ToString())
                        'End If
                    End If

                    'If myDictionary.ContainsKey("key1") Then
                    '    studentlist.Contains("value1")
                    'End If
                    ' Console.WriteLine(String.Format("{0} - {1} - {2} - {3}", StudentName, StudentRollNumber, SubjectMarks, SubjectName))


                    rowcount += 1

                End While
                csvReader.Close()


                For Each S As String In EmptyList
                    Dim csvReader1 As New TextFieldParser("D:\StudentData\Unprocesssed\StudentMarks.csv")
                    csvReader1.Delimiters = New String() {","}
                    csvReader1.TextFieldType = FieldType.Delimited
                    While csvReader1.EndOfData() = False
                        Dim fields = csvReader1.ReadFields()
                        Dim myDictionary As New Dictionary(Of String, List(Of String))
                        If fields(1) = S Then
                            myDictionary.Add(fields(1), New List(Of String) From {fields(0), fields(2), fields(3)})
                            studentlist.Add(myDictionary)
                        End If


                    End While
                    csvReader1.Close()

                Next
                con.Open()
                For Each s As String In EmptyList
                    For Each dict As Dictionary(Of String, List(Of String)) In studentlist
                        For Each emp As KeyValuePair(Of String, List(Of String)) In dict
                            If emp.Key = s Then
                                ' Console.WriteLine("{0},{1}", emp.Key, emp.Value(0))

                                Dim command As SqlCommand = New SqlCommand($"select studentid from student where StudentName = '{emp.Value(0)}'", con)
                                Dim rd As SqlDataReader = command.ExecuteReader()
                                rd.Read()
                                Dim studentID As Integer = rd("Studentid")
                                rd.Close()

                                Dim command1 As SqlCommand = New SqlCommand($"select subjectID from Subject where SubjectName = '{emp.Value(2)}'", con)
                                Dim rd1 As SqlDataReader = command1.ExecuteReader()
                                rd1.Read()
                                Dim subjectID As Integer = rd1("subjectId")
                                rd1.Close()


                                Dim cmd As SqlCommand = New SqlCommand($" insert into studentmarks(subjectid,studentid,studentmark) values({subjectID},{studentID},{emp.Value(1)})", con)
                                cmd.executenonquery()

                            End If
                        Next
                    Next
                Next
                con.Close()
                'con.Open()
                'Dim cmd As SqlCommand = New SqlCommand(" insert into Studentmarks(SubjectId,StudentId,StudentMark)")

                'cmd.ExecuteNonQuery()
                'con.Close()
                'For Each kvp As KeyValuePair(Of String, List(Of String)) In myDictionary
                '    For Each item As String In studentlist
                '        For Each it As String In item
                '            If kvp.Key = item Then

                '            End If
                '        Next
                '    Next
                'Next
                'csvReader.Close()
                MessageBox.Show($"Successfully processed student data csv total number of rows = {rowcount}")

                'File move to processed folder
                File.Move(unprocesspath, processpath)
                success = True
            End If
        Catch ex As Exception
            'Move to error folder
            File.Move(unprocesspath, errorpath)
            MessageBox.Show(ex.Message)
            success = False

        End Try



        'Show message
        If success Then
            MessageBox.Show("Successfully Processed :" & rowcount & "Rows - ")
        Else
            MessageBox.Show("Error")
        End If


    End Sub
End Class
