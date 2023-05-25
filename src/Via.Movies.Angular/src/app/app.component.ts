import { NgFor } from '@angular/common';
import { Component, ViewChild } from '@angular/core';
import { MovieService } from './services/movie.service';
import { NavComponent } from './nav/nav.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {


  searchText = '';
  loginModalVisible = false;
  movies: any[] = [];
  persons: any[] = [];
  directors: any[] = [];
  title = 'Via.Movies.Angular';
  @ViewChild('nav', {static: false}) nav: NavComponent | undefined;

  cachedList: any[] = [];

	constructor(private movieService: MovieService) { }

  ngOnInit(): void {
    this.movieService.getMovies().subscribe((data: any[]) => {
      this.movies = data;
      this.cachedList = this.movies;
    });
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

  loginStatusChanged() {
    this.loginModalVisible = false;
    if (this.nav)
    this.nav.loginStatusChanged();
  }
}
