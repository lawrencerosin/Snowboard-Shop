Imports System.Data.SqlClient
Public Class Log_In
    Inherits System.Web.UI.Page

    Dim connection As New SqlConnection
    Dim evaluate As New SqlCommand

    Protected Sub signIn_Click(sender As Object, e As EventArgs) Handles signIn.Click
        Dim username As String = usernameBox.Text
        Dim password As String = passwordBox.Text
        evaluate.Connection = connection
        evaluate.Parameters.Clear()
        evaluate.Parameters.Add("@username", SqlDbType.VarChar, 20)
        evaluate.Parameters("@username").Value = username
        evaluate.Parameters.Add("@password", SqlDbType.VarChar, 20)
        evaluate.Parameters("@password").Value = password
        evaluate.CommandText = "Select username From Renter_Info Where username=@username And user_password=@password"
        Dim foundUsername As String = evaluate.ExecuteScalar()
        If foundUsername <> "" Then
            Session("username") = foundUsername
            Response.Redirect("User_Account")
        End If
    End Sub

    Private Sub form1_Load(sender As Object, e As EventArgs) Handles form1.Load
        connection.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nellie\Documents\Snowboards Online.mdf;Integrated Security=True;Connect Timeout=30"
        connection.Open()
        Session.Timeout = 120

    End Sub

    Private Sub createAccount_Click(sender As Object, e As EventArgs) Handles createAccount.Click
        Response.Redirect("Create_Account.aspx")
    End Sub

    Private Sub changePassword_Click(sender As Object, e As EventArgs) Handles changePassword.Click
        Response.Redirect("Change_Password")
    End Sub

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub forgotPassword_Click(sender As Object, e As EventArgs) Handles forgotPassword.Click
        Response.Redirect("Forgot_Password")

    End Sub
End Class