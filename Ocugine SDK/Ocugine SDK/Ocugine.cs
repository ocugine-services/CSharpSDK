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
        public const string LOCALE_OBJECT = "localization";     // Oauth Object

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
            if (settings.modules.Contains(SDKModules.Auth) || settings.modules.Contains(SDKModules.All)) auth = new Auth(this); // Create Instance
            if (settings.modules.Contains(SDKModules.Analytics) || settings.modules.Contains(SDKModules.All)) analytics = new Analytics(this); // Create Instance
            if (settings.modules.Contains(SDKModules.GameServices) || settings.modules.Contains(SDKModules.All)) game = new GameServices(this); // Create Instance
            if (settings.modules.Contains(SDKModules.Payments) || settings.modules.Contains(SDKModules.All)) monetization = new Payments(this); // Create Instance
            if (settings.modules.Contains(SDKModules.Notifications) || settings.modules.Contains(SDKModules.All)) notifications = new Notifications(this); // Create Instance
            if (settings.modules.Contains(SDKModules.Marketing) || settings.modules.Contains(SDKModules.All)) marketing = new Marketing(this); // Create Instance
            if (settings.modules.Contains(SDKModules.Ads) || settings.modules.Contains(SDKModules.All)) ads = new Ads(this); // Create Instance
            if (settings.modules.Contains(SDKModules.Backend) || settings.modules.Contains(SDKModules.All)) backend = new Backend(this); // Create Instance
            if (settings.modules.Contains(SDKModules.Reporting) || settings.modules.Contains(SDKModules.All)) reports = new Reporting(this); // Create Instance
            if (settings.modules.Contains(SDKModules.Perfomance) || settings.modules.Contains(SDKModules.All)) perfomance = new Perfomance(this); // Create Instance
            if (settings.modules.Contains(SDKModules.Backoffice) || settings.modules.Contains(SDKModules.All)) office = new Backoffice(this); // Create Instance
            if (settings.modules.Contains(SDKModules.Localization) || settings.modules.Contains(SDKModules.All)) locale = new Localization(this); // Create Instance
            if (settings.modules.Contains(SDKModules.UI) || settings.modules.Contains(SDKModules.All)) ui = new UI(this); // Create Instance
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
        public ProfileModel profile = new ProfileModel();             // Authenticated User Profile
        public ViewerModel viewer = new ViewerModel();               // Authenticated User Viewer Model

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
        //  @type       Static Void
        //  @usage      Get user token
        //              (void) complete - Complete Callback
        //              (void) error - Error Callback
        //  @return     none
        //============================================================
        public delegate void OnAPIInfoComplete(OAuthTokenModel data); // Returns OAuthTokenModel
        public delegate void OnAPIInfoError(string code); // Returns error code
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
                    credentials.is_auth = true;
                    complete(state); // Return Data                       
                }),
            ((string code) => { // Error
                error(code);
            }));
        }


        //============================================================
        //  @class      Auth
        //  @method     Logout()
        //  @type       Static Void
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
            if(sdk_instance.auth.credentials.token == "" || sdk_instance.auth.credentials.is_auth == false)
            {
                sdk_instance.auth.credentials.token = "";
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
                    sdk_instance.auth.credentials.token = "";
                    sdk_instance.auth.credentials.is_auth = false;
                    complete(data);
                }),
            ((string code) => { // Error
                error(code);
            }));
        }

        //============================================================
        //  @class      Auth
        //  @method     GetLink()
        //  @type       Static Async Void
        //  @usage      Get oauth link
        //  @args       (string[] / string) grants - Grants for project
        //              (void) complete - Complete Callback
        //              (void) error - Error Callback
        //  @return     (bool) status
        //============================================================
        public delegate void OnGetLinkComplete(string data);
        public delegate void OnGetLinkError(string code);
        // With an array
        public async void GetLink(OnGetLinkComplete complete, OnGetLinkError error, string[] grants)
        {
            await GetLinkAsync(complete, error, grants);
        }
        public async Task<bool> GetLinkAsync(OnGetLinkComplete complete, OnGetLinkError error, string[] grants)
        {
            var formContent = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("app_id", $"{sdk_instance.application.app_id}"), // App Id
                new KeyValuePair<string, string>("app_key", $"{sdk_instance.application.app_key}"), // App Key
                new KeyValuePair<string, string>("grants", $"{grants}"), // Permissions
                new KeyValuePair<string, string>("lang", $"{sdk_instance.settings.language}") // Language
            });
            return await sdk_instance.utils.sendRequest(Ocugine.PROTOCOL + Ocugine.SERVER + Ocugine.API_GATE + Ocugine.OAUTH_OBJECT + "/get_link", formContent,
                ((string data) => { // Response
                    OAuthModel state = JsonConvert.DeserializeObject<OAuthModel>(data); // Deserialize Object  
                    complete(state.data.auth_url);
                }),
                ((string code) => { // Error
                    error(code);
                }));
        }
        // With a string
        public async void GetLink(OnGetLinkComplete complete, OnGetLinkError error, string grants = "")
        {
            await GetLinkAsync(complete, error, grants);
        }
        public async Task<bool> GetLinkAsync(OnGetLinkComplete complete, OnGetLinkError error, string grants = "")
        {
            var formContent = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("app_id", $"{sdk_instance.application.app_id}"), // App Id
                new KeyValuePair<string, string>("app_key", $"{sdk_instance.application.app_key}"), // App Key
                new KeyValuePair<string, string>("grants", $"{grants}"), // Permissions
                new KeyValuePair<string, string>("lang", $"{sdk_instance.settings.language}") // Language
            });
            return await sdk_instance.utils.sendRequest(Ocugine.PROTOCOL + Ocugine.SERVER + Ocugine.API_GATE + Ocugine.OAUTH_OBJECT + "/get_link", formContent,
                ((string data) => { // Response
                    OAuthModel state = JsonConvert.DeserializeObject<OAuthModel>(data); // Deserialize Object  
                    complete(state.data.auth_url);
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
        private Ocugine sdk_instance; // SDK Instance
        private Dictionary<string, LanguageInfo> LangInfoCache = new Dictionary<string, LanguageInfo>(); // Localization cache
        private Dictionary<string, Dictionary<string, LocaleInfo>> LocInfoCache = new Dictionary<string, Dictionary<string, LocaleInfo>>(); // Localization cache

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

        //============================================================
        //  @class      Localization
        //  @method     GetLang()
        //  @type       Static Async Void
        //  @usage      Get language info
        //  @args       (void) complete - Complete Callback
        //              (void) error - Error Callback
        //              (string) lang_code - Lang code
        //  @return     none
        //============================================================   
        public delegate void OnGetLangComplete(LanguageInfo data);
        public delegate void OnGetLangError(string code);
        public async void GetLang(string lang_code, OnGetLangComplete complete, OnGetLangError error) // Get lang
        {
            await GetLangAsync(lang_code, complete, error);
        }
        public async Task<bool> GetLangAsync(string lang_code, OnGetLangComplete complete, OnGetLangError error) //  (bool) Get lang
        {
            if (LangInfoCache.ContainsKey(lang_code)) // If cached
            {
                complete(LangInfoCache[lang_code]);
                return true;
            }
            else // If not cached
            {
                var formContent = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("app_id", $"{sdk_instance.application.app_id}"), // App Id
                new KeyValuePair<string, string>("app_key", $"{sdk_instance.application.app_key}"), // App key
                new KeyValuePair<string, string>("code", $"{lang_code}"), // Code language
            });
                return await sdk_instance.utils.sendRequest(Ocugine.PROTOCOL + Ocugine.SERVER + Ocugine.API_GATE + Ocugine.LOCALE_OBJECT + "/get_lang", formContent,
                    ((string data) => { // Response
                        LanguageInfo state = JsonConvert.DeserializeObject<LanguageInfo>(data); // Deserialize Object    
                        LangInfoCache[lang_code] = state;
                        complete(state);
                    }),
                ((string code) => { // Error
                error(code);
                }));
            }            
        }

        //============================================================
        //  @class      Localization
        //  @method     GetLang()
        //  @type       Static Async Void
        //  @usage      Get locale info
        //  @args       (void) complete - Complete Callback
        //              (void) error - Error Callback
        //              (string) lang_code - Lang code
        //              (string) locale_code - Locale code
        //  @return     none
        //============================================================   
        public delegate void OnGetLocaleComplete(LocaleInfo data);
        public delegate void OnGetLocaleError(string code);
        public async void GetLocale(string lang_code, string locale_code, OnGetLocaleComplete complete, OnGetLocaleError error) // Get locale
        {
            await GetLocaleAsync(lang_code, locale_code, complete, error);
        }
        public async Task<bool> GetLocaleAsync(string lang_code, string locale_code, OnGetLocaleComplete complete, OnGetLocaleError error) // (bool) Get locale
        {
            if (LocInfoCache.ContainsKey(lang_code) && LocInfoCache[lang_code].ContainsKey(locale_code)) // If has lang and locale in thot lang
            {
                Console.Write("кэш-");
                complete(LocInfoCache[lang_code][locale_code]);               
                return true;
            }
            else
            {
                var formContent = new FormUrlEncodedContent(new[]{
                new KeyValuePair<string, string>("app_id", $"{sdk_instance.application.app_id}"), // App Id
                new KeyValuePair<string, string>("app_key", $"{sdk_instance.application.app_key}"), // App key
                new KeyValuePair<string, string>("lang", $"{lang_code}"), // Code language
                new KeyValuePair<string, string>("code", $"{locale_code}"), // Code locale
            });
                return await sdk_instance.utils.sendRequest(Ocugine.PROTOCOL + Ocugine.SERVER + Ocugine.API_GATE + Ocugine.LOCALE_OBJECT + "/get_locale", formContent,
                    ((string data) => { // Response
                        LocaleInfo state = JsonConvert.DeserializeObject<LocaleInfo>(data); // Deserialize Object   
                        if (LocInfoCache.ContainsKey(lang_code))
                            LocInfoCache[lang_code][locale_code] = state;
                        else
                            LocInfoCache[lang_code] = new Dictionary<string, LocaleInfo> { { locale_code, state } };
                        complete(state);
                    }),
                ((string code) => { // Error
                error(code);
                }));
            }           
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
        //  @usage      Get token by Oauth protocol
        //  @args       (string / string[]) grants - Grants for project
        //              (void) complete - Complete Callback
        //              (void) error - Error Callback
        //  @return     none
        //============================================================   
        public delegate void OnAPIInfoComplete(OAuthTokenModel data);
        public delegate void OnAPIInfoError(string code);
        public async void GetAuthForm(OnAPIInfoComplete complete, OnAPIInfoError error, string grants = "") // Get and return login form with all permissions
        {
            /** checking Auth module **/
            try
            {
                var test = sdk_instance.auth.credentials.is_auth;
            }
            catch(Exception)
            {
                switch (sdk_instance.settings.language)
                {
                    case "RU": { error("Для использования метода GetAuthForm необходимо подключить модуль Auth"); } break;
                    default: { error("Method GetAuthForm requires Auth module"); } break;
                }
                return;
                //sdk_instance.auth = new Auth(sdk_instance);
            }
            /** Get link and open brower **/         
            bool GotLink = await sdk_instance.auth.GetLinkAsync((string c) => Process.Start(c), (string e) => error(e), grants); // OpenBrowser();      
            if (!GotLink) // Error
            {
                return;
            }
            /** Iteration for auth checking **/
            int timeout = 0; bool GotToken = false; string lasterror = "";
            while (!GotToken && timeout != sdk_instance.settings.auth_timeout) // Set auth waiting time (30 sec)
            {
                GotToken = await sdk_instance.auth.GetTokenAsync((OAuthTokenModel token) => complete(token), (string err) => lasterror = err); // Wait for result
                timeout++; Thread.Sleep(1000); // Increase counter and wait 1 sec
            }
            if (!GotToken) // Timeout
            {
                switch (sdk_instance.settings.language)
                {
                    case "RU": { error("Время на аутентификацию вышло\n" + lasterror); } break;
                    default: { error("Authefication timed out\n" + lasterror); } break;
                }
            }
        }        
        public async void GetAuthForm(OnAPIInfoComplete complete, OnAPIInfoError error, string[] grants) // Get and return login form with selected permissions
        {
            /** checking Auth module **/
            try
            {
                var test = sdk_instance.auth.credentials.is_auth;
            }
            catch (Exception)
            {
                switch (sdk_instance.settings.language)
                {
                    case "RU": { error("Для использования метода GetAuthForm необходимо подключить модуль Auth"); } break;
                    default: { error("Method GetAuthForm requires Auth module"); } break;
                }
                return;
                //sdk_instance.auth = new Auth(sdk_instance);
            }
            /** Get link and open brower **/
            bool GotLink = await sdk_instance.auth.GetLinkAsync((string c) => Process.Start(c), (string e) => error(e), grants); // OpenBrowser();   
            if (!GotLink) // Error
            {
                return;
            }
            /** Iteration for auth checking **/
            int timeout = 0; bool GotToken = false; string lasterror = "";
            while (!GotToken && timeout != sdk_instance.settings.auth_timeout) // Set auth waiting time (30 sec)
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
