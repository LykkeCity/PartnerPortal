import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { TabsModule } from 'ngx-bootstrap';
import { ProductsComponent } from './products/products.component';
import { ProductsItemComponent } from './products-item/products-item.component';
import { ProductsRootComponent } from './products-root/products-root.component';
import { ProductsRoutingModule } from './products-routing.module';
import { ProductsDetailsComponent } from './products-details/products-details.component';


@NgModule({
  declarations: [
    ProductsComponent,
    ProductsItemComponent,
    ProductsRootComponent,
    ProductsDetailsComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    ProductsRoutingModule,
    TabsModule.forRoot()
  ]
})
export class ProductsModule { }
