Imports System.Net.Http
Imports System.Net.Sockets
Imports System.Web
Imports Newtonsoft.Json

Public Class TikTokAPI
    Private ReadOnly httpClient As HttpClient
    Private ReadOnly clientId As String
    Private ReadOnly clientSecret As String
    Private ReadOnly redirectUri As String

    Public Sub New(clientId As String, clientSecret As String, redirectUri As String)
        Me.clientId = clientId
        Me.clientSecret = clientSecret
        Me.redirectUri = redirectUri
        Me.httpClient = New HttpClient()
    End Sub

    Public Async Function GetAccessToken(authorizationCode As String) As Task(Of String)
        Dim tokenUrl As String = "https://open.tiktokapis.com/platform/oauth/access_token"

        Dim parameters As New Dictionary(Of String, String) From {
            {"client_key", clientId},
            {"client_secret", clientSecret},
            {"code", authorizationCode},
            {"grant_type", "authorization_code"},
            {"redirect_uri", redirectUri}
        }

        Dim content As New FormUrlEncodedContent(parameters)
        Dim response As HttpResponseMessage = Await httpClient.PostAsync(tokenUrl, content)
        Dim responseContent As String = Await response.Content.ReadAsStringAsync()

        Dim tokenResponse As Dictionary(Of String, String) = JsonConvert.DeserializeObject(Of Dictionary(Of String, String))(responseContent)
        Dim accessToken As String = tokenResponse("access_token")

        Return accessToken
    End Function
End Class