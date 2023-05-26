import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StarService {

  constructor(
    private httpClient: HttpClient
  ) { }

  getStars(): Observable<any[]> {
    return this.httpClient.get<any[]>(environment.baseApiUrl + 'star');
  }
  getStarsForMovie(movieId: number): Observable<any[]> {
    return this.httpClient.get<any[]>(environment.baseApiUrl + 'star/' + movieId);
  }
}
