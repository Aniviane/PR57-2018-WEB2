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
this.Restaurants = this.service.getRestaurants();
this.AllOrders = orderService.getOrders();
this.MyOrders = orderService.getMyOrders(this.Id);
    this.MyOrders.subscribe(item => item.forEach(this.checkOrder));

  }

  checkOrder(order:OrderDTO) {
    if(order.status == "Accepted") {
      this.activeOrder = order;
      this.active = true;

    }
  }
  ngOnInit(): void {
    this.Restaurants = this.service.getRestaurants();
    console.log(this.Restaurants)
  }

}
