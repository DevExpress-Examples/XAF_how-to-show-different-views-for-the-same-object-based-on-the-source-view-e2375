﻿Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Xpo
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web
Imports DevExpress.ExpressApp.Model

Namespace WinWebSolution.Web
    Partial Public Class WinWebSolutionAspNetApplication
        Inherits WebApplication

        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            args.ObjectSpaceProvider = New XPObjectSpaceProvider(args.ConnectionString, args.Connection, True)
        End Sub
        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
        Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
        Private module3 As WinWebSolution.Module.WinWebSolutionModule
        Private module4 As WinWebSolution.Module.Web.WinWebSolutionAspNetModule
        Private securityModule1 As DevExpress.ExpressApp.Security.SecurityModule
        Private securitySimple1 As DevExpress.ExpressApp.Security.SecuritySimple
        Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule
        Private authenticationActiveDirectory1 As DevExpress.ExpressApp.Security.AuthenticationActiveDirectory
        Private sqlConnection1 As System.Data.SqlClient.SqlConnection
        Private module5 As DevExpress.ExpressApp.Validation.ValidationModule

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub WinWebSolutionAspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles Me.DatabaseVersionMismatch
#If EASYTEST Then
            e.Updater.Update()
            e.Handled = True
#Else
            If System.Diagnostics.Debugger.IsAttached Then
                e.Updater.Update()
                e.Handled = True
            Else
                Throw New InvalidOperationException("The application cannot connect to the specified database, because the latter doesn't exist or its version is older than that of the application." & ControlChars.CrLf & "This error occurred  because the automatic database update was disabled when the application was started without debugging." & ControlChars.CrLf & "To avoid this error, you should either start the application under Visual Studio in debug mode, or modify the " & "source code of the 'DatabaseVersionMismatch' event handler to enable automatic database update, " & "or manually create a database using the 'DBUpdater' tool." & ControlChars.CrLf & "Anyway, refer to the 'Update Application and Database Versions' help topic at http://www.devexpress.com/Help/?document=ExpressApp/CustomDocument2795.htm " & "for more detailed information. If this doesn't help, please contact our Support Team at http://www.devexpress.com/Support/Center/")
            End If
#End If
        End Sub

        Private Sub InitializeComponent()
            Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
            Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
            Me.module3 = New WinWebSolution.Module.WinWebSolutionModule()
            Me.module4 = New WinWebSolution.Module.Web.WinWebSolutionAspNetModule()
            Me.module5 = New DevExpress.ExpressApp.Validation.ValidationModule()
            Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
            Me.securityModule1 = New DevExpress.ExpressApp.Security.SecurityModule()
            Me.securitySimple1 = New DevExpress.ExpressApp.Security.SecuritySimple()
            Me.authenticationActiveDirectory1 = New DevExpress.ExpressApp.Security.AuthenticationActiveDirectory()
            Me.sqlConnection1 = New System.Data.SqlClient.SqlConnection()
            DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' securitySimple1
            ' 
            Me.securitySimple1.Authentication = Me.authenticationActiveDirectory1
            Me.securitySimple1.UserType = GetType(DevExpress.Persistent.BaseImpl.SimpleUser)
            ' 
            ' authenticationActiveDirectory1
            ' 
            Me.authenticationActiveDirectory1.CreateUserAutomatically = True
            Me.authenticationActiveDirectory1.UserType = GetType(DevExpress.Persistent.BaseImpl.SimpleUser)
            ' 
            ' sqlConnection1
            ' 
            Me.sqlConnection1.ConnectionString = "Data Source=(local);Initial Catalog=WinWebSolution;Integrated Security=SSPI;Pooling=false"
            Me.sqlConnection1.FireInfoMessageEventOnUserErrors = False
            ' 
            ' WinWebSolutionAspNetApplication
            ' 
            Me.ApplicationName = "WinWebSolution"
            Me.Connection = Me.sqlConnection1
            Me.Modules.Add(Me.module1)
            Me.Modules.Add(Me.module2)
            Me.Modules.Add(Me.module3)
            Me.Modules.Add(Me.module4)
            Me.Modules.Add(Me.module5)
            Me.Modules.Add(Me.module6)

            Me.Modules.Add(Me.securityModule1)
            Me.Security = Me.securitySimple1
            DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
    End Class
End Namespace
Namespace DevExpress.ExpressApp.Utils
    Public NotInheritable Class ViewImageNameHelper

        Private Sub New()
        End Sub

        Public Shared Function GetImageName(ByVal modelView As IModelView) As String
            If modelView Is Nothing Then
                Return String.Empty
            End If
            Dim imageName As String = modelView.ImageName
            If String.IsNullOrEmpty(imageName) Then
                Dim view As IModelObjectView = TryCast(modelView, IModelObjectView)
                If (view IsNot Nothing) AndAlso (view.ModelClass IsNot Nothing) Then
                    imageName = view.ModelClass.ImageName
                End If
            End If
            Return imageName
        End Function
        Public Shared Function GetImageName(ByVal view As View) As String
            If view IsNot Nothing Then
                Return GetImageName(view.Model)
            End If
            Return String.Empty
        End Function
    End Class
End Namespace