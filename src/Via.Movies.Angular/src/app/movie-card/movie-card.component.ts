import { Component, Input, OnInit } from '@angular/core';
import { Movie } from './movie';
import { MovieService } from '../services/movie.service';

@Component({
	selector: 'app-movie-card',
	templateUrl: './movie-card.component.html',
	styleUrls: ['./movie-card.component.css']
})

export class MovieCardComponent implements OnInit {

	@Input() movie?: Movie;

	userEmail: any = '';
	wasHeartClicked: boolean = false;

	constructor(private movieService: MovieService) { }

	ngOnInit(): void {
		localStorage.getItem('email') ? this.userEmail = localStorage.getItem('email') : this.userEmail = '';
	}

	addToTopList(movieId: number | undefined) {
		if (movieId) {
			this.movieService.addToTopList(this.userEmail, movieId).subscribe();
			this.wasHeartClicked = true;
		}
	}
}
