<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoadingForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoadingForm))
        DataLoadingPictureBox = New PictureBox()
        CType(DataLoadingPictureBox, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' DataLoadingPictureBox
        ' 
        DataLoadingPictureBox.Dock = DockStyle.Fill
        DataLoadingPictureBox.Image = CType(resources.GetObject("DataLoadingPictureBox.Image"), Image)
        DataLoadingPictureBox.Location = New Point(0, 0)
        DataLoadingPictureBox.Name = "DataLoadingPictureBox"
        DataLoadingPictureBox.Size = New Size(472, 502)
        DataLoadingPictureBox.SizeMode = PictureBoxSizeMode.CenterImage
        DataLoadingPictureBox.TabIndex = 11
        DataLoadingPictureBox.TabStop = False
        ' 
        ' LoadingForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(472, 502)
        Controls.Add(DataLoadingPictureBox)
        FormBorderStyle = FormBorderStyle.None
        Name = "LoadingForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Please Wait ......"
        TopMost = True
        CType(DataLoadingPictureBox, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents DataLoadingPictureBox As PictureBox
End Class
