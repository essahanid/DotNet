Imports System.Text.RegularExpressions
Imports Google.Apis.Services
Imports Google.Apis.YouTube.v3
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Public NotInheritable Class Services
    Shared chromeDriver As ChromeDriver
    Shared ReadOnly APIKEY = "AIzaSyDgAt1a3Bo5QI_ZlIxbSf-CretiXVE8X34"
    Shared ReadOnly durationThreshold As TimeSpan = TimeSpan.FromMinutes(1) ' Set your desired threshold duration here
    'This function will retreive data from youtube using youtube api/api key
    Shared Async Function GetYouTubeType(ByVal videoIdOrChannelId As String) As Task(Of Integer)
        Dim youtubeService As YouTubeService = New YouTubeService(New BaseClientService.Initializer() With {
            .ApiKey = APIKEY
        })

        Dim request = youtubeService.Videos.List("snippet,statistics,contentDetails")
        Dim videoType = 0
        request.Id = videoIdOrChannelId
        Dim response = Await request.ExecuteAsync()
        Dim _video = Nothing
        If response.Items IsNot Nothing Then
            If response.Items.Count > 0 Then
                Dim videoDuration As TimeSpan = Xml.XmlConvert.ToTimeSpan(response.Items(0).ContentDetails.Duration)

                If videoDuration <= durationThreshold Then
                    videoType = 1
                Else
                    videoType = 2
                End If
            End If
        End If
        Return videoType
    End Function
    'this Function to find ytimg links from related Htmlcontent
    Public Shared Function ExtractYTIMG(ByVal htmlContent As String) As ArrayList
        ' Regular expression to find the "ytimg" in the adrt HTML source.
        Dim pattern As String = "https://i\.ytimg\.com/vi/([^/]+)/hqdefault\.jpg"
        Dim regex As New Regex(pattern)
        Dim matches As MatchCollection = regex.Matches(htmlContent)
        Dim videoIds As New ArrayList()
        For Each match1 As Match In matches
            If match1.Success Then
                Dim videoId As String = match1.Groups(1).Value
                If videoId IsNot Nothing Then
                    videoIds.Add(videoId)
                End If
            End If
        Next
        Return videoIds
    End Function
    'This function return videos IDs from input URL
    Public Shared Function ScrapeAdsTransparencyCenterForUrl(ByVal Url As String) As ArrayList
        Dim driverService = ChromeDriverService.CreateDefaultService()
        Dim driverOptions As New ChromeOptions()
        driverOptions.AddArgument("--headless") ' Optional: Run in headless mode
        chromeDriver = New ChromeDriver(driverService, driverOptions)

        chromeDriver.Navigate().GoToUrl(Url)
        Dim htmlContent As String = chromeDriver.PageSource
        Dim videoIds = ExtractYTIMG(htmlContent)
        Console.WriteLine(htmlContent)

        chromeDriver.Quit()

        Return videoIds
    End Function
    Public Shared Function DisposeChromeDriver()
        chromeDriver.Dispose()
    End Function
    'This function to load more data using pagination
    Public Shared Function LoadMoreScrapeAdsTransparencyCenterForUrl(ByVal Url As String) As ArrayList
        Dim driverService = ChromeDriverService.CreateDefaultService()
        Dim videoIds As New ArrayList()
        Dim driverOptions As New ChromeOptions()
        'driverOptions.AddArgument("--headless") ' Optional: Run in headless mode
        driverOptions.AddArguments("--ignore-certificate-errors")
        chromeDriver = New ChromeDriver(driverService, driverOptions)

        chromeDriver.Navigate().GoToUrl(Url)
        Try
            Dim selector = By.CssSelector("material-button.advertiser-link-button")
            If selector IsNot Nothing Then
                Dim moreButton As IWebElement = chromeDriver.FindElement(selector)
                If moreButton IsNot Nothing Then
                    moreButton.Click()
                Else
                    ScrollDown(chromeDriver)
                End If
            End If
        Catch ex As NoSuchElementException
            ScrollDown(chromeDriver)
        End Try
        Dim htmlContent As String = chromeDriver.PageSource
        videoIds = ExtractYTIMG(htmlContent)
        Console.WriteLine(htmlContent)
        'chromeDriver.Quit()
        'chromeDriver.Close()

        Return videoIds
    End Function
    Shared Sub ScrollDown(driver As IWebDriver)
        ' Execute JavaScript code to scroll down the page
        Dim js As IJavaScriptExecutor = TryCast(driver, IJavaScriptExecutor)
        js.ExecuteScript("window.scrollBy(0, 1000);")
    End Sub
End Class
