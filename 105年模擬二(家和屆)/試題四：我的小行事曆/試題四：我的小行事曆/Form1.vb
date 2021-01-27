Public Class Form1
    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged

        MonthChange()

    End Sub
    Private Sub setAllMonth()
        Dim direct = My.Computer.FileSystem.CurrentDirectory

        Dim collection = My.Computer.FileSystem.GetFiles(
        direct, FileIO.SearchOption.SearchAllSubDirectories, "*.txt")
        For Each fileName In collection
            Dim s = fileName.Split("\")
            Dim fileLastName = s(UBound(s)).Split(".")(0)
            Dim YMD = fileLastName.Split("-")
            Dim d As New Date(YMD(0), YMD(1), YMD(2))
            MonthCalendar1.AddBoldedDate(d)
        Next
        MonthCalendar1.UpdateBoldedDates()

    End Sub
    Private Sub MonthChange()
        Dim k As Date = MonthCalendar1.SelectionRange.Start
        Dim t = k.ToString
        Dim input = t.Split(" ")
        Dim ds = input(0).Split("/")
        readInput(String.Join("-", ds) & ".txt")
    End Sub
    Private Sub readInput(ByVal d As String)
        'd是日期
        TextBox1.Text = ""
        Dim openFile As New OpenFileDialog
        openFile.FileName = d
        If My.Computer.FileSystem.FileExists(openFile.FileName) = True Then
            Dim txt = My.Computer.FileSystem.ReadAllText(openFile.FileName)
            TextBox1.Text = txt
        End If

    End Sub
    Private Sub saveFile(ByVal d As String, ByVal savetxt As String)
        Try
            My.Computer.FileSystem.WriteAllText(d, savetxt, False)
        Catch ex As Exception

        End Try


    End Sub
    Private Sub deleteFile(ByVal d As String)
        If My.Computer.FileSystem.FileExists(d) = True Then
            My.Computer.FileSystem.DeleteFile(d)
        End If
        readInput("")
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim k As Date = MonthCalendar1.SelectionRange.Start
        Dim t = k.ToString
        Dim input = t.Split(" ")
        Dim ds = input(0).Split("/")
        Dim filename = String.Join("-", ds)
        deleteFile(filename & ".txt")
        setbold(String.Join("-", ds))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim savetxt = TextBox1.Text
        Dim k As Date = MonthCalendar1.SelectionRange.Start
        Dim t = k.ToString
        Dim input = t.Split(" ")
        Dim ds = input(0).Split("/")
        Dim filename = String.Join("-", ds) & ".txt"
        saveFile(filename, savetxt)
        readInput(filename)
        setbold(String.Join("-", ds))
    End Sub
    Private Sub setbold(ByVal s As String)
        Dim YMD = s.Split("-")
        Dim d As New Date(YMD(0), YMD(1), YMD(2))
        MonthCalendar1.AddBoldedDate(d)
        MonthCalendar1.UpdateBoldedDates()


    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setAllMonth()
        MonthChange()
    End Sub
End Class
