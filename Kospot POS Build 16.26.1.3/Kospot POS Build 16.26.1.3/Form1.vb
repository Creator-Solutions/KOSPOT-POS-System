Imports MySql.Data.MySqlClient
Public Class frmLogin

    Dim MySqlCon As New MySqlConnection("host=127.0.0.1; user=root; password=")

    Public adminName As String

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        txtPassword.PasswordChar = "*"
        Dim SqlQuery As String = "SELECT AdminName, AdminPassword FROM kospot_db.admin WHERE AdminName='" + txtAdminName.Text + "' AND AdminPassword='" + txtPassword.Text + "'"

        Dim SQLComm As New MySqlCommand

        SQLComm.Connection = MySqlCon
        SQLComm.CommandText = SqlQuery

        Dim sqlReader As MySqlDataReader
        sqlReader = SQLComm.ExecuteReader()

        If sqlReader.Read() = True Then
            adminName = sqlReader.GetValue(0).ToString()
            MessageBox.Show("Welcome " + adminName)
            Dim pos As New PointOfSale()
            pos.ShowDialog()
            Me.Hide()
        End If

        MySqlCon.Close()

    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtPassword.PasswordChar = "*"
        Timer1.Enabled = True
        Try
            MySqlCon.Open()
            PBDBCon.Image = My.Resources.wifi
        Catch ex As Exception
            PBDBCon.Image = My.Resources.disc
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblDateTime.Text = Date.Now.ToString("ddd dd MMM yyyy HH:mm:ss")
    End Sub
End Class
