Public Class createCmd
    Public getProcess As Process
    Public getId As Integer
    Dim oProcess As New Process

    'Sub createCmdSession()
    '    'Dim oProcess As New Process
    '    Dim oProcessStartInfo As New ProcessStartInfo("java.exe -jar C:\Jenkins\agent.jar -url http://192.168.100.33:8080/jenkins/ -secret 342342342dsf3242 -name Win10Virtual -workDir C:\Jenkins")
    '    oProcessStartInfo.CreateNoWindow = False
    '    oProcessStartInfo.UseShellExecute = False
    '    oProcessStartInfo.RedirectStandardInput = True
    '    oProcessStartInfo.RedirectStandardOutput = True
    '    oProcess.StartInfo = oProcessStartInfo
    '    oProcess.Start()
    '    getId = Process.GetCurrentProcess.Id
    '    getProcess = oProcess
    'End Sub


    Sub createJavaSession(args As String)
        Dim oProcessStartInfo As New ProcessStartInfo()
        oProcessStartInfo.FileName = "java.exe"
        'Dim args As String
        args = "-jar " & args
        Debug.Print("Arguments:" + args)
        oProcessStartInfo.Arguments = args
        oProcessStartInfo.CreateNoWindow = False
        oProcessStartInfo.UseShellExecute = False
        oProcessStartInfo.RedirectStandardOutput = True
        oProcessStartInfo.RedirectStandardError = True
        oProcess.StartInfo = oProcessStartInfo
        oProcess.Start()
        getProcess = oProcess
        getId = getProcess.Id


    End Sub


End Class
