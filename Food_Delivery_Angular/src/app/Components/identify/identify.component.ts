import { Component, OnInit } from '@angular/core';
import { UserServiceService } from 'src/app/Services/user-service.service';
import { Observable, retry } from 'rxjs';
import { RegisterDTO } from 'src/app/Models/RegisterDTO';

@Component({
  selector: 'app-identify',
  templateUrl: './identify.component.html',
  styleUrls: ['./identify.component.css']
})
export class IdentifyComponent implements OnInit {

 
  ModalText = "MODAL POWER";


  
  constructor(private service:UserServiceService) { }

  ngOnInit(): void {
  }

 

  
}
