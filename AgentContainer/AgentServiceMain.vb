Imports System.Diagnostics.PerformanceData
Imports System.Runtime.Hosting
Imports System.Threading
Imports System.Timers

Public Class AgentServiceMain

    Dim threadmain As Thread
    Dim oProcess As Process
    Dim agentconnected As Boolean
    Dim servicearg As String

    Dim props As New Dictionary(Of String, String)

    Protected Overrides Sub OnStart(ByVal args() As String)

        'initialize arguments
        'servicearg = args(1)
        'EventLog.WriteEntry("Arguments Count:" & args.Length)
        'servicearg = "C:\Jenkins\agent.jar -url http://192.168.100.33:8080/jenkins/ -secret 454643XXXXX4553 -name Win10Virtual -workDir ""C:\Jenkins"""

        'processfactory.createCmdSession()
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        EventLog.WriteEntry("Starting Jenkins Agent WinService")

        'initialize properties
        Dim thispath As String
        thispath = System.AppDomain.CurrentDomain.BaseDirectory
        Dim prop As New Properties(thispath & "conf.properties")
        prop.ReadProperty()
        Dim agentpath As String = prop.getProperty("jenkinsagentpath")
        Dim url As String = prop.getProperty("jenkinsurl")
        Dim secretcode As String = prop.getProperty("jenkinssecret")
        Dim agentname As String = prop.getProperty("agentname")
        Dim workdir As String = prop.getProperty("workDir")
        Dim iswebsocket As String = prop.getProperty("isWebSocket")


        servicearg = agentpath & " -url " & url & " -secret " & secretcode & " -name " & agentname & " -workDir " & workdir
        If iswebsocket = "true" Then
            servicearg = servicearg + " -webSocket"
        End If


        'EventLog.WriteEntry("Jenkins Agent parameter:" & servicearg)

        'agentconnected = False



        'Dim threadmain As Thread
        threadmain = New Thread(New ThreadStart(AddressOf executeJenkinsAgent))
        threadmain.Start()
        'EventLog.WriteEntry("Jenkins Session ID:" & processfactory.getId)
        'executeJenkinsAgent()

    End Sub

    Protected Overrides Sub OnStop()
        EventLog.WriteEntry("Stopping Jenkins Agent with" & oProcess.Id)
        oProcess.Kill()
        EventLog.WriteEntry("Jenkins Agent WinService Ended")
        'oProcess.StandardOutput.Close()
        'oProcess.Close()
        'End
        'oProcess.StandardInput.WriteLine("exit")

        ' Add code here to perform any tear-down necessary to stop your service.
    End Sub




    Sub executeJenkinsAgent()

        Dim oSession As New createCmd()
        oSession.createJavaSession(servicearg)
        oProcess = oSession.getProcess

        'processfactory.createCmdSession()
        'Dim oProcess As Process
        'oProcess = processfactory.getProcess
        EventLog.WriteEntry("Jenkins Session ID:" & oProcess.Id)


        While (oProcess.StandardError.EndOfStream = False)
            Dim outputerror As String
            outputerror = oProcess.StandardError.ReadLine
            Debug.WriteLine(outputerror)
        End While

        'oProcess.StandardInput.Close()
    End Sub


End Class
