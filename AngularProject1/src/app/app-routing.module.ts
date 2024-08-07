import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvestmentComponent } from './investment/investment.component';

const routes: Routes = [
  { path: 'investment', component: InvestmentComponent },
  { path: '', redirectTo: '/investment', pathMatch: 'full' }  // Redireciona para /investment por padrão
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
