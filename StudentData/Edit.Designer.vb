<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Edit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        TxtID = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        TxtSubject = New TextBox()
        TxtStudentName = New TextBox()
        TxtMark = New TextBox()
        Label4 = New Label()
        ButtonSave = New Button()
        ButtonClose = New Button()
        SuspendLayout()
        ' 
        ' TxtID
        ' 
        TxtID.Location = New Point(283, 101)
        TxtID.Name = "TxtID"
        TxtID.ReadOnly = True
        TxtID.Size = New Size(100, 23)
        TxtID.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(121, 109)
        Label1.Name = "Label1"
        Label1.Size = New Size(22, 17)
        Label1.TabIndex = 1
        Label1.Text = "ID"' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label2.Location = New Point(121, 157)
        Label2.Name = "Label2"
        Label2.Size = New Size(92, 17)
        Label2.TabIndex = 2
        Label2.Text = "StudentName"' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.Location = New Point(121, 196)
        Label3.Name = "Label3"
        Label3.Size = New Size(53, 17)
        Label3.TabIndex = 3
        Label3.Text = "Subject"' 
        ' TxtSubject
        ' 
        TxtSubject.Location = New Point(283, 188)
        TxtSubject.Name = "TxtSubject"
        TxtSubject.ReadOnly = True
        TxtSubject.Size = New Size(100, 23)
        TxtSubject.TabIndex = 4
        ' 
        ' TxtStudentName
        ' 
        TxtStudentName.Location = New Point(283, 149)
        TxtStudentName.Name = "TxtStudentName"
        TxtStudentName.ReadOnly = True
        TxtStudentName.Size = New Size(100, 23)
        TxtStudentName.TabIndex = 5
        ' 
        ' TxtMark
        ' 
        TxtMark.Location = New Point(283, 244)
        TxtMark.Name = "TxtMark"
        TxtMark.Size = New Size(100, 23)
        TxtMark.TabIndex = 6
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Label4.Location = New Point(121, 252)
        Label4.Name = "Label4"
        Label4.Size = New Size(88, 17)
        Label4.TabIndex = 7
        Label4.Text = "Subject Mark"' 
        ' ButtonSave
        ' 
        ButtonSave.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        ButtonSave.Location = New Point(160, 318)
        ButtonSave.Name = "ButtonSave"
        ButtonSave.Size = New Size(75, 30)
        ButtonSave.TabIndex = 8
        ButtonSave.Text = "Save"
        ButtonSave.UseVisualStyleBackColor = True
        ' 
        ' ButtonClose
        ' 
        ButtonClose.Font = New Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        ButtonClose.Location = New Point(308, 318)
        ButtonClose.Name = "ButtonClose"
        ButtonClose.Size = New Size(75, 30)
        ButtonClose.TabIndex = 9
        ButtonClose.Text = "Close"
        ButtonClose.UseVisualStyleBackColor = True
        ' 
        ' Edit
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.MistyRose
        ClientSize = New Size(800, 450)
        Controls.Add(ButtonClose)
        Controls.Add(ButtonSave)
        Controls.Add(Label4)
        Controls.Add(TxtMark)
        Controls.Add(TxtStudentName)
        Controls.Add(TxtSubject)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(TxtID)
        Name = "Edit"
        Text = "Edit"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TxtID As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtSubject As TextBox
    Friend WithEvents TxtStudentName As TextBox
    Friend WithEvents TxtMark As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents ButtonSave As Button
    Friend WithEvents ButtonClose As Button
End Class
