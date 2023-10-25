import { Component ,OnInit} from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, of } from 'rxjs';
import { User } from 'Models/User';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model :any={};
  currentuser$: Observable<User |null>=of(null);
  constructor(public accountservice: AccountService) {}

  ngOnInit():void{
  }


  login(){
    this.accountservice.login(this.model).subscribe(
      {
        next:Response=>{
          console.log(Response);
        },
        error:error =>console.log(error)
        
      })
    }
    logout(){
      this.accountservice.logout();
    }
}
