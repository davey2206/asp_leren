﻿using System.Collections.Generic;
using System.Linq;
using TCG_CollectionGame.Data.Interfaces;
using TCG_CollectionGame.DataContext;
using TCG_CollectionGame.Entities.Models;

namespace TCG_CollectionGame.Data.Services
{
    public class DataSetService : IDataSetService
    {
        private readonly TCG_CollectionGameContext _context;

        public DataSetService(TCG_CollectionGameContext context)
        {
            _context = context;
        }

        public List<Pokeset> GetSets()
        {
            List<Pokeset> sets = _context.Pokeset.ToList();

            return sets;
        }

        public Pokeset GetSet(string code)
        {
            Pokeset set = _context.Pokeset.Where(p => p.SetCode == code).FirstOrDefault();

            return set;
        }
    }
}