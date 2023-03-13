<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchStudent
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
        LblStudentname = New Label()
        LblStudentrollno = New Label()
        LblSubject = New Label()
        TxtStudentName = New TextBox()
        TxtStudentrollno = New TextBox()
        TxtSubject = New TextBox()
        Btnsearch = New Button()
        DataGridView1 = New DataGridView()
        BtnShowAll = New Button()
        ButtonNextgrid = New Button()
        ButtonPrevious = New Button()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' LblStudentname
        ' 
        LblStudentname.AutoSize = True
        LblStudentname.BackColor = Color.Snow
        LblStudentname.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        LblStudentname.Location = New Point(63, 53)
        LblStudentname.Name = "LblStudentname"
        LblStudentname.Size = New Size(96, 17)
        LblStudentname.TabIndex = 0
        LblStudentname.Text = "Student Name"' 
        ' LblStudentrollno
        ' 
        LblStudentrollno.AutoSize = True
        LblStudentrollno.BackColor = Color.Snow
        LblStudentrollno.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        LblStudentrollno.Location = New Point(63, 98)
        LblStudentrollno.Name = "LblStudentrollno"
        LblStudentrollno.Size = New Size(106, 17)
        LblStudentrollno.TabIndex = 1
        LblStudentrollno.Text = "Student Roll No"' 
        ' LblSubject
        ' 
        LblSubject.AutoSize = True
        LblSubject.BackColor = Color.Snow
        LblSubject.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        LblSubject.Location = New Point(63, 151)
        LblSubject.Name = "LblSubject"
        LblSubject.Size = New Size(53, 17)
        LblSubject.TabIndex = 2
        LblSubject.Text = "Subject"' 
        ' TxtStudentName
        ' 
        TxtStudentName.Location = New Point(256, 45)
        TxtStudentName.Name = "TxtStudentName"
        TxtStudentName.Size = New Size(100, 23)
        TxtStudentName.TabIndex = 3
        ' 
        ' TxtStudentrollno
        ' 
        TxtStudentrollno.Location = New Point(256, 90)
        TxtStudentrollno.Name = "TxtStudentrollno"
        TxtStudentrollno.Size = New Size(100, 23)
        TxtStudentrollno.TabIndex = 4
        ' 
        ' TxtSubject
        ' 
        TxtSubject.Location = New Point(256, 143)
        TxtSubject.Name = "TxtSubject"
        TxtSubject.Size = New Size(100, 23)
        TxtSubject.TabIndex = 5
        ' 
        ' Btnsearch
        ' 
        Btnsearch.BackColor = Color.Snow
        Btnsearch.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Btnsearch.Location = New Point(483, 35)
        Btnsearch.Name = "Btnsearch"
        Btnsearch.Size = New Size(81, 35)
        Btnsearch.TabIndex = 6
        Btnsearch.Text = "Search"
        Btnsearch.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.BackgroundColor = Color.Snow
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(63, 223)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(815, 325)
        DataGridView1.TabIndex = 7
        ' 
        ' BtnShowAll
        ' 
        BtnShowAll.BackColor = Color.Snow
        BtnShowAll.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        BtnShowAll.Location = New Point(483, 98)
        BtnShowAll.Name = "BtnShowAll"
        BtnShowAll.Size = New Size(81, 31)
        BtnShowAll.TabIndex = 8
        BtnShowAll.Text = "ShowAll"
        BtnShowAll.UseVisualStyleBackColor = False
        ' 
        ' ButtonNextgrid
        ' 
        ButtonNextgrid.BackColor = Color.Snow
        ButtonNextgrid.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        ButtonNextgrid.Location = New Point(667, 35)
        ButtonNextgrid.Name = "ButtonNextgrid"
        ButtonNextgrid.Size = New Size(75, 35)
        ButtonNextgrid.TabIndex = 9
        ButtonNextgrid.Text = ">>"
        ButtonNextgrid.UseVisualStyleBackColor = False
        ' 
        ' ButtonPrevious
        ' 
        ButtonPrevious.BackColor = Color.Snow
        ButtonPrevious.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        ButtonPrevious.Location = New Point(667, 98)
        ButtonPrevious.Name = "ButtonPrevious"
        ButtonPrevious.Size = New Size(75, 31)
        ButtonPrevious.TabIndex = 10
        ButtonPrevious.Text = "<<"
        ButtonPrevious.UseVisualStyleBackColor = False
        ' 
        ' SearchStudent
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.MistyRose
        ClientSize = New Size(1259, 592)
        Controls.Add(ButtonPrevious)
        Controls.Add(ButtonNextgrid)
        Controls.Add(BtnShowAll)
        Controls.Add(DataGridView1)
        Controls.Add(Btnsearch)
        Controls.Add(TxtSubject)
        Controls.Add(TxtStudentrollno)
        Controls.Add(TxtStudentName)
        Controls.Add(LblSubject)
        Controls.Add(LblStudentrollno)
        Controls.Add(LblStudentname)
        Name = "SearchStudent"
        StartPosition = FormStartPosition.CenterParent
        Text = "SearchStudent"
        WindowState = FormWindowState.Maximized
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents LblStudentname As Label
    Friend WithEvents LblStudentrollno As Label
    Friend WithEvents LblSubject As Label
    Friend WithEvents TxtStudentName As TextBox
    Friend WithEvents TxtStudentrollno As TextBox
    Friend WithEvents TxtSubject As TextBox
    Friend WithEvents Btnsearch As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents BtnShowAll As Button
    Friend WithEvents ButtonNextgrid As Button
    Friend WithEvents ButtonPrevious As Button
End Class
