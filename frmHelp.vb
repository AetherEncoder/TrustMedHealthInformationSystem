Imports MySql.Data.MySqlClient

Public Class frmHelp
    Private ReadOnly _connectionString As String

    Public Sub New(Optional connectionString As String = "")
        InitializeComponent()
        _connectionString = connectionString
    End Sub

    Private Sub frmHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connString As String = _connectionString
        If String.IsNullOrWhiteSpace(connString) Then
            connString = "datasource=localhost;username=root;password=;database=trustmed"
        End If

        Dim idColumnCandidates As String() = {"UserID", "USERID", "user_id", "ID", "id"}
        Dim idColumn As String = ""

        Try
            Using conn As New MySqlConnection(connString)
                conn.Open()

                For Each candidate As String In idColumnCandidates
                    Dim sql As String = "SELECT COUNT(*) FROM information_schema.columns WHERE table_schema = DATABASE() AND table_name = 'USER' AND column_name = @columnName"
                    Using checkCmd As New MySqlCommand(sql, conn)
                        checkCmd.Parameters.AddWithValue("@columnName", candidate)
                        If Convert.ToInt32(checkCmd.ExecuteScalar()) > 0 Then
                            idColumn = candidate
                            Exit For
                        End If
                    End Using
                Next

                If String.IsNullOrWhiteSpace(idColumn) Then
                    lblUsernameValue.Text = "ID column not found in USER table."
                    lblPasswordValue.Text = "-"
                    Return
                End If

                Dim userSql As String = "SELECT username, password FROM USER WHERE " & idColumn & " = @id LIMIT 1"
                Using cmd As New MySqlCommand(userSql, conn)
                    cmd.Parameters.AddWithValue("@id", 190102)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lblUsernameValue.Text = If(reader("username") Is DBNull.Value, "", reader("username").ToString())
                            lblPasswordValue.Text = If(reader("password") Is DBNull.Value, "", reader("password").ToString())
                        Else
                            lblUsernameValue.Text = "No user found for ID 190102."
                            lblPasswordValue.Text = "-"
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            lblUsernameValue.Text = "Unable to load credentials."
            lblPasswordValue.Text = ex.Message
        End Try
    End Sub
End Class