import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StoriesSquadComponent } from './stories-squad.component';

describe('StoriesSquadComponent', () => {
  let component: StoriesSquadComponent;
  let fixture: ComponentFixture<StoriesSquadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StoriesSquadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(StoriesSquadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
