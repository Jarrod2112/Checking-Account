Public Class Form1

    Private inputAmount As Double
    Private Balance As Double
    Private checkCharge = 10
    Private AccountBalance As Double
    Public DepositCount As Integer
    Public ServiceCount As Integer
    Public CheckingCount As Integer
    Public DepositTotalAmount As Double
    Public ServiceTotalAmount As Double
    Public CheckingTotal As Double

    Private Function ValidateInput() As Boolean
        If Not Double.TryParse(txtInputAmount.Text, inputAmount) Then
            MessageBox.Show("Input must be numeric")
        End If
        Return True
    End Function

    Private Function Deposit(inputAmount As Double)
        Dim depositAmount As Double

        depositAmount += inputAmount
        DepositTotalAmount += inputAmount
        Return depositAmount

    End Function

    Public Function ServiceCharge(inputAmount) As Double
        Dim serviceAmount As Double
        serviceAmount = inputAmount
        ServiceCount += 1
        ServiceTotalAmount += inputAmount
        Return serviceAmount
    End Function

    Private Function GetAmountToSubtract(inputValue As Double) As Double

        If inputValue <= AccountBalance Then
            CheckingCount += 1
            CheckingTotal += inputValue
            Return inputValue
        Else
            MessageBox.Show("Insafficient funds: $10.00 Charge")
            ServiceCount += 1
            ServiceTotalAmount += inputValue
            Return checkCharge
        End If
    End Function

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtInputAmount.BackColor = Color.Yellow
        lblAccountBallance.BackColor = Color.Yellow
    End Sub

    Private Sub mnuExit_Click(sender As Object, e As EventArgs) Handles mnuExit.Click
        Me.Close()
    End Sub

    Private Sub mnuAbout_Click(sender As Object, e As EventArgs) Handles mnuAbout.Click
        Dim aboutForm As New About
        aboutForm.ShowDialog()
    End Sub

    Private Sub mnuDeposit_Click(sender As Object, e As EventArgs) Handles mnuDeposit.Click

        If ValidateInput() Then
            AccountBalance += Deposit(inputAmount)
            lblAccountBallance.Text = AccountBalance.ToString("C")

            DepositCount += 1
        End If
    End Sub
    Private Sub mnuFont_Click(sender As Object, e As EventArgs) Handles mnuFont.Click
        If fdFont.ShowDialog() = DialogResult.OK Then
            lblAccountBallance.Font = fdFont.Font
        End If
    End Sub

    Private Sub mnuColor_Click(sender As Object, e As EventArgs) Handles mnuColor.Click

        cdColor.Color = Color.Blue
        If cdColor.ShowDialog() = DialogResult.OK Then
            lblAccountBallance.ForeColor = cdColor.Color
        End If

    End Sub

    Private Sub mnuClear_Click(sender As Object, e As EventArgs) Handles mnuClear.Click
        txtInputAmount.Text = ""
        lblAccountBallance.Text = ""
        txtInputAmount.Focus()
    End Sub

    Private Sub mnuServiceCharge_Click(sender As Object, e As EventArgs) Handles mnuServiceCharge.Click

        If ValidateInput() Then
            AccountBalance -= ServiceCharge(inputAmount)
            lblAccountBallance.Text = AccountBalance.ToString("C")
        End If

    End Sub

    Private Sub mnuCheck_Click(sender As Object, e As EventArgs) Handles mnuCheck.Click
        If ValidateInput() Then
            Dim AmountToSubtract As Double = GetAmountToSubtract(inputAmount)
            AccountBalance -= AmountToSubtract
            lblAccountBallance.Text = AccountBalance.ToString("c")

        End If
    End Sub

    Private Sub mnuSummary_Click(sender As Object, e As EventArgs) Handles mnuSummary.Click

        MessageBox.Show("Total Number of Deposits : " + DepositCount.ToString() & vbNewLine &
                        "Total Amount of Depostit: " + DepositTotalAmount.ToString("c") & vbNewLine &
                        "Total Number of Checks: " + CheckingCount.ToString() & vbNewLine &
                        "Total Amount of Checks: " + CheckingTotal.ToString("c") & vbNewLine &
                        "Total Number of Service Charges: " + ServiceCount.ToString() & vbNewLine &
                        "Total Amount of Service Charges: " + ServiceTotalAmount.ToString("c"))
    End Sub
End Class

