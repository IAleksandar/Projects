﻿using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.Lamazon.DataAccess.Repositories
{
    public class OrderRepository : BaseRepository, IRepository<Order>
    {
        public OrderRepository(LamazonDbContext context) : base(context) { }

        public int Delete(int id)
        {
            Order order = _db.Orders.SingleOrDefault(x => x.Id == id);

            if (order == null)
            {
                return -1;
            }
            _db.Orders.Remove(order);
            return _db.SaveChanges();
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Orders
                .Include(x => x.ProductOrders)
                .ThenInclude(x => x.Product)
                .Include(x => x.User);
        }

        public Order GetById(int id)
        {
            return _db.Orders
                 .Include(x => x.ProductOrders)
                 .ThenInclude(x => x.Product)
                 .Include(x => x.User)
                 .SingleOrDefault(x => x.Id == id);
        }

        public int Insert(Order entity)
        {
            _db.Orders.Add(entity);
            return _db.SaveChanges();
        }

        public int Update(Order entity)
        {
            _db.Orders.Update(entity);
            return _db.SaveChanges();
        }
    }
}
