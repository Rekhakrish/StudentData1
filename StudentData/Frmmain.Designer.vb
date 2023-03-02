<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frmmain
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
        MenuStrip1 = New MenuStrip()
        OptionsToolStripMenuItem = New ToolStripMenuItem()
        LoadDataToolStripMenuItem = New ToolStripMenuItem()
        SearchScreenToolStripMenuItem = New ToolStripMenuItem()
        ExitToolStripMenuItem = New ToolStripMenuItem()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {OptionsToolStripMenuItem, ExitToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(800, 24)
        MenuStrip1.TabIndex = 1
        MenuStrip1.Text = "MenuStrip1"' 
        ' OptionsToolStripMenuItem
        ' 
        OptionsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {LoadDataToolStripMenuItem, SearchScreenToolStripMenuItem})
        OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        OptionsToolStripMenuItem.Size = New Size(61, 20)
        OptionsToolStripMenuItem.Text = "Options"' 
        ' LoadDataToolStripMenuItem
        ' 
        LoadDataToolStripMenuItem.Name = "LoadDataToolStripMenuItem"
        LoadDataToolStripMenuItem.Size = New Size(180, 22)
        LoadDataToolStripMenuItem.Text = "LoadData"' 
        ' SearchScreenToolStripMenuItem
        ' 
        SearchScreenToolStripMenuItem.Name = "SearchScreenToolStripMenuItem"
        SearchScreenToolStripMenuItem.Size = New Size(180, 22)
        SearchScreenToolStripMenuItem.Text = "SearchScreen"' 
        ' ExitToolStripMenuItem
        ' 
        ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        ExitToolStripMenuItem.Size = New Size(38, 20)
        ExitToolStripMenuItem.Text = "Exit"' 
        ' Frmmain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(MenuStrip1)
        IsMdiContainer = True
        MainMenuStrip = MenuStrip1
        Name = "Frmmain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Student Information System"
        WindowState = FormWindowState.Maximized
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LoadDataToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SearchScreenToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As ToolStripMenuItem
End Class
