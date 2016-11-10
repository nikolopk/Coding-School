using CF.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.Data.UnitOfWork
{
    public class UnitOfWorkManager : Disposable, IUnitOfWorkManager
    {
        private readonly ICrowdFundingDbContext _context;

        public UnitOfWorkManager()
        {
            _context = new CrowdFundingDbContext();
            ActiveTransaction = null;
        }

        public IUnitOfWork CreateNew()
        {
            return new UnitOfWork(_context);
        }

        public IUnitOfWork CreateNewTransactional()
        {
            return new UnitOfWorkTransactional(this, _context);
        }

        // The following property is used by the UnitOfWorkTransactional object to store the initial transaction object.
        // Subsequent calls to the CreateNewTransactional() method will use the same object for the transaction.
        // This allows yoy to use multiple UnitOfWorkTransactional objects that share the same transaction
        // even though you might write code like the following:
        //
        //      using(var uow1 = _uowManager.CreateNewTransactional())
        //      {
        //          << data changes on uow1 >>
        //
        //          using(var uow2 = _uowManager.CreateNewTransactional())
        //          {
        //              << data changes on uow2 >>
        //
        //              using(var uow3 = _uowManager.CreateNewTransactional())
        //              {
        //                  << data changes on uow3 >>
        //
        //                  uow3.Commit() <-- IGNORED!!!
        //              }
        //
        //              uow2.Commit() <-- IGNORED!!!
        //          }
        //
        //          uow1.Commit() <-- THE ACTUAL COMMIT!!!
        //      }
        //
        // The Rollback() method works in a similar manner!
        //
        internal DbContextTransaction ActiveTransaction { get; set; }

        protected override void DisposeCore()
        {

        }
    }
}
