<!-- default file list -->
*Files to look at*:

* [frmDEsigner.cs](./CS/CustomProviderSample/frmDEsigner.cs) (VB: [frmDEsigner.vb](./VB/CustomProviderSample/frmDEsigner.vb))
* **[MyWizardCustomizationService.cs](./CS/CustomProviderSample/MyWizardCustomizationService.cs) (VB: [MyWizardCustomizationService.vb](./VB/CustomProviderSample/MyWizardCustomizationService.vb))**
<!-- default file list end -->
# Data Source Wizard - How to hide undesired data providers


<p>This example illustrates how to remove some of the data providers available on the <a href="https://documentation.devexpress.com/#XtraReports/CustomDocument4245">Specify a Connection String</a> wizard page.</p>
<p>The following image illustrates this wizard page with all the data providers removed except for <strong>Microsoft SQL Server</strong>.</p>
<p><img src="https://raw.githubusercontent.com/DevExpress-Examples/data-source-wizard-how-to-hide-undesired-data-providers-t333751/16.2.3+/media/303326bc-bad0-11e6-80bf-00155d62480c.png"></p>
<p>To customize the <a href="https://documentation.devexpress.com/#XtraReports/CustomDocument115389">Data Source</a> and <a href="https://documentation.devexpress.com/#XtraReports/CustomDocument115390">Report</a> wizard pages, do the following.</p>
<p>1. Add a custom service implementing the <strong>IWizardCustomizationService</strong> interface.</p>
<p>In this example, the <a href="https://documentation.devexpress.com/#XtraReports/CustomDocument4243">Select the Data Source Type</a> wizard page is removed by enabling only the <strong>DataSourceType.</strong>Xpo setting (corresponding to the <a href="https://documentation.devexpress.com/#XtraReports/CustomDocument4241">Database Connection</a> option).</p>
<p>Then, the <strong>CustomizeProviders<TModel></strong> method is called, which assigns a custom list of data providers to a corresponding <strong>ISqlDataSourceModel</strong> object.</p>
<p>2. Register the created service by calling the <a href="https://documentation.devexpress.com/#XtraReports/DevExpressXtraReportsUserDesignerXRDesignMdiController_AddServicetopic">XRDesignMdiController.AddService</a> method.</p>
<p><br><strong>See also</strong>:<br>For a general code example on how to customize the Data Source Wizard using the <strong>IWizardCustomizationService</strong> interface, see <em><a href="https://www.devexpress.com/Support/Center/p/T140683">How to customize the New Report Wizard (introduced in the 2014 vol.1 release) in the End-User Designer</a></em>.</p>

<br/>


