import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from 'src/app/services/product-service';
import { ProductImagesService } from 'src/app/services/product-image-service';
import { Product } from 'src/app/Models/product';
import { ProductImage } from 'src/app/models/productImage';
import { Cart } from 'src/app/store/cart/cart.model';
import { CartSuccessfullDialogService } from 'src/app/services/cart-success-dialog-service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product: Product;
  singleProductImages: ProductImage[];
  productImages: ProductImage[];
  bigImageUrl: string;
  productQuantity: number = 1;
  categoryId: number;
  favoriteBtnColor: string;
  matBtnId: string;
  productsByCategory: Product[];
  constructor(private _activatedRoute: ActivatedRoute, private _productService: ProductService, 
              private _productImageService: ProductImagesService, private cart: Cart,
              private _carSuccessfullDialog: CartSuccessfullDialogService, private _router: Router) { }

  ngOnInit() {
    this.goTop();
    this._activatedRoute.paramMap.subscribe(param => {
      let productId = +param.get("id");
      this._productService.getProductById(productId).subscribe(
        data => {
          this.product = data;
          this.categoryId = data.categoryID;
          console.log(this.categoryId);
          this._productService.getProductByCategoryId(this.categoryId).subscribe(
            data=> {
              this.productsByCategory = data;
              console.log(this.productsByCategory);
            })
        }
      );
      this._productImageService.getAllImages().subscribe(data => this.productImages = data)
      this._productImageService.getProductImagesById(productId).subscribe(
        data => {this.singleProductImages = data; this.bigImageUrl = data[0].filePath}
      )
    })
  }
  ngAfterViewInit(){    
    
  }
  onSmallImageClick(filePath: string){
    this.bigImageUrl = filePath;
  }
  setImageUrl(){
    return this.bigImageUrl;
  }
  getQuantity(){
    let qty = [];
    for(let i =1; i < 21; i++){
      qty.push(i);
    }
    return qty;
  }  
  addProductToCart(product: Product){
    this.cart.addLine(product, <number>this.productQuantity);
    this._carSuccessfullDialog.cartSuccessfullDialog().afterClosed().subscribe(
      data=>{
        if(!data){
          this._router.navigate(["/product/cart/details"]);
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
  getDetails(description: string){
    if(description.length > 20){
      return description.substring(0, 20) + "...";
    }
  }
  getProductName(productName: string){
    if(productName.length > 10){
      return productName.substring(0, 10) + "...";
    }
  }
  result = false;
  onFavoriteBtnClick(id: number){
    this.result = !this.result;
    if(this.result){
      this.favoriteBtnColor = "accent";
      this.matBtnId = "btn_"+ id;
    }
    else{
      this.favoriteBtnColor = "";
    }
    console.log(this.favoriteBtnColor);
  }
  goTop(){
    window.scrollTo(0, 0);
  }
}
