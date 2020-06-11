using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NativeApps2WindowsPlaneBackend_2.Models.Domain;

namespace NativeApps2WindowsPlaneBackend_2.Data.Repositories
{
    public class MessageRepositoryImpl : MessageRepository
    {

        private readonly AppDbContext _context;
        private readonly DbSet<Message> _messages;


        public MessageRepositoryImpl(AppDbContext dbContext)
        {
            _context = dbContext;
            _messages = dbContext.Messages;
        }

        public void Add(Message message)
        {
            _messages.Add(message);
        }

        public void Delete(Message message)
        {
            _messages.Remove(message);
        }

        public IEnumerable<Message> getAll()
        {
            return _messages.Include(m => m.Sender).ToList();
        }

        public IEnumerable<Message> getForGroup(TravelGroup tg)
        {
            return _messages.Where(m => tg.Passengers.Contains(m.Sender));
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        
    }
}
