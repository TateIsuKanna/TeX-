Imports System
Public Class Form1
    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        For r = 0 To 100
            DataGridView1.Columns.Add(CStr(r), CStr(r))
            DataGridView1.Rows.Add()
        Next
    End Sub

    Private Sub 選択箇所をTeX形式でクリップボードへコピーToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 選択箇所をTeX形式でクリップボードへコピーToolStripMenuItem.Click
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
            vbTab & vbTab & "\begin{tabular}{" & String.Concat(Enumerable.Repeat("c|", maxcolumn - mincolumn)) & "c" & "}" & vbCrLf &
            vbTab & vbTab & vbTab & "\hline" & vbCrLf
        result &= vbTab & vbTab & vbTab

        For x = mincolumn To maxcolumn - 1
            result &= CStr(DataGridView1.Rows(minrow).Cells(x).Value) & " & "
        Next

        result &= CStr(DataGridView1.Rows(minrow).Cells(maxcolumn).Value) & " \\" & vbCrLf &
            vbTab & vbTab & vbTab & "\hline" & vbCrLf

        For y = minrow + 1 To maxrow
            result &= vbTab & vbTab & vbTab
            For x = mincolumn To maxcolumn - 1
                result &= CStr(DataGridView1.Rows(y).Cells(x).Value) & " & "
            Next
            result &= CStr(DataGridView1.Rows(y).Cells(maxcolumn).Value) & " \\" & vbCrLf
        Next

        result &=
            vbTab & vbTab & vbTab & "\hline" & vbCrLf &
            vbTab & vbTab & "\end{tabular}" & vbCrLf &
            vbTab & "\end{center}" & vbCrLf &
            "\end{table}"

        Debug.WriteLine(result)
        Clipboard.SetText(result)
    End Sub

    Private Sub Csvもしくはtsv形式のデータを貼り付けToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Csvもしくはtsv形式のデータを貼り付けToolStripMenuItem.Click
        If DataGridView1.IsCurrentCellInEditMode = False Then

            Dim gettext As String = Clipboard.GetText()

            'HACK データに,が含まれるとそこで区切られる
            gettext = gettext.Replace(",", vbTab)

            Dim sr As New IO.StringReader(gettext)
            Dim insertRowIndex As Integer = DataGridView1.CurrentCell.RowIndex
            While sr.Peek() > -1
                Dim vals As String() = sr.ReadLine.Split(ControlChars.Tab)
                For i = DataGridView1.CurrentCell.ColumnIndex To DataGridView1.CurrentCell.ColumnIndex + vals.Length - 1
                    DataGridView1.Rows(insertRowIndex).Cells(i).Value = vals(i - DataGridView1.CurrentCell.ColumnIndex)
                Next i
                insertRowIndex += 1
            End While
        End If
    End Sub
End Class