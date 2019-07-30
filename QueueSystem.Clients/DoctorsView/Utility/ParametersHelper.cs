using DoctorsView.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DoctorsView.Utility
{
    public class ParametersHelper
    {
        public static void Save(AppParameters appParameters)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AppParameters));

            using (FileStream stream = new FileStream(StaticDetails.appParametersFilePath, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(stream, appParameters);
            }
        }

        public static AppParameters Read()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AppParameters));
            AppParameters appParameters = new AppParameters();
            try
            {
                using (FileStream stream = new FileStream(StaticDetails.appParametersFilePath, FileMode.Open, FileAccess.Read))
                {
                    appParameters = (AppParameters)xmlSerializer.Deserialize(stream);
                }
            }
            catch (System.IO.FileNotFoundException)
            {
                Save(new AppParameters());
            }
            return appParameters;
        }

    }
}
