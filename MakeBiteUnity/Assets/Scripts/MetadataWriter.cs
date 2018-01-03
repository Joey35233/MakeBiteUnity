using System;
using System.IO;
using System.Xml;

namespace UnityMakeBite
{
    public static class MetadataWriter
    {
        public static void WriteMetadata(string filepath, MakeBiteMod makeBiteMod)
        {
            //string fullFilepath = filepath + makeBiteMod.modFolder;

            //if (Directory.Exists(fullFilepath))
            //{
            //    Directory.CreateDirectory(fullFilepath);
            //}

            XmlWriter xmlWriter = XmlWriter.Create(filepath + "/metadata.xml");

            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("ModEntry");
            xmlWriter.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");
            xmlWriter.WriteAttributeString("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            xmlWriter.WriteAttributeString("Name", makeBiteMod.modName);
            xmlWriter.WriteAttributeString("Version", makeBiteMod.modVersion);
            xmlWriter.WriteAttributeString("Author", makeBiteMod.modAuthor);
            xmlWriter.WriteAttributeString("Website", makeBiteMod.modAuthorWebsite);

            xmlWriter.WriteStartElement("MGSVersion");
            xmlWriter.WriteAttributeString("Version", makeBiteMod.modGameVersion);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("SnakebiteVersion");
            xmlWriter.WriteAttributeString("Version", "0.9.0.3");
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Description");
            xmlWriter.WriteString(makeBiteMod.modDescription);
            xmlWriter.WriteEndElement();

            //Temp variables
            const int qarCount = 0;
            const int fpkCount = 0;
            const int fileCount = 0;

            xmlWriter.WriteStartElement("QarEntries");
            for (int i = 0; i < qarCount; i++)
            {
                xmlWriter.WriteString("QarEntry");
            }
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("FpkEntries");
            for (int i = 0; i < fpkCount; i++)
            {
                xmlWriter.WriteString("FpkEntry");
            }
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("FileEntries");
            for (int i = 0; i < fileCount; i++)
            {
                xmlWriter.WriteString("FileEntry");
            }
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndDocument();   
            xmlWriter.Close();
        }
    }
}
