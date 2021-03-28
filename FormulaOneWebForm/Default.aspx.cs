using FormulaOneDLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FormulaOneWebForm
{
    public partial class Default : System.Web.UI.Page
    {   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Inizializzazioni che vengono eseguite solo la prima volta che la pagina viene caricata
                DBTools myTools = new DBTools();
                lstTables.DataSource = myTools.getTableName();
                lstTables.DataBind();
                lstTables.SelectedIndex = 0;
                dgvItems.DataSource = myTools.getTableData(lstTables.SelectedItem.ToString());
                dgvItems.DataBind();
                getCountry();
            }
            else
            {
                // Eseguite tutte le volte dopo che la pagina è caricata
            }
        }

        protected void changeSelection(object sender, EventArgs e)
        {
            DBTools myTools = new DBTools();
            dgvItems.DataSource = myTools.getTableData(lstTables.SelectedItem.ToString());
            dgvItems.DataBind();
        }

        public void getCountry (string isoCode = "")
        {
            HttpWebRequest apiRequest = WebRequest.Create("https://localhost:44308/api/Country" + isoCode + "") as HttpWebRequest;
            string apiResponse = "";
            try
            {
                using(HttpWebResponse response = apiRequest.GetResponse() as HttpWebResponse)
                {
                    StreamReader reader = new StreamReader(response.GetResponseStream());
                    apiResponse = reader.ReadToEnd();
                    Country[] oCountry = Newtonsoft.Json.JsonConvert.DeserializeObject<Country[]>(apiResponse);
                    dgvItems.DataSource = oCountry;
                    dgvItems.DataBind();
                    dgvItems.Visible = true;
                } 
            }
            catch (System.Net.WebException ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}