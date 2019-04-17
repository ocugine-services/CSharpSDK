using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ocugine_SDK.Models;
using Newtonsoft.Json;

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
//  @url            https://ocugine.pro/
//  @docs           https://docs.ocugine.pro/
//  @license        MIT
//===================================================
//===================================================
//  Namespace Ocugine SDK
//===================================================
namespace Ocugine_SDK
{
    //===================================================
    //  Ocugine SDK General Class
    //===================================================
    public class Ocugine{
        // General Class Constants
        public const string PROTOCOL = "https://";      // Requests Protocol
        public const string SERVER = "cp.ocugine.pro";  // Server URL
        public const bool SSL = true;                   // SSL
        public const string API_GATE = "/api/";         // API Gateway
        public const string VERSION = "0.4.0a";         // Library Version
        public const double BUILD = 401;                // Library Build

        // Settings Instances
        public AppSettings application;                 // Application Settings
        public SDKSettings settings;                    // SDK Settings

        // Classes Instances
        public Auth auth;                               // Authentication Class
        public Analytics analytics;                     // Analytics Class
        public GameServices game;                       // Game Services
        public Payments monetization;                   // Monetization Services
        public Notifications notifications;             // Notifications Services
        public Marketing marketing;                     // Marketing Services
        public Ads ads;                                 // Ads Services
        public Backend backend;                         // Backend Services
        public Reporting reports;                       // Reporting Services
        public Perfomance perfomance;                   // Perfomance Services
        public Backoffice office;                       // Office Services
        public Localization locale;                     // Locale Services
        public Utils utils;                             // SDK Utils

        // Private Class Params
        private const string STATE_OBJECT = "state";    // State Object

        //============================================================
        //  @class      General
        //  @method     Ocugine()
        //  @type       Static Void
        //  @usage      Initialize SDK to use in your projects
        //  @args       (int) api_id - Ocugine Application ID
        //              (string) api_key - Ocugine Application Key
        //  @return     
        //============================================================
        public Ocugine(AppSettings app_settings, SDKSettings sdk_settings = null){
            // Set Params to Ocugine SDK
            application = app_settings;             // Set Application Settings

            // Set SDK Settings
            if (sdk_settings != null){ // Has SDK Settings
                settings = sdk_settings; // Set SDK Settings
            } else { // No SDK Settings
                settings = new SDKSettings(); // Create SDK Settings
                settings.language = "EN"; // Set Default Language as EN
            }

            // Initialize Modules
            _initializeModules(); // Yep
        }

        //============================================================
        //  @class      General
        //  @method     getAPIInfo()
        //  @type       Public with Delegates
        //  @usage      Get API Information
        //  @args       (void) complete - Request Complete Callback
        //              (void) error - Request Error Callback
        //  @return     none
        //============================================================
        public delegate void OnAPIInfoComplete(StateModel data);
        public delegate void OnAPIInfoError(string code);
        public async Task<bool> getAPIInfo(OnAPIInfoComplete complete, OnAPIInfoError error){
            // Set Request data for POST
            var formContent = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("lang", settings.language) // Language
            });

            // Send Request
            bool auth = await utils.sendRequest(PROTOCOL + SERVER + API_GATE + STATE_OBJECT + "/", formContent, ((string data) => { // Response
                StateModel state = JsonConvert.DeserializeObject<StateModel>(data); // Deserialize Object
                complete(state); // Return Data
            }), ((string code) => { // Error
                error(code);
            }));

            // All Right
            return true;
        }

        //============================================================
        //  @class      General
        //  @method     getAPIStatus()
        //  @type       Public with Delegates
        //  @usage      Get API Status
        //  @args       none
        //  @return     none
        //============================================================

        //============================================================
        //  @class      General
        //  @method     _initializeModules()
        //  @type       Private
        //  @usage      Initialize SDK modules for usage
        //  @args       none
        //  @return     none
        //============================================================
        private void _initializeModules(){
            if (settings.modules == SDKModules.Auth || settings.modules == SDKModules.All) auth = new Auth(this); // Create Instance
            if (settings.modules == SDKModules.Analytics || settings.modules == SDKModules.All) analytics = new Analytics(this); // Create Instance
            if (settings.modules == SDKModules.GameServices || settings.modules == SDKModules.All) game = new GameServices(this); // Create Instance
            if (settings.modules == SDKModules.Payments || settings.modules == SDKModules.All) monetization = new Payments(this); // Create Instance
            if (settings.modules == SDKModules.Notifications || settings.modules == SDKModules.All) notifications = new Notifications(this); // Create Instance
            if (settings.modules == SDKModules.Marketing || settings.modules == SDKModules.All) marketing = new Marketing(this); // Create Instance
            if (settings.modules == SDKModules.Ads || settings.modules == SDKModules.All) ads = new Ads(this); // Create Instance
            if (settings.modules == SDKModules.Backend || settings.modules == SDKModules.All) backend = new Backend(this); // Create Instance
            if (settings.modules == SDKModules.Reporting || settings.modules == SDKModules.All) reports = new Reporting(this); // Create Instance
            if (settings.modules == SDKModules.Perfomance || settings.modules == SDKModules.All) perfomance = new Perfomance(this); // Create Instance
            if (settings.modules == SDKModules.Backoffice || settings.modules == SDKModules.All) office = new Backoffice(this); // Create Instance
            if (settings.modules == SDKModules.Localization || settings.modules == SDKModules.All) locale = new Localization(this); // Create Instance
            if (settings.modules == SDKModules.Utils || settings.modules == SDKModules.All) utils = new Utils(this); // Create Instance
        }
    }

    //===================================================
    //  Ocugine Authentication Class
    //===================================================
    public class Auth{
        // General Class Params

        // Authentication Objects
        public AuthenticationModel credentials;  // Authentication Credentials
        public ProfileModel profile;             // Authenticated User Profile
        public ViewerModel viewer;               // Authenticated User Viewer Model

        // Private Class Params
        private Ocugine sdk_instance;            // SDK Instance

        //============================================================
        //  @class      Auth
        //  @method     Auth
        //  @type       Constructor
        //  @usage      Initialize Authentication Module
        //  @args       none
        //  @return     none
        //============================================================
        public Auth(Ocugine instance, string route = "/auth/"){
            sdk_instance = instance; // Set SDK Instance
        }

    }

    //===================================================
    //  Ocugine Analytics Class
    //===================================================
    public class Analytics{

        // Private Class Params
        private Ocugine sdk_instance;            // SDK Instance

        //============================================================
        //  @class      Analytics
        //  @method     Analytics
        //  @type       Constructor
        //  @usage      Initialize Analytics Module
        //  @args       none
        //  @return     none
        //============================================================
        public Analytics(Ocugine instance, string route = "/auth/"){
            sdk_instance = instance; // Set SDK Instance
        }
    }

    //===================================================
    //  Ocugine Game Services Class
    //===================================================
    public class GameServices{

        // Private Class Params
        private Ocugine sdk_instance;            // SDK Instance

        //============================================================
        //  @class      GameServices
        //  @method     GameServices
        //  @type       Constructor
        //  @usage      Initialize Games Services Module
        //  @args       none
        //  @return     none
        //============================================================
        public GameServices(Ocugine instance, string route = "/auth/"){
            sdk_instance = instance; // Set SDK Instance
        }
    }

    //===================================================
    //  Ocugine Payments Class
    //===================================================
    public class Payments{

        // Private Class Params
        private Ocugine sdk_instance;            // SDK Instance

        //============================================================
        //  @class      Payments
        //  @method     Payments
        //  @type       Constructor
        //  @usage      Initialize Payments Module
        //  @args       none
        //  @return     none
        //============================================================
        public Payments(Ocugine instance, string route = "/auth/"){
            sdk_instance = instance; // Set SDK Instance
        }
    }

    //===================================================
    //  Ocugine Notifications Class
    //===================================================
    public class Notifications{

        // Private Class Params
        private Ocugine sdk_instance;            // SDK Instance

        //============================================================
        //  @class      Notifications
        //  @method     Notifications
        //  @type       Constructor
        //  @usage      Initialize Notifications Module
        //  @args       none
        //  @return     none
        //============================================================
        public Notifications(Ocugine instance, string route = "/auth/"){
            sdk_instance = instance; // Set SDK Instance
        }
    }

    //===================================================
    //  Ocugine Marketing Class
    //===================================================
    public class Marketing{

        // Private Class Params
        private Ocugine sdk_instance;            // SDK Instance

        //============================================================
        //  @class      Marketing
        //  @method     Marketing
        //  @type       Constructor
        //  @usage      Initialize Marketing Module
        //  @args       none
        //  @return     none
        //============================================================
        public Marketing(Ocugine instance, string route = "/auth/"){
            sdk_instance = instance; // Set SDK Instance
        }
    }

    //===================================================
    //  Ocugine Ads Class
    //===================================================
    public class Ads{

        // Private Class Params
        private Ocugine sdk_instance;            // SDK Instance

        //============================================================
        //  @class      Ads
        //  @method     Ads
        //  @type       Constructor
        //  @usage      Initialize Ads Module
        //  @args       none
        //  @return     none
        //============================================================
        public Ads(Ocugine instance, string route = "/auth/"){
            sdk_instance = instance; // Set SDK Instance
        }
    }

    //===================================================
    //  Ocugine Backend Class
    //===================================================
    public class Backend{

        // Private Class Params
        private Ocugine sdk_instance;            // SDK Instance

        //============================================================
        //  @class      Backend
        //  @method     Backend
        //  @type       Constructor
        //  @usage      Initialize Backend Module
        //  @args       none
        //  @return     none
        //============================================================
        public Backend(Ocugine instance, string route = "/auth/"){
            sdk_instance = instance; // Set SDK Instance
        }
    }

    //===================================================
    //  Ocugine Reporting Class
    //===================================================
    public class Reporting{

        // Private Class Params
        private Ocugine sdk_instance;            // SDK Instance

        //============================================================
        //  @class      Reporting
        //  @method     Reporting
        //  @type       Constructor
        //  @usage      Initialize Reporting Module
        //  @args       none
        //  @return     none
        //============================================================
        public Reporting(Ocugine instance, string route = "/auth/"){
            sdk_instance = instance; // Set SDK Instance
        }
    }

    //===================================================
    //  Ocugine Perfomance Class
    //===================================================
    public class Perfomance{

        // Private Class Params
        private Ocugine sdk_instance;            // SDK Instance

        //============================================================
        //  @class      Perfomance
        //  @method     Perfomance
        //  @type       Constructor
        //  @usage      Initialize Perfomance Module
        //  @args       none
        //  @return     none
        //============================================================
        public Perfomance(Ocugine instance, string route = "/auth/"){
            sdk_instance = instance; // Set SDK Instance
        }
    }

    //===================================================
    //  Ocugine Backoffice Class
    //===================================================
    public class Backoffice{

        // Private Class Params
        private Ocugine sdk_instance;            // SDK Instance

        //============================================================
        //  @class      Backoffice
        //  @method     Backoffice
        //  @type       Constructor
        //  @usage      Initialize Back Office Module
        //  @args       none
        //  @return     none
        //============================================================
        public Backoffice(Ocugine instance, string route = "/auth/"){
            sdk_instance = instance; // Set SDK Instance
        }
    }

    //===================================================
    //  Ocugine Localization Class
    //===================================================
    public class Localization{

        // Private Class Params
        private Ocugine sdk_instance;            // SDK Instance

        //============================================================
        //  @class      Localization
        //  @method     Localization
        //  @type       Constructor
        //  @usage      Initialize Localization Module
        //  @args       none
        //  @return     none
        //============================================================
        public Localization(Ocugine instance, string route = "/auth/"){
            sdk_instance = instance; // Set SDK Instance
        }
    }

    //===================================================
    //  Ocugine Utils Class
    //===================================================
    public class Utils{
        // Private Class Params
        private Ocugine sdk_instance;            // SDK Instance

        //============================================================
        //  @class      Utils
        //  @method     Utils
        //  @type       Constructor
        //  @usage      Initialize Utils Module
        //  @args       none
        //  @return     none
        //============================================================
        public Utils(Ocugine instance){
            sdk_instance = instance; // Set SDK Instance
        }

        //============================================================
        //  @class      Utils
        //  @method     sendRequest()
        //  @type       Static Void
        //  @usage      Send POST Request to API server
        //  @args       (string) url - Request URL
        //              (FormUrlEncodedContent) data - Form Data
        //              (void) complete - Complete Callback
        //              (void) error - Error Callback
        //  @return     (bool) status
        //============================================================
        public delegate void OnRequestComplete(string data); // Request Complete Callback
        public delegate void OnRequestError(string code); // Request Error Callback
        public async Task<bool> sendRequest(string url, FormUrlEncodedContent data, OnRequestComplete complete, OnRequestError error){
            try{ // Creating client and send request
                // Set client vars
                var myHttpClient = new HttpClient(); // Create HTTP Client
                var response = await myHttpClient.PostAsync(url, data); // HTTP Response
                var json = await response.Content.ReadAsStringAsync(); // JSON Data
                try{ // Trying to decode HTTP Response
                    BaseModel resp = JsonConvert.DeserializeObject<BaseModel>(json); // Deserialize JSON to Object
                    if (resp.complete){ // All Right, Server returns Complete Flag
                        complete(json); // Show Complete
                        return true;
                    } else { // Server Returns Error
                        error(resp.message); // Show Error
                        return false;
                    }
                } catch (Exception ex){ // Failed to decode data
                    error(ex.Message); // Show Error
                    return false;
                }
            } catch (Exception ex){ // Failed to send request
                error(ex.Message); // Show Error
                return false;
            }
        }

        //============================================================
        //  @class      Utils
        //  @method     getStaticData()
        //  @type       Static Void
        //  @usage      Send GET Request to API server
        //  @args       (string) url - Request URL
        //              (void) complete - Complete Callback
        //              (void) error - Error Callback
        //  @return     (bool) status
        //============================================================
        public delegate void OnGetRequestComplete(string data); // Request Complete Callback
        public delegate void OnGetRequestError(string code); // Request Error Callback
        public async Task<bool> getStaticData(string url, OnGetRequestComplete complete, OnGetRequestError error){
            try{ // Creating client and send request
                // Set client vars
                var myHttpClient = new HttpClient(); // Create HTTP Client
                var response = await myHttpClient.GetAsync(url); // HTTP Response
                var datas = await response.Content.ReadAsStringAsync(); // Get Data

                // Return Datas
                complete(datas); // Run Complete Callback
                return true;
            } catch (Exception ex){ // Failed to send request
                error(ex.Message); // Show Error
                return false;
            }
        }


    }
}
