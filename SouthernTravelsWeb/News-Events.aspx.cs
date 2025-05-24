using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SouthernTravelsWeb
{
    public partial class News_Events : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowNews_Events();
            ShowNews_Events_New();
        }
        private void ShowNews_Events_New()
        {

            List<Event_Info_New> lNewBranch_New = new List<Event_Info_New>();
            List<Event_Info_New> lCurrentEvents_New = new List<Event_Info_New>(), lAwardCeremony = new List<Event_Info_New>();
            Event_Info_New lEvent_AwardCeremony = null;

            #region PressCoverage
            List<Event_Info_New> lPressCoverage = new List<Event_Info_New>();
            Event_Info_New lEvent_PressCoverage = null;

            lEvent_PressCoverage = new Event_Info_New(116, "VAARTHA.jpg", "VAARTHA.jpg",
              "VAARTHA_19-04-15", "2015", "NewsAndMedia", "", 1);
            lPressCoverage.Add(lEvent_PressCoverage);

            lEvent_PressCoverage = new Event_Info_New(116, "Southern_Travels_New_Branch_In_Warangal_Eenadu_Warangal_District_Edition_Page_No_16.jpg",
               "Southern_Travels_New_Branch_In_Warangal_Eenadu_Warangal_District_Edition_Page_No_16.jpg",
               "Eenadu Warangal District Edition", "2014", "NewsAndMedia", "", 1);
            lPressCoverage.Add(lEvent_PressCoverage);

            lEvent_PressCoverage = new Event_Info_New(1116, "Southern_Travels_New_Branch_In_Warangal_Sakshi_Warangal_District_Edition_Page_No_2.jpg",
                "Southern_Travels_New_Branch_In_Warangal_Sakshi_Warangal_District_Edition_Page_No_2.jpg",
                "Sakshi Warangal District Edition", "2014", "NewsAndMedia", "", 1);
            lPressCoverage.Add(lEvent_PressCoverage);

            lEvent_PressCoverage = new Event_Info_New(1, "Dakshin_Bharat_Rashtramat_HINDI_DAILY.jpg", "Dakshin_Bharat_Rashtramat_HINDI_DAILY.jpg",
                "Dakshin Bharat Rashtramat Hindi Daily",
                 "2015 / 2014", "PressCoverage", "", 1);
            lPressCoverage.Add(lEvent_PressCoverage);

            lEvent_PressCoverage = new Event_Info_New(2, "The_Hans_India.jpg", "The_Hans_India.jpg", "The Hans India",
                 "2015 / 2014", "PressCoverage", "", 1);
            lPressCoverage.Add(lEvent_PressCoverage);

            lEvent_PressCoverage = new Event_Info_New(3, "Metro_India.jpg", "Metro_India.jpg", "Metro India",
                 "2015 / 2014", "PressCoverage", "", 1);
            lPressCoverage.Add(lEvent_PressCoverage);

            lEvent_PressCoverage = new Event_Info_New(4, "Ethemaad.jpg", "Ethemaad.jpg", "Ethemaad",
                 "2015 / 2014", "PressCoverage", "", 1);
            lPressCoverage.Add(lEvent_PressCoverage);

            lEvent_PressCoverage = new Event_Info_New(5, "Siasat.jpg", "Siasat.jpg", "Siasat",
                 "2015 / 2014", "PressCoverage", "", 1);
            lPressCoverage.Add(lEvent_PressCoverage);

            lEvent_PressCoverage = new Event_Info_New(6, "Andhrajyothi.jpg", "Andhrajyothi.jpg", "Andhra Jyothi",
                 "2015 / 2014", "PressCoverage", "", 1);
            lPressCoverage.Add(lEvent_PressCoverage);

            lEvent_PressCoverage = new Event_Info_New(7, "The_New_Indian_Express_Hyderabad_DigitalEdition.jpg",
                "The_New_Indian_Express_Hyderabad_DigitalEdition.jpg",
                "The New Indian Express Hyderabad Digital Edition",
                 "2015 / 2014", "PressCoverage", "", 1);
            lPressCoverage.Add(lEvent_PressCoverage);

            lEvent_PressCoverage = new Event_Info_New(8, "Prajashakti.jpg", "Prajashakti.jpg", "Prajashakti",
                 "2015 / 2014", "PressCoverage", "", 1);
            lPressCoverage.Add(lEvent_PressCoverage);

            lEvent_PressCoverage = new Event_Info_New(9, "Surya.jpg", "Surya.jpg", "Surya",
                 "2015 / 2014", "PressCoverage", "", 1);
            lPressCoverage.Add(lEvent_PressCoverage);

            lEvent_PressCoverage = new Event_Info_New(10, "Andhra_Prabha.jpg", "Andhra_Prabha.jpg", "Andhra Prabha",
                 "2015 / 2014", "PressCoverage", "", 1);
            lPressCoverage.Add(lEvent_PressCoverage);

            ddlPressCoverage.DataSource = lPressCoverage;
            ddlPressCoverage.DataBind();
            #endregion

            #region AwardCeremony

            lEvent_AwardCeremony = new Event_Info_New(1, "Hans-India_19_Sep.jpg", "Hans-India_19_Sep.jpg",
                "Hans India", "2015 / 2014", "AwardCeremony", "", 1);
            lAwardCeremony.Add(lEvent_AwardCeremony);

            lEvent_AwardCeremony = new Event_Info_New(2, "Indian-Express_19_Sep.jpg", "Indian-Express_19_Sep.jpg", "Indian Express",
                 "2015 / 2014", "AwardCeremony", "", 1);
            lAwardCeremony.Add(lEvent_AwardCeremony);

            lEvent_AwardCeremony = new Event_Info_New(3, "The-Hindu_19_Sep.jpg", "The-Hindu_19_Sep.jpg", "The Hindu",
                 "2015 / 2014", "AwardCeremony", "", 1);
            lAwardCeremony.Add(lEvent_AwardCeremony);

            lEvent_AwardCeremony = new Event_Info_New(4, "Sakshi Tab_2nd Page_19_Sep.jpg", "Sakshi Tab_2nd Page_19_Sep.jpg", "Sakshi Tab",
                 "2015 / 2014", "AwardCeremony", "", 1);
            lAwardCeremony.Add(lEvent_AwardCeremony);

            lEvent_AwardCeremony = new Event_Info_New(5, "Sakshi_19_Sep.jpg", "Sakshi_19_Sep.jpg", "Sakshi",
                 "2015 / 2014", "AwardCeremony", "", 1);
            lAwardCeremony.Add(lEvent_AwardCeremony);

            lEvent_AwardCeremony = new Event_Info_New(6, "Namasthe Telangana_19_Sep.jpg", "Namasthe Telangana_19_Sep.jpg", "Namasthe Telangana",
                 "2015 / 2014", "AwardCeremony", "", 1);
            lAwardCeremony.Add(lEvent_AwardCeremony);

            lEvent_AwardCeremony = new Event_Info_New(6, "Namasthe Telangana_19_Sep.jpg", "Namasthe Telangana_19_Sep.jpg", "Namasthe Telangana",
                 "2015 / 2014", "AwardCeremony", "https://www.youtube.com/embed/ax5muD-6Opw", 0);
            lAwardCeremony.Add(lEvent_AwardCeremony);

            lEvent_AwardCeremony = new Event_Info_New(7, "Dakshin_Bharat_Rashtramat_HINDI_DAILY.jpg", "Dakshin_Bharat_Rashtramat_HINDI_DAILY.jpg",
                "Dakshin Bharat Rashtramat Hindi Daily",
                 "2015 / 2014", "AwardCeremony", "", 1);
            lAwardCeremony.Add(lEvent_AwardCeremony);

            lEvent_AwardCeremony = new Event_Info_New(8, "The_Hans_India.jpg", "The_Hans_India.jpg", "The Hans India",
                 "2015 / 2014", "AwardCeremony", "", 1);
            lAwardCeremony.Add(lEvent_AwardCeremony);

            lEvent_AwardCeremony = new Event_Info_New(9, "Metro_India.jpg", "Metro_India.jpg", "Metro India",
                 "2015 / 2014", "AwardCeremony", "", 1);
            lAwardCeremony.Add(lEvent_AwardCeremony);

            lEvent_AwardCeremony = new Event_Info_New(10, "Ethemaad.jpg", "Ethemaad.jpg", "Ethemaad",
                 "2015 / 2014", "AwardCeremony", "", 1);
            lAwardCeremony.Add(lEvent_AwardCeremony);

            lEvent_AwardCeremony = new Event_Info_New(11, "Siasat.jpg", "Siasat.jpg", "Siasat",
                 "2015 / 2014", "AwardCeremony", "", 1);
            lAwardCeremony.Add(lEvent_AwardCeremony);

            lEvent_AwardCeremony = new Event_Info_New(12, "Andhrajyothi.jpg", "Andhrajyothi.jpg", "Andhra Jyothi",
                 "2015 / 2014", "AwardCeremony", "", 1);
            lAwardCeremony.Add(lEvent_AwardCeremony);

            lEvent_AwardCeremony = new Event_Info_New(13, "The_New_Indian_Express_Hyderabad_DigitalEdition.jpg",
                "The_New_Indian_Express_Hyderabad_DigitalEdition.jpg",
                "The New Indian Express Hyderabad Digital Edition",
                 "2015 / 2014", "AwardCeremony", "", 1);
            lAwardCeremony.Add(lEvent_AwardCeremony);

            lEvent_AwardCeremony = new Event_Info_New(14, "Prajashakti.jpg", "Prajashakti.jpg", "Prajashakti",
                 "2015 / 2014", "AwardCeremony", "", 1);
            lAwardCeremony.Add(lEvent_AwardCeremony);

            lEvent_AwardCeremony = new Event_Info_New(15, "Surya.jpg", "Surya.jpg", "Surya",
                 "2015 / 2014", "AwardCeremony", "", 1);
            lAwardCeremony.Add(lEvent_AwardCeremony);

            lEvent_AwardCeremony = new Event_Info_New(16, "Andhra_Prabha.jpg", "Andhra_Prabha.jpg", "Andhra Prabha",
                 "2015 / 2014", "AwardCeremony", "", 1);
            lAwardCeremony.Add(lEvent_AwardCeremony);

            ddlAwardCeremony.DataSource = lAwardCeremony;
            ddlAwardCeremony.DataBind();





            #endregion

            #region Inauguration

            List<Event_Info_New> lInauguration = new List<Event_Info_New>();
            Event_Info_New lEvent_Inauguration = null;

            lEvent_Inauguration = new Event_Info_New(1, "DAINIK-BHASKAR.jpg", "DAINIK-BHASKAR.jpg", "Zone by the Park- Jaipur",
                 "2015", "Inauguration", "https://www.youtube.com/embed/6HaN5qZDfzk", 0);
            lInauguration.Add(lEvent_Inauguration);

            lEvent_Inauguration = new Event_Info_New(2, "DAINIK-BHASKAR.jpg", "DAINIK-BHASKAR.jpg", "Zone by the Park- Jaipur",
                "2015", "Inauguration", "https://www.youtube.com/embed/kEF_xhMJ4yY", 0);
            lInauguration.Add(lEvent_Inauguration);

            lEvent_Inauguration = new Event_Info_New(3, "DAINIK-BHASKAR.jpg", "DAINIK-BHASKAR.jpg", "Zone by the Park- Jaipur",
                "2015", "Inauguration", "https://www.youtube.com/embed/J0Cf-iSxhPc", 0);
            lInauguration.Add(lEvent_Inauguration);

            lEvent_Inauguration = new Event_Info_New(4, "DAINIK-BHASKAR.jpg", "DAINIK-BHASKAR.jpg", "Zone by the Park- Jaipur",
                 "2015", "Inauguration", "https://www.youtube.com/embed/pxwYGLXAuoA", 0);
            lInauguration.Add(lEvent_Inauguration);

            lEvent_Inauguration = new Event_Info_New(5, "DAINIK-BHASKAR.jpg", "DAINIK-BHASKAR.jpg", "Zone by the Park- Jaipur",
                "2015", "Inauguration", "https://www.youtube.com/embed/3MXaPLLZ6a8", 0);
            lInauguration.Add(lEvent_Inauguration);

            lEvent_Inauguration = new Event_Info_New(6, "DAINIK-BHASKAR.jpg", "DAINIK-BHASKAR.jpg", "Zone by the Park- Jaipur",
                "2015", "Inauguration", "https://www.youtube.com/embed/YlgrmQ7c3zA", 0);
            lInauguration.Add(lEvent_Inauguration);

            lEvent_Inauguration = new Event_Info_New(7, "DAINIK-BHASKAR.jpg", "DAINIK-BHASKAR.jpg",
               "DAINIK BHASKAR_19-04-15", "2015", "Inauguration", "", 1);
            lInauguration.Add(lEvent_Inauguration);

            lEvent_Inauguration = new Event_Info_New(8, "EENADU.jpg", "EENADU.jpg",
               "EENADU_19-04-15", "2015", "Inauguration", "", 1);
            lInauguration.Add(lEvent_Inauguration);

            lEvent_Inauguration = new Event_Info_New(9, "VAARTHA.jpg", "VAARTHA.jpg",
               "VAARTHA_19-04-15", "2015", "Inauguration", "", 1);
            lInauguration.Add(lEvent_Inauguration);

            dlInauguration.DataSource = lInauguration;
            dlInauguration.DataBind();

            #endregion

            #region NewsAndMedia
            List<Event_Info_New> lNewsAndMedia = new List<Event_Info_New>();
            Event_Info_New lEvent_NewsAndMedia = null;



            lEvent_NewsAndMedia = new Event_Info_New(1, "news01.jpg", "news01.jpg", "", "2014", "NewsAndMedia", "", 1);
            lNewsAndMedia.Add(lEvent_NewsAndMedia);

            lEvent_NewsAndMedia = new Event_Info_New(2, "news02.jpg", "news02.jpg", "", "2014", "NewsAndMedia", "", 1);
            lNewsAndMedia.Add(lEvent_NewsAndMedia);

            lEvent_NewsAndMedia = new Event_Info_New(3, "news03.jpg", "news03.jpg", "", "2014", "NewsAndMedia", "", 1);
            lNewsAndMedia.Add(lEvent_NewsAndMedia);

            lEvent_NewsAndMedia = new Event_Info_New(4, "news04.jpg", "news04.jpg", "", "2014", "NewsAndMedia", "", 1);
            lNewsAndMedia.Add(lEvent_NewsAndMedia);

            lEvent_NewsAndMedia = new Event_Info_New(5, "news05.jpg", "news05.jpg", "", "2014", "NewsAndMedia", "", 1);
            lNewsAndMedia.Add(lEvent_NewsAndMedia);

            lEvent_NewsAndMedia = new Event_Info_New(6, "news06.jpg", "news06.jpg", "", "2014", "NewsAndMedia", "", 1);
            lNewsAndMedia.Add(lEvent_NewsAndMedia);

            lEvent_NewsAndMedia = new Event_Info_New(7, "news07.jpg", "news07.jpg", "", "2014", "NewsAndMedia", "", 1);
            lNewsAndMedia.Add(lEvent_NewsAndMedia);

            lEvent_NewsAndMedia = new Event_Info_New(8, "news08.jpg", "news08.jpg", "", "2014", "NewsAndMedia", "", 1);
            lNewsAndMedia.Add(lEvent_NewsAndMedia);

            lEvent_NewsAndMedia = new Event_Info_New(9, "news09.jpg", "news09.jpg", "", "2014", "NewsAndMedia", "", 1);
            lNewsAndMedia.Add(lEvent_NewsAndMedia);

            lEvent_Inauguration = new Event_Info_New(10, "news10.jpg", "news10.jpg", "", "2014", "NewsAndMedia", "", 1);
            lNewsAndMedia.Add(lEvent_NewsAndMedia);

            lEvent_NewsAndMedia = new Event_Info_New(11, "news11.jpg", "news11.jpg", "", "2014", "NewsAndMedia", "", 1);
            lNewsAndMedia.Add(lEvent_NewsAndMedia);

            lEvent_NewsAndMedia = new Event_Info_New(12, "news12.jpg", "news12.jpg", "", "2014", "NewsAndMedia", "", 1);
            lNewsAndMedia.Add(lEvent_NewsAndMedia);

            lEvent_NewsAndMedia = new Event_Info_New(13, "news13.jpg", "news13.jpg", "", "2014", "NewsAndMedia", "", 1);
            lNewsAndMedia.Add(lEvent_NewsAndMedia);

            lEvent_NewsAndMedia = new Event_Info_New(14, "news14.jpg", "news14.jpg", "", "2014", "NewsAndMedia", "", 1);
            lNewsAndMedia.Add(lEvent_NewsAndMedia);



            ddlNewsAndMedia.DataSource = lNewsAndMedia;
            ddlNewsAndMedia.DataBind();

            #endregion


        }
        private void ShowNews_Events()
        {
            
        }
    }

    public class Event_Info
    {
        #region "Member Variable(s)"
        private int _EventID;
        private string _EventImgThumbPath, _EventImgPath, _EventDesc;
        #endregion
        #region "Property(s)"
        public int EventID
        {
            get
            {
                return _EventID;
            }
            set
            {
                _EventID = value;
            }
        }

        public string EventImgThumbPath
        {
            get
            {
                return _EventImgThumbPath;
            }
            set
            {
                _EventImgThumbPath = value;
            }
        }

        public string EventImgPath
        {
            get
            {
                return _EventImgPath;
            }
            set
            {
                _EventImgPath = value;
            }
        }

        public string EventDesc
        {
            get
            {
                return _EventDesc;
            }
            set
            {
                _EventDesc = value;
            }
        }

        #endregion
        #region "Constructor"
        public Event_Info()
        {
        }
        public Event_Info(int pEventID, string pThumbPath, string pImgPath, string pDesc)
        {
            EventID = pEventID;
            EventImgThumbPath = pThumbPath;
            EventImgPath = pImgPath;
            EventDesc = pDesc;
        }
        #endregion
    }
    public class Event_Info_New
    {
        #region "Member Variable(s)"
        private int _EventID;
        private string _EventImgThumbPath, _EventImgPath, _EventDesc, _EventYear, _EventType, _EventVideo; int _IsImg = 1;
        #endregion
        #region "Property(s)"
        public int EventID
        {
            get
            {
                return _EventID;
            }
            set
            {
                _EventID = value;
            }
        }

        public string EventImgThumbPath
        {
            get
            {
                return _EventImgThumbPath;
            }
            set
            {
                _EventImgThumbPath = value;
            }
        }

        public string EventImgPath
        {
            get
            {
                return _EventImgPath;
            }
            set
            {
                _EventImgPath = value;
            }
        }

        public string EventDesc
        {
            get
            {
                return _EventDesc;
            }
            set
            {
                _EventDesc = value;
            }
        }
        public string EventYear
        {
            get
            {
                return _EventYear;
            }
            set
            {
                _EventYear = value;
            }
        }
        public string EventType
        {
            get
            {
                return _EventType;
            }
            set
            {
                _EventType = value;
            }
        }
        public string EventVideo
        {
            get
            {
                return _EventVideo;
            }
            set
            {
                _EventVideo = value;
            }
        }
        public int IsImg
        {
            get
            {
                return _IsImg;
            }
            set
            {
                _IsImg = value;
            }
        }
        #endregion
        #region "Constructor"
        public Event_Info_New()
        {
        }
        public Event_Info_New(int pEventID, string pThumbPath, string pImgPath, string pDesc, string pEventYear, string pEventType, string pEventVideo, int pIsImg)
        {
            EventID = pEventID;
            EventImgThumbPath = pThumbPath;
            EventImgPath = pImgPath;
            EventDesc = pDesc;
            EventYear = pEventYear;
            EventType = pEventType;
            EventVideo = pEventVideo;
            IsImg = pIsImg;
        }
        #endregion
    }
}