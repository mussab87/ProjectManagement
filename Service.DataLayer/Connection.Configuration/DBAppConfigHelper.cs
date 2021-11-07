using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DataLayer.Connection.Configuration
{
   public class DBAppConfigHelper
    {
        internal static readonly string SecretKey = "RSLFEncrypti0nConnect0n@Username&K6yPasswordRSLF";
        private static readonly string PLACEHOLDER_DB_USERNAME = "###";
        private static readonly string PLACEHOLDER_DB_PASSWORD = "$$$";

        #region Get Encrypt Connection Username and Password
        public static string ConnDb(string conn, string ConnUsername, string ConnPassword)
        {
            string value = string.Empty;
            try
            {
                //var key = AppConfigKeys.Key_Conn_MYPADb;
                var v = conn;//CoreConfiguration.Instance.GetConnValue(key);
                if (string.IsNullOrWhiteSpace(v))
                    throw new Exception(string.Format("Unable to find configuration value for key '{0}'", "connection"));

                // Construct the connection string.
                var dbUsername = MYPADbUsername(ConnUsername);
                var dbPassword = MYPADbPassword(ConnPassword);

                v = v.Replace(PLACEHOLDER_DB_USERNAME, dbUsername);
                v = v.Replace(PLACEHOLDER_DB_PASSWORD, dbPassword);

                value = v;
            }
            catch (Exception ex)
            {
                throw;
            }
            
            return value;
        }

        private static string MYPADbUsername(string username)
        {            
            string value = string.Empty;
            try
            {
                //var key = AppConfigKeys.Key_MYPADbUsername;
                var v = username;//CoreConfiguration.Instance.GetConfigValue(key);
                if (string.IsNullOrWhiteSpace(v))
                    throw new Exception(string.Format("Unable to find configuration value for key '{0}'", "Username"));

                v = Crypto.DecryptStringDES(v, SecretKey);
                value = v;
            }
            catch (Exception ex)
            {
                throw;
            }            
            return value;
        }

        private static string MYPADbPassword(string password)
        {
            string value = string.Empty;
            try
            {
                //var key = AppConfigKeys.Key_MYPADbPassword;
                var v = password;//CoreConfiguration.Instance.GetConfigValue(key);
                if (string.IsNullOrWhiteSpace(v))
                    throw new Exception(string.Format("Unable to find configuration value for key '{0}'", "password"));

                v = Crypto.DecryptStringDES(v, SecretKey);
                value = v;
            }
            catch (Exception ex)
            {                
                throw;
            }            
            return value;
        }
        #endregion
    }
}
