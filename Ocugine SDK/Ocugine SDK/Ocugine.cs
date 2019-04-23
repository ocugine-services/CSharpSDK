using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Ocugine_SDK.Models;
using Newtonsoft.Json;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

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
        public UI ui;                                   // UI Module
        public Utils utils;                             // SDK Utils

        // Private Class Params
        private const string STATE_OBJECT = "state";    // State Object

        // Public Class Params
        public const string OAUTH_OBJECT = "oauth";     // Oauth Object

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
        public delegate void OnAPIStatusComplete(APIState data);
        public delegate void OnAPIStatusError(string code);
        public async Task<bool> getAPIStatus(OnAPIStatusComplete complete, OnAPIStatusError error){
            // Set Request data for POST
            var formContent = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("lang", settings.language) // Language
            });

            // Send Request
            bool auth = await utils.sendRequest(PROTOCOL + SERVER + API_GATE + STATE_OBJECT + "/", formContent, ((string data) => { // Response
                APIState state = JsonConvert.DeserializeObject<APIState>(data); // Deserialize Object
                complete(state); // Return Data
            }), ((string code) => { // Error
                error(code);
            }));

            // All Right
            return true;
        }

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
            if (settings.modules == SDKModules.UI || settings.modules == SDKModules.All) ui = new UI(this); // Create Instance
            utils = new Utils(this); // Create Instance 
            // if (settings.modules == SDKModules.Utils || settings.modules == SDKModules.All) 
        }
    }

    //===================================================
    //  Ocugine Authentication Class
    //===================================================
    public class Auth{
        // General Class Params

        // Authentication Objects
        public AuthenticationModel credentials = new AuthenticationModel();  // Authentication Credentials
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

        //============================================================
        //  @class      Auth
        //  @method     GetToken()
        //  @type       Static Async Void
        //  @usage      Get user token
        //              (void) complete - Complete Callback
        //              (void) error - Error Callback
        //  @return     none
        //============================================================
        public delegate void OnAPIInfoComplete(OAuthTokenModel data);
        public delegate void OnAPIInfoError(string code);
        public async void GetToken(OnAPIInfoComplete complete, OnAPIInfoError error)
        {
            await GetTokenAsync(complete, error);
        }
        public async Task<bool> GetTokenAsync(OnAPIInfoComplete complete, OnAPIInfoError error)
        {
            var authContent = new[]{
                        new KeyValuePair<string, string>("app_id", $"{sdk_instance.application.app_id}"),   // App Id
                        new KeyValuePair<string, string>("app_key", $"{sdk_instance.application.app_key}"), // App key
                        new KeyValuePair<string, string>("lang", $"{sdk_instance.settings.language}")       // Language
                    };
            var formContent = new FormUrlEncodedContent(authContent); // Serealize request params
            return await sdk_instance.utils.sendRequest(Ocugine.PROTOCOL + Ocugine.SERVER + Ocugine.API_GATE + Ocugine.OAUTH_OBJECT + "/get_token", formContent,
                ((string data) => { // Response
                        OAuthTokenModel state = JsonConvert.DeserializeObject<OAuthTokenModel>(data); // Deserialize Object
                        credentials.token = state.data.access_token;
                        complete(state); // Return Data                       
                    }),
            ((string code) => { // Error
                    error(code);
            }));
        }


        //============================================================
        //  @class      Logout
        //  @method     GetToken()
        //  @type       Static Async Void
        //  @usage      Logout by user token
        //              (void) complete - Complete Callback
        //              (void) error - Error Callback
        //  @return     none
        //============================================================
        public delegate void OnLogoutComplete(string data);
        public delegate void OnLogoutError(string code);
        public async void Logout(OnLogoutComplete complete, OnLogoutError error)
        {
            await LogoutAsync(complete, error);
        }
        public async Task<bool> LogoutAsync(OnLogoutComplete complete, OnLogoutError error)
        {
            if(sdk_instance.auth.credentials.token == "")
            {
                switch (sdk_instance.settings.language)
                {
                    case "RU": { error("Ошибка деавторизации, приложение не авторизовано"); } break;
                    default: { error("Logout error, application not authorized"); } break;
                }
                return false;
            }              
            var logoutContent = new[]{
                        new KeyValuePair<string, string>("access_token", $"{sdk_instance.auth.credentials.token}"),   // App Token
                    };
            var formContent = new FormUrlEncodedContent(logoutContent); // Serealize request params
            return await sdk_instance.utils.sendRequest(Ocugine.PROTOCOL + Ocugine.SERVER + Ocugine.API_GATE + Ocugine.OAUTH_OBJECT + "/logout", formContent,
                ((string data) => { // Response                      
                    complete(data);
                }),
            ((string code) => { // Error
                error(code);
            }));
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
    //  Ocugine UI Class
    //===================================================
    public class UI{
        // Private Class Params
        private Ocugine sdk_instance;            // SDK Instance


        //============================================================
        //  @class      UI
        //  @method     UI
        //  @type       Constructor
        //  @usage      Initialize UI Module
        //  @args       none
        //  @return     none
        //============================================================
        public UI(Ocugine instance){
            sdk_instance = instance; // Set SDK Instance
        }

        //============================================================
        //  @class      UI
        //  @method     GetToken()
        //  @type       Static Async Void
        //  @usage      Get Auth data
        //  @args       (string[]) grants - Grants for project
        //              (void) complete - Complete Callback
        //              (void) error - Error Callback
        //  @return     none
        //============================================================   
        public delegate void OnAPIInfoComplete(OAuthTokenModel data);
        public delegate void OnAPIInfoError(string code);
        public void GetAuthForm(OnAPIInfoComplete complete, OnAPIInfoError error, string grants = "all") // Get and return login form with all permissions
        {
            var formContent = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("app_id", $"{sdk_instance.application.app_id}"), // App Id
                new KeyValuePair<string, string>("app_key", $"{sdk_instance.application.app_key}"), // App key
                new KeyValuePair<string, string>("lang", $"{sdk_instance.settings.language}"), // Language
                new KeyValuePair<string, string>("grants", $"{grants}"), // App Id
            });
            GetAuthLink(formContent, complete, error);
        }        
        public void GetAuthForm(string[] grants, OnAPIInfoComplete complete, OnAPIInfoError error) // Get and return login form with selected permissions
        {
            var formContent = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("app_id", $"{sdk_instance.application.app_id}"), // App Id
                new KeyValuePair<string, string>("app_key", $"{sdk_instance.application.app_key}"), // App Key
                new KeyValuePair<string, string>("grants", $"{grants}"), // Permissions
                new KeyValuePair<string, string>("lang", $"{sdk_instance.settings.language}") // Language
            });
            GetAuthLink(formContent, complete, error);            
        }

        //============================================================
        //  @class      UI
        //  @method     GetAuthLink()
        //  @type       Static Async Void
        //  @usage      Get or open OAuth form link
        //  @args       (KeyValuePair) authContent - Auth data
        //              (void) complete - Complete Callback
        //              (void) error - Error Callback
        //  @return     (bool) status
        //============================================================
        private async void GetAuthLink(FormUrlEncodedContent formContent, OnAPIInfoComplete complete, OnAPIInfoError error)
        {        
            bool JSON = await sdk_instance.utils.sendRequest(Ocugine.PROTOCOL + Ocugine.SERVER + Ocugine.API_GATE + Ocugine.OAUTH_OBJECT + "/get_link", formContent,
                (async (string data) => { // Response
                    OAuthModel state = JsonConvert.DeserializeObject<OAuthModel>(data); // Deserialize Object  
                    var browser = Process.Start(state.data.auth_url); // OpenBrowser();
                    //                                   
                    int timeout = 0; bool GotToken = false; string lasterror = "";
                    while (!GotToken && timeout != 30) // Set auth waiting time (30 sec)
                    {
                        GotToken = await sdk_instance.auth.GetTokenAsync((OAuthTokenModel token) => complete(token), (string err) => lasterror = err); // Wait for result
                        timeout++; Thread.Sleep(1000); // Increase counter and wait 1 sec
                    }
                    if (!GotToken)
                    {
                        switch (sdk_instance.settings.language)
                        {
                            case "RU": { error("Время на аутентификацию вышло\n" + lasterror); } break;
                            default: { error("Authefication timed out\n" + lasterror); } break;
                        }
                    }
                }),
                ((string code) => { // Error
                    error(code);
                }));         
        }
        /* TODO: Доделать документацию */
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
