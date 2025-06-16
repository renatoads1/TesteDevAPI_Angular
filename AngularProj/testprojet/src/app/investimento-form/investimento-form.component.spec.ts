import { ComponentFixture, TestBed } from '@angular/core/testing';
import { InvestimentoFormComponent } from './investimento-form.component';
import {  ReactiveFormsModule } from '@angular/forms';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { By } from '@angular/platform-browser';

describe('InvestimentoFormComponent', () => {
  let component: InvestimentoFormComponent;
  let fixture: ComponentFixture<InvestimentoFormComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [InvestimentoFormComponent],
      imports: [ReactiveFormsModule,
         HttpClientTestingModule]
    }).compileComponents();

    fixture = TestBed.createComponent(InvestimentoFormComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
    fixture.detectChanges();
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('deve criar o componente', () => {
    expect(component).toBeTruthy();
  });

  it('deve inicializar o formulário com valores padrão', () => {
    expect(component.form.value).toEqual({ valorInicial: 0, prazoMeses: 0 });
  });

  it('deve enviar dados e receber resultado', () => {
    component.form.setValue({ valorInicial: 100, prazoMeses: 12 });
    component.enviar();

    const req = httpMock.expectOne('http://localhost:5216/api/Cdb/calcular');
    expect(req.request.method).toBe('POST');
    expect(req.request.body).toEqual({ valorInicial: 100, prazoMeses: 12 });

    req.flush({ valorBruto: 200, valorLiquido: 180 });
    expect(component.resultado).toEqual({ valorBruto: 200, valorLiquido: 180 });
  });

  it('deve exibir resultado no template', () => {
    component.resultado = { valorBruto: 150, valorLiquido: 140 };
    fixture.detectChanges();
    const valorBruto = fixture.debugElement.query(By.css('p')).nativeElement.textContent;
    expect(valorBruto).toContain('150');
  });

  it('deve tratar erro da requisição', () => {
    spyOn(console, 'error');
    component.form.setValue({ valorInicial: 100, prazoMeses: 12 });
    component.enviar();

    const req = httpMock.expectOne('http://localhost:5216/api/Cdb/calcular');
    req.error(new ErrorEvent('Erro'));

    expect(component.resultado).toBeNull();
  });
});