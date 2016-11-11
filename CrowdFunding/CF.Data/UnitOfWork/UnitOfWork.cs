using CF.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.Data.UnitOfWork
{
    public class UnitOfWork : UnitOfWorkBase
    {
        public UnitOfWork(ICrowdFundingDbContext context) : base(context)
        {
        }

        public override void Commit()
        {
            throw new NotSupportedException("This UnitOfWork object does not support transactions; consider using the UnitOfWorkTransactional instead!");
        }

        public override void Rollback()
        {
            throw new NotSupportedException("This UnitOfWork object does not support transactions; consider using the UnitOfWorkTransactional instead!");
        }

        protected override void DisposeCore()
        {
            // SafeDispose(_context);
        }
    }
}
