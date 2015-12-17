Public Class Form1

    Private Sub DataGridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseUp
        Dim minrow As Integer = DataGridView1.RowCount
        Dim mincolumn As Integer = DataGridView1.ColumnCount
        Dim maxrow As Integer = 0
        Dim maxcolumn As Integer = 0
        For Each c As DataGridViewCell In DataGridView1.SelectedCells
            'Console.WriteLine("{0}, {1}", c.ColumnIndex, c.RowIndex)

            If minrow > c.RowIndex Then
                minrow = c.RowIndex
            End If
            If mincolumn > c.ColumnIndex Then
                mincolumn = c.ColumnIndex
            End If
            If maxrow < c.RowIndex Then
                maxrow = c.RowIndex
            End If
            If maxcolumn < c.ColumnIndex Then
                maxcolumn = c.ColumnIndex
            End If
        Next


        Dim result As String =
            "\begin{table}[h]" & vbCrLf &
            vbTab & "\begin{center}" & vbCrLf &
            vbTab & vbTab & "\caption{}" & vbCrLf &
            vbTab & vbTab & "\label{tbl:}" & vbCrLf &
            vbTab & vbTab & "\begin{tabular}{c|c}" & vbCrLf &
            vbTab & vbTab & vbTab & "\hline" & vbCrLf

        Debug.WriteLine(maxrow)
        For y = minrow To maxrow
            Dim row As DataGridViewRow = DataGridView1.Rows(y)
            For x = mincolumn To maxcolumn - 1
                result &= vbTab & vbTab & vbTab & CStr(row.Cells(x).Value) & " & "
            Next
            result &= CStr(row.Cells(maxcolumn).Value) & " \\" & vbCrLf
        Next

        result &=
             vbTab & vbTab & vbTab & "\hline" & vbCrLf &
            vbTab & vbTab & "\end{tabular}" & vbCrLf &
            vbTab & "\end{center}" & vbCrLf &
            "\end{table}"
        Debug.WriteLine(result)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub
End Class
