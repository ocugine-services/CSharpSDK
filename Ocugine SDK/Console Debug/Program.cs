using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
                language = "EN",
                modules = SDKModules.All
            });

            //Console.WriteLine(SDK.getAPIInfo( (StateModel d) => { Console.WriteLine(d); }, (string s) => { Console.WriteLine(s); }));
            SDK.ui.GetAuthForm ((OAuthTokenModel o) => { Console.WriteLine(o.data.access_token); }, (string s) => { Console.WriteLine(s); });
            
            Console.Read();
        }
    }
}
