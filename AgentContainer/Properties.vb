Imports System.IO

Public Class Properties

    Dim reader As StreamReader
    Dim filename As String

    Sub New(file As String)
        filename = file
    End Sub

    Sub openStream()
        'Dim reader As StreamReader
        reader = My.Computer.FileSystem.OpenTextFileReader(filename)
    End Sub

    Sub closeStream()
        reader.Close()
    End Sub

    Function getProperty(propertyname As String) As String
        While (reader.EndOfStream = False)
            Dim linestr = reader.ReadLine
            If (linestr.Length > 0) Then
                If (linestr.Substring(0, 1) = "#") Then
                    Continue While
                End If


                Dim key As String
                Dim value As String

                Dim linev() As String
                linev = linestr.Split("=")
                key = linev(0)
                value = linev(1)

                If (key = propertyname) Then
                    Return value
                End If
            End If

        End While
        Return ""
    End Function

    Sub setProperty(key As String, value As String)

    End Sub

End Class
