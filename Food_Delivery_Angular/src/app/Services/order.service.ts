import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OrderUrl } from 'src/environments/environment';
import { OrderDTO } from '../Models/OrderDTO';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  

  constructor(private http:HttpClient) { 




  }


getOrders():Observable<any[]> {
  return this.http.get<any[]>(OrderUrl);
}
getMyOrders(id:number):Observable<OrderDTO[]> {
  return this.http.get<OrderDTO[]>(OrderUrl + '/${id}');
}

acceptOrder(id:number):void {
  let data = {
    id : id,
    mode : 1
  }
  this.http.put((OrderUrl),data)
}

FinishOrder(id:number):void {
  let data = {
    id : id,
    mode : 0
  }
  this.http.put((OrderUrl),data)
}

}
