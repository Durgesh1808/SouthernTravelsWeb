using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
namespace SouthernTravelsWeb.UserControl
{
    public partial class UcTourItinerary : System.Web.UI.UserControl
    {

        #region "Member Variable(s)"
        TOURTYPE pvTourType;
        int pvTourID;
        string itinaryHtml;
        #endregion
        #region "Property(s)"
        public TOURTYPE fldTourType
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

        public string fldItinaryHtml
        {
            get
            {
                return itinaryHtml;
            }
            set
            {
                itinaryHtml = value;
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
                ShowItinerary();
            }
        }
        protected void rptItinerary_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

            }
        }
        protected void dgShowItinerary_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
           
        }
        #endregion
        #region "Method(s)"
        private void ShowItinerary()
        {
            List<GetTourItinerary_Meal_spResult> lTourItinerary = new List<GetTourItinerary_Meal_spResult>();
            List<MealPlan> lMealPlan = new List<MealPlan>();

            using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetTourItinerary_Meal_sp, conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@I_TourType", (int)fldTourType);
                    cmd.Parameters.AddWithValue("@I_TourID", fldTourID);

                    SqlParameter returnValue = new SqlParameter("@O_ReturnValue", SqlDbType.Int);
                    returnValue.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(returnValue);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // First result set: Tour Itinerary
                        while (reader.Read())
                        {
                            var item = new GetTourItinerary_Meal_spResult
                            {
                                DayNo = reader["DayNo"] != DBNull.Value ? Convert.ToInt32(reader["DayNo"]) : (int?)null,
                                ItineraryTime = reader["ItineraryTime"]?.ToString(),
                                DayTitle = reader["DayTitle"]?.ToString(),
                                PlaceOfVisit = reader["PlaceOfVisit"]?.ToString(),
                                MealPlan = reader["MealPlan"]?.ToString(),
                                NightHalt = reader["NightHalt"]?.ToString()
                            };
                            lTourItinerary.Add(item);
                        }

                        // Second result set: Meal Plan
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                var meal = new MealPlan
                                {
                                    Day = Convert.ToInt32(reader["DayMealPlan"]),
                                    Meal = reader["MealPlanDescripation"].ToString()
                                };
                                lMealPlan.Add(meal);
                            }
                        }
                    }
                }
            }

            // Bind to Repeater
            if (lTourItinerary.Count > 0)
            {
                rptItinerary.DataSource = lTourItinerary;
                rptItinerary.DataBind();

                for (int i = 0; i < rptItinerary.Items.Count; i++)
                {
                    Literal ltrText = (Literal)rptItinerary.Items[i].FindControl("ltrText");
                    HiddenField hdNightHalt = (HiddenField)rptItinerary.Items[i].FindControl("hdNightHalt");
                    HiddenField hdMealPlan = (HiddenField)rptItinerary.Items[i].FindControl("hdMealPlan");

                    string lIten = " <div class='row_meals'> ";

                    // Meals
                    if (!string.IsNullOrEmpty(hdMealPlan.Value))
                    {
                        lIten += " <div class='mealwrapper'>  <h3>  Meals</h3>  <ul class=\"meal-list withborder\">";
                        if (fldTourType != TOURTYPE.INTERNATIONAL_TOUR)
                        {
                            if (hdMealPlan.Value.Contains("Breakfast"))
                                lIten += " <li><img src='Assets/images/icon-meal.png'>Breakfast</li>";
                            if (hdMealPlan.Value.Contains("Lunch"))
                                lIten += "<li><img src='Assets/images/icon-meal.png'>Lunch</li>";
                            if (hdMealPlan.Value.Contains("Dinner"))
                                lIten += "<li><img src='Assets/images/icon-meal.png'>Dinner</li>";
                        }
                        else
                        {
                            lIten += "<li><img src='Assets/images/icon-meal.png'>" +
                                     hdMealPlan.Value.Replace(",", "</li><li><img src='Assets/images/icon-meal.png'>") + "</li>";
                        }
                        lIten += "</ul>   </div>";
                    }

                    // Night Halt
                    if (!string.IsNullOrEmpty(hdNightHalt.Value) && hdNightHalt.Value != "--")
                    {
                        string lower = hdNightHalt.Value.Trim().ToLower();
                        if (lower.Contains("night journey") || lower.Contains("in journey"))
                            lIten += "<div class='nightstay'>   <h3>  Night Journey</h3> <ul class=\"meal-list withborder\"><li><img src=\"images/icon-njourney.png\">" + hdNightHalt.Value + "</li></ul>";
                        else if (lower.Contains("concludes") || lower.Contains("conculdes"))
                            lIten += "<div class='nightstay'>    <ul class=\"meal-list withborder\"><li><img src=\"Assets/images/Tour-concludes.png\">" + hdNightHalt.Value + "</li></ul>";
                        else
                            lIten += "<div class='nightstay'>   <h3>  Night Stay </h3> <ul class=\"meal-list withborder\"><li><img src=\"Assets/images/icon-nightstay.png\">" + hdNightHalt.Value + "</li></ul>";
                    }

                    lIten += "</div></div>";
                    ltrText.Text = lIten;
                }

                // HTML for Email
                string ItineraryHtml = "";
                for (int i = 0; i < rptItinerary.Items.Count; i++)
                {
                    HiddenField hdnItinairyDayNo = (HiddenField)rptItinerary.Items[i].FindControl("hdnItinairyDayNo");
                    HiddenField hdnItiniraryTime = (HiddenField)rptItinerary.Items[i].FindControl("hdnItiniraryTime");
                    HiddenField hdnItiDayTitle = (HiddenField)rptItinerary.Items[i].FindControl("hdnItiDayTitle");
                    HiddenField hdnItiPlaceOfVisit = (HiddenField)rptItinerary.Items[i].FindControl("hdnItiPlaceOfVisit");
                    HiddenField hdMealPlan = (HiddenField)rptItinerary.Items[i].FindControl("hdMealPlan");
                    HiddenField hdNightHalt = (HiddenField)rptItinerary.Items[i].FindControl("hdNightHalt");

                    ItineraryHtml += "<div class='tbldetail'><table cellpadding='0' cellspacing='0' border='0' width='100%'><tr><td class='paddingbtm40'><table width='100%' cellpadding='0' cellspacing='0'>";
                    ItineraryHtml += "<tr><td valign='top' align='left'><table width='100%' cellpadding='10' cellspacing='0' bordercolor='#cccccc' border='1' style='border-collapse: collapse;'>";
                    ItineraryHtml += $"<tr><td width='15%' valign='top' bgcolor='#fbbf00' style='font-family: Arial; color:#fff; font-size: 14px;'><div class='daydesc'>Day {hdnItinairyDayNo.Value}<br/>{hdnItiniraryTime.Value}</div></td>";
                    ItineraryHtml += $"<td width='85%' valign='top' style='font-family: Arial; color:#000; font-size: 14px;'><div class='desc'>{hdnItiDayTitle.Value}</div></td></tr>";
                    ItineraryHtml += "</table></td></tr><tr><td height='20'>&nbsp;</td></tr>";
                    ItineraryHtml += $"<tr><td style='font-family: Arial; color:#000; font-size: 14px;'>{hdnItiPlaceOfVisit.Value}</td></tr>";

                    // Meals in HTML
                    if (!string.IsNullOrEmpty(hdMealPlan.Value))
                    {
                        ItineraryHtml += "<tr><td height='20'>&nbsp;</td></tr><tr><td style='font-family: Arial; color:#000; font-size: 17px;'>Meals</td></tr><tr><td><table cellpadding='5' cellspacing='5' border='0'><tr>";

                        if (fldTourType != TOURTYPE.INTERNATIONAL_TOUR)
                        {
                            if (hdMealPlan.Value.Contains("Breakfast"))
                                ItineraryHtml += "<td style='border: solid 1px #ccc; border-radius: 5px;'><img src='Assets/images/icon-meal.png'>Breakfast</td>";
                            if (hdMealPlan.Value.Contains("Lunch"))
                                ItineraryHtml += "<td style='border: solid 1px #ccc; border-radius: 5px;'><img src='Assets/images/icon-meal.png'>Lunch</td>";
                            if (hdMealPlan.Value.Contains("Dinner"))
                                ItineraryHtml += "<td style='border: solid 1px #ccc; border-radius: 5px;'><img src='Assets/images/icon-meal.png'>Dinner</td>";
                        }
                        else
                        {
                            ItineraryHtml += $"<td style='border: solid 1px #ccc; border-radius: 5px;'><img src='Assets/images/icon-meal.png'>{hdMealPlan.Value.Replace(",", "</td><td style='border: solid 1px #ccc; border-radius: 5px;'><img src='images/icon-meal.png'>")}</td>";
                        }

                        ItineraryHtml += "</tr></table></td></tr>";
                    }

                    // Night Halt in HTML
                    if (!string.IsNullOrEmpty(hdNightHalt.Value) && hdNightHalt.Value != "--")
                    {
                        string nh = hdNightHalt.Value.ToLower();
                        if (nh.Contains("night journey") || nh.Contains("in journey"))
                            ItineraryHtml += $"<tr><td><table><tr><td style='border: solid 1px #ccc;'><img src='Assets/image/icon-njourney.png'>{hdNightHalt.Value}</td></tr></table></td></tr>";
                        else if (nh.Contains("concludes") || nh.Contains("conculdes"))
                            ItineraryHtml += $"<tr><td><table><tr><td style='border: solid 1px #ccc;'><img src='Assets/images/Tour-concludes.png'>{hdNightHalt.Value}</td></tr></table></td></tr>";
                        else
                            ItineraryHtml += $"<tr><td><table><tr><td style='border: solid 1px #ccc;'><img src='Assets/images/icon-nightstay.png'>{hdNightHalt.Value}</td></tr></table></td></tr>";
                    }

                    ItineraryHtml += "</table></td></tr></table></div>";
                }

                hdnTourItineraryHtml.Value = ItineraryHtml;
                fldItinaryHtml = ItineraryHtml;

                HiddenField hdnTourItitearyHTML = this.Page.FindControl("hdnTourItitearyHTML") as HiddenField;
                if (hdnTourItitearyHTML != null)
                    hdnTourItitearyHTML.Value += ItineraryHtml;
            }
        }



        #endregion
    }
}