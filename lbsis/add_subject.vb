﻿Public Class add_subject

    Public gc As New GlobalCodes
    Public fields() As String = {"username",
                                "name"
                       }
    Dim tbl_teacher As String = "select * from tbl_login WHERE position = 'Teacher'"
    Dim tbl_teacher2 As String = "select * from tbl_login"

    Private Sub add_subject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub




    Private Sub add_subject()

        Dim message As String = "Subject successfully added"
        Dim empty As Boolean


        Dim data() As String = {
        txt_subj.Text,
        cb_level.Text
        }

        For x = 1 To data.Length - 1

            If data(x).ToString = "" Then

                empty = True

            Else
                empty = False

            End If

        Next

        If empty = True Then

            MessageBox.Show("Please complete all fields!", "Complete all fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            Dim result As Integer = MessageBox.Show("Are you sure all the student information is correct?", "Submit dialog", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Cancel Then

            ElseIf result = DialogResult.No Then

            ElseIf result = DialogResult.Yes Then


                gc.insert("INSERT INTO tbl_subject (`subject`,`grade_level`)VALUES(@subject,@grade_level)", gc.insert_subject, data, message)
                cb_level.Text = ""
                txt_subj.Text = ""
            End If

        End If

    End Sub

    Private Sub select_teacher_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub

    Private Sub select_teacher_Click(ByVal sender As Object, ByVal e As System.EventArgs)




    End Sub

    Private Sub txt_subj_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_subj.TextChanged

    End Sub

    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        add_subject()
    End Sub

    Private Sub btn_edit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_edit.Click
        edit()
    End Sub


    Private Sub edit()
        Dim message As String = "Subject Data successfully Updated"
        Dim empty As Boolean

        Dim data() As String = {
                                txt_subj.Text,
                                cb_level.Text
                               }


        For x = 1 To data.Length - 1

            If data(x).ToString = "" Then

                empty = True

            Else
                empty = False

            End If

        Next

        If empty = True Then

            MessageBox.Show("Please complete all fields!", "Complete all fields", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        Else

            Dim result As Integer = MessageBox.Show("Are you sure all the subject information is correct?", "Submit dialog", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = DialogResult.Cancel Then

            ElseIf result = DialogResult.No Then

            ElseIf result = DialogResult.Yes Then
                Try
                    gc.subject_edit("UPDATE tbl_subject set subject = '" & txt_subj.Text & "', grade_level = '" & cb_level.Text & "'  where subject_id = '" & subject_id.text & "' ")

                    Me.Dispose()
                    subject_id.Dispose()
                    subject_id.Show()

                Catch ex As Exception
                    MsgBox(ex)

                End Try

            End If

        End If

    End Sub
End Class