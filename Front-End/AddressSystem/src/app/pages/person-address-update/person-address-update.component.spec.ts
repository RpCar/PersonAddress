import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonAddressUpdateComponent } from './person-address-update.component';

describe('PersonAddressUpdateComponent', () => {
  let component: PersonAddressUpdateComponent;
  let fixture: ComponentFixture<PersonAddressUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonAddressUpdateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PersonAddressUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
