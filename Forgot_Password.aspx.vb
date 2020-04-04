Imports System.Data.SqlClient
Imports System.Net.Mail
Public Class Forgot_Password
    Inherits System.Web.UI.Page
    Dim connection As New SqlConnection
    Dim evaluate As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        connection.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nellie\Documents\Snowboards Online.mdf;Integrated Security=True;Connect Timeout=30"
        connection.Open()
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = usernameBox.Text
        evaluate.Connection = connection
        evaluate.Parameters.Clear()
        evaluate.Parameters.Add("@username", SqlDbType.VarChar, 20)
        evaluate.Parameters("@username").Value = username
        evaluate.CommandText = "Select password From Renter_Info Where username=@username"
        Dim password As String = evaluate.ExecuteScalar()
        If password <> Nothing Then
            Try
                Dim client As New SmtpAccess()

            Catch ex As Exception
                MsgBox("Unable to send e-mail",, "Not Sent")
            End Try
        End If

    End Sub
End Class