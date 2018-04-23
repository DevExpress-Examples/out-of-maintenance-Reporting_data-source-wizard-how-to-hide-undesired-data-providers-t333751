using System.Windows.Forms;
using DevExpress.XtraReports.Wizards3;
// ...

namespace CustomProviderSample {
    public partial class frmDesigner : Form {
        public frmDesigner() {
            InitializeComponent();
            reportDesignerMDIController.AddService(typeof(IWizardCustomizationService), new MyWizardCustomizationService());
        }
    }
}
