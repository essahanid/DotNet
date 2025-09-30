
'Imports Microsoft.Office.Interop.Excel
'Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Net

Public Class Helper
    Public Shared Function GetImageFromUrl(url As String) As Image
        Dim webClient As New WebClient()
        Dim imageBytes() As Byte = webClient.DownloadData(url)
        Using ms As New IO.MemoryStream(imageBytes)
            Return ResizeImage(Image.FromStream(ms), 100, 100)
        End Using
    End Function
    Public Shared Function GetImageFromBase64(base64String As String) As Image
        ' Strip the data:image prefix and base64 header
        Dim base64Data As String = base64String.Substring(base64String.IndexOf(",") + 1)
        Dim imageBytes() As Byte = Convert.FromBase64String(base64Data)
        Using ms As New IO.MemoryStream(imageBytes)

            Return ResizeImage(Image.FromStream(ms), 100, 100)
        End Using
    End Function
    Public Shared Function ResizeImage(img As Image, width As Integer, height As Integer) As Image
        Dim bmp As New Bitmap(width, height)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(img, 0, 0, width, height)
        End Using
        Return bmp
    End Function
    Public Shared Function SaveImage(img As Image, filePath As String)
        ' Get the format of the image
        Dim currentTimestamp As Integer = DateTimeOffset.Now.ToUnixTimeSeconds()
        Dim format As ImageFormat = img.RawFormat
        filePath = filePath & "\" & currentTimestamp & ".jpg"
        Dim directoryPath As String = Path.GetDirectoryName(filePath)

        ' Check if the directory exists, if not, create it
        If Not Directory.Exists(directoryPath) Then
            Directory.CreateDirectory(directoryPath)
        End If

        ' Save the image to the specified file path
        img.Save(filePath, format)
    End Function
    Private Sub ExportDataGridViewToExcel(dgv As DataGridView)
        'Dim excelApp As New Application()
        'Dim excelWorkbook As Workbook = excelApp.Workbooks.Add(Type.Missing)
        'Dim excelWorksheet As Worksheet = Nothing
        'excelWorksheet = excelWorkbook.Sheets("Sheet1")
        'excelWorksheet = excelWorkbook.ActiveSheet
        'excelWorksheet.Name = "ExportedFromDatGrid"

        '' Add the column headers
        'For i As Integer = 1 To dgv.Columns.Count
        '    excelWorksheet.Cells(1, i) = dgv.Columns(i - 1).HeaderText
        'Next

        '' Add the rows
        'For i As Integer = 0 To dgv.Rows.Count - 1
        '    For j As Integer = 0 To dgv.Columns.Count - 1
        '        excelWorksheet.Cells(i + 2, j + 1) = dgv.Rows(i).Cells(j).Value.ToString()
        '    Next
        'Next

        '' Autofit columns
        'excelWorksheet.Columns.AutoFit()

        '' Save the workbook
        'Dim saveFileDialog As New SaveFileDialog()
        'saveFileDialog.Filter = "Excel Files|*.xlsx"
        'saveFileDialog.Title = "Save as Excel File"
        'saveFileDialog.ShowDialog()

        'If saveFileDialog.FileName <> "" Then
        '    excelWorkbook.SaveAs(saveFileDialog.FileName)
        '    excelWorkbook.Close()
        '    excelApp.Quit()

        '    ' Release COM objects to fully kill Excel process from running in the background
        '    Marshal.ReleaseComObject(excelWorksheet)
        '    Marshal.ReleaseComObject(excelWorkbook)
        '    Marshal.ReleaseComObject(excelApp)

        '    MessageBox.Show("Data Exported Successfully to " & saveFileDialog.FileName)
        'Else
        '    excelWorkbook.Close(False)
        '    excelApp.Quit()

        '    ' Release COM objects to fully kill Excel process from running in the background
        '    Marshal.ReleaseComObject(excelWorksheet)
        '    Marshal.ReleaseComObject(excelWorkbook)
        '    Marshal.ReleaseComObject(excelApp)
        'End If
    End Sub
    Private Sub ExportDataGridViewToExcel(dgv As DataGridView, folderPath As String, fileName As String)
        'Dim excelApp As New Application()
        'Dim excelWorkbook As Workbook = excelApp.Workbooks.Add(Type.Missing)
        'Dim excelWorksheet As Worksheet = Nothing
        'excelWorksheet = excelWorkbook.Sheets("Sheet1")
        'excelWorksheet = excelWorkbook.ActiveSheet
        'excelWorksheet.Name = "ExportedFromDataGrid"

        '' Add the column headers
        'For i As Integer = 1 To dgv.Columns.Count
        '    excelWorksheet.Cells(1, i) = dgv.Columns(i - 1).HeaderText
        'Next

        '' Add the rows
        'For i As Integer = 0 To dgv.Rows.Count - 1
        '    For j As Integer = 0 To dgv.Columns.Count - 1
        '        If dgv.Rows(i).Cells(j).Value IsNot Nothing Then
        '            excelWorksheet.Cells(i + 2, j + 1) = dgv.Rows(i).Cells(j).Value.ToString()
        '        End If
        '    Next
        'Next

        '' Autofit columns
        'excelWorksheet.Columns.AutoFit()

        '' Combine folder path and file name
        'Dim fullPath As String = IO.Path.Combine(folderPath, fileName)

        '' Save the workbook
        'Try
        '    excelWorkbook.SaveAs(fullPath)
        '    MessageBox.Show("Data Exported Successfully to " & fullPath)
        'Catch ex As Exception
        '    MessageBox.Show("Failed to save the file: " & ex.Message)
        'Finally
        '    excelWorkbook.Close(False)
        '    excelApp.Quit()

        '    ' Release COM objects to fully kill Excel process from running in the background
        '    Marshal.ReleaseComObject(excelWorksheet)
        '    Marshal.ReleaseComObject(excelWorkbook)
        '    Marshal.ReleaseComObject(excelApp)
        'End Try
    End Sub
End Class
