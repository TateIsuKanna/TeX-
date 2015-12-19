Imports System
Public Class Form1
    Dim right_border(100, 100) As Boolean
    Dim bottom_border(100, 100) As Boolean

    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'For r = 0 To 100
        '    CustomDataGridView1.Columns.Add(CStr(r), CStr(r))
        '    CustomDataGridView1.Rows.Add()
        'Next
    End Sub

    Private Sub 選択箇所をTeX形式でクリップボードへコピーToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 選択箇所をTeX形式でクリップボードへコピーToolStripMenuItem.Click
        Dim minrow As Integer = CustomDataGridView1.RowCount
        Dim mincolumn As Integer = CustomDataGridView1.ColumnCount
        Dim maxrow As Integer = 0
        Dim maxcolumn As Integer = 0
        For Each c As DataGridViewCell In CustomDataGridView1.SelectedCells
            'Debug.WriteLine("{0}, {1}", c.ColumnIndex, c.RowIndex)

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
            result &= CStr(CustomDataGridView1.Rows(minrow).Cells(x).Value) & " & "
        Next

        result &= CStr(CustomDataGridView1.Rows(minrow).Cells(maxcolumn).Value) & " \\" & vbCrLf &
            vbTab & vbTab & vbTab & "\hline" & vbCrLf

        For y = minrow + 1 To maxrow
            result &= vbTab & vbTab & vbTab
            For x = mincolumn To maxcolumn - 1
                result &= CStr(CustomDataGridView1.Rows(y).Cells(x).Value) & " & "
            Next
            result &= CStr(CustomDataGridView1.Rows(y).Cells(maxcolumn).Value) & " \\" & vbCrLf
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
        If CustomDataGridView1.IsCurrentCellInEditMode = False Then

            Dim gettext As String = Clipboard.GetText()

            'HACK データに,が含まれるとそこで区切られる
            gettext = gettext.Replace(",", vbTab)

            Dim sr As New IO.StringReader(gettext)
            Dim insertRowIndex As Integer = CustomDataGridView1.CurrentCell.RowIndex
            While sr.Peek() > -1
                Dim vals As String() = sr.ReadLine.Split(ControlChars.Tab)
                For i = CustomDataGridView1.CurrentCell.ColumnIndex To CustomDataGridView1.CurrentCell.ColumnIndex + vals.Length - 1
                    CustomDataGridView1.Rows(insertRowIndex).Cells(i).Value = vals(i - CustomDataGridView1.CurrentCell.ColumnIndex)
                Next i
                insertRowIndex += 1
            End While
        End If
    End Sub

    Private Sub セルの下側の罫線の有無ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles セルの下側の罫線の有無ToolStripMenuItem.Click
        For Each c As DataGridViewCell In CustomDataGridView1.SelectedCells
            bottom_border(c.RowIndex + 1, c.ColumnIndex + 1) = Not bottom_border(c.RowIndex + 1, c.ColumnIndex + 1)
        Next
    End Sub

    Private Sub セルの右側の罫線の有無ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles セルの右側の罫線の有無ToolStripMenuItem.Click
        For Each c As DataGridViewCell In CustomDataGridView1.SelectedCells
            right_border(c.RowIndex + 1, c.ColumnIndex + 1) = Not right_border(c.RowIndex + 1, c.ColumnIndex + 1)
        Next
    End Sub

    Private Sub dataGridView1_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles CustomDataGridView1.CellPainting
        'If e.RowIndex > 0 AndAlso e.ColumnIndex > 0 AndAlso e.RowIndex < CustomDataGridView1.RowCount AndAlso e.ColumnIndex < CustomDataGridView1.ColumnCount Then
        If right_border(e.RowIndex + 1, e.ColumnIndex + 1) Then
            e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.Single
        Else
            e.AdvancedBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None
            End If
        If bottom_border(e.RowIndex + 1, e.ColumnIndex + 1) Then
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Single
        Else
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
            End If
        'Else

        'End If
        'If CustomDataGridView1.Columns("ContactName").Index = e.ColumnIndex AndAlso e.RowIndex >= 0 Then

        '    Dim newRect As New Rectangle(e.CellBounds.X + 1, e.CellBounds.Y + 1, e.CellBounds.Width - 4, e.CellBounds.Height - 4)
        '    Dim backColorBrush As New SolidBrush(e.CellStyle.BackColor)
        '    Dim gridBrush As New SolidBrush(CustomDataGridView1.GridColor)
        '    Dim gridLinePen As New Pen(gridBrush)

        '    Try

        '        ' Erase the cell.
        '        e.Graphics.FillRectangle(backColorBrush, e.CellBounds)

        '        ' Draw the grid lines (only the right and bottom lines;
        '        ' DataGridView takes care of the others).
        '        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Left,
        '    e.CellBounds.Bottom - 1, e.CellBounds.Right - 1,
        '    e.CellBounds.Bottom - 1)
        '        e.Graphics.DrawLine(gridLinePen, e.CellBounds.Right - 1,
        '    e.CellBounds.Top, e.CellBounds.Right - 1,
        '    e.CellBounds.Bottom)

        '        ' Draw the inset highlight box.
        '        e.Graphics.DrawRectangle(Pens.Blue, newRect)

        '        ' Draw the text content of the cell, ignoring alignment.
        '        If (e.Value IsNot Nothing) Then
        '            e.Graphics.DrawString(CStr(e.Value), e.CellStyle.Font,
        '    Brushes.Crimson, e.CellBounds.X + 2, e.CellBounds.Y + 2,
        '    StringFormat.GenericDefault)
        '        End If
        '        e.Handled = True

        '    Finally
        '        gridLinePen.Dispose()
        '        gridBrush.Dispose()
        '        backColorBrush.Dispose()
        '    End Try

        'End If

    End Sub
End Class


Public Class CustomDataGridView
    Inherits DataGridView

    Public Sub New()
        With Me
            .RowTemplate = New DataGridViewCustomRow()
            '.Columns.Add(New DataGridViewCustomColumn())
            '.Columns.Add(New DataGridViewCustomColumn())
            '.Columns.Add(New DataGridViewCustomColumn())
            '.RowCount = 4

            For r = 0 To 100
                .Columns.Add(New DataGridViewCustomColumn())
                .Rows.Add()
                '.RowCount += 1
            Next

            '.EnableHeadersVisualStyles = False
            '.AutoSize = True
        End With
    End Sub



    'Public Overrides ReadOnly Property AdjustedTopLeftHeaderBorderStyle() _
    '        As DataGridViewAdvancedBorderStyle
    '    Get
    '        Dim newStyle As New DataGridViewAdvancedBorderStyle()
    '        With newStyle
    '            .Top = DataGridViewAdvancedCellBorderStyle.None
    '            .Left = DataGridViewAdvancedCellBorderStyle.None
    '            .Bottom = DataGridViewAdvancedCellBorderStyle.Outset
    '            .Right = DataGridViewAdvancedCellBorderStyle.OutsetDouble
    '        End With
    '        Return newStyle
    '    End Get
    'End Property

    'Public Overrides Function AdjustColumnHeaderBorderStyle(
    '        ByVal dataGridViewAdvancedBorderStyleInput As DataGridViewAdvancedBorderStyle,
    '        ByVal dataGridViewAdvancedBorderStylePlaceHolder As DataGridViewAdvancedBorderStyle,
    '        ByVal firstDisplayedColumn As Boolean, ByVal lastVisibleColumn As Boolean) _
    '        As DataGridViewAdvancedBorderStyle

    '    ' Customize the left border of the first column header and the
    '    ' bottom border of all the column headers. Use the input style for 
    '    ' all other borders.
    '    If firstDisplayedColumn Then
    '        dataGridViewAdvancedBorderStylePlaceHolder.Left =
    '                DataGridViewAdvancedCellBorderStyle.OutsetDouble
    '    Else
    '        dataGridViewAdvancedBorderStylePlaceHolder.Left =
    '                DataGridViewAdvancedCellBorderStyle.None
    '    End If

    '    With dataGridViewAdvancedBorderStylePlaceHolder
    '        .Bottom = DataGridViewAdvancedCellBorderStyle.Single
    '        .Right = dataGridViewAdvancedBorderStyleInput.Right
    '        .Top = dataGridViewAdvancedBorderStyleInput.Top
    '    End With

    '    Return dataGridViewAdvancedBorderStylePlaceHolder
    'End Function
End Class

Public Class DataGridViewCustomColumn
    Inherits DataGridViewColumn

    Public Sub New()
        Me.CellTemplate = New DataGridViewCustomCell()
    End Sub
End Class

Public Class DataGridViewCustomRow
    Inherits DataGridViewRow

    'Public Overrides Function AdjustRowHeaderBorderStyle(
    '        ByVal dataGridViewAdvancedBorderStyleInput As DataGridViewAdvancedBorderStyle,
    '        ByVal dataGridViewAdvancedBorderStylePlaceHolder As DataGridViewAdvancedBorderStyle,
    '        ByVal singleVerticalBorderAdded As Boolean,
    '        ByVal singleHorizontalBorderAdded As Boolean,
    '        ByVal isFirstDisplayedRow As Boolean,
    '        ByVal isLastDisplayedRow As Boolean) As DataGridViewAdvancedBorderStyle

    '    If isFirstDisplayedRow Then
    '        dataGridViewAdvancedBorderStylePlaceHolder.Top =
    '                DataGridViewAdvancedCellBorderStyle.InsetDouble
    '    Else
    '        dataGridViewAdvancedBorderStylePlaceHolder.Top =
    '                DataGridViewAdvancedCellBorderStyle.None
    '    End If

    '    With dataGridViewAdvancedBorderStylePlaceHolder
    '        .Right = DataGridViewAdvancedCellBorderStyle.OutsetDouble
    '        .Left = dataGridViewAdvancedBorderStyleInput.Left
    '        .Bottom = dataGridViewAdvancedBorderStyleInput.Bottom
    '    End With

    '    Return dataGridViewAdvancedBorderStylePlaceHolder
    'End Function
End Class

Public Class DataGridViewCustomCell
    Inherits DataGridViewTextBoxCell

    'Public Overrides Function AdjustCellBorderStyle(
    '        ByVal dataGridViewAdvancedBorderStyleInput As DataGridViewAdvancedBorderStyle,
    '        ByVal dataGridViewAdvancedBorderStylePlaceHolder As DataGridViewAdvancedBorderStyle,
    '        ByVal singleVerticalBorderAdded As Boolean,
    '        ByVal singleHorizontalBorderAdded As Boolean,
    '        ByVal firstVisibleColumn As Boolean,
    '        ByVal firstVisibleRow As Boolean) As DataGridViewAdvancedBorderStyle

    '    If firstVisibleColumn Then
    '        dataGridViewAdvancedBorderStylePlaceHolder.Left =
    '                DataGridViewAdvancedCellBorderStyle.OutsetDouble
    '    Else
    '        dataGridViewAdvancedBorderStylePlaceHolder.Left =
    '                DataGridViewAdvancedCellBorderStyle.None
    '    End If

    '    If firstVisibleRow Then
    '        dataGridViewAdvancedBorderStylePlaceHolder.Top =
    '                DataGridViewAdvancedCellBorderStyle.InsetDouble
    '    Else
    '        dataGridViewAdvancedBorderStylePlaceHolder.Top =
    '                DataGridViewAdvancedCellBorderStyle.None
    '    End If

    '    With dataGridViewAdvancedBorderStylePlaceHolder
    '        .Right = dataGridViewAdvancedBorderStyleInput.Right
    '        .Bottom = dataGridViewAdvancedBorderStyleInput.Bottom
    '    End With

    '    Return dataGridViewAdvancedBorderStylePlaceHolder
    'End Function
End Class