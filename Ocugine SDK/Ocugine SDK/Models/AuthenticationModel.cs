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
    //  Ocugine SDK Authentication Model
    //===================================================
    public class AuthenticationModel{
        public double uid = 0;              // Authentication UID
        public bool is_auth = false;        // Authentication Status
        public string login = "";           // User Login
        public string token = "";           // User Token
        public string from = "";            // Authentication Method
        public double action_time = 0;      // Last Action Time (Unix)
        public double profile_uid = 0;      // Profile (Account) UID
    }

    //===================================================
    //  Ocugine SDK Profile Model
    //===================================================
    public class ProfileModel{
        public double uid = 0;              // Profile (Account) UID
        public string first_name = "";      // First Name
        public string last_name = "";       // Last Name
        public string avatar = "";          // Avatar (Photo) URL
        public string email = "";           // User Email
        public profileData profile_data;    // Profile Data
        public int profile_type = 0;        // Profile Type
    }

    //===================================================
    //  Ocugine SDK Profile Data Model
    //===================================================
    public class profileData{

    }

    //===================================================
    //  Ocugine SDK Viewer Model
    //===================================================
    public class ViewerModel{
        public double uid = 0;              // Viewer UID
        public string ip = "";              // Viewer IP
        public double profile_uid = 0;      // Profile (Account) UID
        public string user_agent = "";      // User Agent
        public string hash = "";            // User Hash
        public string location = "";        // User Location
        public string device = "";          // User Device
        public double time = 0;             // Last Action Time (Unix)
    }

    //===================================================
    //  Ocugine SDK OAuth Model
    //===================================================
    public class OAuthModel : BaseModel
    {
        public SubModel data;

        public class SubModel
        {
            public double app_id = 0;           // Project ID
            public string auth_url = "";        // Auth Link
            public double timeout = 0;          // UNIX Expire time
        }
    }

    //===================================================
    //  Ocugine SDK OAuth Token Model
    //===================================================
    public class OAuthTokenModel : BaseModel
    {
        public SubModel data;

        public class SubModel
        {
            public string access_token = "";    // Access token
            public string[] grants = null;      // Grants
        }
    }

}
