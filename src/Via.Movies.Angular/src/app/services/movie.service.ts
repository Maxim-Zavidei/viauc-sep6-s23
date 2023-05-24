import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, forkJoin } from 'rxjs';
import { map, mergeMap } from 'rxjs/operators';
import { environment } from "src/environments/environment";
import { Movie } from '../movie-card/movie';

@Injectable({
  providedIn: 'root'
})
export class MovieService {

  constructor(
		private httpClient: HttpClient
	) { }

	getMovies(): Observable<Movie[]> {
    return this.httpClient.get<Movie[]>(environment.baseApiUrl + 'movie')
  }
}
