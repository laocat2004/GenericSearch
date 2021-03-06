﻿using System.Collections.Generic;
using System.Web.Mvc;
using GenericSearch.Core;
using GenericSearch.Data;
using GenericSearch.Paging;
using GenericSearch.UI.Models;

namespace GenericSearch.UI.Controllers
{
    public class PagedSearchController : Controller
    {
        private readonly Repository repository;

        public PagedSearchController()
        {
            this.repository = new Repository();
        }

        public ActionResult Index(GenericSearch.Paging.Paging paging, ICollection<AbstractSearch> searchCriteria)
        {
            if (searchCriteria == null)
            {
                searchCriteria = typeof(GenericSearch.Data.SomeClass)
                    .GetDefaultSearchCriteria();
            }

            var data = this.repository
                .GetQuery()
                .ApplySearchCriteria(searchCriteria)
                .GetPagedResult(paging);

            var model = new PagedSearchViewModel()
            {
                Data = data,
                SearchCriteria = searchCriteria
            };

            return this.View(model);
        }
    }
}