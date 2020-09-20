using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public enum UserEnum
    {
        [Description("Administrator")]
        Admin,
        [Description("Employee")]
        Employee,
        [Description("User")]
        User
    }
}
