using System.ComponentModel.DataAnnotations;

namespace Edelweiss.BLL.Enums
{
    public enum TransactionStatus
    {
        [Display(Name = "Создан")]
        Created = 1,
        [Display(Name = "К оплате")]
        ToPay,
        [Display(Name = "Одобрен")]
        Approved,
        [Display(Name = "Подтвержден")]
        Confirmed,
        [Display(Name = "К выплате")]
        ToPayOff,
        [Display(Name = "Выдан")]
        Issued,
        [Display(Name = "Отменен")]
        Canceled
    }
}
