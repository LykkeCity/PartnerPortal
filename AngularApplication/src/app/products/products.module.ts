import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ProductsComponent } from './products/products.component';
import { ProductsItemComponent } from './products-item/products-item.component';


@NgModule({
  declarations: [
    ProductsComponent,
    ProductsItemComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ProductsModule { }
