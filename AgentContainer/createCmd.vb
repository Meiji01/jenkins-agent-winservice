Public Class createCmd
    Public getProcess As Process
    Public getId As Integer
    Dim oProcess As New Process

    Sub createCmdSession()
        'Dim oProcess As New Process
        Dim oProcessStartInfo As New ProcessStartInfo("java.exe -jar C:\Jenkins\agent.jar -url http://192.168.100.33:8080/jenkins/ -secret 5c109df679c57e2891f0602d9dd6f51177c81141dbbc06b7c159e19365bdd6ca -name Win10Virtual -workDir C:\Jenkins")
        oProcessStartInfo.CreateNoWindow = False
        oProcessStartInfo.UseShellExecute = False
        oProcessStartInfo.RedirectStandardInput = True
        oProcessStartInfo.RedirectStandardOutput = True
        oProcess.StartInfo = oProcessStartInfo
        oProcess.Start()
        getId = Process.GetCurrentProcess.Id
        getProcess = oProcess
    End Sub


    Sub createJavaSession(args As String)
        Dim oProcessStartInfo As New ProcessStartInfo()
        oProcessStartInfo.FileName = "java.exe"
        'Dim args As String
        'args = "-jar C:\Jenkins\agent.jar -url http://192.168.100.33:8080/jenkins/ -secret 5c109df679c57e2891f0602d9dd6f51177c81141dbbc06b7c159e19365bdd6ca -name Win10Virtual -workDir ""C:\Jenkins"""
        args = "-jar " & args
        Debug.Print("Arguments:" + args)
        oProcessStartInfo.Arguments = args
        oProcessStartInfo.CreateNoWindow = False
        oProcessStartInfo.UseShellExecute = False
        'oProcessStartInfo.Arguments.Insert(1, "C:\Jenkins\agent.jar")
        'oProcessStartInfo.Arguments.Insert(2, "-url")
        'oProcessStartInfo.Arguments.Insert(3, "http://192.168.100.33:8080/jenkins/")
        'oProcessStartInfo.Arguments.Insert(4, "-secret")
        'oProcessStartInfo.Arguments.Insert(5, "5c109df679c57e2891f0602d9dd6f51177c81141dbbc06b7c159e19365bdd6ca")
        'oProcessStartInfo.Arguments.Insert(6, "-name")
        'oProcessStartInfo.Arguments.Insert(7, "Win10Virtual")
        'oProcessStartInfo.Arguments.Insert(8, "-workDir")
        'oProcessStartInfo.Arguments.Insert(9, "C:\Jenkins")
        oProcess.StartInfo = oProcessStartInfo
        oProcessStartInfo.RedirectStandardOutput = True
        oProcessStartInfo.RedirectStandardError = True
        oProcess.Start()
        getProcess = oProcess
    End Sub


End Class
