import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InterestAreaDropdownComponent } from './interest-areas-dropdown.component';

describe('InterestAreaDropdownComponent', () => {
  let component: InterestAreaDropdownComponent;
  let fixture: ComponentFixture<InterestAreaDropdownComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InterestAreaDropdownComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InterestAreaDropdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
