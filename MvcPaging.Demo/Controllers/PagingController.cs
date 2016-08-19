﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcPaging.Demo.Models;
using Lexicon.DAL.Repositories;
using Lexicon.DAL.Entities;
using Lexicon.DAL.Interfaces;

namespace MvcPaging.Demo.Controllers
{
    public class PagingController : Controller
    {
        private const int DefaultPageSize = 10;
        private IList<Product> allProducts = new List<Product>();
        private readonly string[] allCategories = new string[3] { "Shoes", "Electronics", "Food" };
        IContentRepository cr;


        public PagingController(IContentRepository rep)
        {
            cr = rep;
            InitializeProducts();
        }

        private void InitializeProducts()
        {
            // Create a list of products. 50% of them are in the Shoes category, 25% in the Electronics 
            // category and 25% in the Food category.
            for (var i = 0; i < 527; i++)
            {
                var product = new Product();
                product.Name = "Product " + (i + 1);
                var categoryIndex = i % 4;
                if (categoryIndex > 2)
                {
                    categoryIndex = categoryIndex - 3;
                }
                product.Category = allCategories[categoryIndex];
                allProducts.Add(product);
            }
        }

        public ActionResult Index(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            // return View(this.allProducts.ToPagedList(currentPageIndex, DefaultPageSize));

           // IContentRepository rep = new ContentRepository(new Lexicon.DAL.LexiconDBContext());
            var txt = cr.GetFullContent(391).TextData; //this.LoadContentText()

            return View(txt.ToPagedString(currentPageIndex, 10000));
        }

        public ActionResult CustomPageRouteValueKey(SearchModel search)
        {
            int currentPageIndex = search.page.HasValue ? search.page.Value - 1 : 0;
            return View(this.allProducts.ToPagedList(currentPageIndex, DefaultPageSize));
        }

        public ActionResult ViewByCategory(string categoryName, int? page)
        {
            categoryName = categoryName ?? this.allCategories[0];
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;

            var productsByCategory = this.allProducts.Where(p => p.Category.Equals(categoryName)).ToPagedList(currentPageIndex,
                                                                                                              DefaultPageSize);
            ViewBag.CategoryName = new SelectList(this.allCategories, categoryName);
            ViewBag.CategoryDisplayName = categoryName;
            return View("ProductsByCategory", productsByCategory);
        }

        public ActionResult ViewByCategories(string[] categories, int? page)
        {
            var model = new ViewByCategoriesViewModel();
            model.Categories = categories ?? new string[0];
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;

            model.Products = this.allProducts.Where(p => model.Categories.Contains(p.Category)).ToPagedList(currentPageIndex, DefaultPageSize);
            model.AvailableCategories = this.allCategories;
            return View("ProductsByCategories", model);
        }

        public ActionResult IndexAjax()
        {
            int currentPageIndex = 0;
            var products = this.allProducts.ToPagedList(currentPageIndex, DefaultPageSize);
            return View(products);
        }

        public ActionResult AjaxPage(int? page)
        {
            ViewBag.Title = "Browse all products";
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            var products = this.allProducts.ToPagedList(currentPageIndex, DefaultPageSize);
            return PartialView("_ProductGrid", products);
        }

        public ActionResult Bootstrap(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(this.allProducts.ToPagedList(currentPageIndex, DefaultPageSize));
        }

        public ActionResult Bootstrap3(int? page)
        {
            int currentPageIndex = page.HasValue ? page.Value - 1 : 0;
            return View(this.allProducts.ToPagedList(currentPageIndex, DefaultPageSize));
        }
    }
}