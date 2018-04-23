Imports System.Collections.Generic
Imports System.ComponentModel.Design
Imports DevExpress.DataAccess.Native.Sql.ConnectionStrategies
Imports DevExpress.DataAccess.UI.Wizard
Imports DevExpress.DataAccess.Wizard.Model
Imports DevExpress.DataAccess.Wizard.Presenters
Imports DevExpress.XtraReports.Wizards
Imports DevExpress.XtraReports.Wizards.Presenters
' ...

Namespace CustomProviderSample
    Friend Class MyWizardCustomizationService
        Implements IWizardCustomizationService

        #Region "Implementation of IWizardCustomizationService"

        Private Sub IWizardCustomizationService_CustomizeReportWizard(ByVal tool As IWizardCustomization(Of XtraReportModel)) Implements IWizardCustomizationService.CustomizeReportWizard
            If tool.StartPage Is GetType(ChooseReportTypePage(Of XtraReportModel)) Then
                tool.Model.ReportType = ReportType.Standard
                tool.Model.DataSourceType = DataSourceType.Xpo
                tool.StartPage = GetType(ConnectionPropertiesPage(Of XtraReportModel))
            End If
            CustomizeProviders(tool)
        End Sub

        Private Sub IWizardCustomizationService_CustomizeDataSourceWizard(ByVal tool As IWizardCustomization(Of XtraReportModel)) Implements IWizardCustomizationService.CustomizeDataSourceWizard
            If tool.StartPage Is GetType(ChooseDataSourceTypePage(Of XtraReportModel)) Then
                tool.Model.DataSourceType = DataSourceType.Xpo
                tool.StartPage = GetType(ConnectionPropertiesPage(Of XtraReportModel))
            End If
            CustomizeProviders(tool)
        End Sub

        Private Function IWizardCustomizationService_TryCreateDataSource(ByVal model As IDataSourceModel, ByRef dataSource As Object, ByRef dataMember As String) As Boolean Implements IWizardCustomizationService.TryCreateDataSource
            dataSource = Nothing
            dataMember = Nothing
            Return False
        End Function

        Private Function IWizardCustomizationService_TryCreateReport(ByVal designerHost As IDesignerHost, ByVal model As XtraReportModel, ByVal dataSource As Object, ByVal dataMember As String) As Boolean Implements IWizardCustomizationService.TryCreateReport
            Return False
        End Function

        #End Region

        Private Shared Sub CustomizeProviders(Of TModel As ISqlDataSourceModel)(ByVal tool As IWizardCustomization(Of TModel))
            Dim providers As List(Of ProviderLookupItem) = CType(tool.Resolve(GetType(List(Of ProviderLookupItem))), List(Of ProviderLookupItem))
            providers.RemoveAll(Function(x As ProviderLookupItem) x.ProviderKey <> "MSSqlServer")
        End Sub
    End Class
End Namespace
