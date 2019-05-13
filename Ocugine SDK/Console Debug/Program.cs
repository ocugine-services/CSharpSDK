﻿using System;
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
                modules = new SDKModules[] { SDKModules.UI, SDKModules.Backend },
                auth_timeout = 10
            });

            /** Тест вызова формы аутентификации **/
            //SDK.ui.GetAuthForm((OAuthTokenModel o) => { Console.WriteLine(SDK.auth.credentials.token); }, (string s) => { Console.WriteLine(s); }, new string[]{ "all" });

            /** Тест получения ссылки на авторизацию **/
            //SDK.auth.GetLink((string o) => { Console.WriteLine(o); }, (string s) => { Console.WriteLine(s); }, "somebody,once,told,me");

            /** Тест получения токена **/
            //SDK.auth.GetToken((OAuthTokenModel o) => { Console.WriteLine(SDK.auth.credentials.token); }, (string s) => { Console.WriteLine(s); });

            /** Тест логаута **/
            //SDK.auth.GetToken((OAuthTokenModel o) => { Console.WriteLine(SDK.auth.credentials.token); }, (string s) => { Console.WriteLine(s); });
            //Thread.Sleep(2000);
            //SDK.auth.Logout((string o) => { Console.WriteLine("Успешный логаут"); }, (string s) => { Console.WriteLine(s); });

            /** Тест получения информации о языке **/
            //SDK.locale.GetLang("ru", (LanguageInfo o) => { Console.WriteLine($"{o.data.name}"); }, (string s) => { Console.WriteLine(s); });

            /** Тест получения информации о языке **/
            //SDK.locale.GetLocale("ru", "test-node", (LocaleInfo o) => { Console.WriteLine($"{o.data.value}"); }, (string s) => { Console.WriteLine(s); });

            /** Тест получения списка политик **/
            //SDK.users.GetPolicyList((PolicyListInfo o) => { foreach(PolicyListInfo.SubModel.ListModel d in o.data.list) Console.WriteLine($"[{d.uid}] - {d.policy_name}"); }, (string s) => { Console.WriteLine(s); });

            /** Тест получения информации о политике **/
            //SDK.users.GetPolicyInfo(1, (PolicyInfo o) => { Console.WriteLine($"{o.data.info.policy_name} {o.data.info.policy_text}"); }, (string s) => { Console.WriteLine(s); });
            //SDK.users.GetPolicyInfo(2, (PolicyInfo o) => { Console.WriteLine($"{o.data.info.policy_name} {o.data.info.policy_text}"); }, (string s) => { Console.WriteLine(s); });

            /** Тест получения настроек **/
            //SDK.utils.GetSettings((APISettingsInfo o) => { Console.WriteLine($"{o.data.configs.uid} {o.data.configs.limitation}"); }, (string s) => { Console.WriteLine(s); });

            /** Тест получения списка контента **/
            //SDK.backend.GetContentList((o) => { foreach(ContentListInfo.SubModel.ListModel d in o.data.list) Console.WriteLine($"{d.content_slug} {d.uid}"); }, (string s) => { Console.WriteLine(s); });

            /** Тест получения конкретного контента **/
            //SDK.backend.GetContent(1, (ContentInfo o) => { Console.WriteLine($"{o.data.info.content_size} {o.data.info.content_slug} {o.data.info.content_url}"); }, (string s) => { Console.WriteLine(s); });

            /** Тест загрузки контента **/
            SDK.ui.DownloadContent(1, @"C:\IBS\", (string o) => { Console.WriteLine(o); }, (string s) => { Console.WriteLine(s); });


            /** Тест  **/
            /** Тест  **/
            /** Тест  **/
            /** Тест  **/

            /** Тест  **/

            Console.Read();
        }
        

    }
}
