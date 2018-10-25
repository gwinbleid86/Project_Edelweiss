using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Text;
using Edelweiss.BLL.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Edelweiss.BLL.DTO
{
    public class TariffDTO
    {
        public int Id { get; set; }

        public int? AgentId { get; set; }

        [Required]
        public int CountryId { get; set; }

        [Required]
        public int CurrencyId { get; set; }

        [Required]
        public int? RangeId { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public int CommissionType { get; set; }

        [Required]
        public decimal Value { get; set; }

        public string AgentName { get; set; }
        public string CountryName { get; set; }
        public string CurrencyName { get; set; }
        public decimal RangeMinValue { get; set; }
        public decimal RangeMaxValue { get; set; }
        public CommissionType TypeOfCommission { get; set; }
        //[NotMapped] public CommissionType TypeOfCommission => (CommissionType) CommissionType;
    }
}
