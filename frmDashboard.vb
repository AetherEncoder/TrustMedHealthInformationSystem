Imports System.Data
Imports MySql.Data.MySqlClient

Public Class frmDashboard
    'Create connection variable/object named "MyConnection" 
    Dim MyConnection As Common.DbConnection

    'Create a Data Adapter variable/object
    '---A Data Adapter is the go-between for the connection object (MyConnection)
    'and the Dataset (borrowerDA)
    Dim userDA As New MySqlDataAdapter

    'Create a Dataset variable/object
    '---A Data Set is a place holder for the table in your database
    '---There should be one data set for each table in your database
    Dim userDS As New DataSet()

    'Declare the connection string and query variables/objects
    Dim MyConnectionString As String
    Dim userSQLQuery As String

    'We will use this later in the update and delete modules
    Dim row As Integer

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MyConnectionString = "datasource=localhost;username=root;password=;database=trustmed"
        ClearErrorMessages()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        ClearErrorMessages()

        Dim isValid As Boolean = True

        If String.IsNullOrWhiteSpace(txtUsername.Text) Then
            lblUsernameError.Text = "Username is required"
            lblUsernameError.Visible = True
            txtUsername.Focus()
            isValid = False
        End If

        If String.IsNullOrWhiteSpace(txtPassword.Text) Then
            lblPasswordError.Text = "Password is required"
            lblPasswordError.Visible = True
            If isValid Then
                txtPassword.Focus()
            End If
            isValid = False
        End If

        If isValid Then
            userSQLQuery = "SELECT * FROM USER WHERE username = @username AND password = @password"
            MyConnection = New MySqlConnection(MyConnectionString)

            Try
                MyConnection.Open()
                Dim cmd As New MySqlCommand(userSQLQuery, CType(MyConnection, MySqlConnection))
                cmd.Parameters.AddWithValue("@username", txtUsername.Text)
                cmd.Parameters.AddWithValue("@password", txtPassword.Text)

                Dim reader As MySqlDataReader = cmd.ExecuteReader()

                If reader.HasRows Then
                    reader.Close()
                    ShowDashboard()
                Else
                    lblLoginError.Text = "Invalid username or password."
                    lblLoginError.Visible = True
                End If

                reader.Close()

            Catch ex As MySqlException
                lblLoginError.Text = "Database error: " & ex.Message
                lblLoginError.Visible = True
            Catch ex As Exception
                lblLoginError.Text = "An unexpected error occurred: " & ex.Message
                lblLoginError.Visible = True
            Finally
                If MyConnection IsNot Nothing AndAlso MyConnection.State = ConnectionState.Open Then
                    MyConnection.Close()
                End If
            End Try
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub miAccountLogout_Click(sender As Object, e As EventArgs) Handles miAccountLogout.Click
        ShowLoginPage()
    End Sub

    Private Sub btnNewPatient_Click(sender As Object, e As EventArgs) Handles btnNewPatient.Click
        ShowQuickActionPlaceholder("New Patient")
    End Sub

    Private Sub btnNewDiagnosis_Click(sender As Object, e As EventArgs) Handles btnNewDiagnosis.Click
        ShowQuickActionPlaceholder("New Diagnosis")
    End Sub

    Private Sub btnNewConsultation_Click(sender As Object, e As EventArgs) Handles btnNewConsultation.Click
        ShowQuickActionPlaceholder("New Consultation")
    End Sub

    Private Sub btnNewLabOrder_Click(sender As Object, e As EventArgs) Handles btnNewLabOrder.Click
        ShowQuickActionPlaceholder("New Lab Order")
    End Sub

    Private Sub btnNewPrescription_Click(sender As Object, e As EventArgs) Handles btnNewPrescription.Click
        ShowQuickActionPlaceholder("New Prescription")
    End Sub

    Private Sub ShowQuickActionPlaceholder(actionName As String)
        MessageBox.Show(actionName & " form will be connected in the next module.", "Quick Action", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ShowDashboard()
        pnlLoginContainer.Visible = False
        pnlDashboard.Visible = True

        txtUsername.Text = ""
        txtPassword.Text = ""
        ClearErrorMessages()

        LoadDashboardOverview()
    End Sub

    Private Sub ShowLoginPage()
        pnlDashboard.Visible = False
        pnlLoginContainer.Visible = True

        txtUsername.Text = ""
        txtPassword.Text = ""
        ClearErrorMessages()

        txtUsername.Focus()
    End Sub

    Private Sub ClearErrorMessages()
        lblUsernameError.Visible = False
        lblUsernameError.Text = ""
        lblPasswordError.Visible = False
        lblPasswordError.Text = ""
        lblLoginError.Visible = False
        lblLoginError.Text = ""
    End Sub

    Private Sub LoadDashboardOverview()
        Try
            Using conn As New MySqlConnection(MyConnectionString)
                conn.Open()

                lblTotalPatientsValue.Text = GetTableCount(conn, "patient").ToString()
                lblConsultationsTodayValue.Text = GetTodayCount(conn, "consultation", New String() {"consultation_date", "consult_date", "date", "created_at", "date_created"}).ToString()
                lblPendingLabOrdersValue.Text = GetPendingCount(conn, "lab_order", New String() {"status"}).ToString()
                lblCompletedExaminationsValue.Text = GetCompletedCount(conn, "examination", New String() {"status"}).ToString()

                dgvRecentActivity.DataSource = GetRecentActivityTable(conn)
                dgvTodaysWork.DataSource = GetTodaysWorkTable(conn)
            End Using
        Catch
            lblTotalPatientsValue.Text = "-"
            lblConsultationsTodayValue.Text = "-"
            lblPendingLabOrdersValue.Text = "-"
            lblCompletedExaminationsValue.Text = "-"
            dgvRecentActivity.DataSource = CreateInfoTable("No recent activity available.")
            dgvTodaysWork.DataSource = CreateInfoTable("No work items available for today.")
        End Try
    End Sub

    Private Function GetTableCount(conn As MySqlConnection, tableName As String) As Integer
        If Not TableExists(conn, tableName) Then
            Return 0
        End If

        Using cmd As New MySqlCommand($"SELECT COUNT(*) FROM {tableName}", conn)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    Private Function GetTodayCount(conn As MySqlConnection, tableName As String, dateColumns As String()) As Integer
        If Not TableExists(conn, tableName) Then
            Return 0
        End If

        Dim dateCol As String = GetFirstExistingColumn(conn, tableName, dateColumns)
        If String.IsNullOrEmpty(dateCol) Then
            Return 0
        End If

        Using cmd As New MySqlCommand($"SELECT COUNT(*) FROM {tableName} WHERE DATE({dateCol}) = CURDATE()", conn)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    Private Function GetPendingCount(conn As MySqlConnection, tableName As String, statusColumns As String()) As Integer
        If Not TableExists(conn, tableName) Then
            Return 0
        End If

        Dim statusCol As String = GetFirstExistingColumn(conn, tableName, statusColumns)
        If String.IsNullOrEmpty(statusCol) Then
            Return GetTableCount(conn, tableName)
        End If

        Using cmd As New MySqlCommand($"SELECT COUNT(*) FROM {tableName} WHERE LOWER(COALESCE({statusCol}, '')) = 'pending'", conn)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    Private Function GetCompletedCount(conn As MySqlConnection, tableName As String, statusColumns As String()) As Integer
        If Not TableExists(conn, tableName) Then
            Return 0
        End If

        Dim statusCol As String = GetFirstExistingColumn(conn, tableName, statusColumns)
        If String.IsNullOrEmpty(statusCol) Then
            Return GetTableCount(conn, tableName)
        End If

        Using cmd As New MySqlCommand($"SELECT COUNT(*) FROM {tableName} WHERE LOWER(COALESCE({statusCol}, '')) = 'completed'", conn)
            Return Convert.ToInt32(cmd.ExecuteScalar())
        End Using
    End Function

    Private Function GetRecentActivityTable(conn As MySqlConnection) As DataTable
        Dim activitySelects As New List(Of String)

        Dim consultationSelect As String = BuildRecentActivitySelect(conn, "consultation", "Consultation")
        If consultationSelect <> "" Then activitySelects.Add(consultationSelect)

        Dim diagnosisSelect As String = BuildRecentActivitySelect(conn, "diagnosis", "Diagnosis")
        If diagnosisSelect <> "" Then activitySelects.Add(diagnosisSelect)

        Dim prescriptionSelect As String = BuildRecentActivitySelect(conn, "prescription", "Prescription")
        If prescriptionSelect <> "" Then activitySelects.Add(prescriptionSelect)

        If activitySelects.Count = 0 Then
            Return CreateInfoTable("No recent activity data available.")
        End If

        Dim sql As String = "SELECT activity_type AS Activity, reference_no AS ReferenceNo, patient_no AS PatientNo, activity_date AS ActivityDate FROM (" &
                            String.Join(" UNION ALL ", activitySelects) &
                            ") AS activity_feed ORDER BY activity_date DESC LIMIT 20"

        Dim dt As New DataTable()
        Using da As New MySqlDataAdapter(sql, conn)
            da.Fill(dt)
        End Using

        Return dt
    End Function

    Private Function GetTodaysWorkTable(conn As MySqlConnection) As DataTable
        Dim workSelects As New List(Of String)

        Dim consultWork As String = BuildTodaysConsultationWorkSelect(conn)
        If consultWork <> "" Then workSelects.Add(consultWork)

        Dim labWork As String = BuildTodaysLabWorkSelect(conn)
        If labWork <> "" Then workSelects.Add(labWork)

        If workSelects.Count = 0 Then
            Return CreateInfoTable("No work data available.")
        End If

        Dim sql As String = "SELECT work_type AS WorkType, reference_no AS ReferenceNo, patient_no AS PatientNo, work_date AS WorkDate, work_status AS Status FROM (" &
                            String.Join(" UNION ALL ", workSelects) &
                            ") AS work_feed ORDER BY work_date DESC LIMIT 20"

        Dim dt As New DataTable()
        Using da As New MySqlDataAdapter(sql, conn)
            da.Fill(dt)
        End Using

        Return dt
    End Function

    Private Function BuildRecentActivitySelect(conn As MySqlConnection, tableName As String, activityType As String) As String
        If Not TableExists(conn, tableName) Then
            Return ""
        End If

        Dim idCol As String = GetFirstExistingColumn(conn, tableName, New String() {$"{tableName}_id", "id"})
        Dim patientCol As String = GetFirstExistingColumn(conn, tableName, New String() {"patient_id", "patient_no", "patient"})
        Dim dateCol As String = GetFirstExistingColumn(conn, tableName, New String() {"date", "created_at", "date_created", tableName & "_date"})

        If String.IsNullOrEmpty(dateCol) Then
            Return ""
        End If

        Dim refExpr As String = If(String.IsNullOrEmpty(idCol), "'N/A'", $"CAST({idCol} AS CHAR)")
        Dim patientExpr As String = If(String.IsNullOrEmpty(patientCol), "''", $"CAST({patientCol} AS CHAR)")

        Return $"SELECT '{activityType}' AS activity_type, {refExpr} AS reference_no, {patientExpr} AS patient_no, {dateCol} AS activity_date FROM {tableName}"
    End Function

    Private Function BuildTodaysConsultationWorkSelect(conn As MySqlConnection) As String
        If Not TableExists(conn, "consultation") Then
            Return ""
        End If

        Dim idCol As String = GetFirstExistingColumn(conn, "consultation", New String() {"consultation_id", "id"})
        Dim patientCol As String = GetFirstExistingColumn(conn, "consultation", New String() {"patient_id", "patient_no", "patient"})
        Dim dateCol As String = GetFirstExistingColumn(conn, "consultation", New String() {"consultation_date", "date", "created_at", "date_created"})
        Dim statusCol As String = GetFirstExistingColumn(conn, "consultation", New String() {"status"})

        If String.IsNullOrEmpty(dateCol) Then
            Return ""
        End If

        Dim refExpr As String = If(String.IsNullOrEmpty(idCol), "'N/A'", $"CAST({idCol} AS CHAR)")
        Dim patientExpr As String = If(String.IsNullOrEmpty(patientCol), "''", $"CAST({patientCol} AS CHAR)")
        Dim statusExpr As String = If(String.IsNullOrEmpty(statusCol), "'Scheduled'", $"COALESCE({statusCol}, 'Scheduled')")

        Return $"SELECT 'Consultation' AS work_type, {refExpr} AS reference_no, {patientExpr} AS patient_no, {dateCol} AS work_date, {statusExpr} AS work_status FROM consultation WHERE DATE({dateCol}) = CURDATE()"
    End Function

    Private Function BuildTodaysLabWorkSelect(conn As MySqlConnection) As String
        If Not TableExists(conn, "lab_order") Then
            Return ""
        End If

        Dim idCol As String = GetFirstExistingColumn(conn, "lab_order", New String() {"lab_order_id", "id"})
        Dim patientCol As String = GetFirstExistingColumn(conn, "lab_order", New String() {"patient_id", "patient_no", "patient"})
        Dim dateCol As String = GetFirstExistingColumn(conn, "lab_order", New String() {"order_date", "date", "created_at", "date_created"})
        Dim statusCol As String = GetFirstExistingColumn(conn, "lab_order", New String() {"status"})

        If String.IsNullOrEmpty(dateCol) Then
            Return ""
        End If

        Dim refExpr As String = If(String.IsNullOrEmpty(idCol), "'N/A'", $"CAST({idCol} AS CHAR)")
        Dim patientExpr As String = If(String.IsNullOrEmpty(patientCol), "''", $"CAST({patientCol} AS CHAR)")
        Dim statusExpr As String = If(String.IsNullOrEmpty(statusCol), "'Pending'", $"COALESCE({statusCol}, 'Pending')")
        Dim pendingFilter As String = If(String.IsNullOrEmpty(statusCol), $"DATE({dateCol}) = CURDATE()", $"DATE({dateCol}) = CURDATE() OR LOWER(COALESCE({statusCol}, '')) = 'pending'")

        Return $"SELECT 'Lab Order' AS work_type, {refExpr} AS reference_no, {patientExpr} AS patient_no, {dateCol} AS work_date, {statusExpr} AS work_status FROM lab_order WHERE {pendingFilter}"
    End Function

    Private Function CreateInfoTable(message As String) As DataTable
        Dim dt As New DataTable()
        dt.Columns.Add("Info", GetType(String))
        dt.Rows.Add(message)
        Return dt
    End Function

    Private Function TableExists(conn As MySqlConnection, tableName As String) As Boolean
        Dim sql As String = "SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = DATABASE() AND table_name = @tableName"
        Using cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.AddWithValue("@tableName", tableName)
            Return Convert.ToInt32(cmd.ExecuteScalar()) > 0
        End Using
    End Function

    Private Function GetFirstExistingColumn(conn As MySqlConnection, tableName As String, candidates As String()) As String
        For Each columnName As String In candidates
            Dim sql As String = "SELECT COUNT(*) FROM information_schema.columns WHERE table_schema = DATABASE() AND table_name = @tableName AND column_name = @columnName"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@tableName", tableName)
                cmd.Parameters.AddWithValue("@columnName", columnName)
                If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
                    Return columnName
                End If
            End Using
        Next

        Return ""
    End Function
End Class
