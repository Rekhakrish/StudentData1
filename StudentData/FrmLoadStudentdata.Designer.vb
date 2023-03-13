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
        SuspendLayout()
        ' 
        ' Btnstartprocess
        ' 
        Btnstartprocess.BackColor = SystemColors.Window
        Btnstartprocess.Font = New Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        Btnstartprocess.Location = New Point(308, 189)
        Btnstartprocess.Name = "Btnstartprocess"
        Btnstartprocess.Size = New Size(141, 63)
        Btnstartprocess.TabIndex = 0
        Btnstartprocess.Text = "Start Processing"
        Btnstartprocess.UseVisualStyleBackColor = False
        ' 
        ' FrmloadStudentdata
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.MistyRose
        BackgroundImageLayout = ImageLayout.None
        ClientSize = New Size(767, 431)
        Controls.Add(Btnstartprocess)
        Name = "FrmloadStudentdata"
        StartPosition = FormStartPosition.CenterParent
        Text = "Load StudentData"
        WindowState = FormWindowState.Maximized
        ResumeLayout(False)
    End Sub

    Friend WithEvents Btnstartprocess As Button
End Class
