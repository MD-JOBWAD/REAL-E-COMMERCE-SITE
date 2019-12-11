import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminModule } from './admin/admin.module';
import { GeneralUsersComponent } from './general_users/general-users.component';
import { ModelModule } from './models/model-module';
import { HttpClientModule } from '@angular/common/http';
import { MerchantModule } from './merchant/merchant.module';
import { MaterialModule } from './material/material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';//4th steep
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ConfilmDeleteDialogServiece } from './services/confirm-dialog-serviece';
import { ConfirmDeleteComponent } from './admin/manages/category/confirm-delete.component';
import { StoreHomeComponent } from './store/store-home.component';
import { ProductDetailsComponent } from './general_users/product-details/product-details.component';
import { GeneralUserModule } from './general_users/general-user-module';
import { GeneralUserIndexComponent } from './general_users/general-user-index.component';
import { CartSummeryComponent } from './store/cart/cart-summery/cart-summery.component';
import { CartDetailsComponent } from './store/cart/cart-details/cart-details.component';
import { CartSuccessfullDialogComponent } from './store/cart/cart-successfull-dialog/cart-successfull-dialog.component';
import { MainNavComponent } from './main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { SearchResultComponent } from './general_users/search-result/search-result.component';
import { RepoStorage } from './services/loginService/repo-storage';
import { UserService } from './services/loginService/user.service';
import { LoginComponent } from './user/login/login.component';
import { ChangePasswordComponent } from './user/change-password/change-password.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { ToastrModule } from 'ngx-toastr';
import { UserComponent } from './user/user.component';

@NgModule({
  declarations: [
    AppComponent,
    GeneralUsersComponent,
    StoreHomeComponent,
    ProductDetailsComponent,
    GeneralUserIndexComponent,
    CartSummeryComponent,
    CartDetailsComponent,
    CartSuccessfullDialogComponent,
    MainNavComponent,
    SearchResultComponent,
    LoginComponent,
    ChangePasswordComponent,
    RegistrationComponent,
    UserComponent
  ],
  imports: [
    BrowserModule,
    MaterialModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AdminModule,
    ModelModule,
    HttpClientModule,
    MerchantModule,
    FormsModule,
    GeneralUserModule,
    LayoutModule,
    MatToolbarModule,
    MatButtonModule,
    MatSidenavModule,
    MatIconModule,
    MatListModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      progressBar: true
    })
  ],
  providers: [ConfilmDeleteDialogServiece, RepoStorage, UserService],
  bootstrap: [AppComponent],
  entryComponents:[
    ConfirmDeleteComponent,
    CartSuccessfullDialogComponent
  ]
})
export class AppModule { }
