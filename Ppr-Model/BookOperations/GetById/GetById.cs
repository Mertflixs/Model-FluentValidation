using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Model.DBOperations;
using Microsoft.AspNetCore.Mvc;
using Ppr_Model.Entity;
using Ppr_Model.Common;
using AutoMapper;

namespace Ppr_Model.BookOperations.GetById
{
    public class GetById
    {

        private readonly BookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public int bookId { get; set; }

        public GetById(BookStoreDbContext dbContext, int id, IMapper mapper)
        {
            bookId = id;
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public BookViewModel Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == bookId);
            if (book is null)
            {
                throw new InvalidOperationException("Kitap mevcut değil");
            }
            var vm = _mapper.Map<BookViewModel>(book);
            return vm;
        }
    }
    public class BookViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
    }
}