using System;
using System.Configuration;

namespace Study.Configuration.ByInterface
{
    class Program
    {
        // Add an element to the custom section collection.
        // This function uses the ConfigurationCollectionElement Add method.
        static void AddCollectionElement()
        {
            try
            {

                // Get the current configuration file.
                System.Configuration.Configuration config =
                        ConfigurationManager.OpenExeConfiguration(
                        ConfigurationUserLevel.None);


                // Get the custom configuration section.
                ConnectionStringSection myUrlsSection = config.GetSection("ConnectionStringSection") as ConnectionStringSection;


                // Add the element to the collection in the custom section.
                if (config.Sections["ConnectionStringSection"] != null)
                {
                    ConnectionStringElement urlElement = new ConnectionStringElement();
                    urlElement.Server = "127.0.0.1";
                    urlElement.UserName = "test";
                    urlElement.Password = "test";

                    // Use the ConfigurationCollectionElement Add method
                    // to add the new element to the collection.
                    myUrlsSection.ConnectionStringList.Add(urlElement);


                    // Save the application configuration file.
                    myUrlsSection.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Modified);


                    Console.WriteLine("Added collection element to the custom section in the configuration file: {0}",
                        config.FilePath);
                    Console.WriteLine();
                }
                else
                    Console.WriteLine("You must create the custom section first.");

            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine("AddCollectionElement: {0}", err.ToString());
            }

        }

        static void Main(string[] args)
        {
            try
            {
                //AddCollectionElement();
                // Get the current configuration file.
                System.Configuration.Configuration config =
                        ConfigurationManager.OpenExeConfiguration(
                        ConfigurationUserLevel.None);

                ConnectionStringSection connectionStringSection = config.GetSection("ConnectionStringSection") as ConnectionStringSection;
                //var test = config.Sections["ConnectionStringSection"];
                if (connectionStringSection != null)
                {
                    for (int i = 0; i < connectionStringSection.ConnectionStringList.Count; i++)
                    {
                        Console.WriteLine("Server={0} UserName={1} Password={2}",
                            connectionStringSection.ConnectionStringList[i].Server,
                            connectionStringSection.ConnectionStringList[i].UserName,
                            connectionStringSection.ConnectionStringList[i].Password);
                    }
                }
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine(e.Message);
            }
            
            Console.ReadLine();
        }
    }
}
