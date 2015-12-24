Imports System
Public Class Form1
    Dim right_border(101, 101) As Boolean
    Dim bottom_border(101, 101) As Boolean

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        For r = 0 To 99
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
            Debug.WriteLine("{0}, {1}", c.ColumnIndex, c.RowIndex)

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

        'Dim result As String =
        '    "\begin{table}[h]" & vbCrLf &
        '    vbTab & "\begin{center}" & vbCrLf &
        '    vbTab & vbTab & "\caption{}" & vbCrLf &
        '    vbTab & vbTab & "\label{tbl:}" & vbCrLf &
        '    vbTab & vbTab & "\begin{tabular}{" & String.Concat(Enumerable.Repeat("c|", maxcolumn - mincolumn)) & "c" & "}" & vbCrLf &
        '    vbTab & vbTab & vbTab & "\hline" & vbCrLf
        Dim result As String =
            "\begin{table}[h]" & vbCrLf &
            vbTab & "\begin{center}" & vbCrLf &
            vbTab & vbTab & "\caption{}" & vbCrLf &
            vbTab & vbTab & "\label{tbl:}" & vbCrLf &
            vbTab & vbTab & "\begin{tabular}{" & ""

        For column = mincolumn To maxcolumn
            If right_border(minrow, column) Then
                result &= "c|"
            Else
                result &= "c"
            End If
        Next

        result &= "}" & vbCrLf &
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

    Private Sub セルの下側の罫線の有無ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles セルの下側の罫線の有無ToolStripMenuItem.Click
        For Each c As DataGridViewCell In DataGridView1.SelectedCells
            bottom_border(c.RowIndex, c.ColumnIndex) = Not bottom_border(c.RowIndex, c.ColumnIndex)
        Next
    End Sub

    Private Sub セルの右側の罫線の有無ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles セルの右側の罫線の有無ToolStripMenuItem.Click
        For Each c As DataGridViewCell In DataGridView1.SelectedCells
            right_border(c.RowIndex, c.ColumnIndex) = Not right_border(c.RowIndex, c.ColumnIndex)
        Next
    End Sub

    Private Sub dataGridView1_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            If right_border(e.RowIndex, e.ColumnIndex) Then
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Single
            Else
                e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None
            End If
            If bottom_border(e.RowIndex, e.ColumnIndex) Then
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single
            Else
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
            End If
        End If
    End Sub

    'TODO:down upを活用すれば選択範囲の検索が不要に!
    Private Sub DataGridView1_CellMouseDown(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDown

    End Sub
    Private Sub DataGridView1_CellMouseUp(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseUp

    End Sub
End Class
