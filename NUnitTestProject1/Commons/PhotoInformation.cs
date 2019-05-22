using System;
using System.Collections.Generic;
using System.Text;

namespace GMailUnitFramework.Commons
{
    // This class is used to update or modify an existing entity while making a PUT call in RestSharp
   class PhotoInformation
    {

        public string title { get; set; }
        public string url { get; set; }

        public PhotoInformation()
        {

        }
    }
}
