import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { IdentifyComponent } from './Components/identify/identify.component';
import { RegisterDTO } from './Models/RegisterDTO';
import { UserServiceService } from './Services/user-service.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Food_Delivery_Angular';

  Service: UserServiceService;
  Id = 0;
  UserType = "NoUser";

  constructor(private service:UserServiceService) {
   this.Service = service;
  }

  Login(username:string, password:string):void {

    let call = {
      username: username,
      password: password
    }

    console.log(call);
    
     let ret = this.service.login(call);
      ret.subscribe( ret => {
       this.Id = ret[0];
       this.UserType = ret[1];
       
       console.log(ret);
      })
      


  }


  Register(username:string, password :string, conf:string, mail:string, fname : string, adress:string, day:number, month:number, year:number, utype:string):Observable<any> {
    let date = new Date(year,month,day);
    console.log(date);
    let data = new RegisterDTO(username,password,conf,mail,fname,adress,date,utype);
    console.log(data);
    let ret = this.service.register(data);
    ret.subscribe( ret => {
      this.Id = ret.Id;
      this.UserType = ret.UserType;
      
      console.log(ret);
     })
     return ret;
  }


}
