Imports DPSoft.Framework.Data.SQLServer
Imports DPSoft.Framework.Configuration

Public Class SapConfigReader

        Private strConfigurationFilePath As String

        Private oLoadedApplicationConfiguration As SAPApplicationConfig

        Public Sub New(ByVal strConfigFile As String)

            strConfigurationFilePath = strConfigFile

        End Sub

        Public Function LoadSettings() As SAPApplicationConfig

            Dim oConfigurationMgr As New ConfigurationManager

            oLoadedApplicationConfiguration = New SAPApplicationConfig

            Try

                oLoadedApplicationConfiguration = CType(oConfigurationMgr.Load(strConfigurationFilePath, oLoadedApplicationConfiguration), SAPApplicationConfig)

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

        Public Sub SaveSettings(ByVal oSavedApplicationConfiguration As SAPApplicationConfig)

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
