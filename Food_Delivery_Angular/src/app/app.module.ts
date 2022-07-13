import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IdentifyComponent } from './Components/identify/identify.component';
import { UserServiceService } from './Services/user-service.service';
import { OrdererComponent } from './Components/orderer/orderer.component';
import { DelivererComponent } from './Components/deliverer/deliverer.component';
import { AdminComponent } from './Components/admin/admin.component';

@NgModule({
  declarations: [
    AppComponent,
    IdentifyComponent,
    OrdererComponent,
    DelivererComponent,
    AdminComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [UserServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
