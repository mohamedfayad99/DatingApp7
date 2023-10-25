import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  constructor(private http:HttpClient) { }
  registermode=false;
  users:any;
  ngOnInit(): void { 
    this.getusers();
   }
   getusers(){
    this.http.get('http://localhost:5058/api/users').subscribe({
      next: response => this.users=response ,
      error: error =>console.log(error),
      complete:() =>console.log('Reguest Has Completed')
    });
  }

  RegisterToggle(){
      this.registermode=true;
  }  

  CancelRegisterMode(event : boolean){
      this.registermode=event;
  }

}
