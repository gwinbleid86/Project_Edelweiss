using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Edelweiss.BLL.Enums
{
    public enum CommissionType
    {
        [Display(Name = "Фиксированная")]
        Fixed,
        [Display(Name = "Процентная")]
        Percentage
    }
}
