﻿using MiniBlog.Services;

namespace MiniBlog.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using MiniBlog.Model;
    using MiniBlog.Stores;

    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private IArticleService _articleService;
        public ArticleController(IArticleService articleService)
        {
            this._articleService = articleService;
        }

        [HttpGet]
        public List<Article> List()
        {
            return _articleService.List();
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            return new CreatedResult("/article", _articleService.Create(article));
        }

        [HttpGet("{id}")]
        public Article GetById(Guid id)
        {
            return _articleService.GetById(id);
        }
    }
}