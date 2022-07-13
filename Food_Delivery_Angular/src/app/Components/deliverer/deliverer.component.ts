import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { RestaurantDTO } from 'src/app/Models/RestaurantDTO';
import { RestaurantService } from 'src/app/Services/restaurant.service';

@Component({
  selector: 'app-deliverer',
  templateUrl: './deliverer.component.html',
  styleUrls: ['./deliverer.component.css']
})
export class DelivererComponent implements OnInit {

  @Input() Id! : number;

  Restaurants! : Observable<RestaurantDTO[]>;
  constructor(private service:RestaurantService) { }

  ngOnInit(): void {
    this.Restaurants = this.service.getRestaurants();
    console.log(this.Restaurants)
  }

}
