import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiAdapterService {

  private BASE_URL = 'https://localhost:7020/api';

  constructor(private http: HttpClient) { }

  getAllMovies(): Observable<any> {
    return this.http.get(this.BASE_URL + '/movie');
  }
}
