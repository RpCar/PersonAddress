import { Component, OnInit } from '@angular/core';
import { PersonAddressService } from 'src/app/services/person-address.service';
import { PersonAddress } from 'src/app/model/person-address.model';

@Component({
  selector: 'app-person-address-list',
  templateUrl: './person-address-list.component.html',
  styleUrls: ['./person-address-list.component.less']
})
export class PersonAddressListComponent implements OnInit {
  personAddresses: PersonAddress[] = [];

  constructor(private addressService: PersonAddressService) { }

  ngOnInit(): void {
    this.addressService.getAddresses().subscribe({
      next: (response) => {
        this.personAddresses = response;
      },
      error: () => {
        alert("Error loading information!");
      }
    });
  }

  confirmDelete(id: string | undefined): void {
    const confirmed = confirm("Are you sure you want to delete this address?");
    if (confirmed) {
      this.deleteAddress(id);
    }
  }

  deleteAddress(id: string | undefined): void {
    if (id) {
      this.addressService.deleteAddress(id).subscribe({
        next: (response) => {
          this.personAddresses = this.personAddresses.filter(a => a.id !== id);
          alert("Successfully deleted.");
        },
        error: (errorResponse) => {
          if(errorResponse.errors)this.handleValidationErrors(errorResponse.errors);
          if(errorResponse.Detailed)alert(errorResponse.Detailed);
        }
      });
    } else {
      console.error('ID is undefined');
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
