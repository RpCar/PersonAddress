import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'; 
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PersonAddressCreateComponent } from './pages/person-address-create/person-address-create.component';
import { PersonAddressDetailsComponent } from './pages/person-address-details/person-address-details.component';
import { PersonAddressListComponent } from './pages/person-address-list/person-address-list.component';
import { PersonAddressUpdateComponent } from './pages/person-address-update/person-address-update.component';
import { PersonAddressFormComponent } from './template/person-address-form/person-address-form.component';

@NgModule({
  declarations: [
    AppComponent,
    PersonAddressCreateComponent,
    PersonAddressDetailsComponent,
    PersonAddressListComponent,
    PersonAddressUpdateComponent,
    PersonAddressFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
