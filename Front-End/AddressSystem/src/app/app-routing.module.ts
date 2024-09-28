import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonAddressCreateComponent } from './pages/person-address-create/person-address-create.component';
import { PersonAddressDetailsComponent } from './pages/person-address-details/person-address-details.component';
import { PersonAddressListComponent } from './pages/person-address-list/person-address-list.component';
import { PersonAddressUpdateComponent } from './pages/person-address-update/person-address-update.component';



const routes: Routes = [
  { path: '', redirectTo: '/addresses', pathMatch: 'full' },  // Redireciona a raiz para a lista de endereços
  { path: 'addresses', component: PersonAddressListComponent },      // Exibe a lista de endereços
  { path: 'create', component: PersonAddressCreateComponent },       // Exibe o formulário para criar um novo endereço
  { path: 'update/:id', component: PersonAddressUpdateComponent },   // Exibe o formulário para atualizar um endereço
  { path: 'details/:id', component: PersonAddressDetailsComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
