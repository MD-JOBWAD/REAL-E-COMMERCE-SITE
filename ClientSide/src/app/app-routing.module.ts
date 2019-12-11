import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GeneralUsersComponent } from './general_users/general-users.component';
import { ProductDetailsComponent } from './general_users/product-details/product-details.component';
import { GeneralUserIndexComponent } from './general_users/general-user-index.component';
import { CartDetailsComponent } from './store/cart/cart-details/cart-details.component';
import { SearchResultComponent } from './general_users/search-result/search-result.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { ChangePasswordComponent } from './user/change-password/change-password.component';


const routes: Routes = [
  {path: "", component: GeneralUserIndexComponent, children: [
    {path: "", component: GeneralUsersComponent},
    { path: "product/search/result", component: SearchResultComponent },
    { path: "product/:id", component: ProductDetailsComponent },
    { path: "product/cart/details", component: CartDetailsComponent },
  ]},
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'logIn', component: LoginComponent },
      { path: 'ChangePassword', component: ChangePasswordComponent }
    ]
  },
  {
    path: 'admin', 
    loadChildren: "./admin/admin.module#AdminModule"
  },
  {
    path: 'merchant', 
    loadChildren: "./merchant/merchant.module#MerchantModule"
  },
  { path: '**', redirectTo: '/user', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
