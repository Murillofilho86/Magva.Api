﻿using System;
using System.Collections.Generic;
using System.Transactions;
using Magva.Domain.Interfaces.Repository;

namespace Magva.Infra.Data.Repository
{
    public class TransactionRepository : ITransactionRespository
    {
        public Transaction Add(Transaction obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetAll()
        {
            throw new NotImplementedException();
        }

        public Transaction GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Transaction Update(Transaction obj)
        {
            throw new NotImplementedException();
        }
    }
}
