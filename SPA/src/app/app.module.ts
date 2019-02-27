import { ErrorInterceptorProvider } from './_services/error.interceptor';
import { AuthService } from './_services/auth.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';

import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { AlertifyService } from './_services/alertify.service';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LockerComponent } from './locker/locker.component';


@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      HomeComponent,
      RegisterComponent,
      LockerComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      FormsModule,
      HttpClientModule,
      BrowserAnimationsModule
   ],
   providers: [
      AuthService,
      ErrorInterceptorProvider,
      AlertifyService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
