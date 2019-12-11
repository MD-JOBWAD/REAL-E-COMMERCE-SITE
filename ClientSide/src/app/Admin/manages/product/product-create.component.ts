import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { Category } from 'src/app/models/category';
import { CategoryService } from 'src/app/services/category-service';
import { BrandService } from 'src/app/services/brand-service';
import { Brand } from 'src/app/models/brand';
import { Color } from 'src/app/models/color';
import { ColorService } from 'src/app/services/color-service';
import { ProductSizeService } from 'src/app/services/productSize-service';
import { ProductService } from 'src/app/services/product-service';
import { ProductSize } from 'src/app/models/productSize';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/product';
import { HttpClient } from '@angular/common/http';
import { ProductImagesService } from 'src/app/services/product-image-service';

@Component({
    selector: 'app-product-create',
    templateUrl: './product-create.component.html',
    styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {
    productForm: FormGroup;
    productDescriptionLength: number = 0;
    categoryName: Category[];
    brand: Brand[];
    color: Color[];
    val: number = 0;
    imageUrls = new Array<string>();
    imageName = new Array<string>();
    fileUploadMessage: boolean = true;
    isDisable: boolean = null;
    product: Product = new Product();
    productSize: ProductSize[];
    productColor: string[] = [
        "Green",
        "Black",
        "Red"
    ];
    Season: string[] = [
        "Summer",
        "Rainy-seasion",
        "Autumn",
        "Late-autumn",
        "Winter",
        "Spring"
    ]
    constructor(private _formBuilder: FormBuilder, private _categoryService: CategoryService,
        private _brandServiece: BrandService, private _colorService: ColorService, private _productSizeService: ProductSizeService,
        private _productService: ProductService, private _router: Router, private http: HttpClient,
        private _productImagesService: ProductImagesService) {
    }
    ngOnInit() {
        this._categoryService.getAllCategory().subscribe(data => this.categoryName = data);
        this._brandServiece.getAllBrand().subscribe(data => this.brand = data);
        this._colorService.getAllColor().subscribe(data => this.color = data);
        this._productSizeService.getAllProductSize().subscribe(data => this.productSize = data);
        this.productForm = this._formBuilder.group({
            id: [''],
            name: ['', [Validators.required]],
            categoryID: ['', [Validators.required]],
            brandID: ['', [Validators.required]],
            colors: this._formBuilder.array([
                this.addColorFormGroup()
            ]),
            description: ['', [Validators.required, Validators.minLength(50), Validators.maxLength(400)]],
            SKU: [''],
            marketPrice: ['', [Validators.min(1), Validators.pattern(/^-?(0|[1-9]\d*)?$/)]],
            discountPrice: ['', [Validators.min(1), Validators.pattern(/^-?(0|[1-9]\d*)?$/)]],
            salesPrice: ['', [Validators.required, Validators.min(1), Validators.pattern(/^-?(0|[1-9]\d*)?$/)]],
            stockQuantity: ['', [Validators.required, Validators.min(10), Validators.pattern(/^-?(0|[1-9]\d*)?$/)]],
            isFavourite: [''],
            isActive: [''],
            clothSizes: this._formBuilder.array([
                this.addSizeFormGroup()
            ]),
            otherProductSize: this._formBuilder.array([
                this.addOtherSizeFormGroup()
            ]),
            weight: [''],
            isCloth: [''],
            season: [''],
        });
        this.productForm.get('description').valueChanges.subscribe(value => {
            this.productDescriptionLength = +value.length;
        });
    }

    onAddSizeButton() {
        (<FormArray>this.productForm.get('clothSizes')).push(this.addSizeFormGroup());
        //console.log(this.productForm.value);
    }
    onDescriptionValueChange() {
        this.val = this.productForm.get('description').value.length;
    }
    onRemoveSizeButtonClick(index: number) {
        (<FormArray>this.productForm.get("clothSizes")).removeAt(index);
    }
    addSizeFormGroup(): FormGroup {
        return this._formBuilder.group({
            chest: [''],
            shoulder: [''],
            sleeve: [''],
        });
    }
    addColorFormGroup(): FormGroup {
        return this._formBuilder.group({
            colorID: ['']
        })
    }
    onColorAddButtonClick() {
        (<FormArray>this.productForm.get('colors')).push(this.addColorFormGroup());
        //console.log(this.productForm.get('colors').value);
    }
    onRemoveColorButtonClick(index: number) {
        (<FormArray>this.productForm.get('colors')).removeAt(index);
    }
    onaddOtherSizeButtonClick() {
        (<FormArray>this.productForm.get('otherProductSize')).push(this.addOtherSizeFormGroup());
    }
    onRemoveOtherSizeButtonClick(index: number) {
        (<FormArray>this.productForm.get('otherProductSize')).removeAt(index);
    }
    addOtherSizeFormGroup(): FormGroup {
        return this._formBuilder.group({
            lenth: [''],
            height: [''],
            width: ['']
        })
    }
    onSubmit() {
        if (this.productForm.valid) {
            this.setDataToProduct();
            this._productService.SaveProduct(this.product).subscribe(() => {
                this._router.navigate(["/admin/manage/product/list"]);
            });
            console.log(this.product);
            console.log(this.imageName);
        }
    }
    setDataToProduct() {
        this.product.id = this.productForm.value.id;
        this.product.IsActive = this.productForm.value.isActive;
        this.product.IsCloth = this.productForm.value.isCloth;
        this.product.IsFavourite = this.productForm.value.isFavourite;
        this.product.MarketPrice = this.productForm.value.marketPrice;
        this.product.name = this.productForm.value.name;
        this.product.SKU = this.productForm.value.SKU;
        this.product.salesPrice = this.productForm.value.salesPrice;
        this.product.Season = this.productForm.value.season;
        this.product.StockQuantity = this.productForm.value.stockQuantity;
        this.product.BrandID = this.productForm.value.brandID;
        this.product.Description = this.productForm.value.description;
        this.product.DiscountPrice = this.productForm.value.discountPrice;
        this.product.salesPrice = this.productForm.value.salesPrice;
        this.product.Weight = this.productForm.value.weight;
        this.product.categoryID = this.productForm.value.categoryID;
        this.product.Colors = this.productForm.value.colors;
        this.product.OtherProductSize = this.productForm.value.otherProductSize;
        this.product.ClothSizes = this.productForm.value.clothSizes;
        this.product.ImageName = this.imageName;
    }
    onClear(){
        this.productForm.reset();
    }
    onCardClick() {
        document.getElementById("fileUploadInput").click();
        if(this.isDisable){
            alert("You already upload picture for this product. Please create this product first and edit later to change product picture")
        }
    }
    onInputFileChange(event) {
        if (event.target.files.length > 0) {
            for (let file of event.target.files) {
                let reader = new FileReader();
                reader.onload = (e: any) => {
                    this.imageUrls.push(e.target.result);
                }
                reader.readAsDataURL(file);
            }
            this.fileUploadMessage = false;
        }
        const formData: any = new FormData();
        const test = new Array();
        //tgus=uploadfiles: Array<File> = this.filesToUpload;
        for (let i = 0; i < event.target.files.length; i++) {            
            this.imageName.push(event.target.files[i].name)
            formData.append("files", event.target.files[i]);
            // test.push(event.target.files[i].name);
        }
        this.isDisable = true;
        this._productImagesService.saveImages(formData)
            .subscribe(files => {
            })
    }
    onRemoveImageButtonClick(name){
        console.log(name);
    }
}
