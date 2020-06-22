Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.AccessControl

Public Class Main

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Command() = Nothing Then
            Dim sas As Integer
            If InternetGetConnectedState(sas, 0) = False Then
                MsgBox("安装数字许可证时需要连接网络!"， vbCritical, "ERROR")
                Close()
            End If
            If Environment.OSVersion.Version.Major = 10 Then
                Active()
            Else
                Dim acr = MsgBox("当前系统为非Windows10系统，数字许可证可能会安装失败！", vbExclamation + vbOKCancel, "WARNING")
                If acr = MsgBoxResult.Ok Then Active()
                If acr = MsgBoxResult.Cancel Then Close()
            End If
        Else
            Hide()
            cmd = True
            Dim sas As Integer
            If InternetGetConnectedState(sas, 0) = False Then
                Console.WriteLine("安装数字许可证时需要连接网络!")
                End
            End If
            Select Case Command.ToLower
                Case "-r"
                    If Environment.OSVersion.Version.Major <> 10 Then
                        Console.WriteLine("当前系统为非Windows10系统，数字许可证可能会安装失败！")
                    End If
                    Active()
                    Reboot()
                    End
                Case "-e"
                    Try
                        Dim Px As String = AppDomain.CurrentDomain.BaseDirectory
                        Lines(My.Resources.DigitalLicense, Px + "DigitalLicense.exe")
                        Dim p_ As New Process With {
               .StartInfo = New ProcessStartInfo(Px + "DigitalLicense.exe")
           }
                        p_.Start()
                        p_.WaitForExit()
                        File.Delete(Px + "DigitalLicense.exe")
                        Console.WriteLine("生成安装数字许可证成功!")
                    Catch es As Exception
                        Console.WriteLine("生成数字许可证时遇到错误!")
                    End Try
                    End
                Case "-s"
                    If Environment.OSVersion.Version.Major <> 10 Then
                        Console.WriteLine("当前系统为非Windows10系统，数字许可证可能会安装失败！")
                    End If
                    Active()
                    End
                Case "-?"
                    MsgBox("-? 显示帮助" + vbCrLf + "-s 静默激活（需要联网）" + vbCrLf + "-e 生成证书到当前目录（需要联网）" + vbCrLf + "-r 静默激活（需要联网）并自动重启" + vbCrLf + "每个选项只能单独使用" + vbCrLf + vbCrLf + vbCrLf + "By BiliBili UP MIAIONE" + vbCrLf + "本软件使用微软官方工具生成数字证书，不会修改任何系统设置，也不会设置KMS38，登录微软账户还可以绑定你的账户，以便于在重大硬件更改时保持激活状态。" + vbCrLf + "MIAIONE 版权所有 本软件开源，请遵守GPLv3开源协议，开源地址：https://github.com/MIAIONE/Windows-Digital-License", vbInformation, "INFO")
                    End
                Case Else
                    Console.WriteLine("参数无效，请注意只能使用 -？而不是 /?")
            End Select
        End If
    End Sub
    Private Sub ACS() Handles MyBase.Activated
        EXIT_TIME.Start()
    End Sub
    Private Sub OnPaint_(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        Dim Brusha As New Pen(Color.DodgerBlue, 4)
        e.Graphics.DrawLine(Brusha, New Point(0, 0), New Point(0, Height))
        e.Graphics.DrawLine(Brusha, New Point(0, 0), New Point(Width, 0))
        e.Graphics.DrawLine(Brusha, New Point(0, Height), New Point(Width, Height))
        e.Graphics.DrawLine(Brusha, New Point(Width, 0), New Point(Width, Height))
    End Sub
    Dim STRS As Integer = 120
    Private Sub EXIT_TIME_Tick(sender As Object, e As EventArgs) Handles EXIT_TIME.Tick

        If STRS = 0 Then Close()
        STRS -= 1
        IS_nfo.Text = "激活完成(单击关闭窗口)  " + STRS.ToString + "秒后自动关闭窗口"
    End Sub

    Private Sub IS_nfo_Click(sender As Object, e As EventArgs) Handles IS_nfo.Click
        Close()
    End Sub

    Private Sub UP__Click(sender As Object, e As EventArgs) Handles UP_.Click
        Process.Start("https://space.bilibili.com/185636167")
    End Sub
End Class
Public Module Method
    Public cmd As Boolean = False
    <DllImport("wininet.dll", EntryPoint:="InternetGetConnectedState")>
    Public Function InternetGetConnectedState(<Out> ByRef conState As Integer, ByVal reder As Integer) As Boolean
    End Function
    Public Sub Active()
        Try
            Dim Basepath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)
            Dim XMPATH_ = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Microsoft\Windows\ClipSVC\GenuineTicket"

            Dim XMPATH = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) & "\Microsoft\Windows\ClipSVC\GenuineTicket\DigitalLicense.exe"
            AddSecurityControll2Folder(Basepath + "\Microsoft")

            AddSecurityControll2Folder(Basepath + "\Microsoft\Windows")
            AddSecurityControll2Folder(Basepath + "\Microsoft\Windows\ClipSVC\")

            If Directory.Exists(XMPATH_) = False Then
                Directory.CreateDirectory(XMPATH_)
            End If
            AddSecurityControll2Folder(XMPATH_)
            Lines(My.Resources.DigitalLicense, XMPATH)
            AddSecurityControll2File(XMPATH)
            Dim p_ As New Process With {
            .StartInfo = New ProcessStartInfo(XMPATH)
        }
            p_.Start()
            p_.WaitForExit()
            File.Delete(XMPATH)
            Console.WriteLine("安装数字许可证成功!")
        Catch
            If cmd Then
                Console.WriteLine("安装数字许可证时遇到错误!")
            Else
                MsgBox("安装数字许可证时遇到错误!"， vbCritical, "ERROR")
            End If

            End
        End Try

    End Sub
    Public Sub Lines(res As Byte(), px As String)
        Dim fsObj As FileStream = New FileStream(px, FileMode.Create, FileAccess.ReadWrite)
        fsObj.Write(res, 0, res.Length)
        fsObj.Close()
    End Sub
    Private Sub AddSecurityControll2Folder(ByVal dirPath As String)
        Dim dir As DirectoryInfo = New DirectoryInfo(dirPath)
        Dim dirSecurity As DirectorySecurity = dir.GetAccessControl(AccessControlSections.All)
        Dim [inherits] As InheritanceFlags = InheritanceFlags.ContainerInherit Or InheritanceFlags.ObjectInherit
        Dim everyoneFileSystemAccessRule As FileSystemAccessRule = New FileSystemAccessRule("Everyone", FileSystemRights.FullControl, [inherits], PropagationFlags.None, AccessControlType.Allow)
        Dim usersFileSystemAccessRule As FileSystemAccessRule = New FileSystemAccessRule("Users", FileSystemRights.FullControl, [inherits], PropagationFlags.None, AccessControlType.Allow)
        Dim administratorFileSystemAccessRule As FileSystemAccessRule = New FileSystemAccessRule("Administrator", FileSystemRights.FullControl, [inherits], PropagationFlags.None, AccessControlType.Allow)

        Dim isModified As Boolean = False
        dirSecurity.ModifyAccessRule(AccessControlModification.Add, everyoneFileSystemAccessRule, isModified)
        dirSecurity.ModifyAccessRule(AccessControlModification.Add, usersFileSystemAccessRule, isModified)
        dirSecurity.ModifyAccessRule(AccessControlModification.Add, administratorFileSystemAccessRule, isModified)

        dir.SetAccessControl(dirSecurity)
    End Sub

    Private Sub AddSecurityControll2File(ByVal filePath As String)
        Dim fileInfo As FileInfo = New FileInfo(filePath)
        Dim fileSecurity As FileSecurity = fileInfo.GetAccessControl()
        fileSecurity.AddAccessRule(New FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow))
        fileSecurity.AddAccessRule(New FileSystemAccessRule("Users", FileSystemRights.FullControl, AccessControlType.Allow))
        fileSecurity.AddAccessRule(New FileSystemAccessRule("Administrator", FileSystemRights.FullControl, AccessControlType.Allow))

        fileInfo.SetAccessControl(fileSecurity)
    End Sub
    Public Sub Reboot()
        DoExitWin(EWX_FORCE Or EWX_REBOOT)
    End Sub

    Public Sub ShutDown()
        DoExitWin(EWX_FORCE Or EWX_POWEROFF)
    End Sub

    Public Sub LogOff()
        DoExitWin(EWX_FORCE Or EWX_LOGOFF)
    End Sub
    Public Function Token(name As String) As Boolean
        Try
            Dim tp As TokPriv1Luid
            Dim hproc As IntPtr = GetCurrentProcess()
            Dim htok As IntPtr = IntPtr.Zero
            OpenProcessToken(hproc, TOKEN_ADJUST_PRIVILEGES Or TOKEN_QUERY, htok)
            tp.Count = 1
            tp.Luid = 0
            tp.Attr = SE_PRIVILEGE_ENABLED
            LookupPrivilegeValueA(Nothing, name, tp.Luid)
            AdjustTokenPrivileges(htok, False, tp, 0, IntPtr.Zero, IntPtr.Zero)
            Return True
        Catch
            Return False
        End Try
    End Function
    <StructLayout(LayoutKind.Sequential, Pack:=1)>
    Friend Structure TokPriv1Luid
        Public Count As Integer
        Public Luid As Long
        Public Attr As Integer
    End Structure

    <DllImport("kernel32.dll", ExactSpelling:=True)>
    Friend Function GetCurrentProcess() As IntPtr
    End Function
    <DllImport("advapi32.dll", ExactSpelling:=True, SetLastError:=True)>
    Friend Function OpenProcessToken(ByVal h As IntPtr, ByVal acc As Integer, ByRef phtok As IntPtr) As Boolean
    End Function
    <DllImport("advapi32.dll", SetLastError:=True)>
    Friend Function LookupPrivilegeValueA(ByVal host As String, ByVal name As String, ByRef pluid As Long) As Boolean
    End Function
    <DllImport("advapi32.dll", ExactSpelling:=True, SetLastError:=True)>
    Friend Function AdjustTokenPrivileges(ByVal htok As IntPtr, ByVal disall As Boolean, ByRef newst As TokPriv1Luid, ByVal len As Integer, ByVal prev As IntPtr, ByVal relen As IntPtr) As Boolean
    End Function
    <DllImport("user32.dll", ExactSpelling:=True, SetLastError:=True)>
    Friend Function ExitWindowsEx(ByVal flg As Integer, ByVal rea As Integer) As Boolean
    End Function
    ''' <summary>
    ''' 权限查询令牌
    ''' </summary>
    Public Const TOKEN_QUERY As UInteger = &H8
    ''' <summary>
    ''' 权限修改令牌
    ''' </summary>
    Public Const TOKEN_ADJUST_PRIVILEGES As UInteger = &H20
    ''' <summary>
    ''' 开启权限
    ''' </summary>
    Public Const SE_PRIVILEGE_ENABLED As UInteger = &H2



    Public Const SE_CREATE_TOKEN_NAME As String = "SeCreateTokenPrivilege"

    Public Const SE_ASSIGNPRIMARYTOKEN_NAME As String = "SeAssignPrimaryTokenPrivilege"

    Public Const SE_LOCK_MEMORY_NAME As String = "SeLockMemoryPrivilege"

    Public Const SE_INCREASE_QUOTA_NAME As String = "SeIncreaseQuotaPrivilege"

    Public Const SE_UNSOLICITED_INPUT_NAME As String = "SeUnsolicitedInputPrivilege"

    Public Const SE_MACHINE_ACCOUNT_NAME As String = "SeMachineAccountPrivilege"

    Public Const SE_TCB_NAME As String = "SeTcbPrivilege"

    Public Const SE_SECURITY_NAME As String = "SeSecurityPrivilege"

    Public Const SE_TAKE_OWNERSHIP_NAME As String = "SeTakeOwnershipPrivilege"

    Public Const SE_LOAD_DRIVER_NAME As String = "SeLoadDriverPrivilege"

    Public Const SE_SYSTEM_PROFILE_NAME As String = "SeSystemProfilePrivilege"

    Public Const SE_SYSTEMTIME_NAME As String = "SeSystemtimePrivilege"

    Public Const SE_PROF_SINGLE_PROCESS_NAME As String = "SeProfileSingleProcessPrivilege"

    Public Const SE_INC_BASE_PRIORITY_NAME As String = "SeIncreaseBasePriorityPrivilege"

    Public Const SE_CREATE_PAGEFILE_NAME As String = "SeCreatePagefilePrivilege"

    Public Const SE_CREATE_PERMANENT_NAME As String = "SeCreatePermanentPrivilege"

    Public Const SE_BACKUP_NAME As String = "SeBackupPrivilege"

    Public Const SE_RESTORE_NAME As String = "SeRestorePrivilege"

    Public Const SE_SHUTDOWN_NAME As String = "SeShutdownPrivilege"

    Public Const SE_DEBUG_NAME As String = "SeDebugPrivilege"

    Public Const SE_AUDIT_NAME As String = "SeAuditPrivilege"

    Public Const SE_SYSTEM_ENVIRONMENT_NAME As String = "SeSystemEnvironmentPrivilege"

    Public Const SE_CHANGE_NOTIFY_NAME As String = "SeChangeNotifyPrivilege"

    Public Const SE_REMOTE_SHUTDOWN_NAME As String = "SeRemoteShutdownPrivilege"

    Public Const SE_UNDOCK_NAME As String = "SeUndockPrivilege"

    Public Const SE_SYNC_AGENT_NAME As String = "SeSyncAgentPrivilege"

    Public Const SE_ENABLE_DELEGATION_NAME As String = "SeEnableDelegationPrivilege"

    Public Const SE_MANAGE_VOLUME_NAME As String = "SeManageVolumePrivilege"

    Public Const SE_IMPERSONATE_NAME As String = "SeImpersonatePrivilege"

    Public Const SE_CREATE_GLOBAL_NAME As String = "SeCreateGlobalPrivilege"

    Public Const SE_TRUSTED_CREDMAN_ACCESS_NAME As String = "SeTrustedCredManAccessPrivilege"

    Public Const SE_RELABEL_NAME As String = "SeRelabelPrivilege"

    Public Const SE_INC_WORKING_SET_NAME As String = "SeIncreaseWorkingSetPrivilege"

    Public Const SE_TIME_ZONE_NAME As String = "SeTimeZonePrivilege"

    Public Const SE_CREATE_SYMBOLIC_LINK_NAME As String = "SeCreateSymbolicLinkPrivilege"


    Public Const EWX_LOGOFF As Integer = &H0
    Public Const EWX_SHUTDOWN As Integer = &H1
    Public Const EWX_REBOOT As Integer = &H2
    Public Const EWX_FORCE As Integer = &H4
    Public Const EWX_POWEROFF As Integer = &H8
    Public Const EWX_FORCEIFHUNG As Integer = &H10

    Public Sub DoExitWin(ByVal flg As Integer)
        Token(SE_SHUTDOWN_NAME)
        ExitWindowsEx(flg, 0)
    End Sub
End Module


