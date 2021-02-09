import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import {IProject} from './models/project';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{

  title = 'Yuan (Yuna) Wang Personal Site';
  projects : IProject[];

  constructor(private http: HttpClient){}

  ngOnInit(): void {
    this.http.get('https://localhost:5001/api/projects').subscribe((response: any) => {
      this.projects = response;
  }, error => {
      console.log(error);
    })
  }


}
