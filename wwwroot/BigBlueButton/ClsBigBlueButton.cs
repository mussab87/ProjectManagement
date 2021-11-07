using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using Edu.Helpers;
using Newtonsoft.Json;

namespace bigBlueButtonadmin.bigbluebutton
{
    public class ClsBigBlueButton
    {
        // public const string filename = "https://vc-aa.com/default.pdf";
        clsLog objclsLog = new clsLog(AppDomain.CurrentDomain.BaseDirectory + "log.txt", 1000);

        #region "CreateMeeting"

        /// <summary>
        /// Creates the Meeting
        /// </summary>
        /// <param name="MeetingName">Creates the Meeting with the Specified MeetingName</param>
        /// <param name="MeetingId">Creates the Meeting with the Specified MeetingId</param>
        /// <param name="AttendeePW">Creates the Meeting with the Specified AttendeeePassword</param>
        /// <param name="moderatorPW">Creates the Meeting with the Specified ModeratorPassword</param>
        /// <returns></returns>
        ///
        ///
        private readonly GlobalData globalData = HelperMethods.GlobalData;

        public DataTable CreateMeeting(string MeetingName, string MeetingId, string AttendeePW, string moderatorPW,
            string bannerText, string bannerColor, string logo)
        {
            //XmlTextReader reader = null;
            //String filename = "C:/Users/USER/source/repos/bigBlueButtonadmin/Slide.xml";
            try
            {
                // reader = new XmlTextReader(filename);
                //reader.WhitespaceHandling = WhitespaceHandling.None;
                //XmlDocument docx = new XmlDocument();
                ////docx.Load(filename);
                //foreach (XmlNode node in docx.DocumentElement)
                //{
                //    string name = node.Attributes[0].InnerText;
                //    foreach (XmlNode child in node.ChildNodes)
                //    {
                //        Console.WriteLine(child);
                //    }
                //}

                //string xml = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Slide.xml");
                //DataSet dsvn = new DataSet("DataSet1");
                //// return obj;
                //dsvn.ReadXml(xml);

                //byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(xml);
                // XDocument doc = XDocument.Parse(sr.ReadToEnd());
                // string jsonText = JsonConvert.SerializeXNode(doc);
                string StrServerIPAddress = globalData.ServerPath;
                string StrSalt = globalData.ServerSecret;
                string StrParameters = "name=" + MeetingName + "&meetingID=" + MeetingId + "&attendeePW=" + AttendeePW +
                                       "&moderatorPW=" + moderatorPW + "&bannerText=" + bannerText + "&bannerColor=" +
                                       bannerColor + "&logo=" + logo;
                string StrSHA1_CheckSum = ClsData.getSha1("create" + StrParameters + StrSalt);
                var request = (HttpWebRequest)WebRequest.Create("https://" + StrServerIPAddress +
                                                                 "/bigbluebutton/api/create?" + StrParameters +
                                                                 "&checksum=" + StrSHA1_CheckSum);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                //string xml = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "Slide.xml");
                //var stream = request.GetRequestStream();
                //byte[] messageBytes = System.Text.Encoding.UTF8.GetBytes(xml);
                //stream.Write(messageBytes, 0, messageBytes.Length);
                //stream.Flush();

                //XDocument doc = XDocument.Parse(sr.ReadToEnd());
                //string jsonText = JsonConvert.SerializeXNode(doc);
                //dynamic obj = JsonConvert.DeserializeObject<ExpandoObject>(jsonText);
                DataSet ds = new DataSet("DataSet1");
                // return obj;
                ds.ReadXml(sr);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                objclsLog.Write(ex.Message);
                return null;
            }
        }

        #endregion

        /// <summary>
        /// This project is developed by Godwin from GloriaTech.com.
        /// Contact me support in integrating BigBlueButton with .Net or for customizing BigBlueButton in anyway.
        /// E-mail me at godwin@gloriatech.com for any support on this code or even support on BigBlueButton.
        /// </summary>

        #region "JoinMeeting"

        /// <summary>
        /// To Join in the Existing Meeting
        /// </summary>
        /// <param name="MeetingName">To Join in the ExistingMeeting with the Specified MeetingName</param>
        /// <param name="MeetingId">To Join in the ExistingMeeting with the Specified MeetingId</param>
        /// <param name="Password">To Join in the ExistingMeeting with the Specified ModeratorPW/AttendeePW</param>
        /// <param name="ShowInBrowser">If its true,will Show the Meeting UI in the Browser </param>
        /// <returns></returns>
        public string JoinMeeting(string fullName, string MeetingId, string Password, bool ShowInBrowser)
        {
            try
            {
                string StrServerIPAddress = globalData.ServerPath;
                string StrSalt = globalData.ServerSecret;
                string StrParameters = "fullName=" + fullName + "&meetingID=" + MeetingId + "&password=" + Password;
                string StrSHA1_CheckSum = ClsData.getSha1("join" + StrParameters + StrSalt);
                if (!ShowInBrowser)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://" + StrServerIPAddress +
                        "/bigbluebutton/api/join?" + StrParameters + "&checksum=" + StrSHA1_CheckSum);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    return sr.ReadToEnd();
                }
                else
                {
                    var url = "https://" + StrServerIPAddress + "/bigbluebutton/api/join?" + StrParameters +
                                  "&checksum=" + StrSHA1_CheckSum;
                    Process.Start("https://" + StrServerIPAddress + "/bigbluebutton/api/join?" + StrParameters +
                                  "&checksum=" + StrSHA1_CheckSum);
                    return url;
                }
            }
            catch (Exception ex)
            {
                objclsLog.Write(ex.Message);
                return null;
            }
        }

        #endregion

        /// <summary>
        /// This project is developed by Godwin from GloriaTech.com.
        /// Contact me support in integrating BigBlueButton with .Net or for customizing BigBlueButton in anyway.
        /// E-mail me at godwin@gloriatech.com for any support on this code or even support on BigBlueButton.
        /// </summary>

        #region "IsMeetingRunning"

        /// <summary>
        /// To find the Status of the Existing Meeting
        /// </summary>
        /// <param name="MeetingId">To find the Status of the Existing Meeting with the Specified MeetingId</param>
        /// <returns></returns>
        public DataTable IsMeetingRunning(string MeetingId)
        {
            try
            {
                string StrServerIPAddress = globalData.ServerPath;
                string StrSalt = globalData.ServerSecret;
                string StrParameters = "meetingID=" + MeetingId;
                string StrSHA1_CheckSum = ClsData.getSha1("isMeetingRunning" + StrParameters + StrSalt);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://" + StrServerIPAddress +
                                                                            "/bigbluebutton/api/isMeetingRunning?" +
                                                                            StrParameters + "&checksum=" +
                                                                            StrSHA1_CheckSum);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                DataSet ds = new DataSet("DataSet1");
                ds.ReadXml(sr);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                objclsLog.Write(ex.Message);
                return null;
            }
        }

        #endregion

        /// <summary>
        /// This project is developed by Godwin from GloriaTech.com.
        /// Contact me support in integrating BigBlueButton with .Net or for customizing BigBlueButton in anyway.
        /// E-mail me at godwin@gloriatech.com for any support on this code or even for any support on BigBlueButton.
        /// </summary>

        #region "GetMeetingInfo"

        /// <summary>
        /// To Get the relavant information about the Meeting
        /// </summary>
        /// <param name="MeetingId">To Get the relavant information about the Meeting with the Specified MeetingId</param>
        /// <param name="ModeratorPassword">To Get the relavant information about the Meeting with the Specified ModeratorPW</param>
        /// <returns></returns>
        public DataTable GetMeetingInfo(string MeetingId, string ModeratorPassword)
        {
            try
            {
                string StrServerIPAddress = globalData.ServerPath;
                string StrSalt = globalData.ServerSecret;
                string StrParameters = "meetingID=" + MeetingId + "&password=" + ModeratorPassword;
                string StrSHA1_CheckSum = ClsData.getSha1("getMeetingInfo" + StrParameters + StrSalt);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://" + StrServerIPAddress +
                                                                            "/bigbluebutton/api/getMeetingInfo?" +
                                                                            StrParameters + "&checksum=" +
                                                                            StrSHA1_CheckSum);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                DataSet ds = new DataSet("DataSet1");
                ds.ReadXml(sr);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                objclsLog.Write(ex.Message);
                return null;
            }
        }

        #endregion

        /// <summary>
        /// This project is developed by Godwin from GloriaTech.com.
        /// Contact me support in integrating BigBlueButton with .Net or for customizing BigBlueButton in anyway.
        /// E-mail me at godwin@gloriatech.com for any support on this code or even any support on BigBlueButton.
        /// </summary>

        #region "EndMeeting"

        /// <summary>
        /// To End the Meeting
        /// </summary>
        /// <param name="MeetingId">To End the Meeting with the Specified MeetingId</param>
        /// <param name="ModeratorPassword">To End the Meeting with the Specified ModeratorPW</param>
        /// <returns></returns>
        public DataTable EndMeeting(string MeetingId, string ModeratorPassword)
        {
            try
            {
                string StrServerIPAddress = globalData.ServerPath;
                string StrSalt = globalData.ServerSecret;
                string StrParameters = "meetingID=" + MeetingId + "&password=" + ModeratorPassword;
                string StrSHA1_CheckSum = ClsData.getSha1("end" + StrParameters + StrSalt);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://" + StrServerIPAddress +
                                                                            "/bigbluebutton/api/end?" + StrParameters +
                                                                            "&checksum=" + StrSHA1_CheckSum);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                DataSet ds = new DataSet("DataSet1");
                ds.ReadXml(sr);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                objclsLog.Write(ex.Message);
                return null;
            }
        }

        #endregion

        /// <summary>
        /// This project is developed by Godwin from GloriaTech.com.
        /// Contact me support in integrating BigBlueButton with .Net or for customizing BigBlueButton in anyway.
        /// E-mail me at godwin@gloriatech.com for any support on this code or even for any support on BigBlueButton.
        /// </summary>

        #region "getMeetings"

        /// <summary>
        /// To Get all the Meeting's Information running in the Server
        /// </summary>
        /// <returns></returns>
        public DataTable getMeetings()
        {
            try
            {
                string StrServerIPAddress = globalData.ServerPath;
                string StrSalt = globalData.ServerSecret;
                Random r = new Random(0);
                string StrParameters = "random=" + r.Next(100).ToString();
                string StrSHA1_CheckSum = ClsData.getSha1("getMeetings" + StrParameters + StrSalt);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://" + StrServerIPAddress +
                                                                            "/bigbluebutton/api/getMeetings?" +
                                                                            StrParameters + "&checksum=" +
                                                                            StrSHA1_CheckSum);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader sr = new StreamReader(response.GetResponseStream());
                DataSet ds = new DataSet("DataSet1");
                ds.ReadXml(sr);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                objclsLog.Write(ex.Message);
                return null;
            }
        }

        #endregion
    }
}