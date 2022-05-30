﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TCG_CollectionGame.Data.Interfaces;
using TCG_CollectionGame.DataContext;
using TCG_CollectionGame.Entities.Models;

namespace TCG_CollectionGame.Data.Services
{
    public class DataCardService : IDataCardService
    {
        private readonly TCG_CollectionGameContext _context;

        public DataCardService(TCG_CollectionGameContext context)
        {
            _context = context;
        }

        public void AddCard(Pokecard pokecard)
        {
            _context.Pokecard.Add(pokecard);
            _context.SaveChanges();
        }

        public List<Pokecard> GetAllCards(User user)
        {
            return _context.Pokecard.FromSqlRaw("SELECT * FROM Pokecard WHERE UserID = {0}", user.ID).ToList();
        }

        public List<string> GetCards(string code, User user)
        {
            List<string> cardIds = new List<string>();
            var cards = user.Cards.Where(e => e.Pokeset.SetCode == code);
            foreach (var card in cards)
            {
                cardIds.Add(card.CardImg);
            }
            return cardIds;
        }

        public Pokecard GetCards(int cardID)
        {
            return _context.Pokecard.FromSqlRaw("SELECT * FROM pokecard WHERE ID = {0}", cardID).First();
        }
    }
}