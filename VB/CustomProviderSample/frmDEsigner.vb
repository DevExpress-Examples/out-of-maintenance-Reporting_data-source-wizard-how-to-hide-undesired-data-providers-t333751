Imports System.Windows.Forms
Imports DevExpress.XtraReports.Wizards
' ...

Namespace CustomProviderSample
    Partial Public Class frmDesigner
        Inherits Form

        Public Sub New()
            InitializeComponent()
            reportDesignerMDIController.AddService(GetType(IWizardCustomizationService), New MyWizardCustomizationService())
            AddHandler Load, AddressOf FrmDesigner_Load
        End Sub

        Private Sub FrmDesigner_Load(ByVal sender As Object, ByVal e As System.EventArgs)
            reportDesignerMDIController.CreateNewReportWizard()
        End Sub
    End Class
End Namespace
