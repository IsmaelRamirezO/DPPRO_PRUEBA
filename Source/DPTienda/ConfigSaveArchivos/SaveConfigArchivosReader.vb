Imports DPSoft.Framework.Data.SQLServer
Imports DPSoft.Framework.Configuration

Public Class SaveConfigArchivosReader

    Private strConfigurationFilePath As String

    Private oLoadedApplicationConfiguration As SaveConfigArchivos

    Public Sub New(ByVal strConfigFile As String)

        strConfigurationFilePath = strConfigFile

    End Sub

    Public Function LoadSettings() As SaveConfigArchivos

        Dim oConfigurationMgr As New ConfigurationManager

        oLoadedApplicationConfiguration = New SaveConfigArchivos

        Try

            oLoadedApplicationConfiguration = CType(oConfigurationMgr.Load(strConfigurationFilePath, oLoadedApplicationConfiguration), SaveConfigArchivos)

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

    Public Sub SaveSettings(ByVal oSavedApplicationConfiguration As SaveConfigArchivos)

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
