import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { ProductsComponent } from './products/products.component';
import { ProductsItemComponent } from './products-item/products-item.component';
import { ProductsRootComponent } from './products-root/products-root.component';
import { ProductsRoutingModule } from './products-routing.module';


@NgModule({
  declarations: [
    ProductsComponent,
    ProductsItemComponent,
    ProductsRootComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ProductsRoutingModule,
  ]
})
export class ProductsModule { }
