﻿using SEDC.TryBeingFit.Domain.Database;
using SEDC.TryBeingFit.Domain.Models;
using SEDC.TryBeingFit.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace SEDC.TryBeingFit.Services.Implementations
{
    public class TrainingService<T> : ITrainingService<T> where T : Training
    {
        private IDatabase<T> _database;

        public TrainingService()
        {
            _database = new FileDatabase<T>();
        }
        public void AddTraining(T training)
        {
            if (string.IsNullOrEmpty(training.Title))
            {
                throw new Exception("Title must not be empty");
            }
            _database.Insert(training);
        }

        public List<T> GetAllTrainings()
        {
            return _database.GetAll();
        }

        public T GetTraining(int id)
        {
            return _database.GetbyId(id);
        }
    }
}
