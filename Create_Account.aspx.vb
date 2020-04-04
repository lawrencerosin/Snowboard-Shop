Imports System.Data.SqlClient
Public Class Create_Account
    Inherits System.Web.UI.Page
    Dim connect As New SqlConnection
    Dim addNewUser As New SqlCommand
    Dim dataHold As New DataTable
    Dim adapt As New SqlDataAdapter
    'Is used for the first name and last name validation
    Public Function EvaluateName(ByVal name As TextBox) As Boolean
        If name.Text.Length = 0 Then
            Return False
        Else
            For position As Integer = 0 To name.Text.Length - 1
                If Not (name.Text.Chars(position) >= "a" And name.Text.Chars(position) <= "z" Or name.Text.Chars(position) >= "A" And name.Text.Chars(position) <= "Z") Then
                    Return False
                End If
            Next
            Return True
        End If
    End Function
    Public Function CompareToField(ByVal field As TextBox) As Boolean
        'Since they can't be the same if they have a different amount of characters
        If field.Text.ToUpper() <> passwordBox.Text.ToUpper() Then
            Return False
        Else
            Return True
        End If
    End Function
    Public Function IsAcceptablePassword() As Boolean
        Dim capitalLetters As Boolean = False
        Dim lowercaseLetters As Boolean = False
        Dim specialCharacters As Boolean = False
        'Checks for the length of the password
        If passwordBox.Text.Length < 10 Or passwordBox.Text.Length > 20 Then
            Return False
        End If
        For position As Integer = 0 To passwordBox.Text.Length - 1
            If passwordBox.Text.Chars(position) >= "A" And passwordBox.Text.Chars(position) <= "Z" Then
                capitalLetters = True
            ElseIf passwordBox.Text.Chars(position) >= "a" And passwordBox.Text.Chars(position) <= "z" Then
                lowercaseLetters = True
            ElseIf passwordBox.Text.Chars(position) <> " " Then
                specialCharacters = True
            End If
        Next
        If capitalLetters And lowercaseLetters And specialCharacters Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub createAccount_Click(sender As Object, e As EventArgs) Handles createAccount.Click
        connect.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nellie\Documents\Snowboards Online.mdf;Integrated Security=True;Connect Timeout=30"
        connect.Open()
        addNewUser.Connection = connect
        addNewUser.CommandText = "Insert Into Renter_Info (first_name, last_name, email_address, username, user_password) Values(@first_name, @last_name, @email, @username, @password)"
        addNewUser.Parameters.Clear()
        addNewUser.Parameters.Add("@first_name", SqlDbType.Text)
        addNewUser.Parameters("@first_name").Value = firstNameBox.Text
        addNewUser.Parameters.Add("@last_name", SqlDbType.Text)
        addNewUser.Parameters("@last_name").Value = lastNameBox.Text
        addNewUser.Parameters.Add("@email", SqlDbType.NVarChar, 50)
        addNewUser.Parameters("@email").Value = emailBox.Text
        addNewUser.Parameters.Add("@username", SqlDbType.NVarChar, 20)
        addNewUser.Parameters("@username").Value = usernameBox.Text
        addNewUser.Parameters.Add("@password", SqlDbType.NVarChar, 20)
        addNewUser.Parameters("@password").Value = passwordBox.Text
        'Since the validation won't check if there is input in the e-mail box
        If emailBox.Text.Length = 0 Then
            MsgBox("You must put in your e-mail address.",, "No E-mail Address")
        End If
        adapt.SelectCommand = addNewUser
        Try

            adapt.Fill(dataHold)
            adapt.Update(dataHold)
            MsgBox("You've successfully created your account.",, "Account Creation Successful")
        Catch ex As Exception
            MsgBox("There was a problem creating your account. Make sure your username and password are unique, and you satisfied the above criteria.",, "Problem Creating Account")
        End Try
        connect.Close()
    End Sub

    Protected Sub firstNameValidator_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles firstNameValidator.ServerValidate
        args.IsValid = EvaluateName(firstNameBox)
    End Sub

    Protected Sub lastNameValidator_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles lastNameValidator.ServerValidate
        args.IsValid = EvaluateName(lastNameBox)
    End Sub

    Protected Sub Username_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles usernameValidator.ServerValidate
        Dim checkForUsername As New SqlCommand
        If usernameBox.Text.Length = 0 Then
            args.IsValid = False
        End If
        connect.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nellie\Documents\Snowboards Online.mdf;Integrated Security=True;Connect Timeout=30"
        connect.Open()
        checkForUsername.Connection = connect
        'Makes sure the username doesn't already exist
        checkForUsername.CommandText = "Select username From Renter_Info Where username=@username"
        checkForUsername.Parameters.Clear()
        checkForUsername.Parameters.Add("@username", SqlDbType.NVarChar, 20)
        checkForUsername.Parameters("@username").Value = usernameBox.Text
        Dim username As String = checkForUsername.ExecuteScalar()
        If username <> "" Then
            args.IsValid = False
        End If
        connect.Close()
    End Sub

    Protected Sub passwordValidator_ServerValidate(source As Object, args As ServerValidateEventArgs) Handles passwordValidator.ServerValidate
        If CompareToField(firstNameBox) Or CompareToField(lastNameBox) Or CompareToField(emailBox) Then
            args.IsValid = False
        ElseIf Not IsAcceptablePassword() Then
            args.IsValid = False
        ElseIf passwordBox.Text = "" OrElse passwordBox.Text <> confirmBox.Text Then
            args.IsValid = False
        End If
    End Sub

    Protected Sub back_Click(sender As Object, e As EventArgs) Handles back.Click
        Response.Redirect("http://localhost:51874/Log_In.aspx")
    End Sub
End Class