import { Component, Input } from '@angular/core';
import { ControlContainer, NgModelGroup } from '@angular/forms';
import { PersonAddress } from 'src/app/model/person-address.model';

@Component({
  selector: 'app-person-address-form',
  templateUrl: './person-address-form.component.html',
  styleUrls: ['./person-address-form.component.less'],
  viewProviders: [{ provide: ControlContainer, useExisting: NgModelGroup }] 
})
export class PersonAddressFormComponent {
  @Input() personAddress: PersonAddress = new PersonAddress();
  @Input() readOnly: boolean = false;
  @Input() submitted: boolean = false; 
}
