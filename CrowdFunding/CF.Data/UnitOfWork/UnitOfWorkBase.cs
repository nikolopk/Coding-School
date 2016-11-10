using System;
using CF.Data.Context;
using CF.Data.Repositories;
using CF.Data.Repositories.Models;
using System.Data.Entity;

namespace CF.Data.UnitOfWork
{
    public abstract class UnitOfWorkBase : Disposable, IUnitOfWork
    {
        private readonly ICrowdFundingDbContext _context;
        private IBackerProjectRepository _backerProjects;
        private ICategoryRepository _categories;
        private IProjectRepository _projects;
        private IProjectStatusRepository _projectStatuses;
        private IProjectUpdateRepository _projectUpdates;
        private IRewardRepository _rewards;
        private IUserProjectCommentRepository _userProjectComments;
        private IUserRepository _users;

        protected UnitOfWorkBase(ICrowdFundingDbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context is null.");
            }

            _context = context;
        }

        

        public IBackerProjectRepository BackerProjects
        {
            get { return InstantiateRepository(_backerProjects, typeof(BackerProjectRepository)) as IBackerProjectRepository; }
        }

        public ICategoryRepository Categories
        {
            get { return InstantiateRepository(_categories, typeof(CategoryRepository)) as ICategoryRepository; }
        }

        public IProjectRepository Projects
        {
            get { return InstantiateRepository(_projects, typeof(ProjectRepository)) as IProjectRepository; }
        }

        public IProjectStatusRepository ProjectStatuses
        {
            get { return InstantiateRepository(_projectStatuses, typeof(ProjectStatusRepository)) as IProjectStatusRepository; }
        }

        public IProjectUpdateRepository ProjectUpdates
        {
            get { return InstantiateRepository(_projectUpdates, typeof(ProjectUpdateRepository)) as IProjectUpdateRepository; }
        }

        public IRewardRepository Rewards
        {
            get { return InstantiateRepository(_rewards, typeof(RewardRepository)) as IRewardRepository; }
        }

        public IUserProjectCommentRepository UserProjectComments
        {
            get { return InstantiateRepository(_userProjectComments, typeof(UserProjectCommentRepository)) as IUserProjectCommentRepository; }
        }

        public IUserRepository Users
        {
            get { return InstantiateRepository(_users, typeof(UserRepository)) as IUserRepository; }
        }

        public void ExecuteSql(string sql, params object[] parameters)
        {
            if (_context != null)
            {
                _context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, sql, parameters);
            }
        }

        public void SaveChanges()
        {
            if (_context != null)
            {
                _context.SaveChanges();
            }
        }

        public abstract void Commit();

        public abstract void Rollback();

        protected abstract override void DisposeCore();

        /// <summary>
        /// Instantiates a repository.
        /// </summary>
        /// <typeparam name="T">Repository type</typeparam>
        /// <param name="repository">The repository interface</param>
        /// <param name="concreteType">Type of the concrete repository</param>
        /// <returns></returns>
        protected IRepository<T> InstantiateRepository<T>(IRepository<T> repository, Type concreteType) where T : class
        {
            return repository ?? Activator.CreateInstance(concreteType, new object[] { _context }) as IRepository<T>;
        }
    }
}