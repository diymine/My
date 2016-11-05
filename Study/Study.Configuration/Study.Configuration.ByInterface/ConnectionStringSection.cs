using System.Configuration;

namespace Study.Configuration.ByInterface
{
    public class ConnectionStringSection: ConfigurationSection
    {
        [ConfigurationProperty("ConnectionStringList", IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(ConnectionStringCollection),
        AddItemName = "add",
        ClearItemsName = "clear",
        RemoveItemName = "remove")]
        public ConnectionStringCollection ConnectionStringList
        {
            get
            {
                ConnectionStringCollection connectionStringCollection =
                    (ConnectionStringCollection)base["ConnectionStringList"];

                return connectionStringCollection;
            }

            set
            {
                ConnectionStringCollection connectionStringCollection = value;
            }

        }

        // Create a new instance of the UrlsSection.
        // This constructor creates a configuration element 
        // using the UrlConfigElement default values.
        // It assigns this element to the collection.
        public ConnectionStringSection()
        {
            ConnectionStringElement connectionStringElement = new ConnectionStringElement();
            ConnectionStringList.Add(connectionStringElement);
        }
    }
}
