﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
	
	public class MoviesController : Controller
	{
		private ApplicationDbContext _context;
		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}
		protected override void Dispose(bool disposing)
		{
			_context.Dispose();
		}

		public ViewResult Index()
		{
			//var movies = _context.Movies.Include(m => m.Genre).ToList();
			//return View(movies);

			if (User.IsInRole(RoleName.CanManageMovies))
				return View("list");
			return View("ReadOnlyList");
		}

		//public ActionResult Details(int id)
		//{
		//	var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
		//	if (movie == null)
		//		return HttpNotFound();
		//	return View(movie);

		//}
		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult MovieForm()
		{
			var genre = _context.Genres.ToList();
			var viewModel = new MovieFormViewModel()
			{
				Genres = genre
			};
			return View(viewModel);
		}

		[Authorize(Roles = RoleName.CanManageMovies)]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{
			if(!ModelState.IsValid)
			{
				var viewModel = new MovieFormViewModel(movie)
				{
					Genres = _context.Genres.ToList()
				};
				return View("MovieForm", viewModel);
			}
			if (movie.Id == 0)
			{
				_context.Movies.Add(movie);
				movie.DateAdded = DateTime.Now;
			}
			else
			{
				var moviesInDb = _context.Movies.Single(m => m.Id == movie.Id);
				moviesInDb.Name = movie.Name;
				moviesInDb.ReleaseDate = movie.ReleaseDate;
				moviesInDb.GenreId = movie.GenreId;
				moviesInDb.NumberInStock = movie.NumberInStock;
			}
			_context.SaveChanges();
			return RedirectToAction("Index", "Movies");
		}

		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult Edit(int id)
		{
			var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
			if (movie == null)
				return HttpNotFound();
			var viewModel = new MovieFormViewModel(movie)
			{
				
				Genres = _context.Genres.ToList()
			};
			return View("MovieForm", viewModel);
		}
	}
}