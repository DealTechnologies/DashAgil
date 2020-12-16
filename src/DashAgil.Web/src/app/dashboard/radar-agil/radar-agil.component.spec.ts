import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RadarAgilComponent } from './radar-agil.component';

describe('RadarAgilComponent', () => {
  let component: RadarAgilComponent;
  let fixture: ComponentFixture<RadarAgilComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RadarAgilComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RadarAgilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
