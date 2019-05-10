using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVC_application.Models
{
    public enum OrderTypesEnum
    {
        [Description("From low to high")]
        FromLowToHigh = 1,
        [Description("From high to low")]
        FromHighToLow = 2
    }
}