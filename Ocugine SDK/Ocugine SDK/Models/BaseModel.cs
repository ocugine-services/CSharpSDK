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
    //  Ocugine SDK Base Response Model
    //===================================================
    public class BaseModel{
        public bool complete;       // Operation Status
        public string message;      // Error Message (if complete=false)
    }
}
