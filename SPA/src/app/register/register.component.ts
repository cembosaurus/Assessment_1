import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  userDTO: any = {};
  @Output() canceFromRegister = new EventEmitter();

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.userDTO)
      .subscribe(() => {
        this.alertify.success('User ' + this.userDTO.Name + ' was registered successfuly !');
        this.userDTO = {};
      }, error => {
        this.alertify.error(error);
      });
  }

  cancel() {
    this.canceFromRegister.emit(false);
    this.alertify.warning('Cancelled.');
  }

}
