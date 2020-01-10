using System;
using System.Collections.Generic;

namespace LZ.Model.Models
{
    public partial class Wage
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long? UserName { get; set; }
        public DateTime Month { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal? Total { get; set; }
        public decimal? Base { get; set; }
        public decimal? Achievements { get; set; }
        public decimal? AgeWage { get; set; }
        public decimal? Other { get; set; }
        public decimal? MaternityInsurancePrivate { get; set; }
        public decimal? EndowmentInsurancePrivate { get; set; }
        public decimal? MedicalInsurancePrivate { get; set; }
        public decimal? UnemploymentInsurancePrivate { get; set; }
        public decimal? EmploymentInjuryInsurancePrivate { get; set; }
        public decimal? AccumulationFundPrivate { get; set; }
        public decimal? AccumulationFundCompany { get; set; }
        public decimal? MaternityInsuranceCompany { get; set; }
        public decimal? EndowmentInsuranceCompany { get; set; }
        public decimal? MedicalInsuranceCompany { get; set; }
        public decimal? UnemploymentInsurance1 { get; set; }
        public decimal? EmploymentInjuryInsurance1 { get; set; }
        public decimal? TotalReduction { get; set; }
        public decimal? ToTalCompany { get; set; }
        public decimal? ActualPayment { get; set; }
        public DateTime UpdateTime { get; set; }
        public DateTime CreateTime { get; set; }
        public long CreateUserId { get; set; }
        public string CreateUserName { get; set; }
    }
}
