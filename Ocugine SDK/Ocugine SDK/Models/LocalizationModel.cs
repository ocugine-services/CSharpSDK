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
    public class LocalizationModel
    {
        
    }

    //===================================================
    //  Ocugine Language Info Model
    //===================================================
    public class LanguageInfo : BaseModel
    {
        public SubModel data;

        public class SubModel
        {
            public string uid = "";            // Locale id
            public string code = "";           // Locale short name
            public string name = "";           // Locale name
            public string time = "";           // Locale last edit time
            public string project_id = "";     // Project id
        }
    }
}
