Public Class Main
    Inherits System.Web.UI.Page

    Private Sub logIn_Click(sender As Object, e As EventArgs) Handles logIn.Click
        Response.Redirect("http://localhost:51874/Log_In.aspx")
    End Sub

End Class