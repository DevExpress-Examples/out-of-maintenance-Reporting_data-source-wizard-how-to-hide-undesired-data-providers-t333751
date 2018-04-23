using System.Collections.Generic;
using System.ComponentModel.Design;
using DevExpress.Data.XtraReports.Wizard;
using DevExpress.DataAccess.Native.Sql.ConnectionStrategies;
using DevExpress.DataAccess.UI.Wizard;
using DevExpress.DataAccess.Wizard.Model;
using DevExpress.DataAccess.Wizard.Presenters;
using DevExpress.XtraReports.Wizards3;
using DevExpress.XtraReports.Wizards3.Presenters;
// ...

namespace CustomProviderSample {
    class MyWizardCustomizationService : IWizardCustomizationService {
        #region Implementation of IWizardCustomizationService

        void IWizardCustomizationService.CustomizeReportWizard(IWizardCustomization<XtraReportModel> tool) {
            if(tool.StartPage == typeof(ChooseReportTypePageEx<XtraReportModel>)) {
                tool.Model.ReportType = ReportType.Standard;
                tool.Model.DataSourceType = DataSourceType.Xpo;
                tool.StartPage = typeof(ConnectionPropertiesPage<XtraReportModel>);
            }
            CustomizeProviders(tool);
        }

        void IWizardCustomizationService.CustomizeDataSourceWizard(IWizardCustomization<DataSourceModel> tool) {
            if(tool.StartPage == typeof(ChooseDataSourceTypePage<DataSourceModel>)) {
                tool.Model.DataSourceType = DataSourceType.Xpo;
                tool.StartPage = typeof(ConnectionPropertiesPage<DataSourceModel>);
            }

            CustomizeProviders(tool);
        }

        bool IWizardCustomizationService.TryCreateDataSource(IDataSourceModel model, out object dataSource, out string dataMember) {
            dataSource = null;
            dataMember = null;
            return false;
        }

        bool IWizardCustomizationService.TryCreateReport(IDesignerHost designerHost, XtraReportModel model, object dataSource, string dataMember) {
            return false;
        }

        #endregion

        static void CustomizeProviders<TModel>(IWizardCustomization<TModel> tool) where TModel : ISqlDataSourceModel {
            List<ProviderLookupItem> providers = (List<ProviderLookupItem>)tool.Resolve(typeof(List<ProviderLookupItem>));
            providers.RemoveAll((ProviderLookupItem x) => x.ProviderKey != "MSSqlServer");
        }
    }
}
