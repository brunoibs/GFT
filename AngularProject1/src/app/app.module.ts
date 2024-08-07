import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';  // Importar FormsModule
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { InvestmentComponent } from './investment/investment.component';

@NgModule({
  declarations: [
    AppComponent,
    InvestmentComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,  // Adicionar FormsModule ao array de imports
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
