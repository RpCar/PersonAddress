import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PersonAddressService } from 'src/app/services/person-address.service';
import { PersonAddress } from 'src/app/model/person-address.model';

@Component({
  selector: 'app-person-address-create',
  templateUrl: './person-address-create.component.html',
  styleUrls: ['./person-address-create.component.less']
})
export class PersonAddressCreateComponent {
  personAddress: PersonAddress = new PersonAddress();

  constructor(private addressService: PersonAddressService, private router: Router) { }

  createAddress(personAddressForm: any): void {
    if (personAddressForm.invalid) {
      alert('Please fill in all required fields before submitting.');
      return;
    }
    this.addressService.createAddress(this.personAddress).subscribe({
      next: (response) => {
        alert("Successfully created.");
        this.router.navigate(['/']);
      },
      error: (errorResponse) => {
        if(errorResponse.errors)this.handleValidationErrors(errorResponse.errors);
        if(errorResponse.Detailed)alert(errorResponse.Detailed);
      }
    }
    );
  }

  private handleValidationErrors(errors: any) {
    let errorMessage = 'Validation Errors:\n';

    for (const key in errors) {
      if (errors.hasOwnProperty(key)) {
        errors[key].forEach((message: string) => {
          errorMessage += `- ${message}\n`;
        });
      }
    }
    alert(errorMessage);
  }
}
