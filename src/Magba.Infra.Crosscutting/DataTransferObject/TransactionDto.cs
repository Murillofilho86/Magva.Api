﻿using Magva.Infra.Crosscutting.DataTransferObject.Enum;
using System;

namespace Magva.Infra.Crosscutting.DataTransferObject
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public ETransactionTypeDto Type { get; set; }
        public int NumberInstallments { get; set; }
        public DateTime DateTransaction { get; set; }

        public Guid CardId { get; set; }
        public Guid CustomerId { get; set; }
    }
}
