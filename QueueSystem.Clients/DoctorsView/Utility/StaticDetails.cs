using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorsView.Utility
{
    public class StaticDetails
    {
        public const string userDatabase = "userData.db";
        public static readonly string userDatabasePath = Path.Combine(Environment.CurrentDirectory, "Data", userDatabase);
    }
}
