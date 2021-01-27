Imports System.Net
Imports System.Threading
Imports System.Net.Sockets
Public Class ChatServer
    Inherits ApplicationContext

    Private Server As TcpListener = Nothing
    Private ServerThread As Thread = Nothing
    Public Sub New(ByVal ip As String)
        Server = New TcpListener(IPAddress.Parse(ip), 50000)
        ServerThread = New Thread(AddressOf ConnectionListener)
        ServerThread.IsBackground = True
        ServerThread.Start()

    End Sub
    Public Sub ConnectionListener()
        Server.Start()
        While True
            Dim client As TcpClient = Server.AcceptTcpClient
            Dim T As New Thread(AddressOf StartChatForm)
            T.Start()
        End While
    End Sub
    Public Sub StartChatForm()
        MsgBox(123)
    End Sub
End Class
