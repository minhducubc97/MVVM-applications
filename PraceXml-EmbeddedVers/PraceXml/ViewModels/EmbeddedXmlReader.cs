using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PraceXml.ViewModels
{
    public class EmbeddedXmlReader
    {
        public string GetEmbeddedResourcesFile(string fileNameWithExtension)
        {
            string result = "";
            using (Stream stream = this.GetType().Assembly.GetManifestResourceStream("PraceXml.Xml." + fileNameWithExtension))  // NOTE: need to set the file's Build Action to be EmbeddedResources
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    result = reader.ReadToEnd();
                }
            }
            return result;
        }
    }
}
