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
    public partial class UcTourCostIncludeExcIude : System.Web.UI.UserControl
    {
        #region "Member Variable(s)"
        int pvTourType;
        int pvTourID;
        #endregion
        #region "Property(s)"
        public int fldTourType
        {
            get
            {
                return pvTourType;
            }
            set
            {
                pvTourType = value;
            }
        }

        public int fldTourID
        {
            get
            {
                return pvTourID;
            }
            set
            {
                pvTourID = value;
            }
        }
        #endregion
        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCostIncludeExclue();
            }
        }

        protected void dgShowItinerary_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
    
        }
        #endregion
        #region "Method(s)"

        private void BindCostIncludeExclue()
        {
            List<TourItenerary_SPResult> lGetResult = null;
            clsAdo objOther = new clsAdo();

            try
            {
                lGetResult = new List<TourItenerary_SPResult>();
                lGetResult = objOther.fnGetTourItenerary(fldTourID, fldTourType).ToList();
                if (lGetResult != null && lGetResult.Count > 0)
                { if (!string.IsNullOrEmpty(lGetResult[0].CostIncludes))
                    {
                        ltrConstInclue.Text = lGetResult[0].CostIncludes.ToString();
                        if (!lGetResult[0].CostIncludes.ToString().Contains("<li>"))
                        {
                            ltrConstInclue.Text = "<li style='list-style-type: none;'>" + Server.HtmlDecode(lGetResult[0].CostIncludes.ToString()) + "</li>";
                        }

                    }
                    else
                    {
                        divCostInclude.Visible = false;
                    }

                    if (!string.IsNullOrEmpty(lGetResult[0].CostExcludes))
                    {
                        LtrCostExlude.Text = lGetResult[0].CostExcludes.ToString() + "</li>";
                        if (!lGetResult[0].CostExcludes.ToString().Contains("<li>"))
                        {
                            LtrCostExlude.Text = "<li style='list-style-type: none;'>" + Server.HtmlDecode(lGetResult[0].CostExcludes.ToString()) + "</li>";
                        }
                    }
                    else
                    {
                        divCostInclude.Visible = false;
                    }

                    string strTourInclusionExculision = "";
                    if (!string.IsNullOrEmpty(lGetResult[0].CostIncludes) && !string.IsNullOrEmpty(lGetResult[0].CostExcludes))
                    {
                        strTourInclusionExculision += "<br/><br/><div style='margin-bottom: 30px;'>";
                        strTourInclusionExculision += "<div style='width:100%;'>";
                        strTourInclusionExculision += "<h3 class='title'>";
                        strTourInclusionExculision += "<span>Inclusions</span></h3>";
                        strTourInclusionExculision += ltrConstInclue.Text;
                        strTourInclusionExculision += "</div>";
                        strTourInclusionExculision += "</div>";
                        strTourInclusionExculision += "<div>";
                        strTourInclusionExculision += "<div style='width:100%;'>";
                        strTourInclusionExculision += "<h3 class='title'>";
                        strTourInclusionExculision += "<span>Exclusions</span></h3>";
                        strTourInclusionExculision += LtrCostExlude.Text;
                        strTourInclusionExculision += "</div>";
                        strTourInclusionExculision += "</div><br/><br/>";
                    }
                    HiddenField hdnTourInclusionExculision = this.Page.FindControl("hdnTourInclusionExculision") as HiddenField;
                    hdnTourInclusionExculision.Value = strTourInclusionExculision;

                }
                else
                {
                    divCostInclude.Visible = false;
                }
            }
            catch
            {

            }
            finally
            {
                if (lGetResult != null)
                {
                    lGetResult = null;
                }

                if (objOther != null)
                {
                    objOther = null;
                }
            }
        }

        #endregion
    }
}