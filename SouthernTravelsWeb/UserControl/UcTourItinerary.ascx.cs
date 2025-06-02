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
        private void ShowItinerary_XML()
        {
           
        }
        private void ShowItinerary()
        {
            string connectionString = DataLib.getConnectionString();

            List<GetTourItinerary_Meal_spResult> lTourItinerary = new List<GetTourItinerary_Meal_spResult>();
            List<MealPlan> lMealPlan = new List<MealPlan>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(StoredProcedures.GetTourItinerary_Meal_sp, conn))
                {
                  
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@I_TourID", fldTourID);
                    cmd.Parameters.AddWithValue("@I_TourType", fldTourType);

                    SqlParameter outputParam = new SqlParameter("@O_ReturnValue", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);
                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // First result set: GetTourItinerary_Meal_spResult
                        while (reader.Read())
                        {
                            GetTourItinerary_Meal_spResult item = new GetTourItinerary_Meal_spResult();

                            // Map each column explicitly, e.g.
                            item.DayNo = reader["DayNo"] != DBNull.Value ? Convert.ToInt32(reader["DayNo"]) : 0;
                            item.ItineraryTime = reader["ItineraryTime"] as string ?? "";
                            item.DayTitle = reader["DayTitle"] as string ?? "";
                            item.PlaceOfVisit = reader["PlaceOfVisit"] as string ?? "";
                            item.NightHalt = reader["NightHalt"] as string ?? "";
                            item.MealPlan = reader["MealPlan"] as string ?? "";
                            // Add more properties mapping based on your class and DB schema

                            lTourItinerary.Add(item);
                        }

                        // Move to second result set: MealPlan
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                MealPlan meal = new MealPlan();

                                // Map columns similarly
                                meal.DayMealPlan = reader["DayMealPlan"] as string ?? "";
                                meal.MealPlanDescripation = reader["MealPlanDescripation"] as string ?? "";
                                // Map other MealPlan properties here

                                lMealPlan.Add(meal);
                            }
                        }
                    }
                }

                // Now, bind lTourItinerary to your repeater and generate HTML like your original code
                if (lTourItinerary != null && lTourItinerary.Count > 0)
                {
                    rptItinerary.DataSource = lTourItinerary;
                    rptItinerary.DataBind();

                    if (rptItinerary.Items.Count > 1)
                    {
                        for (int lCtr = 0; lCtr < rptItinerary.Items.Count; lCtr++)
                        {
                            Literal ltrText = (Literal)rptItinerary.Items[lCtr].FindControl("ltrText");
                            HiddenField hdNightHalt = (HiddenField)rptItinerary.Items[lCtr].FindControl("hdNightHalt");
                            HiddenField hdMealPlan = (HiddenField)rptItinerary.Items[lCtr].FindControl("hdMealPlan");

                            string lIten = " <div class='row_meals'> ";
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
                                else if (fldTourType == TOURTYPE.INTERNATIONAL_TOUR)
                                {
                                    lIten += "<li><img src='Assets/images/icon-meal.png'>" + hdMealPlan.Value.Replace(",", "</li><li><img src='Assets/images/icon-meal.png'>") + "</li>";
                                }
                                lIten += "</ul>   </div>";
                            }

                            if (!string.IsNullOrEmpty(hdNightHalt.Value) && hdNightHalt.Value != "--")
                            {
                                var nightHaltLower = hdNightHalt.Value.Trim().ToLower();
                                if (nightHaltLower.Contains("night journey") || nightHaltLower.Contains("in journey"))
                                    lIten += "<div class='nightstay'>   <h3>  Night Journey</h3> <ul class=\"meal-list withborder\"><li><img src=\"Assets/images/icon-njourney.png\">" + hdNightHalt.Value + "</li></ul>";
                                else if (nightHaltLower.Contains("concludes") || nightHaltLower.Contains("conculdes"))
                                    lIten += "<div class='nightstay'>    <ul class=\"meal-list withborder\"><li><img src=\"Assets/images/Tour-concludes.png\">" + hdNightHalt.Value + "</li></ul>";
                                else if (hdNightHalt.Value.Trim() != "Night Journey" && hdNightHalt.Value.Trim() != "Tour concludes" && hdNightHalt.Value.Trim() != "")
                                    lIten += "<div class='nightstay'>   <h3>  Night Stay </h3> <ul class=\"meal-list withborder\"><li><img src=\"Assets/images/icon-nightstay.png\">" + hdNightHalt.Value + "</li></ul>";
                            }

                            lIten += "</div>";
                            lIten += "</div>";

                            ltrText.Text = lIten;
                        }
                    }

                    // Build the hidden field HTML for mail as in your original
                    if (rptItinerary.Items.Count > 0)
                    {
                        hdnTourItineraryHtml.Value = "";
                        string ItineraryHtml = string.Empty;
                        for (int lCtr = 0; lCtr < rptItinerary.Items.Count; lCtr++)
                        {
                            Literal ltrText = (Literal)rptItinerary.Items[lCtr].FindControl("ltrText");
                            HiddenField hdNightHalt = (HiddenField)rptItinerary.Items[lCtr].FindControl("hdNightHalt");
                            HiddenField hdMealPlan = (HiddenField)rptItinerary.Items[lCtr].FindControl("hdMealPlan");

                            HiddenField hdnItinairyDayNo = (HiddenField)rptItinerary.Items[lCtr].FindControl("hdnItinairyDayNo");
                            HiddenField hdnItiniraryTime = (HiddenField)rptItinerary.Items[lCtr].FindControl("hdnItiniraryTime");
                            HiddenField hdnItiDayTitle = (HiddenField)rptItinerary.Items[lCtr].FindControl("hdnItiDayTitle");
                            HiddenField hdnItiPlaceOfVisit = (HiddenField)rptItinerary.Items[lCtr].FindControl("hdnItiPlaceOfVisit");

                            ItineraryHtml += "<div class='tbldetail'>";
                            ItineraryHtml += "<table cellpadding='0' cellspacing='0' border='0' width='100%'>";
                            ItineraryHtml += "<tr><td class='paddingbtm40'>";
                            ItineraryHtml += "<table width='100%' cellpadding='0' cellspacing='0'>";
                            ItineraryHtml += "<tr><td valign='top' align='left'>";
                            ItineraryHtml += "<table width='100%' cellpadding='10' cellspacing='0' bordercolor='#cccccc' border='1' style='border-collapse: collapse;'>";
                            ItineraryHtml += "<tr>";
                            ItineraryHtml += "<td width='15%' valign='top' bgcolor='#fbbf00' style='font-family: Arial, Helvetica, sans-serif; color:#fff; font-size: 14px; border-color: #ccc'>";
                            ItineraryHtml += "<div class='daydesc'>Day " + hdnItinairyDayNo.Value + "<br/>" + hdnItiniraryTime.Value + "</div>";
                            ItineraryHtml += "</td>";
                            ItineraryHtml += "<td width='85%' valign='top' style='font-family: Arial, Helvetica, sans-serif; color:#000; font-size: 14px;border-color: #ccc'>";
                            ItineraryHtml += "<div class='desc'>" + hdnItiDayTitle.Value + "</div>";
                            ItineraryHtml += "</td>";
                            ItineraryHtml += "</tr></table></td></tr>";
                            ItineraryHtml += "<tr><td height='20'>&nbsp;</td></tr>";
                            ItineraryHtml += "<tr><td style='font-family: Arial, Helvetica, sans-serif; color:#000; font-size: 14px;'>" + hdnItiPlaceOfVisit.Value + "</td></tr>";
                            ItineraryHtml += "<tr><td height='20'>&nbsp;</td></tr>";

                            if (!string.IsNullOrEmpty(hdMealPlan.Value))
                            {
                                ItineraryHtml += "<tr><td style='font-family: Arial, Helvetica, sans-serif; color:#000; font-size: 17px;'>Meals</td></tr>";
                                if (fldTourType != TOURTYPE.INTERNATIONAL_TOUR)
                                {
                                    ItineraryHtml += "<tr><td><table cellpadding='5' cellspacing='5' border='0'><tr>";
                                    if (hdMealPlan.Value.Contains("Breakfast"))
                                        ItineraryHtml += "<td style='border: solid 1px #ccc; border-radius: 5px; font-family: Arial, Helvetica, sans-serif; color:#000; font-size: 14px;'><img src='Assets/images/icon-meal.png'>Breakfast</td>";
                                    if (hdMealPlan.Value.Contains("Lunch"))
                                        ItineraryHtml += "<td style='border: solid 1px #ccc; border-radius: 5px; font-family: Arial, Helvetica, sans-serif; color:#000; font-size: 14px;'><img src='Assets/images/icon-meal.png'>Lunch</td>";
                                    if (hdMealPlan.Value.Contains("Dinner"))
                                        ItineraryHtml += "<td style='border: solid 1px #ccc; border-radius: 5px; font-family: Arial, Helvetica, sans-serif; color:#000; font-size: 14px;'><img src='Assets/images/icon-meal.png'>Dinner</td>";
                                    ItineraryHtml += "</tr></table></td></tr>";
                                }
                                else if (fldTourType == TOURTYPE.INTERNATIONAL_TOUR)
                                {
                                    ItineraryHtml += "<tr><td><table cellpadding='5' cellspacing='5' border='0'><tr>";
                                    ItineraryHtml += "<td style='border: solid 1px #ccc; border-radius: 5px; font-family: Arial, Helvetica, sans-serif; color:#000; font-size: 14px;'><img src='Assets/images/icon-meal.png'>" + hdMealPlan.Value.Replace(",", "</td><td style='border: solid 1px #ccc; border-radius: 5px; font-family: Arial, Helvetica, sans-serif; color:#000; font-size: 14px;'><img src='Assets/images/icon-meal.png'>") + "</td>";
                                    ItineraryHtml += "</tr></table></td></tr>";
                                }
                            }

                            if (!string.IsNullOrEmpty(hdNightHalt.Value) && hdNightHalt.Value != "--")
                            {
                                var nightHaltLower = hdNightHalt.Value.Trim().ToLower();
                                if (nightHaltLower.Contains("night journey") || nightHaltLower.Contains("in journey"))
                                {
                                    ItineraryHtml += "<tr><td height='20'>&nbsp;</td></tr>";
                                    ItineraryHtml += "<tr><td style='font-family: Arial, Helvetica, sans-serif; color:#000; font-size: 17px;'>Night Journey</td></tr>";
                                    ItineraryHtml += "<tr><td><table cellpadding='5' cellspacing='5' border='0'><tr><td style='border: solid 1px #ccc; border-radius: 5px; font-family: Arial, Helvetica, sans-serif; color:#000; font-size: 14px;'><img src=\"Assets/images/icon-njourney.png\">" + hdNightHalt.Value + "</td></tr></table></td></tr>";
                                }
                                else if (nightHaltLower.Contains("concludes") || nightHaltLower.Contains("conculdes"))
                                {
                                    ItineraryHtml += "<tr><td height='20'>&nbsp;</td></tr>";
                                    ItineraryHtml += "<tr><td></td></tr>";
                                    ItineraryHtml += "<tr><td><table cellpadding='5' cellspacing='5' border='0'><tr><td style='border: solid 1px #ccc; border-radius: 5px; font-family: Arial, Helvetica, sans-serif; color:#000; font-size: 14px;'><img src=\"Assets/images/Tour-concludes.png\"> " + hdNightHalt.Value + "</td></tr></table></td></tr>";
                                }
                                else if (hdNightHalt.Value.Trim() != "Night Journey" && hdNightHalt.Value.Trim() != "Tour concludes" && hdNightHalt.Value.Trim() != "")
                                {
                                    ItineraryHtml += "<tr><td height='20'>&nbsp;</td></tr>";
                                    ItineraryHtml += "<tr><td style='font-family: Arial, Helvetica, sans-serif; color:#000; font-size: 17px;'>Night Stay</td></tr>";
                                    ItineraryHtml += "<tr><td><table cellpadding='5' cellspacing='5' border='0'><tr><td style='border: solid 1px #ccc; border-radius: 5px; font-family: Arial, Helvetica, sans-serif; color:#000; font-size: 14px;'><img src=\"Assets/images/icon-nightstay.png\">" + hdNightHalt.Value + "</td></tr></table></td></tr>";
                                }
                            }

                            ItineraryHtml += "</table></td></tr>";
                            ItineraryHtml += "</table>";
                            ItineraryHtml += "</div>";
                        }
                        hdnTourItineraryHtml.Value = ItineraryHtml;
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle/log exception
                throw;
            }
        }

        #endregion

    }
}