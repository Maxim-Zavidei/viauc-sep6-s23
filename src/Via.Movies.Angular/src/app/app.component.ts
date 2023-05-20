import { NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { MovieService } from './services/movie.service';
import { Movie } from './movie-card/movie';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  searchText = '';

	movies: Movie[] = [];

  title = 'Via.Movies.Angular';


  cachedList: any[] = [];

	constructor(private movieService: MovieService) { }

  ngOnInit(): void {

		this.movieService.getMovies().subscribe(data => {
      this.movies = data;
    });

    // for (let director of this.directors) {
    //   this.movies.find(movie => movie.Id === director.MovieId).Director = this.persons.find(person => person.Id === director.PersonId).Name;
    // }
  }

  findMovie(searchText: string) {
    this.searchText = searchText;
    if (searchText === '') {
      this.cachedList = this.movies;
    }
    else {
      this.cachedList = this.movies.filter(movie => movie.title.toLowerCase().includes(searchText.toLowerCase()) || movie.directorName.toLowerCase().includes(searchText.toLowerCase()));
    }
  }
}
