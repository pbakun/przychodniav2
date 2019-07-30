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

            ReadParameters();

            saveParametersCommand = new SaveParametersCommand(this);
            
        }

        public void SaveParameters()
        {
            ParametersHelper.Save(AppParameters);
        }

        public void ReadParameters()
        {
            AppParameters = ParametersHelper.Read();
        }
        
    }
}

