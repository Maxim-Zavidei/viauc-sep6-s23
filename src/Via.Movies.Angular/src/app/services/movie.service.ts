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

	private tmdbURL = 'https://api.themoviedb.org/3/search/movie';
  private tmdbAPIKey = 'df24f1c9d4e65e16a8faf697b781a6d3'; // replace with your TMDB API key

  constructor(
		private httpClient: HttpClient
	) { }

  getMoviePoster(title: string): Observable<any> {
    return this.httpClient.get<any>(`${this.tmdbURL}?api_key=${this.tmdbAPIKey}&query=${title}`);
  }

  getMovie(id: number): Observable<Movie> {
    return this.httpClient.get<Movie>(environment.baseApiUrl + 'movie/' + id) 
    };



	getMovies(): Observable<Movie[]> {
    return this.httpClient.get<Movie[]>(environment.baseApiUrl + 'movie?number=18').pipe(
      mergeMap(movies => {
        // For each movie, we create a request to TMDB API to fetch movie details
        const requests = movies.map(movie =>
          this.httpClient.get<any>(`${this.tmdbURL}?api_key=${this.tmdbAPIKey}&query=${movie.title}`).pipe(
            map(response => {
              // The 'poster_path' from TMDB response is combined with the base image URL to create the full image URL
              const posterPath = response.results[0]?.poster_path;
              const imageURL = posterPath ? `https://image.tmdb.org/t/p/w500${posterPath}` : null;
              // Return a new object that includes the original movie properties and the image URL
              return { ...movie, imageURL };
            })
          )
        );
        // Return a single observable that emits when all requests have completed
        return forkJoin(requests) as Observable<Movie[]>;
      })
    );
  }

	searchForMovies(query: string): Observable<Movie[]> {
    return this.httpClient.get<Movie[]>(environment.baseApiUrl + 'movie/search?query=' + query).pipe(
      mergeMap(movies => {
        // For each movie, we create a request to TMDB API to fetch movie details
        const requests = movies.map(movie =>
          this.httpClient.get<any>(`${this.tmdbURL}?api_key=${this.tmdbAPIKey}&query=${movie.title}`).pipe(
            map(response => {
              // The 'poster_path' from TMDB response is combined with the base image URL to create the full image URL
              const posterPath = response.results[0]?.poster_path;
              const imageURL = posterPath ? `https://image.tmdb.org/t/p/w500${posterPath}` : null;
              // Return a new object that includes the original movie properties and the image URL
              return { ...movie, imageURL };
            })
          )
        );
        // Return a single observable that emits when all requests have completed
        return forkJoin(requests) as Observable<Movie[]>;
      })
    );
  }

	getTopListMovies(email: string): Observable<Movie[]> {
    return this.httpClient.get<Movie[]>(environment.baseApiUrl + 'TopList?email=' + email).pipe(
      mergeMap(movies => {
        // For each movie, we create a request to TMDB API to fetch movie details
        const requests = movies.map(movie =>
          this.httpClient.get<any>(`${this.tmdbURL}?api_key=${this.tmdbAPIKey}&query=${movie.title}`).pipe(
            map(response => {
              // The 'poster_path' from TMDB response is combined with the base image URL to create the full image URL
              const posterPath = response.results[0]?.poster_path;
              const imageURL = posterPath ? `https://image.tmdb.org/t/p/w500${posterPath}` : null;
              // Return a new object that includes the original movie properties and the image URL
              return { ...movie, imageURL };
            })
          )
        );
        // Return a single observable that emits when all requests have completed
        return forkJoin(requests) as Observable<Movie[]>;
      })
    );
  }

	addToTopList(email: string, movieId: number) {
		return this.httpClient.post<any>(environment.baseApiUrl + 'TopList', { userEmail:email, movieId:movieId })
  }
}
