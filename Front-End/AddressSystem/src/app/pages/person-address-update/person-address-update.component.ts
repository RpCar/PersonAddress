import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonAddressService } from 'src/app/services/person-address.service';
import { PersonAddress } from 'src/app/model/person-address.model';

@Component({
  selector: 'app-person-address-update',
  templateUrl: './person-address-update.component.html',
  styleUrls: ['./person-address-update.component.less']
})
export class PersonAddressUpdateComponent implements OnInit {
  personAddress: PersonAddress = new PersonAddress();

  constructor(
    private addressService: PersonAddressService,
    private route: ActivatedRoute,
    private router: Router
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.addressService.getAddress(id).subscribe({
        next: (response) => {
          this.personAddress = response;
        },
        error: () => {
          alert("Error loading information!");
        }
      }
      );
    }
  }

  updateAddress(personAddressForm: any): void {
    if (personAddressForm.invalid) {
      alert('Please fill in all required fields before submitting.');
      return;
    }
    if (this.personAddress.id) {
      this.addressService.updateAddress(this.personAddress.id, this.personAddress).subscribe({
        next: (response) => {
          alert("Successfully updated.");
          this.router.navigate(['/']);
        },
        error: (errorResponse) => {
          if(errorResponse.errors)this.handleValidationErrors(errorResponse.errors);
          if(errorResponse.Detailed)alert(errorResponse.Detailed);
        }
      });
    }
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