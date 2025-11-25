using System;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    //Serviço financeiro para calcular juros sobre valores em atraso
    public class FinancialService
    {
        private const decimal DailyRate = 0.025m;

        public InterestRecord CalculateInterest(decimal value, DateTime dueDate)
        {
            if (DateTime.Today <= dueDate)
            {
                return new InterestRecord
                {
                    DaysOverdue = 0,
                    InterestAmount = 0,
                    TotalAmount = value
                };
            }

            int days = (DateTime.Today - dueDate).Days;
            decimal interest = value * DailyRate * days;

            return new InterestRecord
            {
                DaysOverdue = days,
                InterestAmount = interest,
                TotalAmount = value + interest
            };
        }
    }
}