﻿using Entity;

namespace TaxCalculation.Repository.Contract
{
    public interface ITaxCalculationRepository
    {
        Task<Tax> GetInterestRateFromApiAsync();
    }
}
