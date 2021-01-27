Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.IO
Imports System.Text
Public Class Form1
    Public Shared serverOrNot As Boolean = False
    Public Shared Client As TcpClient = Nothing
    Public Shared Server As TcpListener = Nothing
    Public Shared ServerThread As Thread = Nothing
    Public Shared ServerStream As NetworkStream
    Public Shared connectTo = "127.0.0.1"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked = True Then
            TextBox2.Text &= "啟動成功，等待連線..." & vbNewLine
            Server = New TcpListener(IPAddress.Parse(connectTo), 50000)
            ServerThread = New Thread(AddressOf ConnectionListener)
            ServerThread.IsBackground = True
            ServerThread.Start()
            serverOrNot = True
        Else
            Try
                Server = New TcpListener(IPAddress.Parse(connectTo), 50000)
                Client = New TcpClient(connectTo, 50000)
                TextBox2.Text &= "連線成功" & vbNewLine
            Catch ex As Exception
                MsgBox("Failed")
            End Try
        End If


    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Try

                Server.Stop()
                Server = New TcpListener(IPAddress.Parse(connectTo), 50000)
                ServerThread = New Thread(AddressOf ConnectionListener)
                ServerThread.IsBackground = True
                ServerThread.Start()
                Client = New TcpClient(connectTo, 50000)

                Dim msg As Byte()





                If serverOrNot = True Then
                    msg = System.Text.Encoding.ASCII.GetBytes("Server" & " Says:  " & TextBox3.Text)
                Else
                    msg = System.Text.Encoding.ASCII.GetBytes("Client" & " Says:  " & TextBox3.Text)
                End If
                ServerStream = Client.GetStream
                ServerStream.Write(msg, 0, msg.Length)
                ServerStream.Flush()
                Timer1.Start()
            Catch ex As Exception
                MsgBox("未連線")
            End Try
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Server.Pending = True Then
            Client = Server.AcceptTcpClient()

            ServerStream = Client.GetStream
            Dim buffsize As Integer

            buffsize = Client.ReceiveBufferSize
            Dim inStream(buffsize) As Byte
            ServerStream.Read(inStream, 0, buffsize)

            Dim returnData As String = System.Text.Encoding.ASCII.GetString(inStream)

            TextBox2.Text &= returnData
            TextBox2.Text &= vbNewLine
        End If
    End Sub
    Public Sub ConnectionListener()
        Try
            Server.Start()
        Catch ex As Exception
            MessageBox.Show("Unable to Accept Connections", "LAN Chat Server Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub
End Class
