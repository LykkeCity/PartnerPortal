import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { ProductsRootComponent } from './products-root/products-root.component';
import { AuthGuard } from '../core/auth.guard';

const routes: Routes = [
  { path: 'products', component: ProductsRootComponent, canActivate: [ AuthGuard ],
    children: [
      {
        path: '', component: ProductsComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
