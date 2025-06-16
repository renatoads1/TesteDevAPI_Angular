import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-investimento-form',
  templateUrl: './investimento-form.component.html',
  styleUrls: ['./investimento-form.component.css']
})

export class InvestimentoFormComponent {
  form: FormGroup;
  resultado: any = null; // Adicione esta linha

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.form = this.fb.group({
      valorInicial: [0],
      prazoMeses: [0]
    });
  }

  enviar() {
    this.http.post('http://localhost:5216/api/Cdb/calcular', this.form.value)
      .subscribe(res => {
        this.resultado = res; // Salva o resultado
      });
  }
}
