Public Class Form1
    Dim cl As Boolean = False

    Private Sub MonthCalendar1_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        Dim d = MonthCalendar1.SelectionRange
        Dim datas = d.Start.ToString.Split(" ")
        Dim da = datas(0).Replace("/", "-")
        readDatas(da & ".txt")

    End Sub


    Private Sub readDatas(ByVal fileName As String)
        cl = True
        dv.Rows.Clear()

        If My.Computer.FileSystem.FileExists(fileName) = True Then
            Dim txt = My.Computer.FileSystem.ReadAllText(fileName, System.Text.Encoding.Default)
            If txt = "" Then
                Return
            End If
            Dim lines = Split(Trim(txt), vbCrLf)
            For Each item In lines
                Dim datas = item.Split(",")
                dv.Rows.Add(datas(0), datas(1))
            Next

        End If
    End Sub
    Private Sub saveEdit()
        Dim d = MonthCalendar1.SelectionRange
        Dim datas = d.Start.ToString.Split(" ")
        Dim da = datas(0).Replace("/", "-")
        Dim fileName = da & ".txt"

        Dim i = dv.Rows.Count - 1
        If i > 4 Then
            dv.ReadOnly = True
            Return
        Else
            dv.ReadOnly = False
        End If
        Dim str = ""
        For n = 0 To i - 1
            Dim ce = dv.Rows(n).Cells
            Dim orderP = ce(0).Value
            Dim phone = ce(1).Value
            If n <> i - 1 Then
                str &= orderP & "," & phone & vbNewLine
            Else
                str &= orderP & "," & phone
            End If

        Next
        My.Computer.FileSystem.WriteAllText(fileName, str, False)

    End Sub


    Private Sub dv_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dv.CellEndEdit
        saveEdit()
    End Sub

    Private Sub dv_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles dv.RowsRemoved
        If cl = True Then Return
        saveEdit()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim d = MonthCalendar1.SelectionRange
        Dim datas = d.Start.ToString.Split(" ")
        Dim da = datas(0).Replace("/", "-")
        readDatas(da & ".txt")
    End Sub
End Class
