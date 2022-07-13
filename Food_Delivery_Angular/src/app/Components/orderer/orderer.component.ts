import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AnyCatcher } from 'rxjs/internal/AnyCatcher';
import { DishDTO } from 'src/app/Models/DishDTO';
import { RestaurantDTO } from 'src/app/Models/RestaurantDTO';
import { RestaurantService } from 'src/app/Services/restaurant.service';

@Component({
  selector: 'app-orderer',
  templateUrl: './orderer.component.html',
  styleUrls: ['./orderer.component.css']
})
export class OrdererComponent implements OnInit {
  @Input() Id! : number;
  RestID! : number;

  Restaurants! : Observable<any[]>;
  Dishes! : DishDTO[];
  Restaurant! : RestaurantDTO;

  constructor(private service:RestaurantService) { }

  ngOnInit(): void {
    this.Restaurants = this.service.getRestaurants();
    console.log(this.Restaurants)
  }

  orderFrom(id:number): void {
    this.RestID = id;
    let r;
    this.Restaurants.subscribe(Restaurant => Restaurant.forEach(this.getRest));
    console.log(this.Dishes)
  }
  getRest(rest:RestaurantDTO) : void {
    if(rest.Id == this.RestID){
      this.Restaurant = rest;
      this.Dishes = rest.Dishes;
    }
  }
}
