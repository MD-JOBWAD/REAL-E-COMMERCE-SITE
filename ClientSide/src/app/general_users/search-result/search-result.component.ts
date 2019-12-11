import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/Models/product';
import { DataService } from 'src/app/services/data-service';
import { ProductService } from 'src/app/services/product-service';
import { ProductImagesService } from 'src/app/services/product-image-service';
import { ProductImage } from 'src/app/models/productImage';

@Component({
  selector: 'app-search-result',
  templateUrl: './search-result.component.html',
  styleUrls: ['./search-result.component.css']
})
export class SearchResultComponent implements OnInit {
  allProduct: Product[] = [];
  products: Product[] = [];
  productImages: ProductImage[] = [];
  searchBoxValue: string;
  showProgressBar: boolean = true;
  favoriteBtnColor: string;
  matBtnId: string;
  constructor(private _productImagesService: ProductImagesService, private _productService: ProductService, private _dataService: DataService) { }

  ngOnInit() {
    this._productService.getAllProduct().subscribe(data => {
      this.products = data;
      if(this.searchBoxValue != undefined){
        this.allProduct = this.products;  
      }     
    });
    this._productImagesService.getAllImages().subscribe(data => {
      this.productImages = data;
      this.showProgressBar = false;   
    });
    this._dataService.searchBoxValueChange.subscribe(data => {      
      this.allProduct = this.products;  
      this.searchBoxValue = data;
      if (this.searchBoxValue == '') {
        this.allProduct = [];
      }
      else {
        this.allProduct = this.products;
        this.allProduct = this.products.filter(e => e.name.toLowerCase().includes(this.searchBoxValue.toLowerCase()));
      }
    });
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
