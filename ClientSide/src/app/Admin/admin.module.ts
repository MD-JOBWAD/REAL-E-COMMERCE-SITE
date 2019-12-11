import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdmimDashboardComponent } from './dashboard/admim-dashboard.component';
import { AdminRoutingModule } from './admin-routing.module';
import { ManagesComponent } from './manages/manages.component';
import { AdminComponent } from './admin.component';
import { ProductListComponent } from './manages/product/product-list.component';
import { ProductCreateComponent } from './manages/product/product-create.component';
import { FormBuilder, ReactiveFormsModule, FormsModule } from '@angular/forms';
import { OrdersComponent } from './orders/orders.component';
import { MatButtonModule } from '@angular/material/button';
import {MatTableModule} from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material';
import { CategoryListComponent } from './manages/category/category-list.component';
import { CategoryCreateComponent } from './manages/category/category-create.component';
import {MatInputModule} from '@angular/material/input';
import {MatCheckboxModule} from '@angular/material/checkbox';
import { MaterialModule } from '../material/material.module';
import { ConfirmDeleteComponent } from './manages/category/confirm-delete.component';
import { ColorCreateComponent } from './manages/color/color-create.component';
import { ColorListComponent } from './manages/color/color-list.component';
import { ColorDeleteComponent } from './manages/color/color-delete.component';
import { BrandListComponent } from './manages/brand/brand-list.component';
import { BrandCreateComponent } from './manages/brand/brand-create.component';
import { BrandDeleteComponent } from './manages/brand/brand-delete.component';


@NgModule({
  declarations: [AdmimDashboardComponent, ManagesComponent, 
    AdminComponent, ProductListComponent, ProductCreateComponent, 
    OrdersComponent, CategoryCreateComponent, CategoryListComponent, ConfirmDeleteComponent, ColorCreateComponent, ColorListComponent, ColorDeleteComponent, BrandListComponent, BrandCreateComponent, BrandDeleteComponent],
  imports: [
    CommonModule,
    AdminRoutingModule,
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatInputModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    MaterialModule,
    FormsModule
  ],
  providers: [
    FormBuilder,
    CategoryCreateComponent, ColorCreateComponent, BrandCreateComponent
  ],
  exports:[
  ]
})
export class AdminModule { }
