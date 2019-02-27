import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';

import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  baseUrl = 'http://localhost:5000/api/auth/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  constructor(private http: HttpClient) { }

  login(userDTO: any) {
    return this.http.post(this.baseUrl + 'login', userDTO)
      .pipe(
        map((response: any) => {
          const userResponse = response;
          if (userResponse) {
            localStorage.setItem('token', userResponse.token);
            this.decodedToken = this.jwtHelper.decodeToken(userResponse.token);
            console.log(this.decodedToken);
          }
        })
      );
  }

  register(userDTO: any) {
    return this.http.post(this.baseUrl + 'register', userDTO);
  }

  isLoggedIn() {
    const jwt = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(jwt);
  }

}
