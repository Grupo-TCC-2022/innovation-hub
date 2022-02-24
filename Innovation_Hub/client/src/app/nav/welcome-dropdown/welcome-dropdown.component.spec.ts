import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WelcomeDropdownComponent } from './welcome-dropdown.component';

describe('WelcomeDropdownComponent', () => {
  let component: WelcomeDropdownComponent;
  let fixture: ComponentFixture<WelcomeDropdownComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ WelcomeDropdownComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(WelcomeDropdownComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
