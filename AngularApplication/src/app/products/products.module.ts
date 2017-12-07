import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { PopoverModule } from 'ngx-bootstrap';
import { SharedModule } from '../shared/shared.module';
import { ProductsComponent } from './products/products.component';
import { ProductsItemComponent } from './products-item/products-item.component';


@NgModule({
  declarations: [
    ProductsComponent,
    ProductsItemComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    PopoverModule.forRoot()
  ]
})
export class ProductsModule { }
