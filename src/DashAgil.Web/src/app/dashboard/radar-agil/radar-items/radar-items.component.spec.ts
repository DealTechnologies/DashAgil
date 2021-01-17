import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RadarItemsComponent } from './radar-items.component';

describe('RadarItemsComponent', () => {
  let component: RadarItemsComponent;
  let fixture: ComponentFixture<RadarItemsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RadarItemsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RadarItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
