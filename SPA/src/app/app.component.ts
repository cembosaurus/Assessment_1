import { AuthService } from './_services/auth.service';
import { Component, OnInit } from '@angular/core';

import { JwtHelperService } from '@auth0/angular-jwt';

import {BehaviorSubject, Observable, of as observableOf} from 'rxjs';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  jwtHelper = new JwtHelperService();
  lockers: any;
  loggedIn: any;

  constructor(private authService: AuthService) { }


  ngOnInit() {

    const token = localStorage.getItem('token');

    if (token) {
      this.authService.decodedToken = this.jwtHelper.decodeToken(token);
    }

  }

  isLoggedIn(logged: boolean) {
    this.loggedIn = logged;
  }

}
