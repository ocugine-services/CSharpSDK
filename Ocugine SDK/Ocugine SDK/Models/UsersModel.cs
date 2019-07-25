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
    public class UsersModel
    {

    }

    //===================================================
    //  Ocugine Users List Model
    //===================================================
    [Serializable]
    public class UsersListInfo : BaseModel
    {
        public SubModel data;

        [Serializable]
        public class SubModel
        {
            // Модель инфо
            public ListModel[] list;

            [Serializable]
            public class ListModel
            {
                public double uid = 0;
                public string first_name = "";
                public string last_name = "";
                public string avatar = "";
                public string email = "";
                public ProfileDataModel[] profile_data;
                public int profile_type = 1;
                public double group_id = -1;
                public BanStateData banstate;

                [Serializable]
                public class ProfileDataModel
                {
                    // TODO: Implement this by model
                }

                [Serializable]
                public class BanStateData
                {
                    public double uid = 0;
                    public double profile_uid = 0;
                    public double project_uid = 0;
                    public bool ban_state = 0;
                    public double ban_escape = 0;
                    public string ban_reason = 0;
                }
            }
        }
    }

    //===================================================
    //  Ocugine Users Model
    //===================================================
    [Serializable]
    public class UserInfo : BaseModel
    {
        public SubModel data;

        [Serializable]
        public class SubModel
        {
            public BaseData base_data;

            //TODO Implement this
            public AdvancedData advanced_data;
            public GroupData group_data;

            [Serializable]
            public class BaseData
            {
                public double uid = 0;
                public string first_name = "";
                public string last_name = "";
                public string avatar = "";
                public string email = "";
                public bool profile_data = false;
                public int profile_type = 0;
            }

            [Serializable]
            public class AdvancedData
            {

            }

            [Serializable]
            public class GroupData
            {

            }
        }
    }

    //===================================================
    //  Ocugine Policy List Model
    //===================================================
    [Serializable]
    public class PolicyListInfo : BaseModel
    {
        public SubModel data;

        [Serializable]
        public class SubModel
        {
            // Модель инфо
            public ListModel[] list;

            [Serializable]
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
    [Serializable]
    public class PolicyInfo : BaseModel
    {
        public SubModel data;

        [Serializable]
        public class SubModel
        {
            // Модель инфо
            public InfoModel info;

            [Serializable]
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

    //===================================================
    //  Ocugine Groups List Model
    //===================================================
    [Serializable]
    public class GroupListInfo : BaseModel
    {
        public SubModel data;

        [Serializable]
        public class SubModel
        {
            public GroupInfo.SubModel[] list;
        }
    }

    //===================================================
    //  Ocugine Groups Info Model
    //===================================================
    [Serializable]
    public class GroupInfo : BaseModel
    {
        public SubModel data;

        [Serializable]
        public class SubModel
        {
            public string uid = "";
            public string project_id = "";
            public string group_name = "";
            public string group_desc = "";
            public string time = "";
            public ConditionsData[] conditions;
            public bool can_select = false;
            public bool auto_detect = false;
        }

        [Serializable]
        public class ConditionsData
        {
            //TODO: Implement this
        }
    }

}
