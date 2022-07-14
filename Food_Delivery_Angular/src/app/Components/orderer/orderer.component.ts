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

  Restaurants! : Observable<RestaurantDTO[]>;
  Dishes! : DishDTO[];
  Restaurant! : RestaurantDTO;

  constructor(private service:RestaurantService) { }

  ngOnInit(): void {
    this.Restaurants = this.service.getRestaurants();
    
  }

  orderFrom(id:number): void {
   
   console.log(id);
   console.log(this.Dishes)
    
   let l!: RestaurantDTO[];
   this.Restaurants.subscribe(
    o =>{ 
      this.getRest(o,id);
    }
   );
   
   
    //console.log(this.Dishes)
    
  }
 
  getRest(rest:RestaurantDTO[], id:number) : void {
   
   
      rest.forEach(element => {
        console.log(element.id,id)
        if(element.id == id){
          console.log('hit');
          this.Dishes = element.dishes;
          console.log(this.Dishes);
          
        }

        
      });

      console.log(this.Dishes);

   
  }
}
