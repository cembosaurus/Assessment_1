import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  @Input() isLoggedIn_fromAPP: any;

  registerMode = false;

  constructor(private alertify: AlertifyService) { }

  ngOnInit() {
  }

  registerToggle() {
    this.registerMode = true;
  }

  cancelRegister(eventFromRegister: boolean) {
    this.registerMode = eventFromRegister;
  }

  learnMore() {
    this.alertify.message('Developed by Milos Bencek as the assessment for TZ_Limited.');
  }

}
