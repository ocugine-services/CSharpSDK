using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Ocugine_SDK;
using Ocugine_SDK.Models;

namespace Console_Debug
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialize Ocugine SDK
            Ocugine SDK = new Ocugine(new AppSettings
            {
                app_id = 1,
                app_key = "c46361ae80c1679d637c2f23968a4dc5d5ea2a65"
            }, new SDKSettings
            {
                language = "RU",
                modules = SDKModules.All,
                auth_timeout = 10
            });

            /** Тест вызова формы аутентификации **/
            //SDK.ui.GetAuthForm((OAuthTokenModel o) => { Console.WriteLine(SDK.auth.credentials.token); }, (string s) => { Console.WriteLine(s); }, "all");

            /** Тест получения токена **/
            //SDK.auth.GetToken((OAuthTokenModel o) => { Console.WriteLine(SDK.auth.credentials.token); }, (string s) => { Console.WriteLine(s); });

            /** Тест логаута **/
            //Thread.Sleep(1000);
            //SDK.auth.Logout((string o) => { Console.WriteLine("Успешный логаут"); }, (string s) => { Console.WriteLine(s); });

            /** Тест получения информации о языке **/
            SDK.locale.GetLang((LanguageInfo o) => { Console.WriteLine($"{o.data.name}"); }, (string s) => { Console.WriteLine(s); }, "ru");

            /** Тест получения информации о языке **/
            SDK.locale.GetLocale((LocaleInfo o) => { Console.WriteLine($"{o.data.value}"); }, (string s) => { Console.WriteLine(s); }, "ru", "test-node");

            /** Тест  **/


            /** Тест  **/
            
            
            /** Тест  **/
            
            
            /** Тест  **/
            
            
            /** Тест  **/

            Console.Read();
        }
        

    }
}
