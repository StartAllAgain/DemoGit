using System;
using System.Collections.Specialized;
using System.Configuration;

namespace System
{
    /// <summary>
    /// Global
    /// </summary>
    public static class Global
    {
        /// <summary>
        /// CurrentDomain
        /// </summary>
        public static AppDomain Domain
        {
            get { return AppDomain.CurrentDomain; }
        }

        /// <summary>
        /// AppDomain BaseDirectory
        /// </summary>
        public static string BaseDirectory
        {
            get
            {
                return Domain.BaseDirectory;
            }
        }

        /// <summary>
        /// AppSettings
        /// </summary>
        public static NameValueCollection AppSettings
        {
            get
            {
                return ConfigurationManager.AppSettings;
            }
        }

        /// <summary>
        /// ConnectionStrings
        /// </summary>
        public static ConnectionStringSettingsCollection ConnectionStrings
        {
            get { return ConfigurationManager.ConnectionStrings; }
        }
    }
}