import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-locker',
  templateUrl: './locker.component.html',
  styleUrls: ['./locker.component.css']
})
export class LockerComponent implements OnInit {

  lockers: any;

  constructor(private http: HttpClient) { }

  ngOnInit() {
  }

  getLockers() {

    this.http.get('http://localhost:5000/api/lockers')
    .subscribe(response => {
        this.lockers = response;
        console.warn(this.lockers);
      }, error => {
        console.error(error);
      });

  }

  clearLockers() {
    this.lockers = [];
  }

}


