Imports System.IO
Imports System.Net.WebRequestMethods
Imports Microsoft.VisualBasic.FileIO
Imports File = System.IO.File

Public Class Form1

    Private Sub Btnstartprocess_Click(sender As Object, e As EventArgs) Handles Btnstartprocess.Click
        Dim unprocesspath As String = "C:\Student Data\UnProcessed\StudentMarks.csv"
        Dim processpath As String = "C:\Student Data\Processed\StudentMarks.csv"
        Dim errorpath As String = "C:\Student Data\Error Copy StudentMarks.csv file into Unprocessed folder\StudentMarks.csv"
        Dim success As Boolean = False
        ' Dim filename As String
        Dim rowcount As Integer
        'Dim fstream As FileStream
        'Dim Swriter As StreamWriter
        'Dim sreader As StreamReader
        ' fstream = New FileStream("C:\Student Data\UnProcessed\StudentMarks.csv", FileMode.Open, FileAccess.Read)
        'Dim filepath As String = "C:\Student Data\UnProcessed\StudentMarks.csv"


        Dim aList As New List(Of String)
        'check folder is exist or not
        Try

            If Not File.Exists(unprocesspath) Then
                MessageBox.Show("File is not available in Folder")
            Else

                Dim csvReader As New TextFieldParser("C:\Student Data\UnProcessed\StudentMarks.csv")
                csvReader.Delimiters = New String() {","}
                csvReader.TextFieldType = FieldType.Delimited

                rowcount = 0
                Dim row As String = " "
                Dim myDictionary As Dictionary(Of String, String())
                While csvReader.EndOfData() = False
                    Dim fields = csvReader.ReadFields()

                    If fields(0) <> "StudentName" Then
                        myDictionary.Add(fields(1), {fields(0), fields(2), fields(3)})
                        aList.Add(myDictionary.ToString())
                    End If

                    ' Console.WriteLine(String.Format("{0} - {1} - {2} - {3}", StudentName, StudentRollNumber, SubjectMarks, SubjectName))

                    row = csvReader.ReadLine()
                    rowcount += 1

                End While
                csvReader.Close()
                MessageBox.Show($"Successfully processed student data csv total number of rows = {rowcount}")

                'File move to processed folder
                File.Move(unprocesspath, processpath)
                success = True
            End If
        Catch ex As Exception
            'Move to error folder
            File.Move(unprocesspath, errorpath)
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
