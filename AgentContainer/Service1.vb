Imports System.Diagnostics.PerformanceData
Imports System.Runtime.Hosting
Imports System.Threading
Imports System.Timers

Public Class Service1

    Dim threadmain As Thread
    Dim oProcess As Process
    Dim agentconnected As Boolean
    Dim servicearg As String

    Protected Overrides Sub OnStart(ByVal args() As String)

        'initialize arguments
        'servicearg = args(1)
        'EventLog.WriteEntry("Arguments Count:" & args.Length)
        servicearg = "C:\Jenkins\agent.jar -url http://192.168.100.33:8080/jenkins/ -secret 5c109df679c57e2891f0602d9dd6f51177c81141dbbc06b7c159e19365bdd6ca -name Win10Virtual -workDir ""C:\Jenkins"""

        'processfactory.createCmdSession()
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        EventLog.WriteEntry("Starting Jenkins Agent WinService at arguments: -jar " & servicearg)
        agentconnected = False



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
        'oProcess.StandardInput.WriteLine("C:\Jenkins\runagent.bat")
        'oProcess.StandardInput.WriteLine("Y")
        'processfactory.getId = oProcess.SessionId

        'While (oProcess.StandardOutput.EndOfStream = False)
        'Dim outputstream As String
        'outputstream = oProcess.StandardOutput.ReadLine
        'Console.WriteLine(outputstream)
        'Debug.WriteLine(outputstream)
        'End While

        While (oProcess.StandardError.EndOfStream = False)
            Dim outputerror As String
            outputerror = oProcess.StandardError.ReadLine
            Debug.WriteLine(outputerror)
        End While

        'oProcess.StandardInput.Close()
    End Sub

End Class
