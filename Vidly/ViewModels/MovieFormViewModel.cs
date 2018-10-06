using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;
using System.ComponentModel.DataAnnotations;

namespace Vidly.ViewModels
{
	public class MovieFormViewModel
	{
		public IEnumerable<Genre> Genres { get; set; }

		public int? Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Release Date")]
		public DateTime? ReleaseDate { get; set; }

		[Required]
		[Display(Name = "Number In Stock")]
		public int NumberInStock { get; set; }

		[Required]
		[Display(Name = "Genre Id")]
		public byte? GenreId { get; set; }


		public MovieFormViewModel()
		{
			Id = 0;
		}
		public MovieFormViewModel(Movie movie)
		{
			Id = movie.Id;
			Name = movie.Name;
			ReleaseDate = movie.ReleaseDate;
			NumberInStock = movie.NumberInStock;
			GenreId = movie.GenreId;
		}

	}
}
