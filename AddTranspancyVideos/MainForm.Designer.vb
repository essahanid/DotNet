<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
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
        GoButton = New Button()
        YouTubeUrlsText = New RichTextBox()
        GroupBox1 = New GroupBox()
        UTubeViewsDataGridView = New DataGridView()
        UrlColumn = New DataGridViewLinkColumn()
        idColumn = New DataGridViewTextBoxColumn()
        ClearButton = New Button()
        TotalVideosLabel = New Label()
        ResultMessageLabel = New Label()
        LoadMoreButton = New Button()
        GroupBox1.SuspendLayout()
        CType(UTubeViewsDataGridView, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' GoButton
        ' 
        GoButton.Location = New Point(12, 152)
        GoButton.Name = "GoButton"
        GoButton.Size = New Size(312, 29)
        GoButton.TabIndex = 0
        GoButton.Text = "GO"
        GoButton.UseVisualStyleBackColor = True
        ' 
        ' YouTubeUrlsText
        ' 
        YouTubeUrlsText.Location = New Point(15, 12)
        YouTubeUrlsText.Name = "YouTubeUrlsText"
        YouTubeUrlsText.Size = New Size(642, 120)
        YouTubeUrlsText.TabIndex = 1
        YouTubeUrlsText.Text = "https://adstransparency.google.com/advertiser/AR10865321129124298753?region=AU&format=VIDEO"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(UTubeViewsDataGridView)
        GroupBox1.Dock = DockStyle.Bottom
        GroupBox1.Location = New Point(0, 259)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(755, 211)
        GroupBox1.TabIndex = 3
        GroupBox1.TabStop = False
        GroupBox1.Text = "Results"
        ' 
        ' UTubeViewsDataGridView
        ' 
        UTubeViewsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        UTubeViewsDataGridView.Columns.AddRange(New DataGridViewColumn() {UrlColumn, idColumn})
        UTubeViewsDataGridView.Dock = DockStyle.Fill
        UTubeViewsDataGridView.Location = New Point(3, 23)
        UTubeViewsDataGridView.Name = "UTubeViewsDataGridView"
        UTubeViewsDataGridView.RowHeadersVisible = False
        UTubeViewsDataGridView.RowHeadersWidth = 51
        UTubeViewsDataGridView.Size = New Size(749, 185)
        UTubeViewsDataGridView.TabIndex = 0
        ' 
        ' UrlColumn
        ' 
        UrlColumn.HeaderText = "Url"
        UrlColumn.MinimumWidth = 400
        UrlColumn.Name = "UrlColumn"
        UrlColumn.ReadOnly = True
        UrlColumn.Resizable = DataGridViewTriState.True
        UrlColumn.SortMode = DataGridViewColumnSortMode.Automatic
        UrlColumn.Width = 400
        ' 
        ' idColumn
        ' 
        idColumn.HeaderText = "Video Id"
        idColumn.MinimumWidth = 200
        idColumn.Name = "idColumn"
        idColumn.ReadOnly = True
        idColumn.Width = 200
        ' 
        ' ClearButton
        ' 
        ClearButton.Location = New Point(361, 152)
        ClearButton.Name = "ClearButton"
        ClearButton.Size = New Size(296, 29)
        ClearButton.TabIndex = 4
        ClearButton.Text = "Clear All"
        ClearButton.UseVisualStyleBackColor = True
        ' 
        ' TotalVideosLabel
        ' 
        TotalVideosLabel.AutoSize = True
        TotalVideosLabel.Location = New Point(11, 227)
        TotalVideosLabel.Name = "TotalVideosLabel"
        TotalVideosLabel.Size = New Size(115, 20)
        TotalVideosLabel.TabIndex = 6
        TotalVideosLabel.Text = "Total videos = 0"
        ' 
        ' ResultMessageLabel
        ' 
        ResultMessageLabel.AutoSize = True
        ResultMessageLabel.Location = New Point(20, 188)
        ResultMessageLabel.Name = "ResultMessageLabel"
        ResultMessageLabel.Size = New Size(0, 20)
        ResultMessageLabel.TabIndex = 7
        ' 
        ' LoadMoreButton
        ' 
        LoadMoreButton.Location = New Point(636, 227)
        LoadMoreButton.Name = "LoadMoreButton"
        LoadMoreButton.Size = New Size(113, 29)
        LoadMoreButton.TabIndex = 8
        LoadMoreButton.Text = "Load More.."
        LoadMoreButton.UseVisualStyleBackColor = True
        ' 
        ' MainForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        ClientSize = New Size(755, 470)
        Controls.Add(LoadMoreButton)
        Controls.Add(ResultMessageLabel)
        Controls.Add(TotalVideosLabel)
        Controls.Add(ClearButton)
        Controls.Add(GroupBox1)
        Controls.Add(YouTubeUrlsText)
        Controls.Add(GoButton)
        Name = "MainForm"
        Text = "AdTransparency Scrapper"
        GroupBox1.ResumeLayout(False)
        CType(UTubeViewsDataGridView, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GoButton As Button
    Friend WithEvents YouTubeUrlsText As RichTextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents UTubeViewsDataGridView As DataGridView
    Friend WithEvents ClearButton As Button
    Friend WithEvents ViewsCheckBox As CheckBox
    Friend WithEvents TotalVideosLabel As Label
    Friend WithEvents ResultMessageLabel As Label
    Friend WithEvents UrlColumn As DataGridViewLinkColumn
    Friend WithEvents idColumn As DataGridViewTextBoxColumn
    Friend WithEvents LoadMoreButton As Button

End Class
