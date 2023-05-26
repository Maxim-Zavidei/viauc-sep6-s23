import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(
    private httpClient: HttpClient
  ) { }

  login(username: string, password: string) {
    return this.httpClient.post<any>(environment.baseApiUrl + 'account/login', { email:username, password })
  }

  register(email: string, password: string, confirmPassword: string)  {
    return this.httpClient.post<any>(environment.baseApiUrl + 'account/register', { email, password , confirmPassword})
  }
}
