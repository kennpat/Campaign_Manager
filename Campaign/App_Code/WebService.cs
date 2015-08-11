using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;


/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]

public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    public class Campaign
    {
        public string CampaignName { get; set; }
        public string NumberOfPlayers { get; set; }
        public string DMName { get; set; }
    }

    public class loadRequest
    {
        public string CampaignName { get; set; }
    }

    public static string ConnString = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=C:\\CS651\\FinalProject3\\App_Data\\campaignVault.mdf;Integrated Security=True";
    SqlConnection SqlConn = new SqlConnection(ConnString);

    [WebMethod]

    public string SaveCampaign(Campaign campaign)
    {

        string sql = GetSaveSql(campaign);
        SqlCommand cmd;
        try
        {
            SqlConn.Open();
            {
                cmd = new SqlCommand(sql, SqlConn);

                SetSaveParams(campaign, cmd);


                cmd.ExecuteNonQuery();
            }
            return "campaign saved successfully!";
        }
        catch (Exception e)
        {
            return e.ToString();
        }
    }

    private static void SetSaveParams(Campaign campaign, SqlCommand cmd)
    {
        cmd.Parameters.Add("@name", campaign.CampaignName);
    }

    private static string GetLoadSql(loadRequest c)
    {
        string sql = "select * from Campaigns where Name= @CampaignName";
        return sql;
    }

    private static string GetSaveSql(Campaign campaign)
    {
        string sql = "";
        return sql;

    }

}

