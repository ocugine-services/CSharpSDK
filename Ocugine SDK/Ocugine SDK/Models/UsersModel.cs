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
    public class UsersModel
    {

    }

    //===================================================
    //  Ocugine Policy List Model
    //===================================================
    public class PolicyListModel : BaseModel
    {
        public SubModel data;
        public class SubModel
        {
            // Модель инфо
            public ListModel[] list;
            public class ListModel
            {
                public string policy_name = "";
                public int uid = 0;                
                public string time = "";
            }

        }
    }

    //===================================================
    //  Ocugine Policy Info Model
    //===================================================
    public class PolicyInfoModel : BaseModel
    {
        public SubModel data;
        public class SubModel
        {
            // Модель инфо
            public InfoModel info;
            public class InfoModel
            {
                public int uid = 0;
                public string policy_name = "";
                public string policy_text = "";
                public string project_id = "";
                public string time = "";
            }
            
        }
    }
}
