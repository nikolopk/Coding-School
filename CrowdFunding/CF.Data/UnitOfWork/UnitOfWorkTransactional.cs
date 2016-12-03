using CF.Data.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CF.Data.UnitOfWork
{
    public class UnitOfWorkTransactional : UnitOfWorkBase
    {
        private readonly UnitOfWorkManager _manager;
        private bool _transactionOwner;

        public UnitOfWorkTransactional(UnitOfWorkManager manager, ICrowdFundingDbContext context) : base(context)
        {
            if (manager == null)
            {
                // throw new ArgumentNullException("manager");
                //throw new DataLayerException(HttpStatusCode.BadRequest, "Manager is null.");

                throw new Exception("Manager is null.");
            }

            _manager = manager;

            if (_manager.ActiveTransaction != null)
            {
                _transactionOwner = false;
            }
            else
            {
                _manager.ActiveTransaction = context.Database.BeginTransaction(IsolationLevel.ReadCommitted);
                _transactionOwner = true;
            }
        }

        public override void Commit()
        {
            SaveChanges();

            if (!_transactionOwner)
            {
                return;
            }

            if (_manager.ActiveTransaction == null)
            {
                throw new Exception("Current UnitOfWorkTransactional is owner of the transaction but the transaction object is null");
            }

            _manager.ActiveTransaction.Commit();
            _transactionOwner = false;
            _manager.ActiveTransaction.Dispose();
            _manager.ActiveTransaction = null;
        }

        public override void Rollback()
        {
            if (!_transactionOwner)
            {
                return;
            }

            if (_manager.ActiveTransaction == null)
            {
                throw new Exception("Current UnitOfWorkTransactional is owner of the transaction but the transaction object is null");
            }

            _manager.ActiveTransaction.Rollback();
            _transactionOwner = false;
            _manager.ActiveTransaction.Dispose();
            _manager.ActiveTransaction = null;
        }

        protected override void DisposeCore()
        {
            // Disposing of the UnitOfWorkTransactional object without prior explicitly commiting your work,
            // will always result in a rollback of all database changes since the last commit!

            if (_transactionOwner)
            {
                Rollback();
            }
        }
    }
}
