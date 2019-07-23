using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//===================================================
//  Ocugine SDK
//  Sofware Development Kit developed specially for
//  Ocugine Services. With this library you can
//  use all features of Ocugine Services
//
//  @name           Ocugine SDK
//  @developer      CodeBits Interactive
//  @version        0.4.0a
//  @build          401
//  @url            https://ocugine.com/
//  @docs           https://docs.ocugine.com/
//  @license        MIT
//===================================================
//===================================================
//  Namespace Ocugine SDK
//===================================================
namespace Ocugine_SDK.Models
{
    [Serializable]
    public class UtilsModel
    {

    }

    //===================================================
    //  Ocugine Policy List Model
    //===================================================
    [Serializable]
    public class APISettingsInfo : BaseModel
    {
        public SubModel data;

        [Serializable]
        public class SubModel
        {
            // Модель инфо
            public ConfingsModel configs;

            [Serializable]
            public class ConfingsModel
            {
                public double uid = 0;
                public double project_id = 0;
                public bool enabled = true;
                public double limitation = 0;
            }

        }
    }
    
}
