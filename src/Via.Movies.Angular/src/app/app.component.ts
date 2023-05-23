import { NgFor } from '@angular/common';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiAdapterService } from './services/api-adapter.service';

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

  // persons: any[] = [
  //   // create an array of persons with Id, Name, and Birth.
  //     { Id: 1, Name: 'John Doe', Birth: '01/01/1970' },
  //     { Id: 2, Name: 'Nicola Johnson', Birth: '05/04/1980' },
  //     { Id: 3, Name: 'Lesh Smith', Birth: '11/10/1967' }
  //     ];
    
  //     directors: any[] = [
  //   // create an array of directors with MovieId and PersonId.
  //      { MovieId: 1, PersonId: 1 },
  //       { MovieId: 2, PersonId: 2 },
  //       { MovieId: 3, PersonId: 3 }
  //     ];
    
  //     movies: any[] = [
  //   // create an array of movies with Id, Title and Year.
  //       { Id: 1, Title: 'The Shawshank Redemption', Year: 1994 },
  //       { Id: 2, Title: 'The Godfather', Year: 1972 },
  //       { Id: 3, Title: 'The Godfather: Part II', Year: 1974 }
  //     ];
  //       

  constructor(private apiAdapter: ApiAdapterService) {
    
  }
  title = 'Via.Movies.Angular';


  cachedList: any[] = [];

  ngOnInit(): void {
    this.apiAdapter.getAllMovies().subscribe((data: any[]) => {
      this.movies = data;
      this.cachedList = this.movies;
    });
    for (let director of this.directors) {
      this.movies.find(movie => movie.Id === director.MovieId).Director = this.persons.find(person => person.Id === director.PersonId).Name;
    }
  }

  findMovie(searchText: string) {
    this.searchText = searchText;
    if (searchText === '') {
      this.cachedList = this.movies;
    }
    else {
      this.cachedList = this.movies.filter(movie => movie.Title.toLowerCase().includes(searchText.toLowerCase()) || movie.Director.toLowerCase().includes(searchText.toLowerCase()));
    }
  }
}
