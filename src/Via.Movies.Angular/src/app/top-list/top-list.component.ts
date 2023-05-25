import { Component, Inject, OnInit, PLATFORM_ID } from '@angular/core';
import { MovieService } from '../services/movie.service';
import { isPlatformBrowser } from '@angular/common';
import { Movie } from '../movie-card/movie';

@Component({
  selector: 'app-top-list',
  templateUrl: './top-list.component.html',
  styleUrls: ['./top-list.component.css']
})
export class TopListComponent implements OnInit {

	movies: any[] = [];
	userEmail: any = '';

  constructor(private movieService: MovieService, @Inject(PLATFORM_ID) private platformId: Object) { }

  ngOnInit(): void {
		localStorage.getItem('email') ? this.userEmail = localStorage.getItem('email') : this.userEmail = '';
		this.movieService.getTopListMovies(this.userEmail).subscribe((data: any[]) => {
      this.movies = data;
    });
  }

	unfavoriteMovie(movie: Movie) {
		console.log("removed");
		if (movie?.id) {
			this.movieService.addToTopList(this.userEmail, movie?.id).subscribe(data => {
				if (isPlatformBrowser(this.platformId)) {
					window.location.reload();
				}
			});
		}
	}

}
