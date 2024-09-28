import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PersonAddressService } from 'src/app/services/person-address.service';
import { PersonAddress } from 'src/app/model/person-address.model';

@Component({
  selector: 'app-person-address-details',
  templateUrl: './person-address-details.component.html',
  styleUrls: ['./person-address-details.component.less']
})
export class PersonAddressDetailsComponent  implements OnInit {
  personAddress: PersonAddress | undefined;

  constructor(private addressService: PersonAddressService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.addressService.getAddress(id).subscribe({
        next: (response) => {
        this.personAddress = response;
      },
      error: (errorResponse) => {
        alert("Error loading information!");
      }
    });
    }
  }
}
