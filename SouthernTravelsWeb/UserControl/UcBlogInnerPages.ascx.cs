using SouthernTravelsWeb.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;
using System.Xml;

namespace SouthernTravelsWeb.UserControl
{
    public partial class UcBlogInnerPages : System.Web.UI.UserControl
    {
        #region "Member Variable(s)"
        int pvTotalBlogToShow;
        #endregion
        #region "Property(s)"
        public int fldBlogCount
        {
            get
            {
                return pvTotalBlogToShow;
            }
            set
            {
                pvTotalBlogToShow = value;
            }
        }



        #endregion
        #region "Event(s)"
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReadAndBindBlog();
            }
        }

        protected void dgShowItinerary_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            
        }
        #endregion
        #region "Method(s)"

        private void ReadAndBindBlog()
        {
            string Blogurl = "http://blog.southerntravelsindia.com.php53-9.ord1-1.websitetestlink.com/rss2";
            ClsBlog objBlog;
            ClsBlogCategory objBlogCategory = new ClsBlogCategory();
            List<ClsBlog> lstbloglist = new List<ClsBlog>();
            XmlDocument ContDoc = new XmlDocument();
            try
            {
                WebRequest request = WebRequest.Create(Blogurl);
                WebResponse response = request.GetResponse();
                Stream rssStream = response.GetResponseStream();
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(rssStream);
                XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName("item");
                string lStr = "";
                for (int i = 0; i < xmlNodeList.Count; i++)
                {

                    XmlNode xmlNode;
                    objBlog = new ClsBlog();

                    xmlNode = xmlNodeList.Item(i).SelectSingleNode("title");
                    objBlog.BlogTitle = xmlNode.InnerText;
                    string pBlogTitle = xmlNode.InnerText;
                    xmlNode = xmlNodeList.Item(i).SelectSingleNode("link");
                    objBlog.BlogUrl = xmlNode.InnerText;
                    string pBlogUrl = xmlNode.InnerText;

                    xmlNode = xmlNodeList.Item(i).SelectSingleNode("description"); // to read the small description
                    objBlog.SmallDescription = xmlNode.InnerText.Substring(0, xmlNode.InnerText.IndexOf("<p>The post"));

                    for (int J = 0; J < xmlNodeList.Item(i).ChildNodes.Count; J++)
                    {
                        if (xmlNodeList.Item(i).ChildNodes[J].Name == "content:encoded")
                        {
                            objBlog.LongDescription = xmlNodeList.Item(i).ChildNodes[J].InnerText;
                        }

                    }
                    //------Getting the First Image -------
                    string lImgSRC = objBlog.LongDescription;
                    if (lImgSRC.IndexOf("<img") > 0)
                    {
                        lImgSRC = lImgSRC.Substring(lImgSRC.IndexOf("<img"));
                        lImgSRC = lImgSRC.Substring(lImgSRC.IndexOf("src=\"") + 5);
                        lImgSRC = lImgSRC.Substring(0, lImgSRC.IndexOf("\""));
                    }
                    else
                    {
                        lImgSRC = "images/blog3.jpg";
                    }
                    objBlog.ImageUrl = lImgSRC;
                    //------End of getting the first Image---

                    lStr = lStr + "<div class=\"item\"> " +
                   "<img src=" + lImgSRC + " alt=\"Touch\" width=370 height=240>" +
                     "<div class=\"blog-content\">" +
                       "<h3>" + pBlogTitle + "</h3>" +
                       "<div class=\"clearfix\"></div>" +
                       "<p><a class=\"readmore\" href=" + pBlogUrl + ">Read more &nbsp;<i class=\"fa fa-long-arrow-right\"></i></a> </p>" +
                       "</div></div>";

                    lstbloglist.Add(objBlog);
                    if (i == fldBlogCount - 1)
                    {
                        break;
                    }
                }
                ltrBlog.Text = lStr;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (lstbloglist != null)
                {
                    lstbloglist = null;
                }
            }
        }
        public int ConvertStringToInt(string IntString)
        {
            Int32 decval = 0;
            if (string.IsNullOrEmpty(IntString))
            {
                decval = 0;
            }
            else
            {
                try
                {
                    decval = Convert.ToInt32(IntString);
                }
                catch (Exception ex)
                {
                    decval = 0;
                }

            }
            return decval;
        }


        //class Post
        //{
        //    public string Title { get; private set; }
        //    public DateTime? Date { get; private set; }
        //    public string Url { get; private set; }
        //    public string Description { get; private set; }
        //    public string Creator { get; private set; }
        //    public string Content { get; private set; }

        //    private static string GetElementValue(XContainer element, string name)
        //    {
        //        if ((element == null) || (element.Element(name) == null))
        //            return String.Empty;
        //        return element.Element(name).Value;
        //    }

        //    public Post(XContainer post)
        //    {
        //        // Get the string properties from the post's element values
        //        Title = GetElementValue(post, "title");
        //        Url = GetElementValue(post, "guid");
        //        Description = GetElementValue(post, "description");
        //        Creator = GetElementValue(post,
        //            "{http://purl.org/dc/elements/1.1/}creator");
        //        Content = GetElementValue(post,
        //           "{http://purl.org/rss/1.0/modules/content/}encoded");

        //        // The Date property is a nullable DateTime? -- if the pubDate element
        //        // can't be parsed into a valid date, the Date property is set to null
        //        DateTime result;
        //        if (DateTime.TryParse(GetElementValue(post, "pubDate"), out result))
        //            Date = (DateTime?)result;
        //    }

        //    public override string ToString()
        //    {
        //        return String.Format("{0} by {1}", Title ?? "no title", Creator ?? "Unknown");
        //    }
        //}

    }

    #endregion
}