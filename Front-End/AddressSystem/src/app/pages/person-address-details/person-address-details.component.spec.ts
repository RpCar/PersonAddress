import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonAddressDetailsComponent } from './person-address-details.component';

describe('PersonAddressDetailsComponent', () => {
  let component: PersonAddressDetailsComponent;
  let fixture: ComponentFixture<PersonAddressDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonAddressDetailsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PersonAddressDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
