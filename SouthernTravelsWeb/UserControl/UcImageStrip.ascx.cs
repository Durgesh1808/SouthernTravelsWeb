using SouthernTravelsWeb.BLL;
using SouthernTravelsWeb.DAL.DbObjects;
using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcImageStrip : System.Web.UI.UserControl
    {
        #region "Member Variable(s)"

        TOURTYPE pvTourType;
        int pvTourID;

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
        string pvImgIntImagesStrip = "";

        public string fldImgIntImagesStrip
        {
            get
            {
                return pvImgIntImagesStrip;
            }
            set
            {
                pvImgIntImagesStrip = value;
            }
        }
        #endregion

        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            fldImgIntImagesStrip = BindTourStrip();
            litImgIntImagesStrip.Text = fldImgIntImagesStrip;

        }
        #endregion

        #region "Method(s)"
        private string BindTourStrip()
        {
            string lImgIntImagesStrip = "";
            List<TourItenerary_SPResult> lGetResult = new List<TourItenerary_SPResult>();

            try
            {
                using (SqlConnection conn = new SqlConnection(DataLib.getConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(StoredProcedures.TourItenerary_SP, conn))
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
                            while (reader.Read())
                            {
                                TourItenerary_SPResult item = new TourItenerary_SPResult
                                {
                                    Tour_Short_key = reader["Tour_Short_key"].ToString(),
                                    TourName = reader["TourName"].ToString(),
                                    NoOfDays = Convert.ToInt32(reader["NoOfDays"]),
                                    NoOfNights = Convert.ToInt32(reader["NoOfNights"]),
                                    Fair = Convert.ToDecimal(reader["Fair"])
                                };
                                lGetResult.Add(item);
                            }
                        }
                    }
                }

                if (lGetResult.Count > 0)
                {
                    var item = lGetResult[0];

                    string lTourInfo = "<p>Tour Code : " + item.Tour_Short_key + "</p><h3>";
                    string lTourName = item.TourName;
                    string lTourDuration = item.NoOfDays + " D / " + item.NoOfNights + " N</h3>";

                    int lSeparator = 20;
                    string lFinalTourName = lTourName.Length > lSeparator
                        ? lTourName.Substring(0, (lTourName.Substring(0, lSeparator).LastIndexOf(" ") > 0
                            ? lTourName.Substring(0, lSeparator).LastIndexOf(" ")
                            : lTourName.Substring(0, lSeparator).LastIndexOf("-")))
                        : lTourName;

                    if (lTourName.Length > lSeparator)
                    {
                        lFinalTourName += "<br>" + lTourName.Replace(lFinalTourName, "");
                    }

                    lFinalTourName = System.Threading.Thread.CurrentThread
                        .CurrentCulture.TextInfo.ToTitleCase(lFinalTourName.ToLower());

                    lImgIntImagesStrip = "<div class=\"textsection\">" + lTourInfo + lFinalTourName + " " + lTourDuration;

                    System.Globalization.CultureInfo CInfo = new System.Globalization.CultureInfo("hi-IN");

                    lImgIntImagesStrip += "<p>Package Starting @ <i class=\"fa fa-rupee\"></i> " +
                            item.Fair.ToString("N", CInfo).Split('.')[0] + " /-</p></div>";
                }

                return lImgIntImagesStrip;
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }
}