using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Model.DBOperations;
using Microsoft.AspNetCore.Mvc;
using Ppr_Model.Entity;
using Ppr_Model.Common;
using AutoMapper;

namespace Ppr_Model.BookOperations.CreateBook
{
    public class CreateBook
    {
        public CreateBookModel Model { get; set; }
        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateBook(BookStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);

            if (book is not null)
                throw new InvalidOperationException("Mevcut");
            
            book = _mapper.Map<Book>(Model);
            /* book = new Book();
            book.Title = Model.Title;
            book.GenreId = Model.GenreId;
            book.PublishDate = Model.PublishDate;
            book.PageCount = Model.PageCount; */

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

    }
    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
    }
}