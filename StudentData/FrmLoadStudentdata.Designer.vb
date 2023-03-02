<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmloadStudentdata
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Btnstartprocess = New Button()
        btnsearchform = New Button()
        SuspendLayout()
        ' 
        ' Btnstartprocess
        ' 
        Btnstartprocess.BackColor = SystemColors.Window
        Btnstartprocess.Location = New Point(175, 167)
        Btnstartprocess.Name = "Btnstartprocess"
        Btnstartprocess.Size = New Size(113, 33)
        Btnstartprocess.TabIndex = 0
        Btnstartprocess.Text = "Start Processing"
        Btnstartprocess.UseVisualStyleBackColor = False
        ' 
        ' btnsearchform
        ' 
        btnsearchform.BackColor = Color.Snow
        btnsearchform.Location = New Point(467, 167)
        btnsearchform.Name = "btnsearchform"
        btnsearchform.Size = New Size(111, 33)
        btnsearchform.TabIndex = 1
        btnsearchform.Text = "Search"
        btnsearchform.UseVisualStyleBackColor = False
        ' 
        ' FrmloadStudentdata
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.MistyRose
        ClientSize = New Size(800, 450)
        Controls.Add(btnsearchform)
        Controls.Add(Btnstartprocess)
        Name = "FrmloadStudentdata"
        StartPosition = FormStartPosition.CenterParent
        Text = "Load StudentData"
        WindowState = FormWindowState.Maximized
        ResumeLayout(False)
    End Sub

    Friend WithEvents Btnstartprocess As Button
    Friend WithEvents btnsearchform As Button
End Class
