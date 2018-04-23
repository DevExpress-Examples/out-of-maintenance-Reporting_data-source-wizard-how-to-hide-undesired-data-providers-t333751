Imports System.Windows.Forms
Imports DevExpress.XtraReports.Wizards3
' ...

Namespace CustomProviderSample
    Partial Public Class frmDesigner
        Inherits Form

        Public Sub New()
            InitializeComponent()
            reportDesignerMDIController.AddService(GetType(IWizardCustomizationService), New MyWizardCustomizationService())
        End Sub
    End Class
End Namespace
