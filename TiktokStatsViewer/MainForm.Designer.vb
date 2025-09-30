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
        Dim DataGridViewCellStyle1 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As DataGridViewCellStyle = New DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        GoButton = New Button()
        TiktokUrlText = New RichTextBox()
        ViewCountsLabel = New Label()
        GroupBox1 = New GroupBox()
        UTubeViewsDataGridView = New DataGridView()
        UrlColumn = New DataGridViewLinkColumn()
        absoluteUrlColumn = New DataGridViewLinkColumn()
        DescriptionColumn = New DataGridViewTextBoxColumn()
        ViewsColumn = New DataGridViewTextBoxColumn()
        imgURLColumn = New DataGridViewImageColumn()
        DownloadColumn = New DataGridViewImageColumn()
        PlayVideoColumn = New DataGridViewImageColumn()
        ClearButton = New Button()
        Label1 = New Label()
        TotalUrlsLabel = New Label()
        GroupBox2 = New GroupBox()
        Label2 = New Label()
        SetFolderPathButton = New Button()
        FolderPathTextBox = New TextBox()
        ExportToExcelButton = New Button()
        Panel1 = New Panel()
        Panel2 = New Panel()
        GroupBox1.SuspendLayout()
        CType(UTubeViewsDataGridView, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox2.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' GoButton
        ' 
        GoButton.Font = New Font("Segoe UI", 12F)
        GoButton.Location = New Point(184, 154)
        GoButton.Name = "GoButton"
        GoButton.Size = New Size(225, 44)
        GoButton.TabIndex = 0
        GoButton.Text = "Start"
        GoButton.UseVisualStyleBackColor = True
        ' 
        ' TiktokUrlText
        ' 
        TiktokUrlText.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        TiktokUrlText.Font = New Font("Segoe UI", 15F)
        TiktokUrlText.Location = New Point(103, 46)
        TiktokUrlText.Name = "TiktokUrlText"
        TiktokUrlText.Size = New Size(863, 41)
        TiktokUrlText.TabIndex = 1
        TiktokUrlText.Text = "https://www.tiktok.com/@adgilemediagroup"
        ' 
        ' ViewCountsLabel
        ' 
        ViewCountsLabel.AutoSize = True
        ViewCountsLabel.Location = New Point(178, 162)
        ViewCountsLabel.Name = "ViewCountsLabel"
        ViewCountsLabel.Size = New Size(0, 20)
        ViewCountsLabel.TabIndex = 2
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(UTubeViewsDataGridView)
        GroupBox1.Dock = DockStyle.Fill
        GroupBox1.Font = New Font("Segoe UI", 12F)
        GroupBox1.Location = New Point(0, 0)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1066, 271)
        GroupBox1.TabIndex = 3
        GroupBox1.TabStop = False
        GroupBox1.Text = "Results"
        ' 
        ' UTubeViewsDataGridView
        ' 
        UTubeViewsDataGridView.AllowUserToAddRows = False
        UTubeViewsDataGridView.AllowUserToDeleteRows = False
        UTubeViewsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders
        UTubeViewsDataGridView.BackgroundColor = SystemColors.ActiveCaption
        UTubeViewsDataGridView.BorderStyle = BorderStyle.Fixed3D
        UTubeViewsDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SunkenHorizontal
        UTubeViewsDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken
        UTubeViewsDataGridView.ColumnHeadersHeight = 35
        UTubeViewsDataGridView.Columns.AddRange(New DataGridViewColumn() {UrlColumn, absoluteUrlColumn, DescriptionColumn, ViewsColumn, imgURLColumn, DownloadColumn, PlayVideoColumn})
        UTubeViewsDataGridView.Dock = DockStyle.Fill
        UTubeViewsDataGridView.Location = New Point(3, 30)
        UTubeViewsDataGridView.Name = "UTubeViewsDataGridView"
        UTubeViewsDataGridView.RowHeadersWidth = 51
        UTubeViewsDataGridView.RowTemplate.Height = 40
        UTubeViewsDataGridView.Size = New Size(1060, 238)
        UTubeViewsDataGridView.TabIndex = 0
        ' 
        ' UrlColumn
        ' 
        DataGridViewCellStyle1.WrapMode = DataGridViewTriState.True
        UrlColumn.DefaultCellStyle = DataGridViewCellStyle1
        UrlColumn.HeaderText = "Url"
        UrlColumn.MinimumWidth = 350
        UrlColumn.Name = "UrlColumn"
        UrlColumn.ReadOnly = True
        UrlColumn.Resizable = DataGridViewTriState.True
        UrlColumn.SortMode = DataGridViewColumnSortMode.Automatic
        UrlColumn.Width = 350
        ' 
        ' absoluteUrlColumn
        ' 
        absoluteUrlColumn.HeaderText = "Absolute URL"
        absoluteUrlColumn.MinimumWidth = 6
        absoluteUrlColumn.Name = "absoluteUrlColumn"
        absoluteUrlColumn.ReadOnly = True
        absoluteUrlColumn.Visible = False
        absoluteUrlColumn.Width = 125
        ' 
        ' DescriptionColumn
        ' 
        DescriptionColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle2.WrapMode = DataGridViewTriState.True
        DescriptionColumn.DefaultCellStyle = DataGridViewCellStyle2
        DescriptionColumn.HeaderText = "Description"
        DescriptionColumn.MinimumWidth = 6
        DescriptionColumn.Name = "DescriptionColumn"
        DescriptionColumn.ReadOnly = True
        ' 
        ' ViewsColumn
        ' 
        ViewsColumn.HeaderText = "Views"
        ViewsColumn.MinimumWidth = 6
        ViewsColumn.Name = "ViewsColumn"
        ViewsColumn.ReadOnly = True
        ViewsColumn.Width = 80
        ' 
        ' imgURLColumn
        ' 
        imgURLColumn.HeaderText = "Image"
        imgURLColumn.MinimumWidth = 6
        imgURLColumn.Name = "imgURLColumn"
        imgURLColumn.ReadOnly = True
        imgURLColumn.Resizable = DataGridViewTriState.True
        imgURLColumn.SortMode = DataGridViewColumnSortMode.Automatic
        imgURLColumn.Width = 125
        ' 
        ' DownloadColumn
        ' 
        DownloadColumn.HeaderText = "Download Video"
        DownloadColumn.Image = CType(resources.GetObject("DownloadColumn.Image"), Image)
        DownloadColumn.MinimumWidth = 6
        DownloadColumn.Name = "DownloadColumn"
        DownloadColumn.ReadOnly = True
        DownloadColumn.Resizable = DataGridViewTriState.True
        DownloadColumn.Width = 125
        ' 
        ' PlayVideoColumn
        ' 
        PlayVideoColumn.HeaderText = "Play Video"
        PlayVideoColumn.Image = CType(resources.GetObject("PlayVideoColumn.Image"), Image)
        PlayVideoColumn.MinimumWidth = 6
        PlayVideoColumn.Name = "PlayVideoColumn"
        PlayVideoColumn.Resizable = DataGridViewTriState.True
        PlayVideoColumn.SortMode = DataGridViewColumnSortMode.Automatic
        PlayVideoColumn.Width = 125
        ' 
        ' ClearButton
        ' 
        ClearButton.Font = New Font("Segoe UI", 12F)
        ClearButton.Location = New Point(568, 154)
        ClearButton.Name = "ClearButton"
        ClearButton.Size = New Size(228, 43)
        ClearButton.TabIndex = 4
        ClearButton.Text = "Clear All"
        ClearButton.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(386, 22)
        Label1.Name = "Label1"
        Label1.Size = New Size(227, 20)
        Label1.TabIndex = 5
        Label1.Text = "#1 Paste Tiktok url account here..."
        ' 
        ' TotalUrlsLabel
        ' 
        TotalUrlsLabel.AutoSize = True
        TotalUrlsLabel.Location = New Point(14, 4)
        TotalUrlsLabel.Name = "TotalUrlsLabel"
        TotalUrlsLabel.Size = New Size(101, 20)
        TotalUrlsLabel.TabIndex = 6
        TotalUrlsLabel.Text = "Total Videos="
        ' 
        ' GroupBox2
        ' 
        GroupBox2.Controls.Add(Label2)
        GroupBox2.Controls.Add(SetFolderPathButton)
        GroupBox2.Controls.Add(FolderPathTextBox)
        GroupBox2.Controls.Add(ExportToExcelButton)
        GroupBox2.Controls.Add(GoButton)
        GroupBox2.Controls.Add(TiktokUrlText)
        GroupBox2.Controls.Add(Label1)
        GroupBox2.Controls.Add(ClearButton)
        GroupBox2.Dock = DockStyle.Top
        GroupBox2.Location = New Point(0, 0)
        GroupBox2.Name = "GroupBox2"
        GroupBox2.Size = New Size(1066, 207)
        GroupBox2.TabIndex = 7
        GroupBox2.TabStop = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(337, 93)
        Label2.Name = "Label2"
        Label2.Size = New Size(333, 20)
        Label2.TabIndex = 9
        Label2.Text = "#2 specify the path where your files will be saved"
        ' 
        ' SetFolderPathButton
        ' 
        SetFolderPathButton.Location = New Point(836, 116)
        SetFolderPathButton.Name = "SetFolderPathButton"
        SetFolderPathButton.Size = New Size(60, 29)
        SetFolderPathButton.TabIndex = 8
        SetFolderPathButton.Text = "..."
        SetFolderPathButton.UseVisualStyleBackColor = True
        ' 
        ' FolderPathTextBox
        ' 
        FolderPathTextBox.Location = New Point(103, 117)
        FolderPathTextBox.Name = "FolderPathTextBox"
        FolderPathTextBox.ReadOnly = True
        FolderPathTextBox.Size = New Size(727, 27)
        FolderPathTextBox.TabIndex = 7
        ' 
        ' ExportToExcelButton
        ' 
        ExportToExcelButton.Location = New Point(914, 172)
        ExportToExcelButton.Name = "ExportToExcelButton"
        ExportToExcelButton.Size = New Size(76, 29)
        ExportToExcelButton.TabIndex = 6
        ExportToExcelButton.Text = "Export To Excel"
        ExportToExcelButton.UseVisualStyleBackColor = True
        ExportToExcelButton.Visible = False
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(GroupBox1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 207)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1066, 271)
        Panel1.TabIndex = 8
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(TotalUrlsLabel)
        Panel2.Dock = DockStyle.Bottom
        Panel2.Location = New Point(0, 446)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1066, 32)
        Panel2.TabIndex = 9
        ' 
        ' MainForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1066, 478)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(GroupBox2)
        Controls.Add(ViewCountsLabel)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "MainForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Tiktok Videos Scrapper"
        TopMost = True
        WindowState = FormWindowState.Maximized
        GroupBox1.ResumeLayout(False)
        CType(UTubeViewsDataGridView, ComponentModel.ISupportInitialize).EndInit()
        GroupBox2.ResumeLayout(False)
        GroupBox2.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GoButton As Button
    Friend WithEvents TiktokUrlText As RichTextBox
    Friend WithEvents ViewCountsLabel As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents UTubeViewsDataGridView As DataGridView
    Friend WithEvents ClearButton As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TotalUrlsLabel As Label
    Friend WithEvents ViewsCheckBox As CheckBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ExportToExcelButton As Button
    Friend WithEvents SetFolderPathButton As Button
    Friend WithEvents FolderPathTextBox As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents UrlColumn As DataGridViewLinkColumn
    Friend WithEvents absoluteUrlColumn As DataGridViewLinkColumn
    Friend WithEvents DescriptionColumn As DataGridViewTextBoxColumn
    Friend WithEvents ViewsColumn As DataGridViewTextBoxColumn
    Friend WithEvents imgURLColumn As DataGridViewImageColumn
    Friend WithEvents DownloadColumn As DataGridViewImageColumn
    Friend WithEvents PlayVideoColumn As DataGridViewImageColumn

End Class
