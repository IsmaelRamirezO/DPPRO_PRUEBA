Imports DPSoft.Framework.Data.SQLServer
Imports DPSoft.Framework.Configuration

Public Class ConfigSaveArchivosReader

    Private strConfigurationFilePath As String

    Private oLoadedApplicationConfiguration As ConfigSaveArchivos

    Public Sub New(ByVal strConfigFile As String)

        strConfigurationFilePath = strConfigFile

    End Sub

    Public Function LoadSettings() As ConfigSaveArchivos

        Dim oConfigurationMgr As New ConfigurationManager

        oLoadedApplicationConfiguration = New ConfigSaveArchivos

        Try

            oLoadedApplicationConfiguration = CType(oConfigurationMgr.Load(strConfigurationFilePath, oLoadedApplicationConfiguration), ConfigSaveArchivos)

        Catch oException As DPSoft.Framework.Configuration.ConfigurationFileNotFoundException

            Throw oException

        Catch oException As DPSoft.Framework.Configuration.ConfigurationLoadFileException

            Throw oException

        Catch oException As Exception

            Throw oException

        End Try

        oConfigurationMgr = Nothing

        Return oLoadedApplicationConfiguration

    End Function

    Public Sub SaveSettings(ByVal oSavedApplicationConfiguration As ConfigSaveArchivos)

        Dim oConfigurationMgr As New ConfigurationManager

        Try

            oConfigurationMgr.Save(strConfigurationFilePath, oSavedApplicationConfiguration)

        Catch oException As DPSoft.Framework.Configuration.ConfigurationFileNotFoundException

            Throw oException

        Catch oException As DPSoft.Framework.Configuration.ConfigurationLoadFileException

            Throw oException

        Catch oException As Exception

            Throw oException

        End Try

        oConfigurationMgr = Nothing

    End Sub

End Class
