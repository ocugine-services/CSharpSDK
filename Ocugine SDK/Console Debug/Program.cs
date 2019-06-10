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
//
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Permissions;

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
                modules = new SDKModules[] { SDKModules.All },
                auth_timeout = 10
            });

            /** Тест вызова формы аутентификации **/
            //SDK.ui.GetAuthForm((OAuthTokenModel o) => { Console.WriteLine(SDK.auth.credentials.token); }, (string s) => { Console.WriteLine(s); }, "all");

            /** Тест получения ссылки на авторизацию **/
            //SDK.auth.GetLink((string o) => { Console.WriteLine(o); }, (string s) => { Console.WriteLine(s); }, "somebody,once,told,me");
            //SDK.auth.GetLink((string o) => { Console.WriteLine(o); }, (string s) => { Console.WriteLine(s); }, new string[] { "all", "you", "need" });

            /** Тест получения токена **/
            //SDK.auth.GetToken((OAuthTokenModel o) => { Console.WriteLine(SDK.auth.credentials.token); }, (string s) => { Console.WriteLine(s); });

            /** Тест логаута **/
            //SDK.auth.GetToken((OAuthTokenModel o) => { 
            //    Console.WriteLine(SDK.auth.credentials.token);
            //    SDK.auth.Logout((string ls) => { Console.WriteLine("Успешный логаут"); }, (string lf) => { Console.WriteLine(lf); });
            //}, (string s) => { Console.WriteLine(s); });           

            /** Тест получения информации о языке и о локали **/
            //SDK.locale.GetLang("ru", (LanguageInfo o) => { Console.WriteLine($"{o.data.name}"); Console.WriteLine($"{o.message}"); }, (string s) => { Console.WriteLine(s); });
            //SDK.locale.GetLocale("ru", "test-node", (LocaleInfo o) => { Console.WriteLine($"{o.data.value}"); }, (string s) => { Console.WriteLine(s); });

            /** Тест получения списка политик и инфо о политике **/
            //SDK.users.GetPolicyList((PolicyListInfo o) => { foreach(PolicyListInfo.SubModel.ListModel d in o.data.list) Console.WriteLine($"[{d.uid}] - {d.policy_name}"); }, (string s) => { Console.WriteLine(s); });
            //SDK.users.GetPolicyInfo(1, (PolicyInfo o) => { Console.WriteLine($"{o.data.info.policy_name} {o.data.info.policy_text}"); }, (string s) => { Console.WriteLine(s); });

            /** Тест получения настроек **/
            //SDK.utils.GetSettings((APISettingsInfo o) => { Console.WriteLine($"{o.data.configs.uid} {o.data.configs.limitation}"); }, (string s) => { Console.WriteLine(s); });

            /** Тест получения списка контента и инфо о контенте **/
            //SDK.backend.GetContentList((o) => { foreach(ContentListInfo.SubModel.ListModel d in o.data.list) Console.WriteLine($"{d.content_slug} {d.uid}"); }, (string s) => { Console.WriteLine(s); });
            //SDK.backend.GetContent(1, (ContentInfo o) => { Console.WriteLine($"{o.data.info.content_size} {o.data.info.content_slug} {o.data.info.content_url}"); }, (string s) => { Console.WriteLine(s); });

            /** Тест загрузки контента **/
            //SDK.ui.DownloadContent(1, @"C:\IBS\", (string o) => { Console.WriteLine(o); }, (string s) => { Console.WriteLine(s); });

            /** Тест получения списка пользователей, текущего пользователя, пользователя по ID, выборки  **/
            //SDK.users.GetUsersList(1, (UsersListInfo o) => { Console.WriteLine("[U] Get User List:"); foreach (UserInfo.SubModel.BaseData d in o.data.list) Console.WriteLine($"[U] [{d.uid}] - {d.first_name}"); }, (string s) => { Console.WriteLine(s); });
            //SDK.auth.GetToken((OAuthTokenModel o) =>
            //{
            //    SDK.users.GetUserData((UserInfo lo) => { Console.WriteLine($"Get Current Mail: {lo.data.base_data.email}"); }, (string ls) => { Console.WriteLine(ls); });
            //}, (string s) => { Console.WriteLine(s); });
            //SDK.users.GetUserByID(17, (UserInfo lo) => { Console.WriteLine($"Get by ID Mail: {lo.data.base_data.email}"); }, (string ls) => { Console.WriteLine(ls); });
            //SDK.users.FindUser("Ocugine", 1, (UsersListInfo o) => { Console.WriteLine("[S] Search user:"); foreach (UserInfo.SubModel.BaseData d in o.data.list) Console.WriteLine($"[S] [{d.uid}] - {d.first_name}"); }, (string s) => { Console.WriteLine(s); });

            /** Тест получения списка локалей и языков **/
            //SDK.locale.GetLocaleList((LocaleListInfo o) => {Console.WriteLine($"{o.data["testik"][0].value}");}, (string s) => { Console.WriteLine(s); });
            //SDK.locale.GetLangList((LanguageListInfo o) => { Console.WriteLine($"{o.data[0].name}"); }, (string s) => { Console.WriteLine(s); });

            /** Тест установки группы, получения списка групп и конкретной группы **/
            //SDK.users.SetGroup((string s) => Console.WriteLine(s), (string e) => Console.WriteLine(e));
            SDK.users.GetGroupList((GroupListInfo s) => { foreach (GroupInfo.SubModel M in s.data.list) Console.WriteLine($"[{M.uid}] {M.group_name}"); }, (string e) => Console.WriteLine(e));
            SDK.users.GetGroupData(1, (GroupInfo s) => { Console.WriteLine($"{s.data.group_desc}"); }, (string e) => Console.WriteLine(e));


            //DynamicCodeBuilder.Create();
            Console.Read();
        }


    }

 
    //public class DynamicCodeBuilder
    //{
    //    static List<string> AvailableTypes = new List<string> { "string", "int", "float", "double", "char" };

    //    private static Type GetElementType(string inputString)
    //    {
    //        return Type.GetType("system." + inputString, false, true);
    //    }

    //    static IDictionary<string, string> ParseStr(string inputString)
    //    {
    //        IDictionary<string, string> dynamicPair = new Dictionary<string, string>();

    //        foreach (string type in AvailableTypes)
    //        {
    //            if (inputString.Contains(type))
    //            {
    //                string tmpString = inputString.Substring(inputString.IndexOf(type, 0) + type.Length + 1);

    //                tmpString = tmpString.Substring(0, tmpString.Length - 1);
    //                dynamicPair.Add(type, tmpString);

    //                return dynamicPair;
    //            }
    //        }

    //        return dynamicPair;
    //    }

    //    private static Type CreateDynamicClassType(AppDomain currentDomain, string inputString)
    //    {
    //        IDictionary<string, string> parsedValueString = ParseStr(inputString);
    //        string typeName = "";
    //        string typeVariable = "";

    //        foreach (KeyValuePair<string, string> kvp in parsedValueString)
    //        {
    //            typeName = kvp.Key;
    //            typeVariable = kvp.Value;
    //        }

    //        Type type = GetElementType(typeName);

    //        // Create an assembly.
    //        AssemblyName DynamicAssemblyName = new AssemblyName();
    //        DynamicAssemblyName.Name = "DynamicVariablesAssembly";
    //        AssemblyBuilder DynamicAssembly =
    //                       currentDomain.DefineDynamicAssembly(DynamicAssemblyName, AssemblyBuilderAccess.Run);

    //        // Create a dynamic module in Dynamic Assembly.
    //        ModuleBuilder DynamicModuleBuilder = DynamicAssembly.DefineDynamicModule("DynamicVariablesModule");

    //        // Define a public class named "DynamicVariablesClass" in the assembly.
    //        TypeBuilder DynamicTypeBuilder = DynamicModuleBuilder.DefineType("DynamicVariablesClass", TypeAttributes.Public);

    //        // Define a public String field named with inputed parameter in the type and name.
    //        FieldBuilder DynamicFieldBuilder = DynamicTypeBuilder.DefineField(typeVariable, type, FieldAttributes.Public);

    //        return DynamicTypeBuilder.CreateType();
    //    }

    //    [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
    //    public static void Create()
    //    {
    //        try
    //        {
    //            Console.WriteLine("Input string (format: [type][random symbol][variable name][random separator]): ");
    //            string inputString = Console.ReadLine();

    //            Type dynamicVariablesType = CreateDynamicClassType(Thread.GetDomain(), inputString);

    //            Object dynamicVariablesObject = Activator.CreateInstance(dynamicVariablesType);
    //            FieldInfo[] fi = dynamicVariablesType.GetFields();

    //            Console.WriteLine("Fields without value:");
    //            for (int i = 0; i < fi.Length; i++)
    //            {
    //                Console.WriteLine("Name            : {0}", fi[i].Name);
    //                Console.WriteLine("Value           : {0}", fi[i].GetValue(dynamicVariablesObject));
    //                Console.WriteLine("Declaring Type  : {0}", fi[i].DeclaringType);
    //                Console.WriteLine("IsPublic        : {0}", fi[i].IsPublic);
    //                Console.WriteLine("MemberType      : {0}", fi[i].MemberType);
    //                Console.WriteLine("FieldType       : {0}", fi[i].FieldType);
    //                fi[i].SetValue(dynamicVariablesObject, "test");
    //            }

    //            Console.WriteLine("Fields with value:");
    //            for (int i = 0; i < fi.Length; i++)
    //            {
    //                Console.WriteLine("Name            : {0}", fi[i].Name);
    //                Console.WriteLine("Value           : {0}", fi[i].GetValue(dynamicVariablesObject));
    //                Console.WriteLine("Declaring Type  : {0}", fi[i].DeclaringType);
    //                Console.WriteLine("IsPublic        : {0}", fi[i].IsPublic);
    //                Console.WriteLine("MemberType      : {0}", fi[i].MemberType);
    //                Console.WriteLine("FieldType       : {0}", fi[i].FieldType);
    //            }
    //        }
    //        catch (Exception e)
    //        {
    //            Console.WriteLine("Exception Caught " + e.Message);
    //        }
    //    }
    //}

}
