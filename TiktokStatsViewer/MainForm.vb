
Imports System.IO
Imports System.Threading

Public Class MainForm
    Private Account As String
    Private Videos As ArrayList
    Private loadingForm As LoadingForm
    Private loadingFormTask As Task

    Private cancellationTokenSource As CancellationTokenSource
    Private Async Sub GoButton_Click(sender As Object, e As EventArgs) Handles GoButton.Click
        Dim url As String = TiktokUrlText.Text
        Dim folderPath As String = FolderPathTextBox.Text
        If String.IsNullOrEmpty(url) Or String.IsNullOrEmpty(folderPath) Then
            MessageBox.Show("Please add all required inputs....")
        Else
            Dim totalBaseLabel = "Total Videos = "

            UTubeViewsDataGridView.Rows.Clear()
            If url IsNot Nothing Then
                Dim strParams = Split(url, "@")
                If strParams.Length > 1 Then
                    Dim Id = strParams(1)
                    Account = Id
                End If
            End If
            Services.Init(folderPath, Account)
            cancellationTokenSource = New CancellationTokenSource()

            ' Show the loading form
            ShowLoadingForm(cancellationTokenSource.Token)
            Videos = Services.LoadMoreScrapeAdsTransparencyCenterForUrl(url)
            For Each video As TikTokVideoInfo In Videos

                Dim imageUrl As String = video.CoverUrl
                ' Convert the byte array to an Image object
                Dim image As Image = Nothing
                If imageUrl.StartsWith("data:image", StringComparison.OrdinalIgnoreCase) Then
                    image = Helper.GetImageFromBase64(imageUrl)
                Else
                    image = Helper.GetImageFromUrl(imageUrl)
                End If
                Helper.SaveImage(image, folderPath & "\" & Account & "\Images")
                Dim row As New DataGridViewRow()
                row.CreateCells(UTubeViewsDataGridView)
                row.Cells(0).Value = video.Url
                row.Cells(1).Value = video.AbsoluteUrl
                row.Cells(2).Value = video.Title
                row.Cells(3).Value = video.ViewsCount
                row.Cells(4).Value = image

                'Fill datagrid view with retreived data from Tiktok
                UTubeViewsDataGridView.Rows.Add(row)
            Next
            ' Hide the loading form
            HideLoadingForm()
            totalBaseLabel = totalBaseLabel & Videos.Count
            TotalUrlsLabel.Text = totalBaseLabel
        End If
    End Sub
    'Handle video link click to open it in browser
    Private Sub UTubeViewsDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles UTubeViewsDataGridView.CellContentClick
        If e.ColumnIndex = 0 Or e.ColumnIndex = 1 AndAlso e.RowIndex >= 0 Then
            Dim cellValue As Object = UTubeViewsDataGridView(e.ColumnIndex, e.RowIndex).Value
            Dim link As String = cellValue.ToString()

            Dim startInfo As New ProcessStartInfo(link)
            startInfo.UseShellExecute = True
            Process.Start(startInfo)
        End If
        If e.ColumnIndex = 5 AndAlso e.RowIndex >= 0 Then
            Dim cellValue As Object = UTubeViewsDataGridView(0, e.RowIndex).Value
            Dim cell As DataGridViewCell = UTubeViewsDataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex)
            Dim link As String = cellValue.ToString()
            Dim currentTimestamp As Integer = DateTimeOffset.Now.ToUnixTimeSeconds()
            Dim imgCell As DataGridViewImageCell = DirectCast(cell, DataGridViewImageCell)
            cancellationTokenSource = New CancellationTokenSource()

            ' Show the loading form
            ShowLoadingForm(cancellationTokenSource.Token)
            'imgCell.Value = Image.FromFile("loading.gif") ' Set the background image
            'imgCell.ImageLayout = ImageLayout.Stretch ' Adjust the layout of the background image if needed
            Services.DownloadVideoFile(link, Account, currentTimestamp)
            'imgCell.Value = Image.FromFile("download.png") ' Set the background image
            imgCell.Description = currentTimestamp
            'imgCell.ImageLayout = ImageLayout.Stretch ' Adjust the layout of the background image if needed
            HideLoadingForm()
        ElseIf e.ColumnIndex = 6 AndAlso e.RowIndex >= 0 Then
            Dim cellValue As Object = UTubeViewsDataGridView(0, e.RowIndex).Value
            Dim cell As DataGridViewCell = UTubeViewsDataGridView.Rows(e.RowIndex).Cells(5)
            Dim imgCell As DataGridViewImageCell = DirectCast(cell, DataGridViewImageCell)
            cancellationTokenSource = New CancellationTokenSource()

            ' Show the loading form

            Dim videoPath = FolderPathTextBox.Text & "\" & Account & "\" & "Videos" & "\" & imgCell.Description & ".mp4"
            If File.Exists(videoPath) Then
                ShowLoadingForm(cancellationTokenSource.Token)
                Try
                    ' Use ProcessStartInfo to specify the file and launch it with the default player
                    Dim psi As New ProcessStartInfo()
                    psi.FileName = videoPath
                    psi.UseShellExecute = True ' This ensures the file is opened with the default associated application
                    Process.Start(psi)

                Catch ex As Exception
                    ' Display an error message if the process fails to start
                    MessageBox.Show("An error occurred while trying to open the video file: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                HideLoadingForm()
            Else
                MessageBox.Show("Selected Video not found, or not downloaded yet, please firstly download the video")
            End If

        End If

    End Sub
    'The foloowing button click hundler are responsible for hide/show columns in results/datagridview
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        TotalUrlsLabel.Text = "Total Videos = 0"
        TiktokUrlText.Clear()
        UTubeViewsDataGridView.Rows.Clear()
    End Sub

    Private Sub DescriptionCheckBox_CheckedChanged(sender As Object, e As EventArgs)
        Dim isVisible = UTubeViewsDataGridView.Columns.Item(4).Visible
        UTubeViewsDataGridView.Columns.Item(4).Visible = Not isVisible
    End Sub

    Private Sub ViewsCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles ViewsCheckBox.CheckedChanged
        Dim isVisible = UTubeViewsDataGridView.Columns.Item(6).Visible
        UTubeViewsDataGridView.Columns.Item(6).Visible = Not isVisible
    End Sub

    Private Sub LikesCheckBox_CheckedChanged(sender As Object, e As EventArgs)
        Dim isVisible = UTubeViewsDataGridView.Columns.Item(8).Visible
        UTubeViewsDataGridView.Columns.Item(8).Visible = Not isVisible
    End Sub

    Private Sub CommentCountCheckBox_CheckedChanged(sender As Object, e As EventArgs)
        Dim isVisible = UTubeViewsDataGridView.Columns.Item(9).Visible
        UTubeViewsDataGridView.Columns.Item(9).Visible = Not isVisible
    End Sub

    Private Sub VideoCountCheckBox_CheckedChanged(sender As Object, e As EventArgs)
        Dim isVisible = UTubeViewsDataGridView.Columns.Item(7).Visible
        UTubeViewsDataGridView.Columns.Item(7).Visible = Not isVisible
    End Sub

    Private Sub SubscriberCheckBox_CheckedChanged(sender As Object, e As EventArgs)
        Dim isVisible = UTubeViewsDataGridView.Columns.Item(8).Visible
        UTubeViewsDataGridView.Columns.Item(8).Visible = Not isVisible
    End Sub

    Private Sub SetFolderPathButton_Click(sender As Object, e As EventArgs) Handles SetFolderPathButton.Click
        Using folderDialog As New FolderBrowserDialog()
            folderDialog.Description = "Select the folder to save your files"
            folderDialog.ShowNewFolderButton = True

            If folderDialog.ShowDialog() = DialogResult.OK Then
                FolderPathTextBox.Text = folderDialog.SelectedPath
            End If
        End Using
    End Sub
    Private Sub ShowLoadingForm(cancellationToken As CancellationToken)
        loadingForm = New LoadingForm()
        loadingFormTask = Task.Run(Sub() Application.Run(loadingForm), cancellationToken)
    End Sub

    Private Sub HideLoadingForm()
        If loadingForm IsNot Nothing Then
            loadingForm.Invoke(New Action(Sub() loadingForm.Close()))
            loadingFormTask = Nothing
        End If
    End Sub
End Class
