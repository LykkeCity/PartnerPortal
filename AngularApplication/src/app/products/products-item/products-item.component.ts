import { Input } from '@angular/core';
import { Component } from '@angular/core';
import { Product } from '../models/product.model';

@Component({
  selector: 'lpp-products-item',
  templateUrl: './products-item.component.html',
  styleUrls: ['./products-item.component.scss']
})
export class ProductsItemComponent {

  @Input() product: Product;

  constructor() { }

}
