<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.編集ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.選択箇所をTeX形式でクリップボードへコピーToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Csvもしくはtsv形式のデータを貼り付けToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.セルの下側の罫線の有無ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.セルの右側の罫線の有無ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 24)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(692, 349)
        Me.DataGridView1.TabIndex = 0
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.編集ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.MenuStrip1.Size = New System.Drawing.Size(692, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        '編集ToolStripMenuItem
        '
        Me.編集ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.選択箇所をTeX形式でクリップボードへコピーToolStripMenuItem, Me.Csvもしくはtsv形式のデータを貼り付けToolStripMenuItem, Me.セルの下側の罫線の有無ToolStripMenuItem, Me.セルの右側の罫線の有無ToolStripMenuItem})
        Me.編集ToolStripMenuItem.Name = "編集ToolStripMenuItem"
        Me.編集ToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.編集ToolStripMenuItem.Text = "編集"
        '
        '選択箇所をTeX形式でクリップボードへコピーToolStripMenuItem
        '
        Me.選択箇所をTeX形式でクリップボードへコピーToolStripMenuItem.Name = "選択箇所をTeX形式でクリップボードへコピーToolStripMenuItem"
        Me.選択箇所をTeX形式でクリップボードへコピーToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.選択箇所をTeX形式でクリップボードへコピーToolStripMenuItem.Size = New System.Drawing.Size(346, 22)
        Me.選択箇所をTeX形式でクリップボードへコピーToolStripMenuItem.Text = "選択箇所をTeX形式でクリップボードへコピー"
        '
        'Csvもしくはtsv形式のデータを貼り付けToolStripMenuItem
        '
        Me.Csvもしくはtsv形式のデータを貼り付けToolStripMenuItem.Name = "Csvもしくはtsv形式のデータを貼り付けToolStripMenuItem"
        Me.Csvもしくはtsv形式のデータを貼り付けToolStripMenuItem.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
            Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.Csvもしくはtsv形式のデータを貼り付けToolStripMenuItem.Size = New System.Drawing.Size(346, 22)
        Me.Csvもしくはtsv形式のデータを貼り付けToolStripMenuItem.Text = "csvもしくはtsv形式のデータを貼り付け"
        '
        'セルの下側の罫線の有無ToolStripMenuItem
        '
        Me.セルの下側の罫線の有無ToolStripMenuItem.Name = "セルの下側の罫線の有無ToolStripMenuItem"
        Me.セルの下側の罫線の有無ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.B), System.Windows.Forms.Keys)
        Me.セルの下側の罫線の有無ToolStripMenuItem.Size = New System.Drawing.Size(346, 22)
        Me.セルの下側の罫線の有無ToolStripMenuItem.Text = "セルの下側の罫線の有無"
        '
        'セルの右側の罫線の有無ToolStripMenuItem
        '
        Me.セルの右側の罫線の有無ToolStripMenuItem.Name = "セルの右側の罫線の有無ToolStripMenuItem"
        Me.セルの右側の罫線の有無ToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.R), System.Windows.Forms.Keys)
        Me.セルの右側の罫線の有無ToolStripMenuItem.Size = New System.Drawing.Size(346, 22)
        Me.セルの右側の罫線の有無ToolStripMenuItem.Text = "セルの右側の罫線の有無"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 373)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TeX表簡単 α版 0.010"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents 編集ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 選択箇所をTeX形式でクリップボードへコピーToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Csvもしくはtsv形式のデータを貼り付けToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents セルの下側の罫線の有無ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents セルの右側の罫線の有無ToolStripMenuItem As ToolStripMenuItem
End Class
