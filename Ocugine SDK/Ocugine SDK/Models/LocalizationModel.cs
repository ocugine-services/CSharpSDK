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
            public string uid = "";            // Locale language id
            public string code = "";           // Locale language short name
            public string name = "";           // Locale language name
            public string time = "";           // Locale language last edit time
            public string project_id = "";     // Project id
        }
    }

    //===================================================
    //  Ocugine Language List Model
    //===================================================
    public class LanguageListInfo : BaseModel
    {
        public List<LanguageInfo.SubModel> data;
    }

    //===================================================
    //  Ocugine Locale Info Model
    //===================================================
    public class LocaleInfo : BaseModel
    {
        public SubModel data;

        public class SubModel
        {
            public string uid = "";            // Locale id
            public string code = "";           // Locale short name
            public string language = "";       // Locale language
            public string value = "";          // Locale value
            public string project_id = "";     // Project id
        }
    }

    //===================================================
    //  Ocugine Locale List Model
    //===================================================
    public class LocaleListInfo : BaseModel
    {
        public Dictionary<string, LocaleInfo.SubModel[]> data;
    }

}
