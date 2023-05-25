import { Component, OnInit, ViewChild } from '@angular/core';
import { NavComponent } from '../nav/nav.component';
import { MovieService } from '../services/movie.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {


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
}
