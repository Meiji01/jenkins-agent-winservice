Imports System.IO

Public Class Properties

    Dim reader As StreamReader
    Dim filename As String
    Dim props As New Dictionary(Of String, String)

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

        For Each prop In props
            If (prop.Key = propertyname) Then
                Return prop.Value
            End If
        Next

        Return ""
    End Function

    Sub ReadProperty()
        openStream()
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

                props.Add(key, value)

            End If

        End While
        closeStream()
    End Sub

    Sub setProperty(key As String, value As String)

    End Sub

End Class
