using System.Configuration;

namespace Study.Configuration.ByInterface
{
    public class ConnectionStringElement : ConfigurationElement
    {
        public ConnectionStringElement(string server, string userName, string password)
        {
            this.Server = server;
            this.UserName = userName;
            this.Password = password;
        }

        public ConnectionStringElement()
        {

        }

        [ConfigurationProperty("server", DefaultValue = "localhost", IsRequired = true,IsKey =true)]
        public string Server
        {
            get
            {
                return (string)this["server"];
            }
            set
            {
                this["server"] = value;
            }
        }

        [ConfigurationProperty("userName", DefaultValue = "",
            IsRequired = false)]
        public string UserName
        {
            get
            {
                return (string)this["userName"];
            }
            set
            {
                this["userName"] = value;
            }
        }

        [ConfigurationProperty("password", DefaultValue = "", IsRequired = false)]
        public string Password
        {
            get
            {
                return (string)this["password"];
            }
            set
            {
                this["password"] = value;
            }
        }

    }
}
