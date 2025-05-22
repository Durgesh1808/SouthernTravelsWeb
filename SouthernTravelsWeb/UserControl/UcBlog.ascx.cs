using SouthernTravelsWeb.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using SouthernTravelsWeb.DTO;
namespace SouthernTravelsWeb.UserControl
{
    public partial class UcBlog : System.Web.UI.UserControl
    {
        #region "Member Variable(s)"
        int pvTotalBlogToShow;
        protected string connectionString;

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
            connectionString = ConfigurationManager.AppSettings["southernconn"];

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
            string Blogurl = "https://blog.southerntravelsindia.com/rss2";
            ClsBlog objBlog;
            List<ClsBlog> lstbloglist = new List<ClsBlog>();
            XmlDocument xmlDoc = new XmlDocument();
            int missingImageCounter = 0;

            try
            {
                WebRequest request = WebRequest.Create(Blogurl);
                WebResponse response = request.GetResponse();
                Stream rssStream = response.GetResponseStream();

                xmlDoc.Load(rssStream);
                XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName("item");

                for (int i = 0; i < xmlNodeList.Count; i++)
                {
                    XmlNode xmlNode;
                    objBlog = new ClsBlog();

                    xmlNode = xmlNodeList.Item(i).SelectSingleNode("title");
                    objBlog.BlogTitle = xmlNode != null ? xmlNode.InnerText : "";

                    xmlNode = xmlNodeList.Item(i).SelectSingleNode("link");
                    objBlog.BlogUrl = xmlNode != null ? xmlNode.InnerText : "";

                    xmlNode = xmlNodeList.Item(i).SelectSingleNode("description");
                    if (xmlNode != null && xmlNode.InnerText.Contains("<p>The post"))
                    {
                        objBlog.SmallDescription = xmlNode.InnerText.Substring(0, xmlNode.InnerText.IndexOf("<p>The post"));
                    }
                    else
                    {
                        objBlog.SmallDescription = xmlNode != null ? xmlNode.InnerText : "";
                    }

                    // Read long description from content:encoded
                    objBlog.LongDescription = "";
                    for (int j = 0; j < xmlNodeList.Item(i).ChildNodes.Count; j++)
                    {
                        if (xmlNodeList.Item(i).ChildNodes[j].Name == "content:encoded")
                        {
                            objBlog.LongDescription = xmlNodeList.Item(i).ChildNodes[j].InnerText;
                            break;
                        }
                    }

                    // Extract image from long description
                    string lImgSRC = objBlog.LongDescription;
                    if (lImgSRC.IndexOf("<img") > 0)
                    {
                        lImgSRC = lImgSRC.Substring(lImgSRC.IndexOf("<img"));
                        lImgSRC = lImgSRC.Substring(lImgSRC.IndexOf("src=\"") + 5);
                        lImgSRC = lImgSRC.Substring(0, lImgSRC.IndexOf("\""));
                    }
                    else
                    {
                        switch (missingImageCounter)
                        {
                            case 0:
                                lImgSRC = "Assets/images/blog3.jpg";
                                break;
                            case 1:
                                lImgSRC = "Assets/images/blog2.jpg";
                                break;
                            default:
                                lImgSRC = "Assets/images/blog1.jpg";
                                break;
                        }
                        missingImageCounter++;
                    }
                    objBlog.ImageUrl = lImgSRC;

                    lstbloglist.Add(objBlog);

                    // Limit blogs shown
                    if (i == fldBlogCount - 1)
                    {
                        break;
                    }
                }

                repBlog.DataSource = lstbloglist;
                repBlog.DataBind();
            }
            catch (Exception ex)
            {
                // Optional: Log ex.Message
            }
            finally
            {
                if (lstbloglist != null)
                {
                    lstbloglist = null;
                }
            }
        }


        public void SaveBlogToDb(ClsBlog blog)
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();

                try
                {
                    // Insert into Blogs table
                    string insertBlogQuery = @"INSERT INTO Blogs (BlogTitle, BlogUrl, SmallDescription, LongDescription, ImageUrl)
                                       VALUES (@BlogTitle, @BlogUrl, @SmallDescription, @LongDescription, @ImageUrl);
                                       SELECT SCOPE_IDENTITY();";
                    int blogId;
                    using (SqlCommand cmd = new SqlCommand(insertBlogQuery, conn, trans))
                    {
                        cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
                        cmd.Parameters.AddWithValue("@BlogUrl", blog.BlogUrl);
                        cmd.Parameters.AddWithValue("@SmallDescription", blog.SmallDescription);
                        cmd.Parameters.AddWithValue("@LongDescription", blog.LongDescription);
                        cmd.Parameters.AddWithValue("@ImageUrl", blog.ImageUrl);

                        blogId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // Insert each category
                    foreach (var category in blog.CategoryList)
                    {
                        string insertCatQuery = @"INSERT INTO BlogCategories (BlogId, CategoryName) VALUES (@BlogId, @CategoryName)";
                        using (SqlCommand cmd = new SqlCommand(insertCatQuery, conn, trans))
                        {
                            cmd.Parameters.AddWithValue("@BlogId", blogId);
                            cmd.Parameters.AddWithValue("@CategoryName", category.CategoryName);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    trans.Commit();
                }
                catch
                {
                    trans.Rollback();
                    throw; // Re-throw the error
                }
            }
        }


        public List<ClsBlog> GetBlogsWithCategories()
        {
            List<ClsBlog> blogs = new List<ClsBlog>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string blogQuery = @"SELECT * FROM Blogs";
                using (SqlCommand cmd = new SqlCommand(blogQuery, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ClsBlog blog = new ClsBlog
                        {
                            BlogTitle = reader["BlogTitle"].ToString(),
                            BlogUrl = reader["BlogUrl"].ToString(),
                            SmallDescription = reader["SmallDescription"].ToString(),
                            LongDescription = reader["LongDescription"].ToString(),
                            ImageUrl = reader["ImageUrl"].ToString()
                        };

                        blogs.Add(blog);
                    }
                }

                // Fetch categories for each blog
                foreach (var blog in blogs)
                {
                    string categoryQuery = @"SELECT CategoryName FROM BlogCategories 
                                     INNER JOIN Blogs ON BlogCategories.BlogId = Blogs.BlogId
                                     WHERE Blogs.BlogTitle = @BlogTitle";

                    using (SqlCommand cmd = new SqlCommand(categoryQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@BlogTitle", blog.BlogTitle);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                blog.CategoryList.Add(new ClsBlogCategory
                                {
                                    CategoryName = reader["CategoryName"].ToString()
                                });
                            }
                        }
                    }
                }
            }

            return blogs;
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


        class Post
        {
            public string Title { get; private set; }
            public DateTime? Date { get; private set; }
            public string Url { get; private set; }
            public string Description { get; private set; }
            public string Creator { get; private set; }
            public string Content { get; private set; }

            private static string GetElementValue(XContainer element, string name)
            {
                if ((element == null) || (element.Element(name) == null))
                    return String.Empty;
                return element.Element(name).Value;
            }

            public Post(XContainer post)
            {
                // Get the string properties from the post's element values
                Title = GetElementValue(post, "title");
                Url = GetElementValue(post, "guid");
                Description = GetElementValue(post, "description");
                Creator = GetElementValue(post,
                    "{http://purl.org/dc/elements/1.1/}creator");
                Content = GetElementValue(post,
                   "{http://purl.org/rss/1.0/modules/content/}encoded");

                // The Date property is a nullable DateTime? -- if the pubDate element
                // can't be parsed into a valid date, the Date property is set to null
                DateTime result;
                if (DateTime.TryParse(GetElementValue(post, "pubDate"), out result))
                    Date = (DateTime?)result;
            }

            public override string ToString()
            {
                return String.Format("{0} by {1}", Title ?? "no title", Creator ?? "Unknown");
            }
        }

    }

    #endregion
}