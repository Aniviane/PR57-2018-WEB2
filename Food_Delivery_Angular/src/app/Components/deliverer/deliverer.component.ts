import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderDTO } from 'src/app/Models/OrderDTO';
import { RestaurantDTO } from 'src/app/Models/RestaurantDTO';
import { OrderService } from 'src/app/Services/order.service';
import { RestaurantService } from 'src/app/Services/restaurant.service';

@Component({
  selector: 'app-deliverer',
  templateUrl: './deliverer.component.html',
  styleUrls: ['./deliverer.component.css']
})
export class DelivererComponent implements OnInit {

  @Input() Id! : number;

  Restaurants! : Observable<RestaurantDTO[]>;
  AllOrders! : Observable<OrderDTO[]>;
  MyOrders! : Observable<OrderDTO[]>;
  activeOrder! : OrderDTO;
  active! : boolean;




  constructor(private service:RestaurantService, private orderService:OrderService) { 


  }

  checkOrder(order:OrderDTO) {
    if(order.status == "Accepted") {
      this.activeOrder = order;
      this.active = true;

    }
  }

 acceptOrder(id:number):void {
    this.orderService.acceptOrder(id);
 }


  ngOnInit(): void {
    console.log(this.Id, ' lol');
    this.Restaurants = this.service.getRestaurants();
    this.AllOrders = this.orderService.getOrders();
    this.AllOrders.subscribe(o => {
      console.log(o);
    });

    this.MyOrders = this.orderService.getMyOrders(this.Id);
    this.MyOrders.subscribe(item => item.forEach(this.checkOrder));
    
  }

}
