import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-regitser',
  templateUrl: './regitser.component.html',
  styleUrls: ['./regitser.component.css']
})
export class RegitserComponent implements OnInit{
  model:any={}
  @Output() CancelRegister=new EventEmitter();
  constructor(private accountservice : AccountService,private toaster:ToastrService) {
    
  }
  ngOnInit(): void {
    
  }
  Register(){
    this.accountservice.register(this.model).subscribe({
      next:()=> this.Cancel() ,
      error:error =>{
        this.toaster.error(error.error.title) 
        console.log(error)
      }  

})    
  }
 
  Cancel(){
    this.CancelRegister.emit(false);
  }
}
