import { Component, OnInit } from '@angular/core';
import { UserServiceService } from 'src/app/Services/user-service.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-identify',
  templateUrl: './identify.component.html',
  styleUrls: ['./identify.component.css']
})
export class IdentifyComponent implements OnInit {

  Id = 0;
  UserType$ = "NoUser";
  ModalText = "MODAL POWER";

   a = [1,2,3];
  constructor(private service:UserServiceService) { }

  ngOnInit(): void {
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
       this.UserType$ = ret[1];
       this.ModalText = this.Id + " " + this.UserType$;
       console.log(ret);
      })
      
  }


}
