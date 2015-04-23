using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    ShowTrackerEntities showentities = new ShowTrackerEntities();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        { 
        var shows = from sa in showentities.Artists
                    orderby sa.ArtistName
                    select new { sa.ArtistName, sa.ArtistKey };

        DropDownList1.DataSource = shows.ToList();
        DropDownList1.DataTextField = "ArtistName";
        DropDownList1.DataValueField = "ArtistKey";
        DropDownList1.DataBind();
        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int key = int.Parse(DropDownList1.SelectedValue.ToString());
        var artist = from a in showentities.ShowDetails
                     where a.ArtistKey == key
                     select new {
                     a.Show.ShowName,
                     a.Show.ShowDate,
                     a.Artist.ArtistName
                     };
        GridView1.DataSource = artist.ToList();
        GridView1.DataBind();
                     
                    
    }
}