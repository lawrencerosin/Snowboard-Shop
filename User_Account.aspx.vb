Imports System.Data
Imports System.Data.SqlClient
Public Class User_Account
    Inherits System.Web.UI.Page
    Dim day As Integer
    Dim acceptable As Boolean
    Const NO_BOOTS_FEE As Decimal = 20.0
    Const BOOTS_FEE As Decimal = 30.0
    Dim noBootsCount As Integer
    Dim bootsCount As Integer
    Dim noBootsTotal As Decimal
    Dim bootsTotal As Decimal
    'SQL variables
    Dim username As String
    Dim connection As New SqlConnection
    Dim showData As New SqlCommand
    Dim data As New DataTable
    Dim adapt As New SqlDataAdapter
    Dim changeData As New SqlCommand
    'Makes sure the input is a number and a positive one 
    Public Function EvaluateNumericalInput(ByVal inputBox As TextBox, ByVal type As String, ByRef hold As Integer) As Boolean
        'In case the day number isn't a number
        Try
            If Integer.Parse(inputBox.Text) >= 0 Then
                hold = Integer.Parse(inputBox.Text)
                Return True
            Else
                MsgBox("The " + type + " must be no lower than 0.", , "Unacceptable " + type + " Number")
                Return False
            End If

        Catch ex As Exception
            MsgBox("Your " + type + " must be a number.",, "Not a Number")
            Return False
        End Try
    End Function
    'Makes sure the input is a number and a positive one 
    Public Function EvaluateDayInput() As Boolean
        'In case the day number isn't a number
        Try
            If Integer.Parse(dayBox.Text) > 0 Then
                day = Integer.Parse(dayBox.Text)
                Return True
            Else
                MsgBox("The day in business must be greater than 0.", , "Unacceptable Day in Business")
                Return False
            End If

        Catch ex As Exception
            MsgBox("Your day must be a number.",, "Not a Number")
            Return False
        End Try
    End Function
    Public Sub Calculate()

        Dim noBootsAcceptable As Boolean = EvaluateNumericalInput(noBootsBox, "number of snowboards rented without boots", noBootsCount)
        Dim bootsAcceptable As Boolean = EvaluateNumericalInput(bootsBox, "number of snowboards rented with boots", bootsCount)
        Dim dayAcceptable As Boolean = EvaluateDayInput()
        'Exits if input was invalid
        If Not noBootsAcceptable OrElse Not bootsAcceptable Or Not dayAcceptable Then
            acceptable = False
            Exit Sub
        Else
            acceptable = True
        End If

        noBootsTotal = noBootsCount * NO_BOOTS_FEE
        bootsTotal = bootsCount * BOOTS_FEE
    End Sub
    Public Function MoneyFormat(ByVal money As Decimal) As String
        Dim formattedMoney As String = ""
        Dim position As Integer = 0
        'So each character can be retrieved
        Dim moneyString As String = money.ToString()



        While position < moneyString.Length AndAlso moneyString(position) <> "."


                formattedMoney += moneyString(position)
                position += 1

            End While

        'Adds the decimal point, and the two digits after it
        formattedMoney += "."
        'Avoids index out of bounds error
        If position + 1 < moneyString.Length Then
            formattedMoney += moneyString(position + 1)
            If position + 2 < moneyString.Length Then
                formattedMoney += moneyString(position + 2)
            Else
                formattedMoney += "0"



            End If
        Else
            formattedMoney += "00"

        End If
        'Adds a $ in the beginning
        formattedMoney = "$" + formattedMoney


        Return formattedMoney







    End Function
    Public Sub UpdateData()
        'Keeps unacceptable data from being added
        If Not acceptable Then
            Exit Sub
        End If
        Dim id As Integer
        Dim getLength As New SqlCommand
        connection.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nellie\Documents\Snowboards Online.mdf;Integrated Security=True;Connect Timeout=30"
        connection.Open()
        getLength.Connection = connection
        getLength.CommandText = "Select Count(*)+1 From Rentals"
        id = getLength.ExecuteScalar()
        changeData.Connection = connection
        changeData.CommandText = "Update_Purchase_Info"
        changeData.CommandType = CommandType.StoredProcedure
        changeData.Parameters.Clear()
        changeData.Parameters.Add("@day_number", SqlDbType.Int, 3)
        changeData.Parameters("@day_number").Value = day
        changeData.Parameters.Add("@username", SqlDbType.NVarChar, 20)
        changeData.Parameters("@username").Value = username
        changeData.Parameters.Add("@no_boots_rented", SqlDbType.Int, 3).Value = noBootsCount
        changeData.Parameters.Add("@boots_rented", SqlDbType.Int, 3).Value = bootsCount
        changeData.Parameters.Add("@no_boots_price", SqlDbType.Int, 3).Value = NO_BOOTS_FEE
        changeData.Parameters.Add("@boots_price", SqlDbType.Int, 3).Value = BOOTS_FEE
        changeData.Parameters.Add("@id", SqlDbType.Int, 3).Value = id
        adapt.SelectCommand = changeData
        adapt.Fill(data)
        adapt.Update(data)
        connection.Close()
    End Sub
    Public Sub ShowUpdatedData()
        Dim showAdapter As SqlDataAdapter
        Dim shownData As New DataTable
        Dim setOfData As New DataSet
        connection.Open()
        showData.Connection = connection
        showData.CommandText = "Select day_number, day_no_boots_rented, day_boots_rented, day_no_boots_fee, day_boots_fee, day_fee From Renter_Purchases Where username=@renterId Order By day_number"
        showData.Parameters.Clear()
        showData.Parameters.Add("@renterId", SqlDbType.VarChar, 20)
        showData.Parameters("@renterId").Value = username
        showAdapter = New SqlDataAdapter(showData.CommandText, connection)
        showAdapter.SelectCommand = showData
        showAdapter.Fill(data)
        renterInfo.DataSource = data
        renterInfo.DataBind()
        ReadToGridView()
        connection.Close()
    End Sub
    Public Sub ReadToGridView()

        Dim columnNames() As String = {"day_number", "day_no_boots_rented", "day_boots_rented", "day_no_boots_fee", "day_boots_fee", "day_fee"}
        For row As Integer = 0 To renterInfo.Rows.Count() - 1
            For column As Integer = 0 To columnNames.Length - 1
                If column > 2 Then
                    renterInfo.Rows(row).Cells(column).Text = data.Rows(row).Item(columnNames(column))
                Else
                    renterInfo.Rows(row).Cells(column).Text = MoneyFormat(data.Rows(row).Item(columnNames(column)))


                End If

            Next
        Next
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Session("username") = Nothing Then
            'Explains situation to user
            MsgBox("You didn't sign in.",, "Sign In Required")
            Response.Redirect("Log_In.aspx")
        Else
            username = Session("username")
            connection.ConnectionString = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Nellie\Documents\Snowboards Online.mdf;Integrated Security=True;Connect Timeout=30"
            ShowUpdatedData()
        End If
    End Sub

    Private Sub calculate_Click(sender As Object, e As EventArgs) Handles calculateRent.Click
        renterInfo.Columns.Clear()
        Calculate()
        Dim transaction As SqlTransaction = connection.BeginTransaction(IsolationLevel.ReadCommitted)
        Try
            UpdateData()
            changeData.Transaction = transaction
            transaction.Commit()
        Catch ex As Exception
            MsgBox("There was a problem updating the data.",, "Problem Updating Data")
            transaction.Rollback()
        End Try
        Try
            ShowUpdatedData()
        Catch ex As Exception
            MsgBox("This webpage was unable to show your purchase info.",, "Unable to Show Purchase Info")
        End Try
    End Sub

    Protected Sub renterInfo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles renterInfo.SelectedIndexChanged

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Session("username") = Nothing
        Response.Redirect("/Log_In.aspx")

    End Sub
End Class