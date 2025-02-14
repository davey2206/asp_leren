﻿using System.Collections.Generic;
using TCG_CollectionGame.Entities.Models;

namespace TCG_CollectionGame.Data.Interfaces
{
    public interface IDataSetService
    {
        List<Pokeset> GetSets();
        Pokeset GetSet(string code);
    }
}