<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Campaign_new.aspx.cs" Inherits="Campaign_new" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <link href="style.css" rel="stylesheet"/>
     <script type="text/javascript" src="Scripts/jquery-1.10.2.min.js"></script>
    <title>Campaign Manager</title>
</head>



<body>
    <style type="text/css">
        #CampaignName {
            width: 250px;
        }
        #NumberOfPlayers {
            width: 40px;
        }

        label{
            font-size: 12px;
        }
    </style>
    <div class="header">
        <h1>Campaign Manager</h1>      
    </div>

    <form id="new_campaign" runat="server">
        <label>What is the name of your campaign?</label>
        <input id="CampaignName"/><br/>
        <label>How many players?</label>
        <input id="NumberOfPlayers" /><br/>
        <label>What is your name?</label>
        <input id="DMName" /><br/>
        <button type="button" id="FooBtn" onclick="SaveMe(); location.href='CampaignDetails.aspx'">Click Me</button>
    </form>

     <script type="text/javascript">
         function SaveMe() {
             var campaign = {};
             campaign.CampaignName = $("#CampaignName").val();
             campaign.NumberOfPlayers = $("#NumberOfPlayers").val();
             campaign.DMName = $("#DMName").val();

             $.ajax({
                 url: "WebService.asmx/SaveCampaign",
                 data: "{ campaign:" + JSON.stringify(campaign) + " }",
                 type: "POST",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: function (result) {
                     alert(result.d)
                 },
                 error: function (x, y, z) {
                     alert(x.responseText + "  " + x.status);
                 }


             });
             $("#CampaignName").val("This Campaign");
         }
    </script>
    
</body>
</html>
