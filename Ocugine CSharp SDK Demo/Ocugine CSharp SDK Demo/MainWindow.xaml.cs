using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ocugine_SDK;
using Ocugine_SDK.Models;

//===================================================
//  Ocugine SDK Demo
//  Sofware Development Kit demonstration for .Net
//  applications and games. You can use this SDK
//  for WinForms, WPF or Universal Windows Platform.
//
//  @name           Ocugine SDK Demo
//  @developer      CodeBits Interactive
//  @version        0.4.0a
//  @build          401
//  @url            https://ocugine.com/
//  @docs           https://docs.ocugine.com/
//  @license        MIT
//===================================================
//===================================================
//  Namespace Ocugine C# SDK Demo
//===================================================
namespace Ocugine_CSharp_SDK_Demo{
    //===================================================
    //  Main Window / SDK Demo
    //===================================================
    public partial class MainWindow : Window{
        // Public Params
        public Ocugine SDK;                     // Ocugine SDK

        //============================================================
        //  @class      MainWindow
        //  @method     MainWindow()
        //  @type       Constructor
        //  @usage      Window Constructor
        //  @args       none
        //  @return     none
        //============================================================
        public MainWindow(){
            InitializeComponent(); // Initialize WPF Components

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

            // Send Test Request

        }
    }
}
