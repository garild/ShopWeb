using System.Collections.Generic;
using DataLayer.Entities.Context.Respository;
using System.Linq;
using System;
using Shop.Web.BLL.Service.Books.Interface;
using Shop.Web.BLL.Data.Enum;
using DataLayer;
using Shop.Web.BLL.Data.Models;
using System.Data.Entity.Core.Objects;
using System.Data.Entity;
using DataLayer.Shop.Web.BLL.Service.Books.Interface;

namespace Shop.Web.BLL.Service.Books.Implementation
{
    public class BooksService<T> where T:class,new() 
    {
        public readonly IBook repository;

        public BooksService(IBook _book)
        {
            repository = _book;
        }

    }

    public class BookContractor : IBookContractor
    {

        public List<Book> FindBooks(BookType bookType, string title, string publisher)
        {
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                var data = _ctx.Context.Books.Where(p=> p.BookType_Id== (int)bookType || p.Name.Contains(title) || p.Publisher == publisher).OrderBy(p=>p.DateRelease).ToList();
                return data;
            }
        }

        public List<Book> GetAllBooks()
        {
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                var data = _ctx.Context.Books.OrderBy(p=>p.DateRelease).ToList(); ;
                return data;
            }
        }
    }
    public class AllBooks : IBook, IBookType
    {
        private BookType type;
        public BookType bookType { get => type; set => type = value; }

        public AllBooks()
        {
            // DIP - SOLID
        }

        public List<Book> GetBooks()
        {
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                var data = _ctx.Context.Books.OrderBy(p => p.DateRelease).ToList();
                return data;
            }
        }

        public List<Book> FindBook(int search)
        {
            var searchBy = $"{search}";
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                var data = _ctx.Context.Books.Where(p => p.Name.Contains(searchBy) || p.Author.Contains(searchBy)).OrderBy(p=>p.DateRelease).ToList();
                return data;
            }
        }
    }

    public class AudioBooks : IBook, IBookType
    {
        private BookType type = BookType.AudioBooks;
        public BookType bookType { get => type; set => type = value; }

        public List<Book> FindBook(int search)
        {
            var searchBy = $"{search}";
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                var data = _ctx.Context.Books.Where(p => p.BookType_Id == (int)type && p.Name.Contains(searchBy) || p.Author.Contains(searchBy)).OrderBy(p => p.DateRelease).ToList();
                return data;
            }
        }

        public List<Book> GetBooks()
        {
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                var data = _ctx.Context.Books.Where(p => p.BookType_Id == (int)bookType).OrderBy(p => p.DateRelease).ToList();
                return data;
            }
        }
    }

    public class EBooks : IBook, IBookType
    {
        private BookType type = BookType.EBooks;
        public BookType bookType { get => type; set => type = value; }

        public List<Book> FindBook(int search)
        {
            var searchBy = $"{search}";
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                var data = _ctx.Context.Books.Where(p => p.BookType_Id == (int)type && p.Name.Contains(searchBy) || p.Author.Contains(searchBy)).OrderBy(p => p.DateRelease).ToList();
                return data;
            }
        }

        public List<Book> GetBooks()
        {
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                var data = _ctx.Context.Books.Where(p => p.BookType_Id == (int)bookType).OrderBy(p => p.DateRelease).ToList();
                return data;
            }
        }
    }
    // Nowości
    public class News : IBook
    {
        public List<Book> GetBooks()
        {
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                var data = _ctx.Context.Books.Where(p => p.DateRelease >= DateTime.Now && DbFunctions.DiffDays(DateTime.Now, p.DateRelease) <= 14).OrderBy(p => p.DateRelease).ToList();
                return data;
            }
        }
        public List<Book> FindBook(int search)
        {
            var searchBy = $"{search}";
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                var data = GetBooks().Where(p => p.Name.Contains(searchBy) || p.Author.Contains(searchBy)).OrderBy(p => p.DateRelease).ToList();
                return data;
            }
        }
    }

    //  Zapowiedzi
    public class Upcomming : IBook
    {
        public List<Book> GetBooks()
        {
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                var data = _ctx.Context.Books.Where(p => DbFunctions.DiffDays(DateTime.Now, p.DateRelease) > 14).OrderBy(p => p.DateRelease).ToList();
                return data;
            }
        }

        public List<Book> FindBook(int search)
        {
            var searchBy = $"{search}";
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                var data = GetBooks().Where(p => p.Name.Contains(searchBy) || p.Author.Contains(searchBy)).OrderBy(p => p.DateRelease).ToList();
                return data;
            }
        }
    }

    // Super Okazje
    public class SuperPromotions : IBook
    {
        public List<Book> FindBook(int search)
        {
            var searchBy = $"{search}";
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                var data = _ctx.Context.Books.Where(p => p.IsSuperPromtion == true && p.Name.Contains(searchBy) || p.Author.Contains(searchBy)).ToList();
                return data;
            }
        }

        public List<Book> GetBooks()
        {
            using (var _ctx = new ShopWebRepository<ShopWebEntities>())
            {
                var data = _ctx.Context.Books.Where(p => p.IsSuperPromtion == true).ToList();
                return data;
            }
        }
    }
}
