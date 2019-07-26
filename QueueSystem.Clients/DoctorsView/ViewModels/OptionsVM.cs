using DoctorsView.Commands;
using DoctorsView.Models;
using DoctorsView.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DoctorsView.ViewModels
{
    public class OptionsVM
    {

        public AppParameters AppParameters { get; set; }

        public SaveParametersCommand saveParametersCommand { get; set; }

        public OptionsVM()
        {
            AppParameters = new AppParameters();

            RetrieveParameters();

            saveParametersCommand = new SaveParametersCommand(this);
            
        }

        public void SaveParameters()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AppParameters));

            using (FileStream stream = new FileStream(StaticDetails.appParametersFilePath, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(stream, AppParameters); 
            }
        }

        public void RetrieveParameters()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(AppParameters));

            using (FileStream stream = new FileStream(StaticDetails.appParametersFilePath, FileMode.Open, FileAccess.Read))
            {
                AppParameters = (AppParameters)xmlSerializer.Deserialize(stream);
            }
        }
        
    }
}

