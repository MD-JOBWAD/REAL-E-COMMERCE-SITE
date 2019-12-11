import { Component, OnInit, ViewChild } from '@angular/core';
import { Product } from 'src/app/models/product';
import { ProductService } from 'src/app/services/product-service';
import { MatTableDataSource, MatPaginator } from '@angular/material';
import { Router } from '@angular/router';
import { BehaviorSubject } from 'rxjs';
import { ConfilmDeleteDialogServiece } from 'src/app/services/confirm-dialog-serviece';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {
  searchValue: string;
  showProgressBar: boolean = true;
  dataSource = new MatTableDataSource();
  products: Product[];
  data: Product = {
    id: null,
    BrandID: null,
    ClothSizes: null,
    Colors: null,
    Description: '',
    DiscountPrice: null,
    ImageName: null,
    IsActive: null,
    IsCloth: null,
    IsFavourite: null,
    MarketPrice: null,
    name: '',
    OtherProductSize: null, 
    SKU: '', 
    Season: null,
    StockQuantity: null,
    Weight: null, 
    categoryID: null,
    salesPrice: null
  };
  constructor(private _productService: ProductService, private _router: Router,
              private confilmDeleteDialogServiece: ConfilmDeleteDialogServiece) { }

  @ViewChild(MatPaginator, {static: true}) paginator: MatPaginator;
  ngAfterViewInit(){
    this.dataSource.paginator = this.paginator;
  }
  ngOnInit() {
    this._productService.getAllProduct().subscribe(data=> {
      this.dataSource.data = data;
      this.showProgressBar = false;
    });
  }
  filterData(){
    this.dataSource.filter = this.searchValue.trim().toLowerCase();
  }  
  onEdit(row){
    this._router.navigate(["/admin/manage/product/edit/"], row.id);
  }
  onDelete(id){
    this.confilmDeleteDialogServiece.confilmDeleteDialog()
    .afterClosed().subscribe(data => this.deleteCategory(data, id));
  }
  deleteCategory(data, id){
    // if(data){
    //   this._categoryService.deleteCategoryById(id).subscribe((data)=>{
    //     this._categoryService.getAllCategory().subscribe(data=> this.dataSource.data = data);
    //   });
    // }
  }
  getDescription(description: string){
    if(description.length > 50){
      return description.substring(0, 50) + "...";
    }
    else{
      return description
    }
  }
  getName(name: string){
    if(name.length > 10){
      return name.substring(0, 10) + "...";
    }
    else{
      return name
    }
  }
  editData = new BehaviorSubject(this.data);
  currentData = this.editData.asObservable();
  displayedColumns: string[] = ['Name', 'Description', 'SalesPrice', 'StockQty', 'Action'];
}
