﻿using Magva.Infra.Crosscutting.DataTransferObject;
using System;
using System.Collections.Generic;

namespace Magva.Domain.Interfaces.Service
{
    public interface ITransactionService
    {

        TransactionDto Withdrawal(TransactionDto transactionDto);
        TransactionDto Deposit(TransactionDto transactionDto);
        void Remove(Guid id);
        TransactionDto GetById(Guid id);
        IEnumerable<TransactionDto> GetAll();
    }
}
