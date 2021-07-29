import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VerBorrarTrabajadorComponent } from './ver-borrar-trabajador.component';

describe('VerBorrarTrabajadorComponent', () => {
  let component: VerBorrarTrabajadorComponent;
  let fixture: ComponentFixture<VerBorrarTrabajadorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ VerBorrarTrabajadorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(VerBorrarTrabajadorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
