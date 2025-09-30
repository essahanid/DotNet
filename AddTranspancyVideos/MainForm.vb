Public Class MainForm
    'start scrapping from target urls and fill in retreived videos
    Private Async Sub GoButton_Click(sender As Object, e As EventArgs) Handles GoButton.Click
        'https://youtu.be/
        Dim shortBaseUrl = "https://www.youtube.com/shorts/"
        Dim longBaseUrl = "https://www.youtube.com/watch?v="
        Dim url = YouTubeUrlsText.Text '"https://adstransparency.google.com/advertiser/AR10865321129124298753/creative/CR11401737908462288897?region=AU&format=VIDEO"
        If Not String.IsNullOrWhiteSpace(url) Then
            Dim ids = Services.ScrapeAdsTransparencyCenterForUrl(url)
            UTubeViewsDataGridView.Rows.Clear()
            TotalVideosLabel.Text = "Total videos = " & ids.Count

            ResultMessageLabel.Text = "Video urls fetched successfully...."
            For Each id As String In ids
                If Not String.IsNullOrEmpty(id) Then
                    Dim videoType = Await Services.GetYouTubeType(id)
                    Dim resUrl As String
                    Select Case videoType
                        Case 1
                            Console.WriteLine("Option 2 selected")
                            resUrl = shortBaseUrl
                        Case 2
                            resUrl = longBaseUrl
                        Case Else
                            Exit For
                    End Select
                    UTubeViewsDataGridView.Rows.Add(New String() {resUrl & id, id})
                End If
            Next
        Else
            ResultMessageLabel.Text = "Paste url in textarea please....."

        End If
    End Sub
    'The following button click hundler are responsible for clear textinput 
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click

        YouTubeUrlsText.Clear()
        UTubeViewsDataGridView.Rows.Clear()
        TotalVideosLabel.Text = "Total videos = 0"
        ResultMessageLabel.Text = ""
        Services.DisposeChromeDriver()
    End Sub
    'Handle video link click to open it in browser
    Private Sub UTubeViewsDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles UTubeViewsDataGridView.CellContentClick
        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then
            Dim cellValue As Object = UTubeViewsDataGridView(e.ColumnIndex, e.RowIndex).Value
            Dim link As String = cellValue.ToString()

            Dim startInfo As New ProcessStartInfo(link)
            startInfo.UseShellExecute = True
            Process.Start(startInfo)
        End If
    End Sub

    Private Sub MainForm_FontChanged(sender As Object, e As EventArgs) Handles MyBase.FontChanged
        Services.DisposeChromeDriver()
    End Sub
    'start scrapping from target urls and fill in more paginated  videos
    Private Async Sub LoadMoreButton_Click(sender As Object, e As EventArgs) Handles LoadMoreButton.Click
        Dim shortBaseUrl = "https://www.youtube.com/shorts/"
        Dim longBaseUrl = "https://www.youtube.com/watch?v="
        Dim url = YouTubeUrlsText.Text
        If Not String.IsNullOrWhiteSpace(url) Then
            Dim ids = Services.LoadMoreScrapeAdsTransparencyCenterForUrl(url)
            Dim count = UTubeViewsDataGridView.Rows.Count
            count = count + ids.Count
            TotalVideosLabel.Text = "Total videos = " & count

            ResultMessageLabel.Text = "Video urls fetched successfully...."
            For Each id As String In ids
                If Not String.IsNullOrEmpty(id) Then
                    Dim videoType = Await Services.GetYouTubeType(id)
                    Dim resUrl As String
                    Select Case videoType
                        Case 1
                            resUrl = shortBaseUrl
                        Case 2
                            resUrl = longBaseUrl
                        Case Else
                            Exit For
                    End Select
                    UTubeViewsDataGridView.Rows.Add(New String() {resUrl & id, id})
                End If
            Next
        Else
            ResultMessageLabel.Text = "Cannot load more videos....."

        End If
    End Sub
End Class
