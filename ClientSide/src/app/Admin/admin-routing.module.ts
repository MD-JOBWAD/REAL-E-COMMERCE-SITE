import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdmimDashboardComponent } from './dashboard/admim-dashboard.component';
import { ManagesComponent } from './manages/manages.component';
import { AdminComponent } from './admin.component';
import { ProductListComponent } from './manages/product/product-list.component';
import { ProductCreateComponent } from './manages/product/product-create.component';
import { OrdersComponent } from './orders/orders.component';
import { CategoryListComponent } from './manages/category/category-list.component';
import { CategoryCreateComponent } from './manages/category/category-create.component';
import {ColorListComponent} from './manages/color/color-list.component';
import { ColorCreateComponent } from './manages/color/color-create.component';
import { BrandCreateComponent } from './manages/brand/brand-create.component';
import { BrandListComponent } from './manages/brand/brand-list.component';


const routes: Routes = [
  { path: "", component:  AdminComponent, children:[
    { path: "", component: AdmimDashboardComponent },
    { path: "dashboard", component: AdmimDashboardComponent },
    { path: "manage", component: ManagesComponent },
    { path: "manage/product/list", component: ProductListComponent },
    { path: "manage/product/create", component: ProductCreateComponent },
    { path: "manage/product/edit/:id", component: ProductCreateComponent },
    { path: "manage/orders", component: OrdersComponent },
    { path: "manage/category/list", component: CategoryListComponent },
    { path: "manage/category/create", component: CategoryCreateComponent },
    { path: "manage/category/edit/:id", component: CategoryCreateComponent },
    { path: "manage/color/create", component: ColorCreateComponent },
    { path: "manage/color/list", component: ColorListComponent },
    { path: "manage/color/edit/:id", component: ColorCreateComponent },
    { path: "manage/brand/create", component: BrandCreateComponent },
    { path: "manage/brand/list", component: BrandListComponent },
    { path: "manage/brand/edit/:id", component: BrandCreateComponent }
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }