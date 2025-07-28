﻿using System.Collections.Generic;
using LibrarySystem.Core.Models;

namespace LibrarySystem.Core.Interfaces
{
    public interface IReaderRepository
    {
        List<Reader> GetAll();
        Reader GetById(int id);
        void Add(Reader reader);
        void Update(Reader reader);
        void Delete(int id);
    }
}