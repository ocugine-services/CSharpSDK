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
namespace Ocugine_SDK.Models{
    //===================================================
    //  Ocugine SDK Settings
    //===================================================
    public class SDKSettings{
        // General Settings
        public string language = "";           // SDK Language
        public SDKModules modules;             // SDK Modules
    }

    //===================================================
    //  Ocugine Application Settings
    //===================================================
    public class AppSettings{
        public double app_id = 0;           // Application ID
        public string app_key = "";         // Application Key
        public string app_name = "";        // Application Name
        public string app_desc = "";        // Application Desc
        public string app_version = "";     // Application Version
    }
}
