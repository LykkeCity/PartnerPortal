import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterPartnerComponent } from './register-partner/register-partner.component';
import { AuthGuard } from '../core/auth.guard';
import { RegisterGuard } from '../core/register.guard';
import { RegisterRootComponent } from './register-root/register-root.component';

const routes: Routes = [
  {
    path: 'register', component: RegisterRootComponent,
    children: [
      {
        path: '', component: RegisterPartnerComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RegisterRoutingModule {
}
