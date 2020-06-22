<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.WIN_T = New System.Windows.Forms.PictureBox()
        Me.WIN_K = New System.Windows.Forms.PictureBox()
        Me.MS_LOGO = New System.Windows.Forms.PictureBox()
        Me.IS_nfo = New System.Windows.Forms.Label()
        Me.EXIT_TIME = New System.Windows.Forms.Timer(Me.components)
        Me.UP_ = New System.Windows.Forms.Label()
        CType(Me.WIN_T, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.WIN_K, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MS_LOGO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WIN_T
        '
        Me.WIN_T.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.WIN_T, "WIN_T")
        Me.WIN_T.Image = Global.WindowsUpdate.My.Resources.Resources.win_text
        Me.WIN_T.Name = "WIN_T"
        Me.WIN_T.TabStop = False
        '
        'WIN_K
        '
        Me.WIN_K.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.WIN_K, "WIN_K")
        Me.WIN_K.Image = Global.WindowsUpdate.My.Resources.Resources.win10
        Me.WIN_K.Name = "WIN_K"
        Me.WIN_K.TabStop = False
        '
        'MS_LOGO
        '
        Me.MS_LOGO.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.MS_LOGO, "MS_LOGO")
        Me.MS_LOGO.Image = Global.WindowsUpdate.My.Resources.Resources.microsoft
        Me.MS_LOGO.Name = "MS_LOGO"
        Me.MS_LOGO.TabStop = False
        '
        'IS_nfo
        '
        Me.IS_nfo.BackColor = System.Drawing.Color.Transparent
        resources.ApplyResources(Me.IS_nfo, "IS_nfo")
        Me.IS_nfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.IS_nfo.ForeColor = System.Drawing.Color.DodgerBlue
        Me.IS_nfo.Name = "IS_nfo"
        '
        'EXIT_TIME
        '
        Me.EXIT_TIME.Interval = 1000
        '
        'UP_
        '
        resources.ApplyResources(Me.UP_, "UP_")
        Me.UP_.BackColor = System.Drawing.Color.Transparent
        Me.UP_.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.UP_.ForeColor = System.Drawing.Color.DodgerBlue
        Me.UP_.Name = "UP_"
        '
        'Main
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me, "$this")
        Me.ControlBox = False
        Me.Controls.Add(Me.UP_)
        Me.Controls.Add(Me.IS_nfo)
        Me.Controls.Add(Me.WIN_T)
        Me.Controls.Add(Me.WIN_K)
        Me.Controls.Add(Me.MS_LOGO)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.Violet
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Main"
        Me.ShowInTaskbar = False
        Me.TopMost = True
        CType(Me.WIN_T, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.WIN_K, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MS_LOGO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MS_LOGO As PictureBox
    Friend WithEvents WIN_K As PictureBox
    Friend WithEvents WIN_T As PictureBox
    Friend WithEvents IS_nfo As Label
    Friend WithEvents EXIT_TIME As Timer
    Friend WithEvents UP_ As Label
End Class
