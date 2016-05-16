﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BasteleiApp.Repositories {
	public class Repository<TEntity> : IRepository<TEntity> where TEntity : class {

		#region Fields

		protected readonly DbContext Context;

		#endregion //Fields

		#region Properties

		#endregion //Properties

		#region Constructors

		public Repository(DbContext context) {
			Context = context;
		}

		#endregion //Constructors

		#region Methods

		public void Add(TEntity entity) {
			throw new NotImplementedException();
		}

		public void AddRange(IEnumerable<TEntity> entities) {
			throw new NotImplementedException();
		}

		public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) {
			throw new NotImplementedException();
		}

		public TEntity Get(int id) {
			return Context.Set<TEntity>().Find(id);
		}

		public IEnumerable<TEntity> GetAll() {
			return Context.Set<TEntity>().ToList();
		}

		public void Remove(TEntity entity) {
			throw new NotImplementedException();
		}

		public void RemoveRange(IEnumerable<TEntity> entities) {
			throw new NotImplementedException();
		}

		#endregion //Methods
	}
}
