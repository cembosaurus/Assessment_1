import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  @Output() isLoggedIn = new EventEmitter();

  userDTO: any = {};
  logged = false;

  constructor(public authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.userDTO)
      .subscribe(
        next => {
          this.alertify.success('Login was successful');
        },
        error => {
          this.alertify.error(error);
        }
      );
  }

  loggedIn() {
    this.logged = this.authService.isLoggedIn();
    this.isLoggedIn.emit(this.logged);
    console.warn(this.logged);
    return this.logged;
  }

  logOut() {
    localStorage.removeItem('token');
    this.userDTO = {};
    this.alertify.warning('Logged OUT !');
  }

}
