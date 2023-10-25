import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from 'Models/User';
import { BehaviorSubject, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
baseUsrl='http://localhost:5058/api/'
private currentusersource= new BehaviorSubject<User | null>(null);
currentuser$=this.currentusersource.asObservable();

  constructor(private http :HttpClient) {}

   login(model:any){
    return this.http.post<User>(this.baseUsrl+'account/login',model).pipe(
      map((response:User) =>
      {
        const user=response;
        if(user){
          localStorage.setItem('user',JSON.stringify(user))
          this.currentusersource.next(user);
        }
      })
    )
   }

   register(model:any){
    return this.http.post<User>(this.baseUsrl+'account/register',model).pipe(
      map(user=>{
        if(user){
          localStorage.setItem('user',JSON.stringify(user))
          this.currentusersource.next(user);            
        } 
        return user;
      })
    )
   }
   
   setcurrentuser(user:User){
    this.currentusersource.next(user);
   }
   
   logout(){
    localStorage.removeItem('user')
    this.currentusersource.next(null);
   }
}
