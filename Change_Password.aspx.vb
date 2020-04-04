Imports System.Data.SqlClient
Public Class Update_Info
    Inherits System.Web.UI.Page
    Dim passwordChanger As New SqlCommand
    Dim connection As New SqlConnection
    Dim adapt As New SqlDataAdapter
    Dim hold As New DataTable
    Public Sub CallChangePassword()
        Dim username As String = usernameBox.Text
        Dim oldPassword As String = oldPasswordBox.Text
        Dim newPassword As String = newPasswordBox.Text
        Dim confirmNewPassword As String = confirmNewPasswordBox.Text
        passwordChanger.CommandText = "Change_Password"
        passwordChanger.Parameters.Add("@username", SqlDbType.NVarChar, 20)
        passwordChanger.Parameters("@username").Value = username
        passwordChanger.Parameters.Add("@old_password", SqlDbType.NVarChar, 20)
        passwordChanger.Parameters("@old_password").Value = oldPassword
        passwordChanger.Parameters.Add("@new_password", SqlDbType.NVarChar, 20)
        passwordChanger.Parameters("@newPassword").Value = newPassword
        passwordChanger.Parameters.Add("@confirm_new_password", SqlDbType.NVarChar, 20)
        passwordChanger.Parameters("@confirm_new_password").Value = confirmNewPassword
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        connection.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nellie\Documents\Snowboards Online.mdf;Integrated Security=True;Connect Timeout=30"
    End Sub

    Private Sub changePassword_Click(sender As Object, e As EventArgs) Handles changePassword.Click
        Dim transaction As SqlTransaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
        connection.Open()
        CallChangePassword()
        adapt.UpdateCommand = passwordChanger
        Try
            passwordChanger.Transaction = transaction
            adapt.Update(hold)
            transaction.Commit()
        Catch ex As Exception
            MsgBox("There was a problem changing your password.", "Problem Changing Password")
            transaction.Rollback()
        End Try
    End Sub
End Class