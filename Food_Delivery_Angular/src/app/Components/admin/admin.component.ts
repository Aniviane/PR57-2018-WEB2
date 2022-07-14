import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderDTO } from 'src/app/Models/OrderDTO';
import { RegisterDTO } from 'src/app/Models/RegisterDTO';
import { RestaurantDTO } from 'src/app/Models/RestaurantDTO';
import { OrderService } from 'src/app/Services/order.service';
import { RestaurantService } from 'src/app/Services/restaurant.service';
import { UserServiceService } from 'src/app/Services/user-service.service';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit {

  @Input() Id! : number;

  Restaurants! : Observable<RestaurantDTO[]>;
  Users! : Observable<RegisterDTO[]>;
  Orders! : Observable<OrderDTO[]>;
  constructor(private service:RestaurantService, private userService:UserServiceService, private orderService:OrderService) { }

  ngOnInit(): void {
    this.Restaurants = this.service.getRestaurants();
    this.Users = this.userService.getUsers();
    this.Orders = this.orderService.getOrders();
  }

  Verify(id:number):void {
    if(localStorage.getItem('token') == "NoToken"){
      alert("TOKEN ERROR") 
    }else {
    this.userService.verifyUser(id);
    }
  }

  DeleteUser(id:number):void {
    if(localStorage.getItem('token') == "NoToken"){
      alert("TOKEN ERROR") 
    }else {
    this.userService.deleteUser(id);
    }
  }

}
