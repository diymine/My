using System;
using System.Configuration;

namespace Study.Configuration.ByInterface
{
    public class ConnectionStringCollection : ConfigurationElementCollection
    {
        public ConnectionStringCollection()
        {

        }

        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.AddRemoveClearMap;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new ConnectionStringElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            //throw new Exception("not support");
            return ((ConnectionStringElement)element).Server;
        }

        public ConnectionStringElement this[int index]
        {
            get
            {
                return (ConnectionStringElement)BaseGet(index);
            }
            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }
                BaseAdd(index, value);
            }
        }

        new public ConnectionStringElement this[string Name]
        {
            get
            {
                return (ConnectionStringElement)BaseGet(Name);
            }
        }


        public int IndexOf(ConnectionStringElement url)
        {
            return BaseIndexOf(url);
        }

        public void Add(ConnectionStringElement url)
        {
            BaseAdd(url);

            // Your custom code goes here.

        }

        protected override void BaseAdd(ConfigurationElement element)
        {
            BaseAdd(element, false);

            // Your custom code goes here.

        }

        public void Remove(ConnectionStringElement url)
        {
            int index = BaseIndexOf(url);
            if (index >= 0)
            {
                BaseRemove(url.Server);
                // Your custom code goes here.
                Console.WriteLine("UrlsCollection: {0}", "Removed collection element!");
            }
        }

        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);

            // Your custom code goes here.

        }

        public void Remove(string name)
        {
            BaseRemove(name);

            // Your custom code goes here.

        }

        public void Clear()
        {
            BaseClear();

            // Your custom code goes here.
            //Console.WriteLine("UrlsCollection: {0}", "Removed entire collection!");
        }
    }
}
