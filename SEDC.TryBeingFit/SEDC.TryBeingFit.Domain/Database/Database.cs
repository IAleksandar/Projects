using SEDC.TryBeingFit.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.TryBeingFit.Domain.Database
{
    public class Database<T> : IDatabase<T> where T : BaseEntity
    {
        private List<T> _table { get; set; }
        public int Id { get; set; }

        public Database()
        {
            _table = new List<T>();
            Id = 1;
        }
        public List<T> GetAll()
        {
            return _table;
        }

        public T GetbyId(int id)
        {
            T dbEntity = _table.FirstOrDefault(x => x.Id == id);
            if(dbEntity == null)
            {
                throw new Exception($"Entity with id {id} not found");
            }
            return dbEntity;
        }

        public int Insert(T entity)
        {
            entity.Id = Id++;
            _table.Add(entity);
            return entity.Id;
        }

        public void RemoveById(int id)
        {
            T dbEntity = _table.FirstOrDefault(x => x.Id == id);
            if (dbEntity == null)
            {
                throw new Exception($"Entity with id {id} not found");
            }
            _table.Remove(dbEntity);
        }

        public void Update(T entity)
        {
            T dbEntity = _table.FirstOrDefault(x => x.Id == entity.Id);
            if (dbEntity == null)
            {
                throw new Exception($"Entity with id {entity.Id} not found");
            }

            dbEntity = entity;
        }
    }
}
