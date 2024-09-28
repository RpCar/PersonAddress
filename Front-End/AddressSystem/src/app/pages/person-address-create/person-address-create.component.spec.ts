import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonAddressCreateComponent } from './person-address-create.component';

describe('PersonAddressCreateComponent', () => {
  let component: PersonAddressCreateComponent;
  let fixture: ComponentFixture<PersonAddressCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonAddressCreateComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PersonAddressCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
