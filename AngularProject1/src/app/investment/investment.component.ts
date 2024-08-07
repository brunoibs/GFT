
import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-investment',
  templateUrl: './investment.component.html',
  styleUrls: ['./investment.component.scss']
})
export class InvestmentComponent {
  valorInicial: number = 0;
  prazo: number = 0;
  resultado: any;

  constructor(private http: HttpClient) {}

  calcularInvestimento() {
    const dados = {
      valorInicial: this.valorInicial,
      prazo: this.prazo
    };

    this.http.post<any>('http://localhost:5062/api/Investimento', dados)
      .subscribe(res => {
        this.resultado = res;
      });
  }
}
