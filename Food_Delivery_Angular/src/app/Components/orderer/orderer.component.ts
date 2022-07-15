import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { AnyCatcher } from 'rxjs/internal/AnyCatcher';
import { DishDTO } from 'src/app/Models/DishDTO';
import { OrderDTO } from 'src/app/Models/OrderDTO';
import { OrderItemDTO } from 'src/app/Models/OrderItemDTO';
import { RestaurantDTO } from 'src/app/Models/RestaurantDTO';
import { OrderService } from 'src/app/Services/order.service';
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
  ordering : boolean = false;
  Cart : OrderItemDTO[] = []; 

  constructor(private service:RestaurantService, private orderService:OrderService) { }

  ngOnInit(): void {
    this.Restaurants = this.service.getRestaurants();
    
  }

  orderFrom(id:number): void {
   
   console.log(id);
   console.log(this.Dishes)
    
  
   this.Restaurants.subscribe(
    o =>{ 
      this.getRest(o,id);
    }
   );
   
   this.Dishes = [];
   
    //console.log(this.Dishes)
    
  }
 
  addToCart(id:number):void{
    this.Dishes.forEach( dish => {
      if(dish.id == id){
      console.log("hit");
        let OI = new OrderItemDTO(id,"");
       // console.log(OI);
        this.Cart.push(OI);
        //console.log(this.Cart);
      }
    })
  }



  Order():Observable<any> {
    console.log('2');
    let order = new OrderDTO("",this.Id, this.Cart,this.RestID,'Available');
   // console.log(order);
    let ret = this.orderService.addOrder(order);
    //console.log(ret);
    console.log(3);
    return  ret;

  }

  getRest(rest:RestaurantDTO[], id:number) : void {
   
    
   
      rest.forEach(element => {
        console.log(element.id,id)
        if(element.id == id){
          this.RestID = element.id;
          console.log('hit');
          this.Dishes = element.dishes;
          this.ordering = true;
          console.log(this.ordering);
          console.log(this.Dishes);
          
        }

        
      });

      console.log(this.Dishes);

   
  }
}
