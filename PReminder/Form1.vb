Imports System.IO

Public Class Form1
    Public Medication_Array As New Dictionary(Of String, Medicine)
    Public exeDirectory As String
    Public savefile As String
    Public prescription_data As String
    Public lastdate As Date
    Public lasttakenmed As String = ""

    Public Class Medicine
        Public repeat As Integer = 0
        Public maxcount As Integer
        Public count As Integer = 0
    End Class

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FileCheck_ExistorCreate()
        Check_todayActivity()
        Data_Read()
        Populate()
        Medtaken_text.Text = lasttakenmed
    End Sub

    Private Sub FileCheck_ExistorCreate()
        ' looks if save file exist, else creates one
        exeDirectory = Application.StartupPath
        savefile = exeDirectory & "/Prescriptions.txt"

        If Not File.Exists(savefile) Then
            ' If file doesn't exist, set last reminder date to current date
            File.WriteAllText(savefile, $"{Date.Today}> >Med1;60;60;5|Med2;20;20;5")
        End If

        prescription_data = File.ReadAllText(savefile)
    End Sub

    Private Sub Check_todayActivity()
        ' checks if preminder has been updated today
        lastdate = Date.Parse(prescription_data.Split(">")(0))
        Label2.Text = lastdate

        If lastdate = Date.Today Then
            lasttakenmed = prescription_data.Split(">")(1)
        End If
    End Sub

    Private Sub Data_Read()
        ' Read data
        For Each xmed In prescription_data.Split(">")(2).Split("|")
            Dim xname = xmed.Split(";")(0)
            Dim xcount = xmed.Split(";")(1)
            Dim xmaxcount = xmed.Split(";")(2)
            Dim xrepeat = xmed.Split(";")(3)

            Medication_Array.Add(xname, New Medicine With {.maxcount = xmaxcount, .count = xcount, .repeat = xrepeat})
        Next
    End Sub

    Private Sub Populate()
        ' Populate grid
        For Each xobj As KeyValuePair(Of String, Medicine) In Medication_Array
            Dim xrow As New DataGridViewRow()
            Dim cell1 As New DataGridViewTextBoxCell() With {.Value = xobj.Key}
            Dim cell2 As New DataGridViewTextBoxCell() With {.Value = xobj.Value.repeat}
            Dim cell3 As New DataGridViewTextBoxCell() With {.Value = $"{xobj.Value.count}/{xobj.Value.maxcount}"}

            xrow.Cells.Add(cell1)
            xrow.Cells.Add(cell2)
            xrow.Cells.Add(cell3)

            Med_List.Rows.Add(xrow)
        Next
    End Sub

    Private Sub Edit_Medicine(sender As DataGridView, e As DataGridViewCellEventArgs) Handles Med_List.CellClick
        If e.ColumnIndex > 1 AndAlso TypeOf sender.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
            If e.ColumnIndex = 3 Then
                Medicine_take(sender.Rows(e.RowIndex))
            ElseIf e.ColumnIndex = 4 Then
                Medicine_Add(sender.Rows(e.RowIndex))
            End If
        End If
    End Sub

    Public Sub Medicine_take(xrow As DataGridViewRow)
        Dim oldcount As Integer = xrow.Cells(2).Value.Split("/")(0)
        xrow.Cells(2).Value = $"{oldcount - 1}/{xrow.Cells(2).Value.Split("/")(1)}"
        lastdate = Date.Today
        Label2.Text = lastdate
        Medtaken_text.Text = Medtaken_text.Text & $"{xrow.Cells(0).Value.Substring(0, 3)}"
    End Sub

    Public Sub Medicine_Add(xrow As DataGridViewRow)
        xrow.Cells(1).Value += 1
        lastdate = Date.Today
        Label2.Text = lastdate
    End Sub

    Private Function Updated_MedicationList() As List(Of String)
        Dim list_medicationcurrent As New List(Of String)

        For Each xrow As DataGridViewRow In Med_List.Rows
            If xrow.Cells(0).Value = "" Then
                Continue For
            End If

            list_medicationcurrent.Add(xrow.Cells(0).Value)
            If Not Medication_Array.Keys.Contains(xrow.Cells(0).Value) Then
                Try
                    Dim xname As String = xrow.Cells(0).Value
                    Dim xcount As Integer = xrow.Cells(2).Value.Split("/")(0)
                    Dim xmaxcount As Integer = xrow.Cells(2).Value.Split("/")(1)
                    Dim xrepeat As Integer = xrow.Cells(1).Value
                    Medication_Array.Add(xname, New Medicine With {.maxcount = xmaxcount, .count = xcount, .repeat = xrepeat})
                Catch ex As Exception
                    MessageBox.Show($"{xrow.Cells(0).Value} invalid entry in some of the columns. Preminder will close without saving")
                    End
                End Try
            End If

            Medication_Array(xrow.Cells(0).Value).repeat = xrow.Cells(1).Value
            Medication_Array(xrow.Cells(0).Value).count = xrow.Cells(2).Value.Split("/")(0)
        Next
        Return list_medicationcurrent
    End Function

    Private Function GenerateLines_toSave() As List(Of String)
        Dim xlist As List(Of String) = Updated_MedicationList()
        Dim newlines As New List(Of String)
        For i As Integer = 0 To Medication_Array.Count - 1
            Dim xname = Medication_Array.Keys(i)
            If Not xlist.Contains(xname) Then
                Continue For
            End If

            Dim xcount = Medication_Array.Values(i).count
            Dim xmaxcount = Medication_Array.Values(i).maxcount
            Dim xrepeat = Medication_Array.Values(i).repeat

            newlines.Add($"{xname};{xcount};{xmaxcount};{xrepeat}")
        Next
        Return newlines
    End Function

    Private Sub WindowClose(sender As Object, e As EventArgs) Handles Me.Closing
        Dim newlines As List(Of String) = GenerateLines_toSave()
        File.WriteAllText(savefile, lastdate.ToString & ">" & Medtaken_text.Text & ">" & String.Join("|", newlines))
    End Sub
End Class
