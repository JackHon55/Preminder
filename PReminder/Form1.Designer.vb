<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Med_List = New System.Windows.Forms.DataGridView()
        Me.Med_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Med_repeat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Med_Count = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Med_take = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Med_buy = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Medtaken_text = New System.Windows.Forms.TextBox()
        CType(Me.Med_List, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Prescription List"
        '
        'Med_List
        '
        Me.Med_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Med_List.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Med_name, Me.Med_repeat, Me.Med_Count, Me.Med_take, Me.Med_buy})
        Me.Med_List.Location = New System.Drawing.Point(12, 37)
        Me.Med_List.MultiSelect = False
        Me.Med_List.Name = "Med_List"
        Me.Med_List.Size = New System.Drawing.Size(338, 257)
        Me.Med_List.TabIndex = 2
        '
        'Med_name
        '
        Me.Med_name.HeaderText = "Name"
        Me.Med_name.MinimumWidth = 100
        Me.Med_name.Name = "Med_name"
        '
        'Med_repeat
        '
        Me.Med_repeat.HeaderText = "Repeats"
        Me.Med_repeat.MinimumWidth = 60
        Me.Med_repeat.Name = "Med_repeat"
        Me.Med_repeat.Width = 60
        '
        'Med_Count
        '
        Me.Med_Count.HeaderText = "Count"
        Me.Med_Count.MinimumWidth = 50
        Me.Med_Count.Name = "Med_Count"
        Me.Med_Count.Width = 50
        '
        'Med_take
        '
        Me.Med_take.HeaderText = ""
        Me.Med_take.MinimumWidth = 40
        Me.Med_take.Name = "Med_take"
        Me.Med_take.Text = "Take"
        Me.Med_take.UseColumnTextForButtonValue = True
        Me.Med_take.Width = 40
        '
        'Med_buy
        '
        Me.Med_buy.HeaderText = ""
        Me.Med_buy.MinimumWidth = 40
        Me.Med_buy.Name = "Med_buy"
        Me.Med_buy.Text = "Add"
        Me.Med_buy.UseColumnTextForButtonValue = True
        Me.Med_buy.Width = 40
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 305)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Label2"
        '
        'Medtaken_text
        '
        Me.Medtaken_text.Location = New System.Drawing.Point(128, 302)
        Me.Medtaken_text.Name = "Medtaken_text"
        Me.Medtaken_text.Size = New System.Drawing.Size(222, 20)
        Me.Medtaken_text.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 329)
        Me.Controls.Add(Me.Medtaken_text)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Med_List)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(378, 368)
        Me.MinimumSize = New System.Drawing.Size(378, 368)
        Me.Name = "Form1"
        Me.Text = "PReminder"
        CType(Me.Med_List, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Med_List As DataGridView
    Friend WithEvents Med_name As DataGridViewTextBoxColumn
    Friend WithEvents Med_repeat As DataGridViewTextBoxColumn
    Friend WithEvents Med_Count As DataGridViewTextBoxColumn
    Friend WithEvents Med_take As DataGridViewButtonColumn
    Friend WithEvents Med_buy As DataGridViewButtonColumn
    Friend WithEvents Label2 As Label
    Friend WithEvents Medtaken_text As TextBox
End Class
