using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcNewsUpdateShow : System.Web.UI.UserControl
    {
        #region "Member Variable(s)"
        #endregion
        #region "Property(s)"


        #endregion
        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        #endregion
        #region "Method(s)"

        public void BindData()
        {
            clsAdo clsObj = null;
            List<GetNewsUpdate_SPResult> lResults = null;
            try
            {
                clsObj = new clsAdo();

                lResults = new List<GetNewsUpdate_SPResult>();
                lResults = clsObj.fnGetNewsUpdate(-1);
                if (lResults != null && lResults.Count > 0)
                {
                    string lStrHtml = "<div style='padding-left: 10px; padding-right: 10px; text-align: justify; color:Blue;'><marquee id='scroller' scrollamount='1' height='100px' onmouseover='javascript:scroller.stop()' onmouseout='javascript:scroller.start()' direction='up'><ul  style='list-style: none;'>";
                    for (int lCtr = 0; lCtr < lResults.Count; lCtr++)
                    {
                        lStrHtml = lStrHtml + "<li><b class='orange'>" + lResults[lCtr].HeadLine.ToString() + "</b><br/><br/>";
                        lStrHtml = lStrHtml + Convert.ToString(lResults[lCtr].LongNews.ToString().Length > 500 ? Convert.ToString(lResults[lCtr].LongNews.ToString()).Substring(0, Convert.ToString(lResults[lCtr].LongNews.ToString()).Substring(0, 500).LastIndexOf(" ")) + "..." : lResults[lCtr].LongNews.ToString()) + "<div class='row tb10' align='right' ><span class='orange' style='padding-right: 20px;'><a href='NewsAlert.aspx?RowID=" + lResults[lCtr].RowID.ToString() + "'target='_blank'>More...</a></span> </div></li>";
                    }
                    lStrHtml = lStrHtml + "</ul></marquee></div>";
                    ltrNewsUpdate.Text = lStrHtml;
                }
                else
                {

                }
            }
            finally
            {
                if (clsObj != null)
                {
                    clsObj = null;
                }
                if (lResults != null)
                {
                    lResults = null;
                }
            }
        }

        #endregion
    }
}