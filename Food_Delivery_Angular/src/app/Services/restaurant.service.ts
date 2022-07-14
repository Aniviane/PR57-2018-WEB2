import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RestUrl } from 'src/environments/environment';
import { DishDTO } from '../Models/DishDTO';
import { RestaurantDTO } from '../Models/RestaurantDTO';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  //readonly url = "https://localhost:7036/api/Restaurants"

  constructor(private http:HttpClient) { 

  }


  getRestaurants():Observable<RestaurantDTO[]> {
    return this.http.get<RestaurantDTO[]>(RestUrl);
  }

// getDishes():Observable<DishDTO[]> {
  
// }

}
