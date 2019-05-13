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
    public class BackendModel
    {

    }

    //===================================================
    //  Ocugine Content List Model
    //===================================================
    public class ContentListInfo : BaseModel
    {
        public SubModel data;
        public class SubModel
        {
            public ListModel[] list;
            public class ListModel
            {
                public double uid = 0;
                public double project_id = 0;
                public string content_slug = "";
                public double time = 0;
            }
        }
    }

    //===================================================
    //  Ocugine Content Model
    //===================================================
    public class ContentInfo : BaseModel
    {
        public SubModel data;
        public class SubModel
        {
            // Модель инфо
            public InfoModel info;
            public class InfoModel
            {
                public double uid = 0;
                public double project_id = 0;
                public string content_slug = "";
                public double content_size;
                public string content_url;
                public double time = 0;
            }
        }
    }

}
