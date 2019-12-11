import { Component, OnInit, Input } from '@angular/core';
import { ProductService } from '../services/product-service';
import { Product } from '../models/product';
import { ProductImagesService } from '../services/product-image-service';
import { ProductImage } from '../models/productImage';
import { DataService } from '../services/data-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-general-users',
  templateUrl: './general-users.component.html',
  styleUrls: ['./general-users.component.css']
})
export class GeneralUsersComponent implements OnInit {
  products: Product[];
  productImages: ProductImage[] = [];
  url: ProductImage;
  matBtnId: string;
  showProgressBar: boolean = true;
  test;
  favoriteBtnColor: string;
  constructor(private _productService: ProductService, private _productImagesService: ProductImagesService,
    private _dataService: DataService, private _route: Router) { }

  ngOnInit() {
    
      this._productService.getAllProduct().subscribe(data => {
        this.products = data;   
      });
      this._productImagesService.getAllImages().subscribe(data => {
        this.productImages = data;
        this.showProgressBar = false;   
      }); 
    this._dataService.searchBoxValueChange.subscribe(data => {
      this._route.navigate(["/product/search/result"]);
    });
  }
  ngAfterViewInit() {
    // this.url = this.productImages.filter( e => e.DisplayOrder === 1);
    // console.log(this.url)
  }
  getImageUrl(id) {
    let text = this.productImages.filter(e => { return e.productID == id });
    let s = text.filter(e => { return e.displayOrder == 1 });
    let g: string;
    let p = s.filter(e => { g = e.filePath });
    if (g != null) {
      //console.log(g);
      return g;
    }
    else {
      return "noimage.jpg";
    }
  }
  getProductName(productName: string) {
    if (productName.length > 10) {
      return productName.substring(0, 15) + "...";
    }
  }
  getDetails(description: string) {
    if (description.length > 50) {
      return description.substring(0, 50) + "...";
    }
  }

  result = false;
  onFavoriteBtnClick(id: number) {
    this.result = !this.result;
    if (this.result) {
      this.favoriteBtnColor = "accent";
      this.matBtnId = "btn_" + id;
    }
    else {
      this.favoriteBtnColor = "";
    }
    console.log(this.favoriteBtnColor);
  }
}
