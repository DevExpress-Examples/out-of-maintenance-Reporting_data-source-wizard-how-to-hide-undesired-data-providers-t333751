using System.Windows.Forms;
using DevExpress.XtraReports.Wizards;
// ...

namespace CustomProviderSample {
    public partial class frmDesigner : Form {
        public frmDesigner() {
            InitializeComponent();
            reportDesignerMDIController.AddService(typeof(IWizardCustomizationService), new MyWizardCustomizationService());
            Load += FrmDesigner_Load;
        }

        void FrmDesigner_Load(object sender, System.EventArgs e) {
            reportDesignerMDIController.CreateNewReportWizard();
        }
    }
}
