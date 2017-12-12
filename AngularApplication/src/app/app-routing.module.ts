import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductsComponent } from './products/products/products.component';
import { LoginRedirectGuard } from './core/login-redirect.guard';
import { AuthGuard } from './core/auth.guard';

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [ LoginRedirectGuard ] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
