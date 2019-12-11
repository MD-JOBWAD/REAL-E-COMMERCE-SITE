import { Component, OnInit } from '@angular/core';
import { Cart } from '../store/cart/cart.model';
import { Product } from '../Models/product';

@Component({
  selector: 'app-general-user-index',
  templateUrl: './general-user-index.component.html',
  styleUrls: ['./general-user-index.component.css']
})
export class GeneralUserIndexComponent implements OnInit {

  constructor(private cart: Cart) { }

  ngOnInit() {
  }
}
