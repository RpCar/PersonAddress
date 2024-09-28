import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonAddressListComponent } from './person-address-list.component';

describe('PersonAddressListComponent', () => {
  let component: PersonAddressListComponent;
  let fixture: ComponentFixture<PersonAddressListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PersonAddressListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PersonAddressListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
