﻿using NativeApps2WindowsPlaneBackend_2.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NativeApps2WindowsPlaneBackend_2.Data.Repositories
{
    public interface MessageRepository
    {
        Message GetById(int id);
        IEnumerable<Message> getAll();
        void Add(Message message);
        void Delete(Message message);
        void Update(Message message);
        void SaveChanges();
    }
}
