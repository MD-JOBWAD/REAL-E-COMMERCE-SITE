// import { Component, OnInit } from '@angular/core';
// import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
// import { Category } from 'src/app/models/category';
// import { CategoryService } from 'src/app/services/category-service';
// import { BrandService } from 'src/app/services/brand-service';
// import { Brand } from 'src/app/models/brand';
// import { Color } from 'src/app/models/color';
// import { ColorService } from 'src/app/services/color-service';
// import { ProductSizeService } from 'src/app/services/productSize-service';
// import { ProductService } from 'src/app/services/product-service';
// import { ProductSize } from 'src/app/models/productSize';
// import { Router } from '@angular/router';
// import { Product } from 'src/app/models/product';
// import { HttpClient } from '@angular/common/http';

// @Component({
//     selector: 'app-product-create',
//     templateUrl: './product-create.component.html',
//     styleUrls: ['./product-create.component.css']
// })
// export class ProductCreateComponent implements OnInit {
//     productForm: FormGroup;
//     productDescriptionLength: number = 0;
//     categoryName: Category[];
//     formData: any = new FormData();
//     brand: Brand[];
//     color: Color[];
//     val: number = 0;
//     imageUrls = new Array<string>();
//     fileUploadMessage: boolean = true;
//     product: Product = new Product();
//     productSize: ProductSize[];
//     productColor: string[] = [
//         "Green",
//         "Black",
//         "Red"
//     ];
//     Season: string[] = [
//         "Summer",
//         "Rainy-seasion",
//         "Autumn",
//         "Late-autumn",
//         "Winter",
//         "Spring"
//     ]
//     constructor(private _formBuilder: FormBuilder, private _categoryService: CategoryService,
//         private _brandServiece: BrandService, private _colorService: ColorService, private _productSizeService: ProductSizeService,
//         private _productService: ProductService, private _router: Router, private http: HttpClient) {
//     }
//     ngOnInit() {
//         this._categoryService.getAllCategory().subscribe(data => this.categoryName = data);
//         this._brandServiece.getAllBrand().subscribe(data => this.brand = data);
//         this._colorService.getAllColor().subscribe(data => this.color = data);
//         this._productSizeService.getAllProductSize().subscribe(data => this.productSize = data);
//         this.productForm = this._formBuilder.group({
//             id: [''],
//             name: ['', [Validators.required]],
//             categoryID: ['', [Validators.required]],
//             brandID: ['', [Validators.required]],
//             colors: this._formBuilder.array([
//                 this.addColorFormGroup()
//             ]),
//             description: ['', [Validators.required, Validators.minLength(50), Validators.maxLength(400)]],
//             SKU: [''],
//             marketPrice: ['', [Validators.min(1), Validators.pattern(/^-?(0|[1-9]\d*)?$/)]],
//             discountPrice: ['', [Validators.min(1), Validators.pattern(/^-?(0|[1-9]\d*)?$/)]],
//             salesPrice: ['', [Validators.required, Validators.min(1), Validators.pattern(/^-?(0|[1-9]\d*)?$/)]],
//             stockQuantity: ['', [Validators.required, Validators.min(10), Validators.pattern(/^-?(0|[1-9]\d*)?$/)]],
//             isFavourite: [''],
//             isActive: [''],
//             clothSizes: this._formBuilder.array([
//                 this.addSizeFormGroup()
//             ]),
//             otherProductSize: this._formBuilder.array([
//                 this.addOtherSizeFormGroup()
//             ]),
//             weight: [''],
//             isCloth: [''],
//             season: [''],
//         });
//         this.productForm.get('description').valueChanges.subscribe(value => {
//             this.productDescriptionLength = +value.length;
//         });
//     }

//     onAddSizeButton() {
//         (<FormArray>this.productForm.get('clothSizes')).push(this.addSizeFormGroup());
//         //console.log(this.productForm.value);
//     }
//     onDescriptionValueChange() {
//         this.val = this.productForm.get('description').value.length;
//     }
//     onRemoveSizeButtonClick(index: number) {
//         (<FormArray>this.productForm.get("clothSizes")).removeAt(index);
//     }
//     addSizeFormGroup(): FormGroup {
//         return this._formBuilder.group({
//             chest: [''],
//             shoulder: [''],
//             sleeve: [''],
//         });
//     }
//     addColorFormGroup(): FormGroup {
//         return this._formBuilder.group({
//             colorID: ['']
//         })
//     }
//     onColorAddButtonClick() {
//         (<FormArray>this.productForm.get('colors')).push(this.addColorFormGroup());
//         //console.log(this.productForm.get('colors').value);
//     }
//     onRemoveColorButtonClick(index: number) {
//         (<FormArray>this.productForm.get('colors')).removeAt(index);
//     }
//     onaddOtherSizeButtonClick() {
//         (<FormArray>this.productForm.get('otherProductSize')).push(this.addOtherSizeFormGroup());
//     }
//     onRemoveOtherSizeButtonClick(index: number) {
//         (<FormArray>this.productForm.get('otherProductSize')).removeAt(index);
//     }
//     addOtherSizeFormGroup(): FormGroup {
//         return this._formBuilder.group({
//             lenth: [''],
//             height: [''],
//             width: ['']
//         })
//     }
//     onSubmit() {
//         if (this.productForm.valid) {
//             this.setDataToProduct();
//             this._productService.SaveProduct(this.formData).subscribe(() => {
//                 this._router.navigate(["/admin/manage/product/list"]);
//             });
//             console.log(this.product);
//         }
//     }
//     setDataToProduct() {
//         this.formData.append("id", this.productForm.value.id);
//         this.formData.append("isActive", this.productForm.value.isActive);
//         this.formData.append("isCloth", this.productForm.value.isCloth);
//         this.formData.append("isFavourite", this.productForm.value.isFavourite);
//         this.formData.append("marketPrice", this.productForm.value.marketPrice);
//         this.formData.append("name", this.productForm.value.name);
//         this.formData.append("SKU", this.productForm.value.SKU);
//         this.formData.append("salesPrice", this.productForm.value.salesPrice);
//         this.formData.append("season", this.productForm.value.season);
//         this.formData.append("stockQuantity", this.productForm.value.stockQuantity);
//         this.formData.append("brandID", this.productForm.value.brandID);
//         this.formData.append("description", this.productForm.value.description);
//         this.formData.append("discountPrice", this.productForm.value.discountPrice);
//         this.formData.append("salesPrice", this.productForm.value.salesPrice);
//         this.formData.append("weight", this.productForm.value.weight);
//         this.formData.append("categoryID", this.productForm.value.categoryID);
//         this.product.Colors = this.productForm.value.colors;
//         this.product.OtherProductSize = this.productForm.value.otherProductSize;
//         this.product.ClothSizes = this.productForm.value.clothSizes;
//         for (let i = 0; i < this.product.Colors.length; i++) {
//             this.formData.append("color", this.product.Colors[i]);
//         }
//         if(this.product.OtherProductSize.length > 0){
//             for (let i = 0; i < this.product.OtherProductSize.length; i++) {
//                 for (let i = 0; i < this.productForm.value.otherProductSize.height.length; i++) {
//                     this.formData.append("height", this.productForm.value.otherProductSize.height[i]);
//                 }
//                 for (let i = 0; i < this.productForm.value.otherProductSize.weight.length; i++) {
//                     this.formData.append("weight", this.productForm.value.otherProductSize.weight[i]);
//                 }
//                 for (let i = 0; i < this.productForm.value.otherProductSize.width.length; i++) {
//                     this.formData.append("width", this.productForm.value.otherProductSize.width[i]);
//                 }
//             }
//         }
//         if(this.productForm.value.clothSizes.length > 0){
//             for (let i = 0; i < this.productForm.value.clothSizes.length; i++) {
//                 for (let i = 0; i < this.productForm.value.clothSizes.height.length; i++) {
//                     this.formData.append("shoulder", this.productForm.value.clothSizes.shoulder[i]);
//                 }
//                 for (let i = 0; i < this.productForm.value.clothSizes.weight.length; i++) {
//                     this.formData.append("sleeve", this.productForm.value.clothSizes.sleeve[i]);
//                 }
//                 for (let i = 0; i < this.productForm.value.clothSizes.width.length; i++) {
//                     this.formData.append("chest", this.productForm.value.clothSizes.chest[i]);
//                 }
//             } 
//         }
//     }
//     onCardClick() {
//         document.getElementById("fileUploadInput").click();
//     }
//    files: ProductImg = new ProductImg();
//     onInputFileChange(event) {
//         if (event.target.files.length > 0) {
//             for (let file of event.target.files) {
//                 let reader = new FileReader();
//                 reader.onload = (e: any) => {
//                     this.imageUrls.push(e.target.result);
//                 }
//                 reader.readAsDataURL(file);
//             }
//             this.fileUploadMessage = false;
//         }
        
//         //tgus=uploadfiles: Array<File> = this.filesToUpload;
//         for (let i = 0; i < event.target.files.length; i++) {
//             this.formData.append("files", event.target.files[i]);
//         }
//         // this.files.Id = 23;
//         // this.files.file = "Pias";
//         // console.log(this.files);
//         // const tes = formData;
//         // tes.append("id", 23);
//         // tes.append("name", "Pias");
//         // tes.append("file", event.target.files[0]);
//         // this.http.post<ProductImg>('http://localhost:57087/api/category', tes)
//         //     .subscribe(files => console.log('files', files))
//     }
// }
// // export class ProductImg{
// //     Id: number;
// //   file: string;
// // }
