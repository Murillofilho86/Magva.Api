﻿using System;
using System.Collections.Generic;
using Magva.Infra.Crosscutting.DataTransferObject;
using Magva.Domain.Interfaces.Repository;

namespace Magva.Infra.Data.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        public TransactionDto Add(TransactionDto obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TransactionDto> GetAll()
        {
            throw new NotImplementedException();
        }

        public TransactionDto GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public TransactionDto Update(TransactionDto obj)
        {
            throw new NotImplementedException();
        }
    }
}
