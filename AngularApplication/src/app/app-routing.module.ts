import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ProductsComponent } from './products/products/products.component';
import { RegisterPartnerComponent } from './register/register-partner/register-partner.component';
import { LoginRedirectGuard } from './core/login-redirect.guard';

const routes: Routes = [
  { path: '', component: HomeComponent, canActivate: [ LoginRedirectGuard ] },
  { path: 'products', component: ProductsComponent },
  { path: 'register', component: RegisterPartnerComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
