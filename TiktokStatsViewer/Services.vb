Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Forms.Design.AxImporter
Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json
Imports OpenQA.Selenium
Imports OpenQA.Selenium.Chrome
Imports OpenQA.Selenium.Interactions
Imports OpenQA.Selenium.Support.UI
Imports Windows.Win32.UI.Input

Public NotInheritable Class Services

    Shared BASE_FOLDER_PATH As String
    Shared chromeDriver As ChromeDriver
    Public Shared Function Init(ByVal Path As String, ByVal AccountName As String)
        BASE_FOLDER_PATH = Path

        ' Check if the directory exists, if not, create it
        If Not Directory.Exists(Path) Then
            Directory.CreateDirectory(Path)
        End If
        If Not Directory.Exists(Path & "\" & AccountName & "\" & "Videos") Then
            Directory.CreateDirectory(Path & "\" & AccountName & "\" & "Videos")
        End If
        If Not Directory.Exists(Path & "\" & AccountName & "\" & "Images") Then
            Directory.CreateDirectory(Path & "\" & AccountName & "\" & "Images")
        End If
    End Function
    'This function to load more data using pagination
    Public Shared Function LoadMoreScrapeAdsTransparencyCenterForUrl(ByVal Url As String) As ArrayList
        Dim driverService = ChromeDriverService.CreateDefaultService()

        Dim videoIds As New ArrayList()
        Dim driverOptions As New ChromeOptions()
        'driverOptions.AddArgument("--headless") ' Optional: Run in headless mode
        driverOptions.AddArguments("--ignore-certificate-errors")
        chromeDriver = New ChromeDriver(driverService, driverOptions)

        ' Increase timeout settings
        chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60)
        chromeDriver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(60)
        Dim videoInfoList As New ArrayList()
        chromeDriver.Navigate().GoToUrl(Url)
        'Dim htmlContent As String = chromeDriver.PageSource
        Dim wait As WebDriverWait = New WebDriverWait(chromeDriver, TimeSpan.FromSeconds(10))
        wait.Until(Function(drv) drv.FindElement(By.TagName("body")))

        ' Additional pop-up handling (example for other pop-ups or modals)
        Try
            Dim modalCloseButton As IWebElement = chromeDriver.FindElement(By.Id("verify-bar-close"))
            modalCloseButton.Click()
        Catch ex As NoSuchElementException
            ' If no modal popup is found, continue
        End Try

        'wait.Until(Function(d) d.FindElements(By.CssSelector("*[class$='DivGuestModeContainer']")).Count > 0)
        'Dim script As String = "return document.querySelectorAll('*[class$=""-DivGuestModeContainer""]');"

        'Dim elements As Object = chromeDriver.ExecuteScript(script)
        ' Check for login popup and close it if it appears
        Try
            Dim loginPopupCloseButtonContainer As IWebElement = chromeDriver.FindElement(By.CssSelector("[class$='DivGuestModeContainer']"))
            Dim loginPopupCloseButton As IWebElement = loginPopupCloseButtonContainer.FindElement(By.CssSelector("[data-e2e='channel-item']"))
            loginPopupCloseButton.Click()
        Catch ex As NoSuchElementException
            ' If no login popup is found, continue
        End Try


        ' Define maximum number of retries
        Dim maxRetries As Integer = 10
        Dim retries As Integer = 0
        Dim elementFound As Boolean = False
        Dim ItemListSelector = By.CssSelector("[data-e2e='user-post-item-list']")
        Try
            elementFound = wait.Until(Function(d) d.FindElements(ItemListSelector).Count > 0)
        Catch ex As WebDriverTimeoutException
            elementFound = False
        End Try
        ' Dim ItemListElement1 = chromeDriver.FindElement(ItemListSelector)
        ' Loop until the element is found or the maximum number of retries is reached
        While Not elementFound AndAlso retries < maxRetries
            Try
                ' Refresh the browser
                chromeDriver.Navigate().Refresh()

                ' Wait for the element to be present
                elementFound = wait.Until(Function(d) d.FindElements(ItemListSelector).Count > 0)
            Catch ex As WebDriverTimeoutException
                ' Element not found within the timeout, increment the retry counter
                retries += 1
            End Try
        End While

        ' Check if the element was found
        If elementFound Then
            ScrollDown(chromeDriver)
        End If
        ' Wait for the video elements to be visible
        'wait.Until(Function(drv) drv.FindElement(ItemListSelector))

        Try


            If ItemListSelector IsNot Nothing Then
                Dim ItemListElement As IWebElement = chromeDriver.FindElement(ItemListSelector)
                If ItemListElement IsNot Nothing Then
                    Dim videoInfo As TikTokVideoInfo

                    Dim videoList = ItemListElement.FindElements(By.CssSelector("[data-e2e='user-post-item']"))

                    For Each videoElement As IWebElement In videoList

                        videoInfo = New TikTokVideoInfo
                        Dim viewsElement = videoElement.FindElement(By.CssSelector("[data-e2e='video-views']"))
                        Dim absoluteUrl As String = ""

                        Dim videoTitleElementContainer = videoElement.FindElement(By.XPath("following-sibling::div[1]"))
                        Dim videoTitleElement = videoTitleElementContainer.FindElement(By.CssSelector("[data-e2e='user-post-item-desc']"))
                        Dim aElements = videoElement.FindElements(By.TagName("a"))
                        Dim videoUrlElement = aElements(0)

                        Dim href As String = videoUrlElement.GetAttribute("href")
                        Dim imgElement = videoElement.FindElement(By.TagName("img"))
                        Dim imgSrc As String = imgElement.GetAttribute("src")
                        Dim title As String = videoTitleElement.GetAttribute("aria-label")

                        Dim viewsCount = If(String.IsNullOrWhiteSpace(viewsElement.Text), "0", viewsElement.Text)
                        videoInfo.ViewsCount = Integer.Parse(viewsCount)
                        videoInfo.Url = href
                        videoInfo.AbsoluteUrl = absoluteUrl
                        videoInfo.CoverUrl = imgSrc
                        videoInfo.Title = title
                        videoInfoList.Add(videoInfo)
                    Next
                Else
                    'ScrollDown(chromeDriver)
                End If
            End If
        Catch ex As NoSuchElementException

        End Try

        chromeDriver.Quit()
        'chromeDriver.Close()

        Return videoInfoList
    End Function
    Shared Sub ScrollDown(driver As IWebDriver)
        ' Execute JavaScript code to scroll down the page
        Dim js As IJavaScriptExecutor = TryCast(driver, IJavaScriptExecutor)
        js.ExecuteScript("window.scrollBy(0, 1000);")
    End Sub

    'this Function to find ytimg links from related Htmlcontent
    Public Shared Async Function DownloadVideoFile(ByVal url As String, ByVal account As String, ByVal index As String) As Task
        Dim driverService = ChromeDriverService.CreateDefaultService()
        Dim chromeOptions As New ChromeOptions()

        ' Add preferences to ChromeOptions
        chromeOptions.AddUserProfilePreference("profile.default_content_settings.popups", 0)
        chromeOptions.AddUserProfilePreference("download.prompt_for_download", False)
        chromeOptions.AddUserProfilePreference("download.default_directory", BASE_FOLDER_PATH & "\" & account)
        chromeOptions.AddUserProfilePreference("download.directory_upgrade", True)
        chromeOptions.AddUserProfilePreference("safebrowsing.enabled", True)

        chromeDriver = New ChromeDriver(driverService, chromeOptions)
        ' Navigate to the TikTok video page
        chromeDriver.Navigate().GoToUrl(url)

        ' Wait for the video element to be present
        Dim wait As WebDriverWait = New WebDriverWait(chromeDriver, TimeSpan.FromSeconds(30))
        wait.Until(Function(d) d.FindElement(By.TagName("video")))

        ' Find the video element
        Dim videoElement As IWebElement = chromeDriver.FindElement(By.TagName("video"))

        ' Perform a right-click action on the video element
        Dim actions As New Actions(chromeDriver)
        actions.ContextClick(videoElement).Perform()

        ' Pause to allow time for AutoIt to handle the context menu
        'System.Threading.Thread.Sleep(2000) ' Adjust the time as needed
        Dim xpathExpression As String = "//span[text()='Download video']"

        Dim spanElement As IWebElement = chromeDriver.FindElement(By.XPath(xpathExpression))
        Dim parentElement As IWebElement = spanElement.FindElement(By.XPath("parent::*"))
        parentElement.Click()

        ' Wait for the download to complete
        Dim downloadDir As String = BASE_FOLDER_PATH & "\" & account
        Dim newDownloadDir As String = BASE_FOLDER_PATH & "\" & account & "\Videos"
        Dim downloadedFilePath As String = WaitForDownloadToComplete(downloadDir)
        chromeDriver.Quit()
        ' Rename the downloaded file
        Dim newFileName As String = index & ".mp4"
        Dim newFilePath As String = Path.Combine(newDownloadDir, newFileName)
        File.Move(downloadedFilePath, newFilePath)

    End Function

    Public Shared Function IsDownloadComplete(ByVal fileName As String) As Boolean
        ' Specify the download directory
        Dim downloadDir As String = "C:\Downloads"

        ' Specify the file name to wait for


        ' Wait for the file to be downloaded
        Dim downloadComplete As Boolean = False
        Dim timeoutInSeconds As Integer = 60
        Dim waitTimeMilliseconds As Integer = 1000
        Dim elapsedTimeMilliseconds As Integer = 0

        While Not downloadComplete AndAlso elapsedTimeMilliseconds < timeoutInSeconds * 1000
            ' Check if the file exists in the download directory
            If File.Exists(Path.Combine(downloadDir, fileName)) Then
                downloadComplete = True
            Else
                ' Wait for a short duration before checking again
                Threading.Thread.Sleep(waitTimeMilliseconds)
                elapsedTimeMilliseconds += waitTimeMilliseconds
            End If
        End While

        Return downloadComplete

    End Function
    Public Shared Function WaitForDownloadToComplete(downloadDir As String) As String
        Dim timeout As TimeSpan = TimeSpan.FromMinutes(2)
        Dim stopTime As DateTime = DateTime.Now.Add(timeout)
        Dim latestFile As String = ""

        While DateTime.Now < stopTime
            ' Get the latest file in the download directory
            latestFile = Directory.GetFiles(downloadDir).OrderByDescending(Function(f) New FileInfo(f).CreationTime).FirstOrDefault()

            ' Check if the file is still being downloaded (if it has a .crdownload extension)
            If latestFile IsNot Nothing AndAlso Not latestFile.EndsWith(".crdownload") Then
                Exit While
            End If

            ' Wait for a short period before checking again
            Thread.Sleep(1000)
        End While

        If latestFile = "" OrElse latestFile.EndsWith(".crdownload") Then
            Throw New Exception("Download timed out or failed.")
        End If

        Return latestFile
    End Function


    'Public Shared Function GetLastDownloaded(ByVal fileName As String) As Boolean
    'End Function
End Class

